using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace KonovalovArtemUpISP41.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAdmin.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        public string path = null;
        public PageAdmin()
        {
            InitializeComponent();
            NameUser.Text = $"{App.UserContext.Surname} {App.UserContext.Name.Remove(1)}. {App.UserContext.MiddleName.Remove(1)}.";
            CbSex.ItemsSource = App.Context.PolLists.Select(p => p.NamePol).ToList();

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            int IdDoljnost = 0;
            if (TbF.Text.Length != 0 && TbI.Text.Length != 0 && TbO.Text.Length != 0 && TbD.Text.Length != 0)
            {
                if (App.Context.DoljnostLists.Where(p => p.NameDoljnost.ToLower() == TbD.Text.ToLower()).Count() == 1)
                {

                    switch (TbD.Text)
                    {
                        case "Администратор доступа":
                            IdDoljnost = 1;
                            break;
                        case "Специалист ИБ":
                            IdDoljnost = 2;
                            break;
                        case "Руководитель отдела":
                            IdDoljnost = 3;
                            break;
                        case "Контрелер ГОЗ":
                            IdDoljnost = 4;
                            break;
                        default:
                            break;
                    }
                    if (IdDoljnost != 0)
                    {
                        var NewUser = new DB.User
                        {
                            Surname = TbF.Text,
                            Name = TbI.Text,
                            MiddleName = TbO.Text,
                            Doljnost = IdDoljnost,
                            Pol = CbSex.SelectedIndex+1,
                            Foto = path
                        };
                        App.Context.Users.Add(NewUser);
                        App.Context.SaveChanges();
                        MessageBox.Show("Пользователь добавлен", "Ok", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else {
                        MessageBox.Show("Не верно указана должность", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                }
            }
            else
            { MessageBox.Show("Заполните поля", "Error", MessageBoxButton.OK, MessageBoxImage.Error); }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TbD.Text = "";
            TbF.Text = "";
            TbI.Text = "";
            TbO.Text = "";
        }

        private void BtnSelectFoto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog a = new OpenFileDialog();
                a.ShowDialog();
                a.Filter = "(*.png, *.jpeg,*.jpg)|*.png; *.jpeg;*.jpg";
                ImgAgent.Source = new BitmapImage(new Uri(a.FileName));
                path = a.FileName;
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error); }

        }
    }
}
