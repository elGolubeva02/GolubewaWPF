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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
            listGenders.ItemsSource = BD.BaseModel.genders.ToList();
            listGenders.SelectedValuePath = "id";
            listGenders.DisplayMemberPath = "gender";
            string[] traits1 = new string[3];
            List<traits> traits2 = BD.BaseModel.traits.ToList();
            int i = 0;
            foreach (traits traits in traits2)
            {
                traits1[i] = traits.trait;
                i++;
            }
            CH1character.Content = traits1[0];
            CH2character.Content = traits1[1];
            CH3character.Content = traits1[2];

        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                auth LoginAndPass = new auth() {login = txtLogin.Text, password = txtPass.Password, role = 2};
                BD.BaseModel.auth.Add(LoginAndPass);
                BD.BaseModel.SaveChanges();
                users User = new users() { name = txtName.Text, id = LoginAndPass.id, gender = (int)listGenders.SelectedValue, dr = (DateTime)DPdb.SelectedDate };
                BD.BaseModel.users.Add(User);
                if (CH1character.IsChecked == true)
                {
                    users_to_traits users_To_Traits = new users_to_traits();
                    users_To_Traits.id_user = User.id;
                    users_To_Traits.id_trait = 1;
                    BD.BaseModel.users_to_traits.Add(users_To_Traits);
                }
                if (CH2character.IsChecked == true)
                {
                    users_to_traits users_To_Traits = new users_to_traits();
                    users_To_Traits.id_user = User.id;
                    users_To_Traits.id_trait = 2;
                    BD.BaseModel.users_to_traits.Add(users_To_Traits);
                }

                if (CH3character.IsChecked == true)
                {
                    users_to_traits users_To_Traits = new users_to_traits();
                    users_To_Traits.id_user = User.id;
                    users_To_Traits.id_trait = 3;
                    BD.BaseModel.users_to_traits.Add(users_To_Traits);
                }
                BD.BaseModel.SaveChanges();
                MessageBox.Show("Вы успешно зарегестрировались!");
            }
            catch (Exception exp)
            {
                MessageBox.Show("Ошибка! " + exp.Message);
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PagesCh.switchPage.GoBack();
        }
    }
}