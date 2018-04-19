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
    /// Interaction logic for BooksInfo.xaml
    /// </summary>
    public partial class BooksInfo : MetroWindow
    {
        SqlConnection conn;
        public Book Book { get; set; }
        public string Role { get; set; }
        public BooksInfo(Book book, String role)
        {
            InitializeComponent();
            Loaded += OnLoaded;
            conn = DBSQLServerUtils.DBConnection();

            this.Book = book;
            this.Role = role;

            if (book != null)
            {
                tbBookName.Text = Book.Book_Name;
                tbBookAuthor.Text = Book.Book_Author;
                tbBookInfo.Text = Book.Book_Info;
            }

            setTitle();

        }

        public void addBook(Book book)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("INSERT INTO Books(Book_Name,Book_Author,Book_Info) values(@name,@author,@info)", conn);
            comm.Parameters.AddWithValue("@name", book.Book_Name);
            comm.Parameters.AddWithValue("@author", book.Book_Author);
            comm.Parameters.AddWithValue("@info", book.Book_Info);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        public void editBook(Book book)
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("UPDATE Books set Book_Name=@name,Book_Author=@author,Book_Info=@info where PkBook_ID=@id", conn);
            comm.Parameters.AddWithValue("@name", book.Book_Name);
            comm.Parameters.AddWithValue("@author", book.Book_Author);
            comm.Parameters.AddWithValue("@info", book.Book_Info);
            comm.Parameters.AddWithValue("@id", Book.PkBook_ID);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        private void delBook()
        {
            conn.Open();
            SqlCommand comm = new SqlCommand("DELETE FROM Books WHERE PkBook_ID = @id", conn);
            comm.Parameters.AddWithValue("@id", Book.PkBook_ID);
            comm.ExecuteNonQuery();
            conn.Close();
        }
        private void btnSubmitBookInfo_Click(object sender, RoutedEventArgs e)
        {
            if (Role == "add")
            {
                try
                {
                    Book newBook = new Book();
                    newBook.Book_Name = tbBookName.Text;
                    newBook.Book_Author = tbBookAuthor.Text;
                    newBook.Book_Info = tbBookInfo.Text;
                    addBook(newBook);
                    ((MainWindow)this.Owner).ucBooks.refreshData();
                    this.Close();
                    MessageBox.Show("Thêm thành công");
                }
                catch
                {
                    MessageBox.Show("Lỗi rồi bạn");
                }
            }
            else if(Role == "edit")
            {
                try
                {
                    Book newBook = new Book();
                    newBook.Book_Name = tbBookName.Text;
                    newBook.Book_Author = tbBookAuthor.Text;
                    newBook.Book_Info = tbBookInfo.Text;
                    editBook(newBook);
                    ((MainWindow)this.Owner).ucBooks.refreshData();
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
                    delBook();
                    ((MainWindow)this.Owner).ucBooks.refreshData();
                    this.Close();
                    MessageBox.Show("Đã xóa xong");
                }
                catch
                {
                    MessageBox.Show("Lỗi rồi bạn");
                }
            }
        }

        private void setTitle()
        {
            if(Role == "add")
            {
                tbTitleBookInfo.Text = "THÊM SÁCH MỚI";
            }
            else if (Role == "edit")
            {
                tbTitleBookInfo.Text = "SỬA THỐNG TIN SÁCH";
            }
            else if (Role == "del")
            {
                tbTitleBookInfo.Text = "XÁC NHẬN XÓA SÁCH";
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
