using ARM_Lib.converters;
using ARM_Lib.database;
using ARM_Lib.models_view;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ARM_Lib.vm
{
    // Прослойка, через которую идёт двунаправленная обработка данных с View части, со стороны кода
    class NeedReturnBooksViewModel : INotifyPropertyChanged
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
            var dataFromDb = booksOutDao.Fetch(100, 0);
            var readerfromDb = readersDao.Fetch(100, 0);
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

    }
}
