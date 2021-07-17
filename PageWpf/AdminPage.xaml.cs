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
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        public void HotelClear()
        {
            txtHotelId.Text = string.Empty;
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
            Hotel hot = HBSBl.SearchHotel(txtHotelId.Text);
            if (hot != null)
                gridHotel.DataContext = hot;
            else
                MessageBox.Show("Hotel not found");
        }

        private void btnDisplayHotel_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DisplayHotelsAdmin.xaml", UriKind.Relative));
        }

        private void btnDeleteHotel_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int studDeleted = HBSBl.DeleteHotel(txtHotelId.Text);

                if (studDeleted > 0)
                {
                    MessageBox.Show("Hotel Record Deleted Successfully");
                    HotelClear();
                    

                }
                else
                {
                    throw new HBSException("Hotel Record not Deleted");
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

        private void btnUpdateHotel_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Hotel hot = new Hotel();

                hot.HotelID = txtHotelId.Text;
                hot.City = CmboHotelCity.Text;
                hot.HotelName = txtHotelName.Text;
                hot.HotelAddress = txtHotelAddress.Text;
                hot.HotelDescription = txtHotelDesc.Text;
                hot.HotelAverageRatePerNight = int.Parse(txtHotelAverageRate.Text);
                hot.HotelPhoneNo1 = txtHotelPhone1.Text;
                hot.HotelPhoneNo2 = txtHotelPhone2.Text;
                hot.HotelRating = CmboHotelRating.Text;
                hot.HotelEmail = txtHotelEmail.Text;
                hot.HotelFax = txtHotelFax.Text;


                int studUpdated = HBSBl.UpdateHotel(hot);

                if (studUpdated > 0)
                {
                    MessageBox.Show("Hotel Record Updated Successfully");
                    HotelClear();
                    //Display();
                }
                else
                {
                    throw new HBSException("Hotel Record not Updated");
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

        private void btnHotelClear_Click_1(object sender, RoutedEventArgs e)
        {
            HotelClear();

        }

        private void btnSwitchToRoom_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("AddRoom.xaml", UriKind.Relative));
           
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }
    }
}
