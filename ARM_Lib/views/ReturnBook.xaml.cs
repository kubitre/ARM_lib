using ARM_Lib.database;
using ARM_Lib.vm;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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

        private void DataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.return_button.IsEnabled = true;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(this.DataContext as NeedReturnBooksViewModel).ReturnBook(this.return_book_grid.SelectedItems))
            {
                await this.ShowMessageAsync("Error", "Невозможно вернуть книгу");
            }
        }

        private void back_to_main_window_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void report_per_books_button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var reportsBooks = new ReportPerBooks();
            reportsBooks.ShowDialog();
            this.IsEnabled = true;
        }

        private void report_per_reader_button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var reportsReaders = new ReportPerReader();
            reportsReaders.ShowDialog();
            this.IsEnabled = true;
        }
    }
}
