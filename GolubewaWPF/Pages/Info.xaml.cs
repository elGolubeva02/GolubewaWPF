using GolubewaWPF.Pages;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        public int ind;
        public Info(auth CurrentUser)
        {
            InitializeComponent();
            try
            {
                TBname.Text = CurrentUser.users.name;
                TBdb.Text = CurrentUser.users.dr.ToString("yyyy MMMM dd");
                TBGender.Text = CurrentUser.users.genders.gender;
                ind = CurrentUser.users.id;
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
        private void UserImage_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Image IMG = sender as System.Windows.Controls.Image;
            users U = BD.BaseModel.users.FirstOrDefault(x => x.id == ind);
            usersimage UI = BD.BaseModel.usersimage.FirstOrDefault(x => x.id_user == ind);
            BitmapImage BI = new BitmapImage();
            if (UI != null && UI.avatar == true)
            {
                if (UI.path != null)
                {
                    BI = new BitmapImage(new Uri(UI.path, UriKind.Relative));
                }
                else
                {
                    BI.BeginInit();
                    BI.StreamSource = new MemoryStream(UI.image);
                    BI.EndInit();
                }
            }
            else
            {
                switch (U.gender)
                {
                    case 1:
                        BI = new BitmapImage(new Uri(@"/Pictures/man.jpg", UriKind.Relative));
                        break;
                    case 2:
                        BI = new BitmapImage(new Uri(@"/Pictures/woman.jpg", UriKind.Relative));
                        break;
                    default:
                        BI = new BitmapImage(new Uri(@"/Pictures/other.jpg", UriKind.Relative));
                        break;
                }
            }
            IMG.Source = BI;
        }
        private void btnAvatar_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Controls.Image im = (System.Windows.Controls.Image)sender;
            Ava G = new Ava(ind);
            G.Show();
        }
    }
}
