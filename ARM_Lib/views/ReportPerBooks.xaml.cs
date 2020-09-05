using ARM_Lib.vm;
using MahApps.Metro.Controls;

namespace ARM_Lib.views
{
    /// <summary>
    /// Логика взаимодействия для ReportPerBooks.xaml
    /// </summary>
    public partial class ReportPerBooks : MetroWindow
    {
        public ReportPerBooks()
        {
            InitializeComponent();

            this.DataContext = new ReportPerBooksViewModel();
        }
    }
}
