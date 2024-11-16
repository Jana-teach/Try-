using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for Application.xaml
    /// </summary>
    public partial class Application : Page
    {
        CollegeEntities db = new CollegeEntities();
        public Application()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Student stu = new Student();
            Department department = new Department();
            stu = db.Students.First(x => x.S_Name == nametxt.Text);
            stu.S_Name = nametxt.Text;
            stu.S_Address = addresstxt.Text;
            stu.S_Age = int .Parse(agetxt.Text);
           department.D_Name = deptxt.Text;
           stu.Department = department;

            db.Students.AddOrUpdate(stu);
            db.SaveChanges();

            MessageBox.Show("Data saved");
        }
    }
}
