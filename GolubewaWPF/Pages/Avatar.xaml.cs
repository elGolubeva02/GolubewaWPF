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
    //    public List<usersimage> UI { get; set; }
    //    public users U { get; set; }
    //    public int ind;
    //    int userImg;
    //    public Avatar(auth CurrentUser)
    //    {
    //        InitializeComponent();
    //        ind = CurrentUser.users.id;
    //    }
    //    private void UserImage_Loaded(object sender, RoutedEventArgs e)
    //    {
    //        U = BD.BaseModel.users.FirstOrDefault(x => x.id == ind);
    //        UI = BD.BaseModel.usersimage.Where(x => x.id_user == ind).ToList();
    //        UI.Reverse();
    //        BitmapImage BI = new BitmapImage();
    //        try
    //        {
    //            if (UI != null)
    //            {
    //                if (UI[userImg].path != null)
    //                {
    //                    BI = new BitmapImage(new Uri(UI[userImg].path, UriKind.Relative));
    //                }
    //                else
    //                {
    //                    BI.BeginInit();
    //                    BI.StreamSource = new MemoryStream(UI[userImg].image);
    //                    BI.EndInit();
    //                }
    //                UserImage.Source = BI;
    //            }
    //            else
    //            {
    //                switch (U.gender)
    //                {
    //                    case 1:
    //                        BI = new BitmapImage(new Uri(@"/Image/man.png", UriKind.Relative));
    //                        break;
    //                    case 2:
    //                        BI = new BitmapImage(new Uri(@"/Image/woman.png", UriKind.Relative));
    //                        break;
    //                    default:
    //                        BI = new BitmapImage(new Uri(@"/Image/other.png", UriKind.Relative));
    //                        break;
    //                }
    //            }
    //        }
    //        catch { }
    //    }
    }
}
