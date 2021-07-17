using HBSBlLayer;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for DisplayUserWindow.xaml
    /// </summary>
    public partial class DisplayUserWindow : Window
    {
        public DisplayUserWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            DataTable dtCust = HBSBl.DisplayUser();

            if (dtCust.Rows.Count > 0)
            {
                dgCustomer.DataContext = dtCust;
            }
            else
                MessageBox.Show("Data not Available");
        }
        private void DgCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
