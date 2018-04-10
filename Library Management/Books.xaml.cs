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
    /// Interaction logic for Books.xaml
    /// </summary>
    public partial class Books : UserControl
    {
        SqlConnection conn;
        List<Book> book = new List<Book>();
        public Books()
        {
            InitializeComponent();

            conn = DBSQLServerUtils.DBConnection();

            selectSQLtoArray();
            lvBooks.ItemsSource = book;
        }

        public void selectSQLtoArray()
        {
            string sqlSELECT = "SELECT PkBook_ID, Book_Name, Book_Author, Book_Info FROM Books";
            conn.Open();
            SqlCommand command = new SqlCommand(sqlSELECT, conn);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                book.Add(new Book() {
                    PkBook_ID = Convert.ToInt32(reader[0].ToString()),
                    Book_Name = reader[1].ToString(),
                    Book_Author = reader[2].ToString(),
                    Book_Info = reader[3].ToString()
                    });
            }
            conn.Close();
        }

        public class Book
        {
            public int PkBook_ID { get; set; }
            public string Book_Name { get; set; }
            public string Book_Author { get; set; }
            public string Book_Info { get; set; }
        }

        public void refreshData()
        {
            book.Clear();
            selectSQLtoArray();
            lvBooks.Items.Refresh();
        }

        private void addBook_Click(object sender, RoutedEventArgs e)
        {
            BooksInfo bookInfoWindows = new BooksInfo(null,"add");
            bookInfoWindows.Owner = Window.GetWindow(this);
            bookInfoWindows.Show();
        }
        private void delBook_Click(object sender, RoutedEventArgs e)
        {
            int id = lvBooks.Items.IndexOf(lvBooks.SelectedItem);
            BooksInfo bookInfoWindows = new BooksInfo(book[id], "del");
            bookInfoWindows.Owner = Window.GetWindow(this);
            bookInfoWindows.Show();
        }

        private void editBook_Click(object sender, RoutedEventArgs e)
        {
            int id = lvBooks.Items.IndexOf(lvBooks.SelectedItem);
            BooksInfo bookInfoWindows = new BooksInfo(book[id],"edit");
            bookInfoWindows.Owner = Window.GetWindow(this);
            bookInfoWindows.Show();
        }
    }
}
