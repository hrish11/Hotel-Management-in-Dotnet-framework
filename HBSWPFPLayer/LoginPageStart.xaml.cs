using System;
using System.Collections.Generic;
using System.Data;
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
using HBSBlLayer;
using HBSDalLayer;
using HBSEntityLayer;
using HBSExceptionLayer;

namespace HBSWPFPLayer
{
    /// <summary>
    /// Interaction logic for LoginPageStart.xaml
    /// </summary>
    public partial class LoginPageStart : Window
    {
        public LoginPageStart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string userid = textBoxUserID.Text;
                string userpassword = passwordBox1.Password;


                int userloggedin = HBSBl.LoginUser(userid, userpassword);

                 if (userloggedin > 0)
                {
                    MessageBox.Show("SuccessFul log in");
                    UserCustomerAfterLoginWindow addcustomafterlog = new UserCustomerAfterLoginWindow();
                    addcustomafterlog.Show();
                }
              else  if (userid == "admin" && userpassword == "admin")
                {
                    MessageBox.Show("SuccessFul log in as admin");
                    AdminWindowAfterLogin adminlog = new AdminWindowAfterLogin();
                    adminlog.Show();
                }
                else
                {
                    throw new HBSException("User ID or Password is wrong");
                }
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

        
        private void buttonRegister_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow adduser = new AddUserWindow();
            adduser.Show();
        }
    }
}
