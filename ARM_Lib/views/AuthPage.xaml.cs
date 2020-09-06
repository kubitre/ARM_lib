
using ARM_Lib.auth;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace ARM_Lib.views
{
    /// <summary>
    /// Логика взаимодействия для Books.xaml
    /// </summary>
    public partial class AuthPage : MetroWindow
    {
        private AuthConsts authService;
        public AuthPage()
        {
            authService = new AuthConsts();
            InitializeComponent();
        }

        
        private async void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // после нажатия кнопки войти, чекаем валидность данных, и  либо пускаем, либо не впускаем с соответсвующей нотификацией
            if( this.authService.checkAuth(this.username_text.Text, this.password_text.Password))
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            } else
            {
                await this.ShowMessageAsync("Ошибка аутентификации", "проверьте правильность вводимых данных");
            }
        }

        private void exit_button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
