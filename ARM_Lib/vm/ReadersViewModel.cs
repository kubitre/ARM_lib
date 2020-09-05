using ARM_Lib.converters;
using ARM_Lib.database;
using ARM_Lib.models;
using ARM_Lib.models_view;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ARM_Lib.vm
{
    class ReadersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ReaderView> Readers { get; set; }
        
        private ReaderView selectedReader;
        private ReadersDao readersDao;

        public ReaderView SelectedReader
        {
            get
            {
                return selectedReader;
            }
            set
            {
                selectedReader = value;
                OnPropertyChanged("SelectedReader");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public ReadersViewModel()
        {
            var converter = new ReaderDbToReaderView();
            readersDao = new ReadersDao();
            var dataFromDb = readersDao.Fetch(100, 0);
            this.Readers = new ObservableCollection<ReaderView> ( 
               dataFromDb.ConvertAll(it => converter.convert(it))
            );
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
