using ARM_Lib.database;
using ARM_Lib.models_view;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ARM_Lib.vm
{
    class ReportPerBooksViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ReportPerBooks> Reports { get; set; }

        private ReportPerBooks selectedReport;
        private StatsDao statsDao;
        public event PropertyChangedEventHandler PropertyChanged;


        public ReportPerBooks SelectedReport
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

        public ReportPerBooksViewModel()
        {
            statsDao = new StatsDao();
            Reports = new ObservableCollection<ReportPerBooks>(statsDao.ReportPerBooks());
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
