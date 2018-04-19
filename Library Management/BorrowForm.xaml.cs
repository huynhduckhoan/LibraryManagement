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
using static Library_Management.Books;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for BorrowForm.xaml
    /// </summary>
    public partial class BorrowForm : MetroWindow
    {
        SqlConnection conn;
        List<String> booksName = new List<string>();
        List<String> studentsName = new List<string>();
        public BorrowForm()
        {
            InitializeComponent();

            conn = DBSQLServerUtils.DBConnection();
            selectStudentsSQLtoArray();
            selectBooksSQLtoArray();
            drBorrowBook.ItemsSource = booksName;
            drBorrowBook1.ItemsSource = booksName;
            drBorrowBook2.ItemsSource = booksName;

            drStudent.ItemsSource = studentsName;
        }
        public void selectBooksSQLtoArray()
        {
            string sqlSELECT = "SELECT PkBook_ID, Book_Name, Book_Author, Book_Info FROM Books";
            conn.Open();
            SqlCommand command = new SqlCommand(sqlSELECT, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                booksName.Add(reader[1].ToString());
            }
            conn.Close();
        }
        public void selectStudentsSQLtoArray()
        {
            string sqlSELECT = "SELECT PkStudent_ID, Student_Name, Student_Class, Student_Info FROM Students";
            conn.Open();
            SqlCommand command = new SqlCommand(sqlSELECT, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                studentsName.Add(reader[1].ToString());
            }
            conn.Close();
        }

        public void insertBorrow(int student)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Borrow(PkStudent_ID,BorrowDate) values(@student,@date)", conn);
            comm.Parameters.AddWithValue("@student", student);
            comm.Parameters.AddWithValue("@date", DateTime.Now.ToString("MM/dd/yyyy HH-mm"));
            comm.ExecuteNonQuery();
            conn.Close();
        }
        public void insertBorrowBook(int idBorrow, int idBook)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO BorrowBook(PkBorrow_ID,PkBook_ID) values(@idBorrow,@idBook)", conn);
            comm.Parameters.AddWithValue("@idBorrow", idBorrow);
            comm.Parameters.AddWithValue("@idBook", idBook);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public int getIDStudent(string studentName)
        {
            List<int> IDStudent = new List<int>();
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT PkStudent_ID FROM Students WHERE Student_Name = N'"+ studentName.Trim() + "'", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                IDStudent.Add(Convert.ToInt32(reader[0].ToString()));
            }
            conn.Close();
            return IDStudent[0];
        }
        public int getIDBook(string bookName)
        {
            List<int> IDBook = new List<int>();
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT PkBook_ID FROM Books WHERE Book_Name = N'" + bookName.Trim() + "'", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                IDBook.Add(Convert.ToInt32(reader[0].ToString()));
            }
            conn.Close();
            return IDBook[0];
        }
        public int getIDBorrow(int studentID)
        {
            List<int> IDBorrow = new List<int>();
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT PkBorrow_ID FROM Borrow WHERE PkStudent_ID = " + studentID + " AND BorrowDate='" + DateTime.Now.ToString("MM/dd/yyyy HH-mm") + "'", conn);
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                IDBorrow.Add(Convert.ToInt32(reader[0].ToString()));
            }
            conn.Close();
            return IDBorrow[0];
        }
        private void btnSubmitBookInfo_Click(object sender, RoutedEventArgs e)
        {
            int idDrStudent = drStudent.Items.IndexOf(drStudent.SelectedItem);
            int idStudent = getIDStudent(studentsName[idDrStudent]);
            try
            {
                insertBorrow(idStudent);
                if (drBorrowBook.Items.IndexOf(drBorrowBook.SelectedItem) != -1)
                {
                    insertBorrowBook(getIDBorrow(idStudent),getIDBook(booksName[drBorrowBook.Items.IndexOf(drBorrowBook.SelectedItem)]) );
                }
                if (drBorrowBook1.Items.IndexOf(drBorrowBook1.SelectedItem) != -1)
                {
                    insertBorrowBook(getIDBorrow(idStudent), getIDBook(booksName[drBorrowBook1.Items.IndexOf(drBorrowBook1.SelectedItem)]));
                }
                if (drBorrowBook2.Items.IndexOf(drBorrowBook2.SelectedItem) != -1)
                {
                    insertBorrowBook(getIDBorrow(idStudent), getIDBook(booksName[drBorrowBook2.Items.IndexOf(drBorrowBook2.SelectedItem)]));
                }
                ((MainWindow)this.Owner).ucBorrowBook.refreshData();
                this.Close();
                MessageBox.Show("Thêm thành công");
            }
            catch
            {
                MessageBox.Show("Error");   
            }
        }
    }
}
