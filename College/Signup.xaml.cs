using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Signup.xaml
    /// </summary>
    public partial class Signup : Page
    {
        CollegeEntities db = new CollegeEntities();
        public Signup()
        {
            InitializeComponent();
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {

            if (nametxt.Text==""||passtxt.Text==""||confpasstxt.Text==""||emailtxt.Text=="") 
            {
                MessageBox.Show("Require feild");
                return;
            }
            if (!Regex.IsMatch(passtxt.Text, "[a,z]") && Regex.IsMatch(passtxt.Text, "[A,Z]") && Regex.IsMatch(passtxt.Text, "[\\d]") && Regex.IsMatch(passtxt.Text, "[$ - # - ! - & - @]"))
            {
                MessageBox.Show("Password weak");
                return;
            }
            if (passtxt.Text!=confpasstxt.Text)
            {
                MessageBox.Show("Password didn't match");
                return;
            }

            Student stu = new Student();
            Login login = new Login();  
           var name = db.Students.Where(x=> x.S_Name == stu.S_Name).FirstOrDefault();
            if (name != null) {

                MessageBox.Show("This name is taken");
                return;
            }
            stu.S_Name = nametxt.Text;
            stu.S_Email = emailtxt.Text;
            stu.S_Password = passtxt.Text;

            db.Students.Add(stu);
            db.SaveChanges();
            MessageBox.Show("Data saved");

            NavigationService.Navigate(login);
        }
    }
}
