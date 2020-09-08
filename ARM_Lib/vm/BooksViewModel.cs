using ARM_Lib.converters;
using ARM_Lib.database;
using ARM_Lib.dg_actions;
using ARM_Lib.models;
using ARM_Lib.models_view;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.UI.WebControls;

namespace ARM_Lib.vm
{
    class BooksViewModel : INotifyPropertyChanged, IViewModelARM<BookView>, IBookChanger
    {
        public ObservableCollection<BookView> Books { get; set; }
        private BooksDao booksDao;
        private ReadersDao readersDao;
        private BooksOutDao booksOutDao;
        public ObservableCollection<SimpleReaderView> SimpleReaders { get; set; }

        private BookView selectedBook;
        private SimpleReaderView selectedReader;

        public BookView SelectedBook
        {
            get
            {
                return selectedBook;
            }
            set
            {
                selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }

        public SimpleReaderView SelectedSimpleReader
        {
            get
            {
                return selectedReader;
            }
            set
            {
                selectedReader = value;
                OnPropertyChanged("SelectedSimpleReader");
                changeListBooksByReader(value); // в случае, когда у нас меняется читатьель, которому надо выдать книгу, то обновляем текущий вывод в datagrid относительно него
                cleaningBooksOutOfStocks(); 
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public BooksViewModel()
        {
            this.booksDao = new BooksDao();
            this.readersDao = new ReadersDao();
            this.booksOutDao = new BooksOutDao();
            var dataReadersFromBd = readersDao.Fetch(100, 0);
            var dataFromDb = booksDao.Fetch(100, 0);
            var converter = new BooksDBToBooksView();
            var converterReader = new ReadersDbToSimplereaders();
            this.SimpleReaders = new ObservableCollection<SimpleReaderView>(
                dataReadersFromBd.Select(it => converterReader.convert(it)));
            this.Books = new ObservableCollection<BookView>(
                dataFromDb.Select(it => converter.convert(it))
                );
        }

        private void changeListBooksByReader(SimpleReaderView readerView)
        {
            var allBooks = this.booksOutDao.Fetch(100, 0) as List<BookOut>;
            var converter = new BooksDBToBooksView();
            addedAllAvailableBooksFromDB();
            foreach (var correltedBook in allBooks)
            {
                if (correltedBook.reader.id.Equals(readerView.ID))
                {
                    if (correltedBook.dateIn == null)
                    {
                        try
                        {
                            Books.Remove(Books.Single(it => it.ID == converter.convert(correltedBook.book).ID));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: ", ex);
                        }
                        continue;
                    } 
                }
            }
        }

        private void addedAllAvailableBooksFromDB()
        {
            var allBooksDb = this.booksDao.Fetch(100, 0) as List<Book>;
            var converter = new BooksDBToBooksView();
            foreach (var book in allBooksDb)
            {
                var modelBookView = converter.convert(book);
                if (!Books.Any(it => it.ID == modelBookView.ID))
                {
                    Books.Add(modelBookView);
                }
            }
        }

        private void cleaningBooksOutOfStocks()
        {
            try
            {
                var tempBooker = Books.ToList();
                foreach (var book in tempBooker)
                {
                    if (book.AmountCopies <= 0)
                    {
                        try
                        {
                            Books.Remove(Books.Single(it => it.ID == book.ID));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: ", ex);
                        }
                    }
                }
            } catch (Exception exc)
            {
                Console.WriteLine("Error: ", exc);
            }
        }

        public void commitChangeData(Dictionary<int, ActionTypes> keys, List<BookView> deletedList)
        {
            var converter = new BookViewToDb();
            foreach (var key in keys)
            {
                switch (key.Value)
                {
                    case ActionTypes.Create:
                        booksDao.CreateData(converter.convert(Books[key.Key]));
                        break;
                    case ActionTypes.Remove:
                        booksDao.RemoveData(converter.convert(deletedList[key.Key]));
                        break;
                    case ActionTypes.Update:
                        booksDao.UpdateData(converter.convert(Books[key.Key]));
                        break;
                }
            }
        }

        public bool readerWasSelected ()
        {
            return this.selectedReader != null;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public bool LendingBook(IList booksSelected)
        {
            var converter = new BookViewToDb();
            if (selectedReader != null)
            {
                foreach(var element in booksSelected)
                {
                    this.booksOutDao.CreateData(new BookOut
                    {
                        book = converter.convert(element as BookView),
                        reader = readersDao.ConvertSimpleToFull(selectedReader),
                        dateOut = DateTime.Now.Ticks
                    });
                }
                changeListBooksByReader(selectedReader);
                cleaningBooksOutOfStocks();
                return true;
            }
            return false; 
        }

        public bool ReturnBook(IList booksSelected)
        {
            throw new NotImplementedException();
        }
    }
}
