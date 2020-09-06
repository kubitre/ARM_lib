using ARM_Lib.converters;
using ARM_Lib.database;
using ARM_Lib.models;
using ARM_Lib.models_view;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ARM_Lib.vm
{
    // Прослойка, через которую идёт двунаправленная обработка данных с View части, со стороны кода
    class NeedReturnBooksViewModel : INotifyPropertyChanged, IBookChanger
    {
        // Коллекция, содержащая книги, которые отображаются в списки. данную коллекцю во view части биндит Wpf двига (можно в кодгене увидеть)
        public ObservableCollection<BookOutView> Books { get; set; }
        // выбранная книга в dataGrid (инкапсулированная часть кст, ниже объявлены геттеры и сеттеры для этого закрытого поля
        private BookOutView selectedBookOut;

        // Dao слой, содержащий оснонвые интерфейсы по взаимодействию с базой для каждого конкретного типа
        private BooksOutDao booksOutDao;
        private ReadersDao readersDao;

        // выбранный в списке читатель
        private SimpleReaderView selectedSimpleReader;


        // Список читателей (упрощённый до имени и фамилии)
        public ObservableCollection<SimpleReaderView> Readers { get; set; }

        //
        public BookOutView SelectedBookOut
        {
            get
            {
                return selectedBookOut;
            }
            set
            {
                selectedBookOut = value;
                OnPropertyChanged("SelectedBookOut");
            }
        }


        public SimpleReaderView SelectedSimpleReader
        {
            get
            {
                return selectedSimpleReader;
            }
            set
            {
                selectedSimpleReader = value;
                OnPropertyChanged("SelectedSimpleReader");
                changeListBooksByReader(value);
            }
        }


        // инициализация ивента, который содержится в интерфейсе InotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public NeedReturnBooksViewModel()
        {
            var converter = new BookOutDbToView();
            var converterSimpleReader = new ReadersDbToSimplereaders();
            booksOutDao = new BooksOutDao();
            readersDao = new ReadersDao();
            var dataFromDb = booksOutDao.Fetch(100, 0).Where(it => it.dateIn == null).ToList();
            var readerfromDb = readersDao.Fetch(100, 0);
            readerfromDb.Insert(0, new Reader
            {
                id = -1,
                firstName = "ВСЕ",
            });
            this.Books = new ObservableCollection<BookOutView>(
                dataFromDb.ConvertAll(it => converter.convert(it)).ToList());
            this.Readers = new ObservableCollection<SimpleReaderView>(
                readerfromDb.ConvertAll(it => converterSimpleReader.convert(it)));
        }

        // Генерация события, для того, чтобы произошёл перерендер
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void changeListBooksByReader(SimpleReaderView readerView)
        {
            if (readerView.ID == -1)
            {
                updateCurrentlyListbooks();
                return;
            }
            var allBooks = this.booksOutDao.Fetch(100, 0);
            var correlatedBooks = allBooks.FindAll(it => !it.reader.id.Equals(readerView.ID));
            var converter = new BookOutDbToView();
            foreach (var correltedBook in correlatedBooks)
            {
                try
                {
                    allBooks.Remove(allBooks.Single(it => it.book.id == correltedBook.book.id));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: ", ex);
                }
            }
            var newResult = new List<BookOut>(allBooks);
            foreach (var element in allBooks)
            {
                if (element.dateIn != null)
                {
                    newResult.Remove(element);
                }
            }

            var newResultTemp = new List<BookOut>(newResult);

            var tempBookView = new ObservableCollection<BookOutView>(Books);

            foreach(var book in tempBookView) {
                var needRemoving = false;
                foreach(var booFromBd in newResult)
                {
                    if (booFromBd.id == book.ID)
                    {
                        needRemoving = true;
                        newResultTemp.Remove(booFromBd);
                    }
                }
                if (!needRemoving)
                {
                    Books.Remove(book);
                }
            }
            foreach(var newAdd in newResultTemp)
            {
                Books.Add(converter.convert(newAdd));
            }
        }

        private void removedAlreadyInBook()
        {
            var tempBooks = new ObservableCollection<BookOutView>(Books);
            foreach(var element in tempBooks)
            {
                if (element.DateIn != null)
                {
                    Books.Remove(element);
                }
            }
        }

        public bool LendingBook(IList booksSelected)
        {
            throw new NotImplementedException();
        }

        public bool ReturnBook(IList booksSelected)
        {
            var converter = new BookOutViewToDb();
            try
            {
                foreach (var element in booksSelected)
                {
                    var bookFromDb = converter.convert(element as BookOutView);
                    this.booksOutDao.UpdateData(new BookOut
                    {
                        book = bookFromDb.book,
                        reader = bookFromDb.reader,
                        dateIn = bookFromDb.dateIn,
                        dateOut = bookFromDb.dateOut,
                        id = bookFromDb.id
                    });


                }
                removedAlreadyInBook();
                return true;
            } catch (Exception exc)
            {
                return false;
            }
        }

        // обновление текущего списка выданных книг
        private void updateCurrentlyListbooks()
        {
            var converter = new BookOutDbToView();

            var allBooks = this.booksOutDao.Fetch(100, 0)
                .ConvertAll(it => converter.convert(it)); 
            foreach(var book in Books)
            {
                allBooks.Remove(allBooks.Find(it => it.ID == book.ID));
            }
            allBooks.Where(it => it.DateIn == null && it.DateIn != DateTime.FromBinary(0)).ToList().ForEach(
                it => Books.Add(it)); // костыль, лучше не придумал на скорую руку
        }
    }
}
