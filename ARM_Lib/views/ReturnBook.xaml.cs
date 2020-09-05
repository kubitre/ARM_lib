using ARM_Lib.database;
using ARM_Lib.vm;
using MahApps.Metro.Controls;
using System.Windows;

namespace ARM_Lib.views
{
    /// <summary>
    /// Логика взаимодействия для ReturnBook.xaml
    /// </summary>
    public partial class ReturnBook : MetroWindow
    {
        public ReturnBook()
        {
            InitializeComponent();

            this.DataContext = new NeedReturnBooksViewModel();
        }

        private void about_app_Click(object sender, RoutedEventArgs e)
        {
            this.AboutApp.IsOpen = !this.AboutApp.IsOpen;
        }

        private void reports_button_click(object sender, RoutedEventArgs e)
        {
            this.reports_pane.IsOpen = !this.reports_pane.IsOpen;
        }
        private void exit_app_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
