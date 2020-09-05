using ARM_Lib.vm;
using MahApps.Metro.Controls;
using System.Windows;

namespace ARM_Lib.views
{
    /// <summary>
    /// Логика взаимодействия для LendingBooks.xaml
    /// </summary>
    public partial class LendingBooks : MetroWindow
    {
        public LendingBooks()
        {
            InitializeComponent();

            this.DataContext = new BooksViewModel();
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

        private void search_input_open_click(object sender, RoutedEventArgs e)
        {
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.out_agreee.IsEnabled = true;
        }
    }
}
