using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : UserControl
    {
        SqlConnection conn;
        List<Student> students = new List<Student>();

        public class Student
        {
            public int PkStudent_ID { get; set; }
            public string Student_Name { get; set; }
            public string Student_Class { get; set; }
            public string Student_Info { get; set; }
        }
        public Students()
        {
            InitializeComponent();

            conn = DBSQLServerUtils.DBConnection();
            selectSQLtoArray();
            lvStudents.ItemsSource = students;
        }
        public void selectSQLtoArray()
        {
            string sqlSELECT = "SELECT PkStudent_ID, Student_Name, Student_Class, Student_Info FROM Students";
            conn.Open();
            SqlCommand command = new SqlCommand(sqlSELECT, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                students.Add(new Student()
                {
                    PkStudent_ID = Convert.ToInt32(reader[0].ToString()),
                    Student_Name = reader[1].ToString(),
                    Student_Class = reader[2].ToString(),
                    Student_Info = reader[3].ToString()
                });
            }
            conn.Close();
        }
        public void refreshData()
        {
            students.Clear();
            selectSQLtoArray();
            lvStudents.Items.Refresh();
        }
        private void addStudent_Click(object sender, RoutedEventArgs e)
        {
            StudentsInfo studentInfoWindows = new StudentsInfo(null, "add");
            studentInfoWindows.Owner = Window.GetWindow(this);
            studentInfoWindows.Show();
        }

        private void delStudent_Click(object sender, RoutedEventArgs e)
        {
            int id = lvStudents.Items.IndexOf(lvStudents.SelectedItem);
            StudentsInfo studentInfoWindows = new StudentsInfo(students[id], "del");
            studentInfoWindows.Owner = Window.GetWindow(this);
            studentInfoWindows.Show();
        }

        private void editStudent_Click(object sender, RoutedEventArgs e)
        {
            int id = lvStudents.Items.IndexOf(lvStudents.SelectedItem);
            StudentsInfo studentInfoWindows = new StudentsInfo(students[id], "edit");
            studentInfoWindows.Owner = Window.GetWindow(this);
            studentInfoWindows.Show();
        }
    }
}
