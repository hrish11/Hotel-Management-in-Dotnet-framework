using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBSEntityLayer;
using HBSExceptionLayer;
using HBSDalLayer;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using System.Collections.ObjectModel;

namespace HBSBlLayer
{
    public class HBSBl
    {
        public static bool ValidateUser(User newUser)
        {
            StringBuilder message = new StringBuilder();
            bool validCustomer = true;

            try
            {
                if (newUser.UserName == string.Empty)
                {
                    message.Append("Name should be provided\n");
                    validCustomer = false;
                }
                else if (!Regex.IsMatch(newUser.UserName, "^[A-Z][a-z]+"))
                {
                    message.Append("Name should start with Capital letter and it should have alphabets only\n");
                    validCustomer = false;
                }

                if (newUser.UserAddress == string.Empty)
                {
                    message.Append("User Address should be provided\n");
                    validCustomer = false;
                }



                if (newUser.UserPhoneNo == String.Empty)
                {
                    message.Append("Phone number should be provided\n");
                    validCustomer = false;
                }
                else if (!Regex.IsMatch(newUser.UserPhoneNo, "[0-9]{10}"))
                {
                    message.Append("Phone number should have exactly 10 digits\n");
                    validCustomer = false;
                }

                if (newUser.UserID == String.Empty)
                {
                    message.Append("User ID should be provided\n");
                    validCustomer = false;
                }

                if (newUser.UserPassword == String.Empty)
                {
                    message.Append("Password should be provided\n");
                    validCustomer = false;
                }


                if (newUser.UserRole == String.Empty)
                {
                    message.Append("Role should be provided\n");
                    validCustomer = false;
                }
                if (newUser.UserMobileNo == String.Empty)
                {
                    message.Append("Mobile No should be provided\n");
                    validCustomer = false;
                }

                if (newUser.UserEmail == String.Empty)
                {
                    message.Append("Email should be provided\n");
                    validCustomer = false;
                }




                if (validCustomer == false)
                {
                    throw new HBSException(message.ToString());
                }
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return validCustomer;
        }

        public static int InsertUser(User newUser)
        {
            int custUser = 0;

            try
            {
                if (ValidateUser(newUser))
                {
                    custUser = HBSDal.InsertUser(newUser);
                }
                else
                    throw new HBSException("User data is invalid");
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return custUser;
        }

        public static int UpdateUser(User userToBeUpdated)
        {
            int userUpdated = 0;

            try
            {
                if (ValidateUser(userToBeUpdated))
                {
                    userUpdated = HBSDal.UpdateUser(userToBeUpdated);
                }
                else
                {
                    throw new HBSException("Invalid Customer data for updation");
                }
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return userUpdated;
        }

        public static int DeleteUser(string userID)
        {
            int userDeleted = 0;

            try
            {
                userDeleted = HBSDal.DeleteUser(userID);
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return userDeleted;
        }

        public static User SearchUser(string userID)
        {
            User userSearched = null;

            try
            {
                userSearched = HBSDal.SearchUser(userID);
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return userSearched;
        }

        public static DataTable DisplayUser()
        {
            DataTable dtUser = null;

            try
            {
                dtUser = HBSDal.DisplayUser();
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return dtUser;
        }

        //public static User LoginUser(string userID,string password)
        //{
        //    User userLogin = null;

        //    try
        //    {
        //        userLogin = HBSDal.LoginUser(userID, password);
        //    }
        //    catch (HBSException ex)
        //    {
        //        throw ex;
        //    }
        //    catch (SystemException ex)
        //    {
        //        throw ex;
        //    }

        //    return userLogin;
        //}

        public static int LoginUser(string userID, string password)
        {
            int userLogin = 0;

            try
            {
                userLogin = HBSDal.LoginUser(userID, password);
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return userLogin;
        }

        //********************************************************************************
        //                             hotel bll
        //********************************************************************************
        public static bool ValidateHotel(Hotel newHotel)
        {
            StringBuilder message = new StringBuilder();
            bool validHotel = true;

            try
            {
                if (newHotel.HotelID == string.Empty)
                {
                    message.Append("Hotel ID should be provided\n");
                    validHotel = false;
                }

                if (newHotel.City == string.Empty)
                {
                    message.Append("City should be provided\n");
                    validHotel = false;
                }

               


                if (newHotel.HotelName == string.Empty)
                {
                    message.Append("HotelName should be provided\n");
                    validHotel = false;
                }
                else if (!Regex.IsMatch(newHotel.HotelName, "^[A-Z][a-z]+"))
                {
                    message.Append("Hotel Name should start with Capital letter and it should have alphabets only\n");
                    validHotel = false;
                }

                if (newHotel.HotelAddress == string.Empty)
                {
                    message.Append("Hotel Address should be provided\n");
                    validHotel = false;
                }



                if (newHotel.HotelPhoneNo1 == String.Empty)
                {
                    message.Append("Phone number should be provided\n");
                    validHotel = false;
                }
                else if (!Regex.IsMatch(newHotel.HotelPhoneNo1, "[0-9]{10}"))
                {
                    message.Append("Phone number should have exactly 10 digits\n");
                    validHotel = false;
                }

                if (newHotel.HotelPhoneNo2 == String.Empty)
                {
                    message.Append("Phone number should be provided\n");
                    validHotel = false;
                }
                else if (!Regex.IsMatch(newHotel.HotelPhoneNo2, "[0-9]{10}"))
                {
                    message.Append("Phone number should have exactly 10 digits\n");
                    validHotel = false;
                }

                if (newHotel.HotelDescription == string.Empty)
                {
                    message.Append("Hotel Description should be provided\n");
                    validHotel = false;
                }

                if (newHotel.HotelAverageRatePerNight <=0)
                {
                    message.Append("Hotel Average Rate Per Night should be provided and should not be less than or equal to zero\n");
                    validHotel = false;
                }

                if (newHotel.HotelRating == string.Empty)
                {
                    message.Append("Hotel Rating should be provided\n");
                    validHotel = false;
                }

                if (newHotel.HotelEmail == string.Empty)
                {
                    message.Append("Hotel Email should be provided\n");
                    validHotel = false;
                }
                if (newHotel.HotelFax == string.Empty)
                {
                    message.Append("Hotel Fax should be provided\n");
                    validHotel = false;
                }

                if (validHotel == false)
                {
                    throw new HBSException(message.ToString());
                }
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return validHotel;
        }

        public static int InsertHotel(Hotel newHotel)
        {
            int custHotel = 0;

            try
            {
                if (ValidateHotel(newHotel))
                {
                    custHotel = HBSDal.InsertHotel(newHotel);
                }
                else
                    throw new HBSException("Hotel data is invalid");
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return custHotel;
        }

        public static int UpdateHotel(Hotel hotelToBeUpdated)
        {
            int hotelUpdated = 0;

            try
            {
                if (ValidateHotel(hotelToBeUpdated))
                {
                    hotelUpdated = HBSDal.UpdateHotel(hotelToBeUpdated);
                }
                else
                {
                    throw new HBSException("Invalid Hotel data for updation");
                }
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return hotelUpdated;
        }

        public static int DeleteHotel(string hotelID)
        {
            int hotelDeleted = 0;

            try
            {
                hotelDeleted = HBSDal.DeleteHotel(hotelID);
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return hotelDeleted;
        }

        public static Hotel SearchHotel(string hotelID)
        {
            Hotel hotelSearched = null;

            try
            {
                hotelSearched = HBSDal.SearchHotel(hotelID);
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return hotelSearched;
        }

        public static DataTable DisplayHotel()
        {
            DataTable dtHotel = null;

            try
            {
                dtHotel = HBSDal.DisplayHotel();
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return dtHotel;
        }


        //********************************************************************************
        //                                       RoomDetails Bll
        //**********************************************************************************

        public static bool ValidateRoom(RoomDetails newRoom)
        {
            StringBuilder message = new StringBuilder();
            bool validRoom = true;

            try
            {
                //if (newRoom.RoomID == string.Empty)
                //{
                //    message.Append("RoomID should be provided\n");
                //    validRoom = false;
                //}
                //else if (!Regex.IsMatch(newRoom.RoomID, "^[R][0-9]{3}$"))
                //{
                //    message.Append("RoomID should start with Capital letter and it should have alphabets only\n");
                //    validRoom = false;
                //}


                if (newRoom.HotelID == string.Empty)
                {
                    message.Append("Hotel ID should be provided\n");
                    validRoom = false;
                }
                if (newRoom.RoomNumber == string.Empty)
                {
                    message.Append("Room Number should be provided\n");
                    validRoom = false;
                }
                else if (!Regex.IsMatch(newRoom.RoomNumber, "^[R][0-9]{2}$"))
                {
                    message.Append("Room Number should start with Capital letter R and it should contain 2 numbers\n");
                    validRoom = false;
                }

                if (newRoom.RoomType == string.Empty)
                {
                    message.Append("Room Type should be provided\n");
                    validRoom = false;
                }

                if (newRoom.RoomPerNightRate <= 0)
                {
                    message.Append("Room Per Night Rate should be provided and should not be less than or equal to zero\n");
                    validRoom = false;
                }

                if (newRoom.RoomAvailability < 0 || newRoom.RoomAvailability > 1)
                {
                    message.Append("Room Availability should be provided\n");
                    validRoom = false;
                }

                if (newRoom.RoomPhoto == null)
                {
                    message.Append("Room Photo should be provided\n");
                    validRoom = false;
                }

                if (validRoom == false)
                {
                    throw new HBSException(message.ToString());
                }
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return validRoom;
        }

        //public static byte[] GetPhoto(string filePath)
        //{
        //    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
        //    BinaryReader br = new BinaryReader(fs);

        //    byte[] photo = br.ReadBytes((int)fs.Length);

        //    br.Close();
        //    fs.Close();

        //    return photo;
        //}

        public static int InsertRoom(RoomDetails newRoom)
        {
            int custRoom = 0;

            try
            {
                if (ValidateRoom(newRoom))
                {
                    custRoom = HBSDal.InsertRoom(newRoom);
                }
                else
                    throw new HBSException("Room data is invalid");
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return custRoom;
        }

        public static int UpdateRoom(RoomDetails roomToBeUpdated)
        {
            int roomUpdated = 0;

            try
            {
                if (ValidateRoom(roomToBeUpdated))
                {
                    roomUpdated = HBSDal.UpdateRoom(roomToBeUpdated);
                }
                else
                {
                    throw new HBSException("Invalid Hotel data for updation");
                }
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return roomUpdated;
        }

        public static int DeleteRoom(string roomID)
        {
            int roomDeleted = 0;

            try
            {
                roomDeleted = HBSDal.DeleteRoom(roomID);
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return roomDeleted;
        }

        public static RoomDetails SearchRoom(string roomid)
        {
            RoomDetails roomSearched = null;

            try
            {
                roomSearched = HBSDal.SearchRoom(roomid);
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return roomSearched;
        }



        public static DataTable DisplayRoom()
        {
            DataTable dtRoom = null;

            try
            {
                dtRoom = HBSDal.DisplayRoom();
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return dtRoom;
        }
        //******************************************************************************************************************
        //                                                    BookingDetails bll
        //********************************************************************************************************************
        public static int InsertBookingDetails(BookingDetails newBooking)
        {
            int custBooking = 0;

            try
            {


                custBooking = HBSDal.InsertBookingDetails(newBooking);


            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return custBooking;
        }

        public static ObservableCollection<string> getHotelNamesByCity(string city)
        {
            ObservableCollection<string> hotelNamesList = null;
            try
            {
                hotelNamesList = HBSDal.SearchHotelByCity(city);
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return hotelNamesList;
        }


        public static ObservableCollection<string> GetAvailableRooms(string hotelid, string roomtype, DateTime dateFrom, DateTime dateTo)
        {
            {
                ObservableCollection<string> roomNoList = null;
                try
                {
                    roomNoList = HBSDal.GetAvailableRooms(hotelid, roomtype, dateFrom, dateTo);
                }
                catch (HBSException ex)
                {
                    throw ex;
                }
                catch (SystemException ex)
                {
                    throw ex;
                }

                return roomNoList;
            }

        }

        public static DataTable SearchBookingByUserID(string userid)
        {
            DataTable dtUserBooking = null;

            try
            {
                dtUserBooking = HBSDal.SearchBookingByUserID(userid);
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return dtUserBooking;
        }

        public static int GetPerNigthRate(string roomID)
        {
            int rateFetched = 0;

            try
            {
                rateFetched = HBSDal.GetPerNigthRate(roomID);
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return rateFetched;
        }

        public static DataTable FetchRoomImage(string roomid)
        {
            DataTable dtRoomImage = null;

            try
            {
                dtRoomImage = HBSDal.FetchRoomImage(roomid);
            }
            catch (HBSException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return dtRoomImage;
        }
    }
}
