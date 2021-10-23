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
using ClassLibrary1;

namespace GolubewaWPF
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        List<users> users;
        public Admin()
        {
            InitializeComponent();
            users = BD.BaseModel.users.ToList();
            lbUsersList.ItemsSource = users;
        }
        private void lbTraits_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ListBox lb = (ListBox)sender;
                int index = Convert.ToInt32(lb.Uid);
                lb.ItemsSource = BD.BaseModel.users_to_traits.Where(x => x.id_user == index).ToList();
                lb.DisplayMemberPath = "traits.trait";
            }
            catch (Exception exp)
            {
                MessageBox.Show("Возникла  ошибка" + exp.Message);
            }
        }
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            users = BD.BaseModel.users.ToList();
            lbUsersList.ItemsSource = users;
        }
        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            int OT = Convert.ToInt32(txtOT.Text) - 1;
            int DO = Convert.ToInt32(txtDO.Text);
            List<users> lu1 = users.Skip(OT).Take(DO - OT).ToList();
            lbUsersList.ItemsSource = lu1;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btnedit = (Button)sender;
                int index = Convert.ToInt32(btnedit.Uid);
                auth CurrentUser = BD.BaseModel.auth.FirstOrDefault(x => x.id == index);
                MessageBox.Show("" + index);
                PagesCh.switchPage.Navigate(new Change(CurrentUser));
            }
            catch (Exception exp)
            {
                MessageBox.Show("Возникла  ошибка" + exp.Message);
            }
        }

        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            Button btnedit = (Button)sender;
            int index = Convert.ToInt32(btnedit.Uid);
            auth CurrentUser = BD.BaseModel.auth.FirstOrDefault(x => x.id == index);
            BD.BaseModel.auth.Remove(CurrentUser);
            BD.BaseModel.SaveChanges();
            users = BD.BaseModel.users.ToList();
            lbUsersList.ItemsSource = users;
        }
        private void btnNewUser_Click(object sender, RoutedEventArgs e)
        {
            PagesCh.switchPage.Navigate(new Registration());
        }
    }
}
