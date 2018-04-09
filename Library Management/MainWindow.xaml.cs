using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using MahApps.Metro.Controls;

namespace Library_Management
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
        
    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {

        #region  Test ToggleButton

        private bool isBorrowBook, isBook, isStudent, isTransgress;

        public bool IsBorrowBook { get => isBorrowBook; set { isBorrowBook = value; isBook = false; isStudent = false; isTransgress = false; OnPropertyChanged("IsBorrowBook"); OnPropertyChanged("IsBook"); OnPropertyChanged("IsStudent"); OnPropertyChanged("IsTransgress"); }  }
        public bool IsBook { get => isBook; set { isBorrowBook = false; isBook = value; isStudent = false; isTransgress = false; OnPropertyChanged("IsBorrowBook"); OnPropertyChanged("IsBook"); OnPropertyChanged("IsStudent"); OnPropertyChanged("IsTransgress"); } }
        public bool IsStudent { get => isStudent; set { isBorrowBook = false; isBook = false; isStudent = value; isTransgress = false; OnPropertyChanged("IsBorrowBook"); OnPropertyChanged("IsBook"); OnPropertyChanged("IsStudent"); OnPropertyChanged("IsTransgress"); } }
        public bool IsTransgress { get => isTransgress; set { isBorrowBook = false; isBook = false; isStudent = false; isTransgress = value; OnPropertyChanged("IsBorrowBook"); OnPropertyChanged("IsBook"); OnPropertyChanged("IsStudent"); OnPropertyChanged("IsTransgress"); } }

        private void github_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/huynhduckhoan/LibraryManagement");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void tgbBorrowBook_Click(object sender, RoutedEventArgs e)
        {
            ucBorrowBook.Visibility = Visibility.Visible;
            ucBooks.Visibility = Visibility.Hidden;
        }

        private void tgbBooks_Click(object sender, RoutedEventArgs e)
        {
            ucBorrowBook.Visibility = Visibility.Hidden;
            ucBooks.Visibility = Visibility.Visible;
        }

        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
        }
        #endregion

        #region SQL Connect 
        SqlConnection conn = DBSQLServerUtils.DBConnection();
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            //ToggleButton Binding
            this.DataContext = this;
            isBorrowBook = true;
        }

    }
}
