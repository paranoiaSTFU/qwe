using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KonovalovArtemUpISP41.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAvtoriz.xaml
    /// </summary>
    public partial class PageAvtoriz : Page
    {
        public PageAvtoriz()
        {
            InitializeComponent();
            CBType.ItemsSource = App.Context.UserRoles.Select(p => p.NameRole).ToList();
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (TBLogin.Text.Length != 0 && TBPassword.Password.Length != 0 && TBCode.Text.Length != 0)
            {
                if (App.Context.Users.Where(p => p.Login == TBLogin.Text && p.Password == TBPassword.Password && p.SecretWord == TBCode.Text).Count() == 1)
                {
                    App.UserContext = App.Context.Users.FirstOrDefault(p => p.Login == TBLogin.Text && p.Password == TBPassword.Password && p.SecretWord == TBCode.Text);
                    switch (App.UserContext.Role)
                    {
                        case 1:
                            NavigationService.Navigate(new Pages.PageAdmin());
                            break;
                        case 2:
                            MessageBox.Show($"Вы зашли как {App.UserContext.DoljnostList.NameDoljnost}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 3:
                            MessageBox.Show($"Вы зашли как {App.UserContext.DoljnostList.NameDoljnost}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        case 4:
                            MessageBox.Show($"Вы зашли как {App.UserContext.DoljnostList.NameDoljnost}", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            { MessageBox.Show("Заполните поля", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }
    }
}
