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

namespace GolubewaWPF
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void btnAutorise_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                auth CurrentUser = BD.BaseModel.auth.FirstOrDefault(x => x.login == txtLogin.Text && x.password == txtPassword.Password);
                if (CurrentUser != null)
                {//сюда напишем алгоритм перехода на страницу в зависимости от роли
                    switch (CurrentUser.role)
                    {
                        case 1:
                            MessageBox.Show("Вы вошли как администратор");
                            PagesCh.switchPage.Navigate(new Admin());
                            break;
                        case 2:
                        default:
                            MessageBox.Show("Вы вошли как обычный пользователь");
                            PagesCh.switchPage.Navigate(new Info(CurrentUser));
                            break;

                    }

                }
                else
                {
                    MessageBox.Show("Пользователь не зарегестрирован");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Возникла  ошибка" + exp.Message);
            }
        }

        private void btnRegistr_Click(object sender, RoutedEventArgs e)
        {
            PagesCh.switchPage.Navigate(new Registration()) ;
        }
    }
}
