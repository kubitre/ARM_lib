using ARM_Lib.converters;
using ARM_Lib.database;
using ARM_Lib.models_view;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ARM_Lib.vm
{
    class BooksOutViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<ReportOutView> Reports { get; set; }

        private ReportOutView selectedReport;
        private BooksOutDao booksOutDao;

        public ReportOutView SelectedReport
        {
            get
            {
                return selectedReport;
            }
            set
            {
                selectedReport = value;
                OnPropertyChanged("SelectedReport");
            }
        }

        public BooksOutViewModel()
        {
            this.booksOutDao = new BooksOutDao();
            var converter = new BookOutToViewReport();
            var allBookOuts = booksOutDao.Fetch(100, 0).Where(it => it.dateIn != null).ToList().ConvertAll(it => converter.convert(it));

            this.Reports = new ObservableCollection<ReportOutView>(allBookOuts);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
