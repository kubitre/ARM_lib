using ARM_Lib.converters;
using ARM_Lib.database;
using ARM_Lib.models_view;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ARM_Lib.vm
{
    class BooksViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<BookView> Books { get; set; }
        private BooksDao booksDao;
        private ReadersDao readersDao;
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
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public BooksViewModel()
        {
            this.booksDao = new BooksDao();
            this.readersDao = new ReadersDao();
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

        public void commitChangeData(int[] keys)
        {
            foreach(var key in keys)
            {
               // booksDao.UpdateData;
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
