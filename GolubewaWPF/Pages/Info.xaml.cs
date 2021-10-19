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
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Page
    {
        public Info(auth CurrentUser)
        {
            InitializeComponent();
            try
            {
                TBname.Text = CurrentUser.users.name;
                TBdb.Text = CurrentUser.users.dr.ToString("yyyy MMMM dd");
                TBGender.Text = CurrentUser.users.genders.gender;
                List<users_to_traits> LUTT = BD.BaseModel.users_to_traits.Where(x => x.id_user == CurrentUser.id).ToList();
                foreach (users_to_traits UT in LUTT)
                {
                    TBCharacter.Text += UT.traits.trait + "  ";
                }
            }
            catch
            (Exception exp)
            {
                MessageBox.Show("Ошибка " + exp.Message);
            }
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            PagesCh.switchPage.GoBack();
        }
    }
}
