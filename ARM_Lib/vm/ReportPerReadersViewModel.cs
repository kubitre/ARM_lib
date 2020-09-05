using ARM_Lib.database;
using ARM_Lib.models_view;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ARM_Lib.vm
{
    class ReportPerReadersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ReportPerReader> Reports { get; set; }

        private ReportPerReader selectedReport;
        private StatsDao statsDao;
        public event PropertyChangedEventHandler PropertyChanged;


        public ReportPerReader SelectedReport
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

        public ReportPerReadersViewModel()
        {
            statsDao = new StatsDao();
            Reports = new ObservableCollection<ReportPerReader>(statsDao.ReportPerReaders());
        }
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
