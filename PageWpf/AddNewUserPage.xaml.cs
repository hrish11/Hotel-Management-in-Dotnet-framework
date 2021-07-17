using HBSBlLayer;
using HBSEntityLayer;
using HBSExceptionLayer;
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

namespace PageWpf
{
    /// <summary>
    /// Interaction logic for AddNewUserPage.xaml
    /// </summary>
    public partial class AddNewUserPage : Page
    {
        public AddNewUserPage()
        {
            InitializeComponent();
        }

        private void btnAddUserWin_Click_1(object sender, RoutedEventArgs e)
        {
            User newUser = new User();

            try
            {
                newUser.UserID = txtUserID.Text;
                newUser.UserPassword = passbxUserPassword.Password;
                newUser.UserRole = CmboUserRole.Text;
                newUser.UserName = txtUserName.Text;
                newUser.UserMobileNo = txtUserMobileNo.Text;
                newUser.UserPhoneNo = txtUserPhoneNo.Text;
                newUser.UserAddress = txtUserAddress.Text;
                newUser.UserEmail = txtUserEmail.Text;



                int custInserted = HBSBl.InsertUser(newUser);

                if (custInserted > 0)
                {
                    MessageBox.Show("User Record Inserted Successfully");
                    MessageBox.Show("Redirecting to Login Page");
                    this.NavigationService.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
                }
                else
                    throw new HBSException("User record not inserted");
            }
            catch (HBSException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SystemException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearUserWin_Click_1(object sender, RoutedEventArgs e)
        {
            txtUserID.Text = string.Empty;
            passbxUserPassword.Password = string.Empty;
            CmboUserRole.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtUserMobileNo.Text = string.Empty;
            txtUserPhoneNo.Text = string.Empty;
            txtUserAddress.Text = string.Empty;
            txtUserEmail.Text = string.Empty;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
        }
    }
}
