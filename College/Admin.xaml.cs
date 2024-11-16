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
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        CollegeEntities db = new CollegeEntities();
        public Admin()
        {
            InitializeComponent();
            S_DataGrid.ItemsSource= db.Students.Select(x=> new { x.Did, x.ID, x.S_Name, x.S_Email, x.S_Age, x.S_Address, x.Department.D_Name}).ToList();

        }

        private void Refresh() {

            S_DataGrid.ItemsSource = db.Students.Select(x=> new { x.Did, x.ID, x.S_Name, x.S_Email, x.S_Age, x.S_Address, x.Department.D_Name }).ToList();

        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Student stu = new Student();
            int id = int.Parse( sidtxt.Text);
            stu = db.Students.First(x => x.ID == id);
            db.Students.Remove(stu);
            db.SaveChanges();

            S_DataGrid.ItemsSource = db.Students.Select(x => new { x.Did, x.ID, x.S_Name, x.S_Email, x.S_Age, x.S_Address, x.Department.D_Name }).ToList();

            Refresh();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Student stu = new Student();
            Department d = new Department();
            int id = int.Parse(sidtxt.Text);
            stu = db.Students.First(x=> x.ID == id);
            d.D_Name = deptxt.Text;
            stu.Department = d;
            stu.Department.D_ID = d.D_ID;

            db.Students.AddOrUpdate(stu);
            db.SaveChanges();

            Refresh();

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
          
            var ST = db.Students.Where(x => x.S_Name.Contains(searchtxt.Text)).Select(S => new
            {
                S.ID,
                S.S_Name,
                S.S_Address,
                S.S_Age,
                S.Department.D_Name
            });
            S_DataGrid.ItemsSource = ST.ToList();
        }
    }
}
