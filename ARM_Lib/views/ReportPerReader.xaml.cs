using ARM_Lib.vm;
using MahApps.Metro.Controls;

namespace ARM_Lib.views
{
    /// <summary>
    /// Логика взаимодействия для ReportPerReader.xaml
    /// </summary>
    public partial class ReportPerReader : MetroWindow
    {
        public ReportPerReader()
        {
            InitializeComponent();
            this.DataContext = new ReportPerReadersViewModel();
        }
    }
}
