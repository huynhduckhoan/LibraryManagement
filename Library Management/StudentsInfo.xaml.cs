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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using static Library_Management.Students;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for StudentsInfo.xaml
    /// </summary>
    public partial class StudentsInfo : MetroWindow
    {
        SqlConnection conn;
        public Student Student { get; set; }
        public string Role { get; set; }
        public StudentsInfo(Student student, String role)
        {
            InitializeComponent();
            Loaded += OnLoaded;
            conn = DBSQLServerUtils.DBConnection();

            this.Student = student;
            this.Role = role;

            if (student != null)
            {
                tbStudentName.Text = student.Student_Name;
                tbStudentClass.Text = student.Student_Class;
                tbStudentInfo.Text = student.Student_Info;
            }

            setTitle();
        }

        private void btnSubmitStudentInfo_Click(object sender, RoutedEventArgs e)
        {
            if (Role == "add")
            {
                try
                {
                    Student newStudent = new Student();
                    newStudent.Student_Name = tbStudentName.Text;
                    newStudent.Student_Class = tbStudentClass.Text;
                    newStudent.Student_Info = tbStudentInfo.Text;
                    addStudent(newStudent);
                    ((MainWindow)this.Owner).ucStudents.refreshData();
                    this.Close();
                    MessageBox.Show("Thêm thành công");
                }
                catch
                {
                    MessageBox.Show("Lỗi rồi bạn");
                }
            }
            else if (Role == "edit")
            {
                try
                {
                    Student newStudent = new Student();
                    newStudent.Student_Name = tbStudentName.Text;
                    newStudent.Student_Class = tbStudentClass.Text;
                    newStudent.Student_Info = tbStudentInfo.Text;
                    editStudent(newStudent);
                    ((MainWindow)this.Owner).ucStudents.refreshData();
                    this.Close();
                    MessageBox.Show("Đã cập nhật thành công");
                }
                catch
                {
                    MessageBox.Show("Lỗi rồi bạn");
                }
            }
            else if (Role == "del")
            {
                try
                {
                    delStudent();
                    ((MainWindow)this.Owner).ucStudents.refreshData();
                    this.Close();
                    MessageBox.Show("Đã xóa xong");
                }
                catch
                {
                    MessageBox.Show("Lỗi rồi bạn");
                }
            }
        }
        public void addStudent(Student student)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Students(Student_Name,Student_Class,Student_Info) values(@name,@class,@info)", conn);
            comm.Parameters.AddWithValue("@name", student.Student_Name);
            comm.Parameters.AddWithValue("@class", student.Student_Class);
            comm.Parameters.AddWithValue("@info", student.Student_Info);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void editStudent(Student student)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("UPDATE Students SET Student_Name=@name,Student_Class=@class,Student_Info=@info WHERE PkStudent_ID=@id", conn);
            comm.Parameters.AddWithValue("@name", student.Student_Name);
            comm.Parameters.AddWithValue("@class", student.Student_Class);
            comm.Parameters.AddWithValue("@info", student.Student_Info);
            comm.Parameters.AddWithValue("@id", Student.PkStudent_ID);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        private void delStudent()
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("DELETE FROM Students WHERE PkStudent_ID = @id", conn);
            comm.Parameters.AddWithValue("@id", Student.PkStudent_ID);
            comm.ExecuteNonQuery();
            conn.Close();
        }



        private void setTitle()
        {
            if (Role == "add")
            {
                tbTitleBookInfo.Text = "THÊM SINH VIÊN";
            }
            else if (Role == "edit")
            {
                tbTitleBookInfo.Text = "SỬA THỐNG TIN SINH VIÊN";
            }
            else if (Role == "del")
            {
                tbTitleBookInfo.Text = "XÁC NHẬN XÓA SINH VIÊN";
            }
        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            ResizeMode = ResizeMode.NoResize;
            ShowMaxRestoreButton = false;
            ShowMinButton = false;
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
            Loaded -= OnLoaded;
        }

    }
}
