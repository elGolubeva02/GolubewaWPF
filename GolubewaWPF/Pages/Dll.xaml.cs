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
    /// Логика взаимодействия для Dll.xaml
    /// </summary>
    public partial class Dll : Page
    {
        Class1 Class1 = new Class1();
        List<users> users;
        public static List<DateTime> dates;
        public static List<string> names;
        public static string n; 
        public Dll()
        {
            InitializeComponent();
        }
        private void ага_Click(object sender, RoutedEventArgs e)
        {
            dates = new List<DateTime>();
            users = BD.BaseModel.users.ToList();
            foreach (users userss in users)
            {
                dates.Add(userss.dr);
            }
            MessageBox.Show("Срединй возраст пользователей " + Class1.sredn(dates));
        }

        private void угу_Click(object sender, RoutedEventArgs e)
        {
            Names.Text = "";
            names = new List<string>();
            users = BD.BaseModel.users.ToList();
            foreach (users userss in users)
            {
                names.Add(userss.name);
            }
            if (txtName.Text == "")
            {
                MessageBox.Show("Введите параметр поиска");
            }
            else
            {
                n = txtName.Text;
                if (Class1.imena(names, n).Count == 0)
                {
                    MessageBox.Show("Ничего не найдено");
                }
                else
                {
                    foreach (string u in Class1.imena(names, n))
                    {
                        Names.Text += u + "\n";
                    }
                }
            }
        }
    }
}
