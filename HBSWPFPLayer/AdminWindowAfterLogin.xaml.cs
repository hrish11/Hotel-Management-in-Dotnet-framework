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
using System.Windows.Shapes;

namespace HBSWPFPLayer
{
    /// <summary>
    /// Interaction logic for AdminWindowAfterLogin.xaml
    /// </summary>
    public partial class AdminWindowAfterLogin : Window
    {
        public AdminWindowAfterLogin()
        {
            InitializeComponent();
        }

       

        private void btnAddHotel_Click_1(object sender, RoutedEventArgs e)
        {
            Hotel newHotel = new Hotel();

            try
            {
                newHotel.HotelID = txtHotelId.Text;
                newHotel.City = CmboHotelCity.Text;
                newHotel.HotelName = txtHotelName.Text;
                newHotel.HotelAddress = txtHotelAddress.Text;
                newHotel.HotelDescription = txtHotelDesc.Text;
                newHotel.HotelAverageRatePerNight = int.Parse(txtHotelAverageRate.Text);
                newHotel.HotelPhoneNo1 = txtHotelPhone1.Text;
                newHotel.HotelPhoneNo2 = txtHotelPhone2.Text;
                newHotel.HotelRating = CmboHotelRating.Text;
                newHotel.HotelEmail = txtHotelEmail.Text;
                newHotel.HotelFax = txtHotelFax.Text;



                int hotelInserted = HBSBl.InsertHotel(newHotel);

                if (hotelInserted > 0)
                {
                    MessageBox.Show("Hotel Record Inserted Successfully");
                    // Clear();
                    // Display();
                }
                else
                    throw new HBSException("Hotel record not inserted");
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

        private void btnSearchHotel_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateHotel_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteHotel_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnDisplayHotel_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnSwitchToRoom_Click_1(object sender, RoutedEventArgs e)
        {
            RoomAddingPageByAdmin roomaddpage = new RoomAddingPageByAdmin();
            roomaddpage.Show();
        }

        private void btnHotelClear_Click_1(object sender, RoutedEventArgs e)
        {
           txtHotelId.Text =string.Empty;
            CmboHotelCity.Text = string.Empty;
            txtHotelName.Text = string.Empty;
            txtHotelAddress.Text = string.Empty;
            txtHotelDesc.Text = string.Empty;
            txtHotelAverageRate.Text = string.Empty;
            txtHotelPhone1.Text = string.Empty;
            txtHotelPhone2.Text = string.Empty;
            CmboHotelRating.Text = string.Empty;
             txtHotelEmail.Text = string.Empty;
            txtHotelFax.Text = string.Empty;
        }
    }
}
