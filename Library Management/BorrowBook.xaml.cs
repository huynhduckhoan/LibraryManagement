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
    /// Interaction logic for BorrowBook.xaml
    /// </summary>
    public partial class BorrowBook : UserControl
    {
        SqlConnection conn;
        List<Borrow> borrows = new List<Borrow>();

        public class Borrow
        {
            public int pkPkBorrow_ID { get; set; }
            public string Student_Name { get; set; }
            public string Books_Name { get; set; }
            public string BorrowDate { get; set; }
            public string PaidDay { get; set; }
        }

        public BorrowBook()
        {
            InitializeComponent();
            conn = DBSQLServerUtils.DBConnection();
            selectSQLtoArray();

            lvBorrowBook.ItemsSource = borrows;

        }
        public void selectSQLtoArray()
        {
            string sqlSELECT = "SELECT DISTINCT br.PkBorrow_ID, st.Student_Name, br.BorrowDate, br.PaidDay FROM Borrow br INNER JOIN Students st ON br.PkStudent_ID = st.PkStudent_ID INNER JOIN BorrowBook brb ON br.PkBorrow_ID = brb.PkBorrow_ID INNER JOIN Books bo ON brb.PkBook_ID = bo.PkBook_ID";
            conn.Open();
            SqlCommand command = new SqlCommand(sqlSELECT, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string sqlSELECTBook = "SELECT bo.Book_Name FROM Borrow br INNER JOIN BorrowBook brb ON br.PkBorrow_ID = brb.PkBorrow_ID INNER JOIN Books bo ON brb.PkBook_ID = bo.PkBook_ID WHERE br.PkBorrow_ID = " + Convert.ToInt32(reader[0].ToString());
                SqlCommand command2 = new SqlCommand(sqlSELECTBook, conn);
                SqlDataReader reader2 = command2.ExecuteReader();
                string books = "";
                while (reader2.Read())
                {
                    books = String.Concat(books, reader2[0].ToString() + ", ");
                }
                string dayPaid = "";
                if (reader[3].ToString() == "")
                {
                    dayPaid = "Chưa trả";
                }
                else
                {
                    dayPaid = reader[3].ToString();
                }
                borrows.Add(new Borrow()
                {
                    pkPkBorrow_ID = Convert.ToInt32(reader[0].ToString()),
                    Books_Name = books,
                    Student_Name = reader[1].ToString(),
                    BorrowDate = reader[2].ToString(),
                    PaidDay = dayPaid
                });
            }
            conn.Close();
        }

        public void refreshData()
        {
            borrows.Clear();
            selectSQLtoArray();
            lvBorrowBook.Items.Refresh();
        }

        private void BorrowBook_Click(object sender, RoutedEventArgs e)
        {
            var borrowForm = new BorrowForm();
            borrowForm.Owner = Window.GetWindow(this);
            borrowForm.Show();   
        }

        private void cusBook_Click(object sender, RoutedEventArgs e)
        {
            conn.Open();
            int id = lvBorrowBook.Items.IndexOf(lvBorrowBook.SelectedItem);
            SqlCommand comm = new SqlCommand("UPDATE Borrow set PaidDay = @today where PkBorrow_ID=@id", conn);
            comm.Parameters.AddWithValue("@today", DateTime.Now.ToString("MM/dd/yyyy HH-mm"));
            comm.Parameters.AddWithValue("@id", borrows[id].pkPkBorrow_ID);
            comm.ExecuteNonQuery();
            conn.Close();
            refreshData();
        }
    }
}
