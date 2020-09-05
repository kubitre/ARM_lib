using ARM_Lib.vm;
using MahApps.Metro.Controls;
using System.Windows;

namespace ARM_Lib.views
{
    /// <summary>
    /// Логика взаимодействия для Readers.xaml
    /// </summary>
    public partial class Readers : MetroWindow
    {
        public Readers()
        {
            InitializeComponent();

            this.DataContext = new ReadersViewModel();
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
