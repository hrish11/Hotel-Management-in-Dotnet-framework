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
using System.Windows.Shapes;
using HBSBlLayer;

namespace HBSWPFPLayer
{
    /// <summary>
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        public AddUserWindow()
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
                   // Clear();
                   // Display();
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
            txtUserID.Text=string.Empty;
            passbxUserPassword.Password=string.Empty;
            CmboUserRole.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtUserMobileNo.Text = string.Empty;
            txtUserPhoneNo.Text = string.Empty;
            txtUserAddress.Text = string.Empty;
            txtUserEmail.Text = string.Empty;
        }
    }
}
