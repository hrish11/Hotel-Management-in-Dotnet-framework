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
using System.Windows.Shapes;

namespace HBSWPFPLayer
{
    /// <summary>
    /// Interaction logic for MainUserWindowAccess.xaml
    /// </summary>
    public partial class MainUserWindowAccess : Window
    {
        public MainUserWindowAccess()
        {
            InitializeComponent();
        }

        private void btnAddUser_Click_1(object sender, RoutedEventArgs e)
        {
            AddUserWindow adduser = new AddUserWindow();
            adduser.Show();
        }

        private void btnUpdateUser_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteUser_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearchUser_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnDisplay_Click_1(object sender, RoutedEventArgs e)
        {
            DisplayUserWindow disuser = new DisplayUserWindow();
            disuser.Show();
        }
    }
}
