using ARM_Lib.Migrations;
using ARM_Lib.models_db;
using ARM_Lib.views;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading;
using System.Web;
using System.Windows;

namespace ARM_Lib
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var result = new _202009031701201_init_license().checkConcurency();

            repos(result);
        }

        private async void repos(Res res)
        {
            if (!res.open)
            {
                
                var threadCounter = new Thread(new ThreadStart(count));
                threadCounter.Start();
                this.Close();
            }
        }

        private void count()
        {
            for (var i = 0; i <= 100; i++)
            {
                System.Threading.Thread.Sleep(1000);
            }
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

        private void readers_open_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var readersWindow = new Readers();
            readersWindow.ShowDialog();
            this.IsEnabled = true;
        }

        private void books_open_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var booksWindow = new Books();
            booksWindow.ShowDialog();
            this.IsEnabled = true;
        }

        private void leading_books_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var lendingWindow = new LendingBooks();
            lendingWindow.ShowDialog();
            this.IsEnabled = true;
        }

        private void return_books_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var returnBooksWindow = new ReturnBook();
            returnBooksWindow.ShowDialog();
            this.IsEnabled = true;
        }

        private void Report_per_reader_button(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var reportsReaders = new ReportPerReader();
            reportsReaders.ShowDialog();
            this.IsEnabled = true;
        }

        private void Report_per_books_button(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var reportsBooks = new ReportPerBooks();
            reportsBooks.ShowDialog();
            this.IsEnabled = true;
        }

        private void report_history_button_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            var reportHistory = new ReportHistory();
            reportHistory.ShowDialog();
            this.IsEnabled = true;
        }
    }
}
