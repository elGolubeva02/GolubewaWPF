using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Avatar.xaml
    /// </summary>
    public partial class Avatar : Page
    {
        public int ind;
        public Avatar(auth CurrentUser)
        {
            InitializeComponent();
            ind = CurrentUser.users.id;
        }
        private void UserImage_Loaded(object sender, RoutedEventArgs e)
        {
            users U = BD.BaseModel.users.FirstOrDefault(x => x.id == ind);
            usersimage UI = BD.BaseModel.usersimage.FirstOrDefault(x => x.id_user == ind);
            BitmapImage BI = new BitmapImage();
            if (UI != null)
            {
                Button button = new Button();
                this.Controls.Add(button);
            }
        }
    }
}
