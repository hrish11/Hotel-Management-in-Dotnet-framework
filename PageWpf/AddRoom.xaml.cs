using HBSBlLayer;
using HBSEntityLayer;
using HBSExceptionLayer;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Page
    {
        public AddRoom()
        {
            InitializeComponent();
        }

        public void RoomClear()
        {
            txtHotelId.Text = string.Empty;
           // txtRoomID.Text = string.Empty;
            txtRoomNumber.Text = string.Empty;
            CmboRoomType.Text = string.Empty;
            txtRoomPerNightRate.Text = string.Empty;
            txtRoomAvailability.Text = string.Empty;
            txtRoomPhoto.Text = string.Empty;
        }
        private void btnAddRoom_Click_1(object sender, RoutedEventArgs e)
        {
            RoomDetails newRoom = new RoomDetails();

            try
            {
                newRoom.HotelID = txtHotelId.Text;
              //  newRoom.RoomID = txtRoomID.Text;
               
                newRoom.RoomNumber = txtRoomNumber.Text;
                newRoom.RoomID = txtHotelId.Text + txtRoomNumber.Text;
                newRoom.RoomType = CmboRoomType.Text;
                newRoom.RoomPerNightRate = int.Parse(txtRoomPerNightRate.Text);
                if (txtRoomAvailability.Text == "Yes")
                {
                    newRoom.RoomAvailability = 1;
                }
                else
                {
                    newRoom.RoomAvailability = 0;
                }
              //  newRoom.RoomAvailability = int.Parse(txtRoomAvailability.Text);
                newRoom.RoomPhoto = GetPhoto(txtRoomPhoto.Text);





                int roomInserted = HBSBl.InsertRoom(newRoom);

                if (roomInserted > 0)
                {
                    MessageBox.Show("Room Record Inserted Successfully");
                    // Clear();
                    // Display();
                }
                else
                    throw new HBSException("Room record not inserted");
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

        private void btnSearchRoom_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomDetails room = HBSBl.SearchRoom(txtHotelId.Text+txtRoomNumber.Text);
                if (room != null)
                    gridRoom.DataContext = room;
                else
                    MessageBox.Show("Room not found");
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void btnDisplayRoom_Click_1(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("DisplayRoomPageAdmin.xaml", UriKind.Relative));
        }

        private void btnDeleteRoom_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateRoom_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void btnRoomClear_Click_1(object sender, RoutedEventArgs e)
        {
            RoomClear();
        }

        private void btnBrowseRoomPhoto_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            // Launch OpenFileDialog by calling ShowDialog method

            Nullable<bool> result = openFileDlg.ShowDialog();

            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                 txtRoomPhoto.Text = openFileDlg.FileName;
                // txtRoomPhoto.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
               GetPhoto(openFileDlg.FileName);
            }
        }

        public static byte[] GetPhoto(string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);

            byte[] photo = br.ReadBytes((int)fs.Length);

            br.Close();
            fs.Close();

            return photo;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminPage());
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
        }
    }
}
