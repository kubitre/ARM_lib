using ARM_Lib.vm;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace ARM_Lib.views
{
    /// <summary>
    /// Логика взаимодействия для LendingBooks.xaml
    /// </summary>
    public partial class LendingBooks : MetroWindow
    {
        private bool selectedReader = false;
        private bool selectedBooks = false;
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
            selectedReader = true;
            this.out_agreee.IsEnabled = true && selectedBooks;
        }

        // метод, который обрабатыват клик на кнопку "выдать"
        private async void out_agreee_Click(object sender, RoutedEventArgs e)
        {
            if ((this.DataContext as BooksViewModel).readerWasSelected() &&
                this.datagrid.SelectedItems.Count > 0)
            {
                IList books = this.datagrid.SelectedItems;
                if (!(this.DataContext as BooksViewModel).LendingBook(books))
                {
                    await this.ShowMessageAsync("Error", "не удалось выдать книгу");
                }

            }
        }


        // отслеживаем начало выделения
        private void datagrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid)sender,
                                        e.OriginalSource as DependencyObject) as DataGridRow;
            selectedBooks = true;
            this.out_agreee.IsEnabled = true && selectedReader;
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
