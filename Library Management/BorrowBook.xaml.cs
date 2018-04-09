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

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for BorrowBook.xaml
    /// </summary>
    public partial class BorrowBook : UserControl
    {
        List<User> items = new List<User>();

        public BorrowBook()
        {
            InitializeComponent();
            items.Add(new User() { Name = "123.com", Age = 42, Mail = "1@123.com" });
            items.Add(new User() { Name = "123", Age = 39, Mail = "2@123.com" });
            items.Add(new User() { Name = "Free Education", Age = 7, Mail = "3@123.com" });
            items.Add(new User() { Name = "Free Educati23on", Age = 23, Mail = "3@123.com" });
            lvUsers.ItemsSource = items;

        }

        public class User
        {
            public string Name { get; set; }

            public int Age { get; set; }

            public string Mail { get; set; }
        }

        private void MenuItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            int id = lvUsers.Items.IndexOf(lvUsers.SelectedItem);
            MessageBox.Show(items[id].Name);
        }
    }
}
