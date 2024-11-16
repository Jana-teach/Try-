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

namespace College
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        CollegeEntities db = new CollegeEntities();
        public Login()
        {
            InitializeComponent();
        }

        private void LOGIN_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            Application app = new Application();
            if(emailtxt.Text=="" || passtxt.Text=="")
            {
                MessageBox.Show("Please enter your data");
                return;
            }

            if (emailtxt.Text =="1" && passtxt.Text == "1")
            {
                NavigationService.Navigate(admin);
                return;
            }

            var stu = db.Students.Where(x=> x.S_Email == emailtxt.Text && x.S_Password==passtxt.Text).FirstOrDefault();
            if (stu != null) 
            {
                NavigationService.Navigate(app);
            }
            else
            {
                MessageBox.Show("This Student not found");
            }
        }

       

        private void Signup_Click_1(object sender, RoutedEventArgs e)
        {
            Signup signup = new Signup();
            NavigationService.Navigate(signup);
        }
    }
}
