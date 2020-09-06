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

        private void back_to_main_window_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void about_app_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AboutApp.IsOpen = !this.AboutApp.IsOpen;
        }
    }
}
