using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBSEntityLayer;
using HBSExceptionLayer;

namespace HBSDalLayer
{
    public class HBSDal
    {
        //Function to create the command object with connection
        public static SqlCommand CreateCommand()
        {
            SqlCommand cmd = null;

            try
            {

                string s = @"Data Source=DESKTOP-ET98443\SQLEXPRESS;Initial Catalog=HotelManagementSystem;Integrated Security=True";
                SqlConnection con = new SqlConnection();
                // con.ConnectionString = @"Data Source=SHRIYA-PC;Database=Training; integrated security=true;";
                con.ConnectionString = s;
                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

            return cmd;
        }

        public static DataTable DisplayUser()
        {
            DataTable dtCust = new DataTable();

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_DisplayUser";

                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dtCust.Load(dr);
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return dtCust;
        }

        public static User SearchUser(string userID)
        {
            User searchedUser = null;

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_SearchUser";

                cmd.Parameters.AddWithValue("@userID", userID);

                cmd.Connection.Open();
                SqlDataReader drCust = cmd.ExecuteReader();
                if (drCust.HasRows)
                {
                    searchedUser = new User();
                    drCust.Read();
                    searchedUser.UserID = drCust["user_id"].ToString();
                    searchedUser.UserPassword = drCust["password"].ToString();
                    searchedUser.UserRole = drCust["role"].ToString();

                    searchedUser.UserName = drCust["user_name"].ToString();
                    searchedUser.UserMobileNo = drCust["mobile_no"].ToString();
                    searchedUser.UserPhoneNo = drCust["phone"].ToString();
                    searchedUser.UserAddress = drCust["address"].ToString();
                    searchedUser.UserEmail = drCust["email"].ToString();

                }
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
              
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return searchedUser;
        }


        public static int InsertUser(User newUser)
        {
            int userInserted = 0;
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_InsertUser";

                cmd.Parameters.AddWithValue("@Id", newUser.UserID);
                cmd.Parameters.AddWithValue("@Pass", newUser.UserPassword);
                cmd.Parameters.AddWithValue("@role", newUser.UserRole);
                cmd.Parameters.AddWithValue("@username", newUser.UserName);
                cmd.Parameters.AddWithValue("@Mob", newUser.UserMobileNo);
                cmd.Parameters.AddWithValue("@Phone", newUser.UserPhoneNo);
                cmd.Parameters.AddWithValue("@Addrs", newUser.UserAddress);
                cmd.Parameters.AddWithValue("@Email", newUser.UserEmail);


                cmd.Connection.Open();
                userInserted = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return userInserted;
        }

        public static int UpdateUser(User userToBeUpdated)
        {
            int userUpdated = 0;

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_UpdateUser";

                cmd.Parameters.AddWithValue("@UserID", userToBeUpdated.UserID);
                cmd.Parameters.AddWithValue("@UserPassword", userToBeUpdated.UserPassword);
                cmd.Parameters.AddWithValue("@UserRole", userToBeUpdated.UserRole);
                cmd.Parameters.AddWithValue("@UserName", userToBeUpdated.UserName);
                cmd.Parameters.AddWithValue("@UserMobileNo", userToBeUpdated.UserMobileNo);
                cmd.Parameters.AddWithValue("@UserPhoneNo", userToBeUpdated.UserPhoneNo);
                cmd.Parameters.AddWithValue("@UserAddress", userToBeUpdated.UserAddress);
                cmd.Parameters.AddWithValue("@UserEmail", userToBeUpdated.UserEmail);

                cmd.Connection.Open();
                userUpdated = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (SqlException ex)
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
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_DeleteUser";

                cmd.Parameters.AddWithValue("@UserID", userID);

                cmd.Connection.Open();
                userDeleted = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return userDeleted;
        }

       

        public static int LoginUser(string userID, string password)
        {
            int userLogin = 0;
            string userStatus = null;
          //  SqlDataReader rdr = null;
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_checkUserExist";

                cmd.Parameters.AddWithValue("@userID", userID);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.Add("@StatusCount", SqlDbType.Int);
                cmd.Parameters["@StatusCount"].Direction = ParameterDirection.Output;

                cmd.Connection.Open();
                cmd.ExecuteReader();
                // userLogin = cmd.ExecuteNonQuery();
                userStatus = cmd.Parameters["@StatusCount"].Value.ToString();
                userLogin = int.Parse(userStatus);
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return userLogin;
        }
        //***************************************************************************************
        //                                     Hotel Dal

        //****************************************************************************************

        public static DataTable DisplayHotel()
        {
            DataTable dtHotel = new DataTable();

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_DisplayHotel";

                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dtHotel.Load(dr);
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return dtHotel;
        }

        public static Hotel SearchHotel(string hotelID)
        {
            Hotel searchedHotel = null;

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_SearchHotel";

                cmd.Parameters.AddWithValue("@hotelid", hotelID);

                cmd.Connection.Open();
                SqlDataReader drHotel = cmd.ExecuteReader();
                if (drHotel.HasRows)
                {
                    searchedHotel = new Hotel();
                    drHotel.Read();
                    searchedHotel.HotelID = drHotel["hotel_id"].ToString();
                    searchedHotel.City = drHotel["city"].ToString();
                    searchedHotel.HotelName = drHotel["hotel_name"].ToString();

                    searchedHotel.HotelAddress = drHotel["address"].ToString();
                    searchedHotel.HotelDescription = drHotel["description"].ToString();
                    searchedHotel.HotelAverageRatePerNight = int.Parse(drHotel["avg_rate_per_night"].ToString());
                    searchedHotel.HotelPhoneNo1 = drHotel["phone_no1"].ToString();
                    searchedHotel.HotelPhoneNo2 = drHotel["phone_no2"].ToString();
                    searchedHotel.HotelRating = drHotel["rating"].ToString();
                    searchedHotel.HotelEmail = drHotel["email"].ToString();
                    searchedHotel.HotelFax = drHotel["fax"].ToString();

                }
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return searchedHotel;
        }
        public static int InsertHotel(Hotel newHotel)
        {
            int hotelInserted = 0;
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_InsertHotelDetails";

                cmd.Parameters.AddWithValue("@hotelid", newHotel.HotelID);
                cmd.Parameters.AddWithValue("@city", newHotel.City);
                cmd.Parameters.AddWithValue("@hotelname", newHotel.HotelName);
                cmd.Parameters.AddWithValue("@address", newHotel.HotelAddress);
                cmd.Parameters.AddWithValue("@description", newHotel.HotelDescription);
                cmd.Parameters.AddWithValue("@avg_rate_per_night", newHotel.HotelAverageRatePerNight);
                cmd.Parameters.AddWithValue("@phone_no1", newHotel.HotelPhoneNo1);
                cmd.Parameters.AddWithValue("@phone_no2", newHotel.HotelPhoneNo2);
                cmd.Parameters.AddWithValue("@rating", newHotel.HotelRating);
                cmd.Parameters.AddWithValue("@email", newHotel.HotelEmail);
                cmd.Parameters.AddWithValue("@fax", newHotel.HotelFax);


                cmd.Connection.Open();
                hotelInserted = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return hotelInserted;
        }

        public static int UpdateHotel(Hotel hotelToBeUpdated)
        {
            int hotelUpdated = 0;

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_UpdateHotel";

            

                cmd.Parameters.AddWithValue("@hotelid", hotelToBeUpdated.HotelID);
                cmd.Parameters.AddWithValue("@city", hotelToBeUpdated.City);
                cmd.Parameters.AddWithValue("@hotelname", hotelToBeUpdated.HotelName);
                cmd.Parameters.AddWithValue("@address", hotelToBeUpdated.HotelAddress);
                cmd.Parameters.AddWithValue("@description", hotelToBeUpdated.HotelDescription);
                cmd.Parameters.AddWithValue("@avg_rate_per_night", hotelToBeUpdated.HotelAverageRatePerNight);
                cmd.Parameters.AddWithValue("@phone_no1", hotelToBeUpdated.HotelPhoneNo1);
                cmd.Parameters.AddWithValue("@phone_no2", hotelToBeUpdated.HotelPhoneNo2);
                cmd.Parameters.AddWithValue("@rating", hotelToBeUpdated.HotelRating);
                cmd.Parameters.AddWithValue("@email", hotelToBeUpdated.HotelEmail);
                cmd.Parameters.AddWithValue("@fax", hotelToBeUpdated.HotelFax);



                cmd.Connection.Open();
                hotelUpdated = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (SqlException ex)
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
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_DeleteHotel";

                cmd.Parameters.AddWithValue("@hotelid", hotelID);

                cmd.Connection.Open();
                hotelDeleted = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return hotelDeleted;
        }

        //****************************************************************************************
        //                                   Room Dal
        //****************************************************************************************
        public static DataTable DisplayRoom()
        {
            DataTable dtRoom = new DataTable();

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_DisplayRoom";

                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dtRoom.Load(dr);
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return dtRoom;
        }

        public static RoomDetails SearchRoom(string roomid)
        {
            RoomDetails searchedRoom = null;

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_SearchRoom";
                cmd.Parameters.AddWithValue("@roomid", roomid);
              //  cmd.Parameters.AddWithValue("@hotelid", hotelid);
               // cmd.Parameters.AddWithValue("@roomno", roomno);
                cmd.Connection.Open();
                SqlDataReader drRoom = cmd.ExecuteReader();
                if (drRoom.HasRows)
                {
                    searchedRoom = new RoomDetails();
                    drRoom.Read();
                    searchedRoom.HotelID = drRoom["hotel_id"].ToString();
                    searchedRoom.RoomID = drRoom["room_id"].ToString();
                    searchedRoom.RoomNumber = drRoom["room_no"].ToString();
                    searchedRoom.RoomType = drRoom["room_type"].ToString();
                    searchedRoom.RoomPerNightRate = int.Parse(drRoom["per_night_rate"].ToString());
                    searchedRoom.RoomAvailability = int.Parse(drRoom["availability"].ToString());
                    //Ask sir
                   // searchedRoom.RoomPhoto = byte[].Parse(drCust["RoomPhoto"].ToString());
                    

                }
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return searchedRoom;
        }

        public static int InsertRoom(RoomDetails newRoom)
        {
            int roomInserted = 0;
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_InsertRoomDetails";

                cmd.Parameters.AddWithValue("@hotel_id", newRoom.HotelID);
                cmd.Parameters.AddWithValue("@room_id", newRoom.RoomID);
                cmd.Parameters.AddWithValue("@room_no", newRoom.RoomNumber);
                cmd.Parameters.AddWithValue("@room_type", newRoom.RoomType);
                cmd.Parameters.AddWithValue("@per_night_rate", newRoom.RoomPerNightRate);
                cmd.Parameters.AddWithValue("@availability", newRoom.RoomAvailability);
                cmd.Parameters.AddWithValue("@photo", newRoom.RoomPhoto);
              


                cmd.Connection.Open();
                roomInserted = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return roomInserted;
        }

        public static int UpdateRoom(RoomDetails roomToBeUpdated)
        {
            int roomUpdated = 0;

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_UpdateRoom";

                
                cmd.Parameters.AddWithValue("@HotelID", roomToBeUpdated.HotelID);
                cmd.Parameters.AddWithValue("@RoomID", roomToBeUpdated.RoomID);
                cmd.Parameters.AddWithValue("@RoomNumber", roomToBeUpdated.RoomNumber);
                cmd.Parameters.AddWithValue("@RoomType", roomToBeUpdated.RoomType);
                cmd.Parameters.AddWithValue("@RoomPerNightRate", roomToBeUpdated.RoomPerNightRate);
                cmd.Parameters.AddWithValue("@RoomAvailability", roomToBeUpdated.RoomAvailability);
                cmd.Parameters.AddWithValue("@RoomPhoto", roomToBeUpdated.RoomPhoto);
            

                cmd.Connection.Open();
                roomUpdated = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (SqlException ex)
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
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_DeleteRoom";

                cmd.Parameters.AddWithValue("@roomID", roomID);

                cmd.Connection.Open();
                roomDeleted = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return roomDeleted;
        }

        //****************************************************************************************
        //                                   Booking Dal
        //****************************************************************************************

        public static int InsertBookingDetails(BookingDetails newBook)
        {
            int bookingInserted = 0;
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_Booking";

              //  cmd.Parameters.AddWithValue("@booking_id", newBook.BookingID);

                cmd.Parameters.AddWithValue("@room_id", newBook.RoomID);
                cmd.Parameters.AddWithValue("@user_id", newBook.UserID);
                cmd.Parameters.AddWithValue("@booked_from", newBook.BookedFromDate);
                cmd.Parameters.AddWithValue("@booked_to", newBook.BookedToDate);
                cmd.Parameters.AddWithValue("@no_of_adults", newBook.NoOfAdults);
                cmd.Parameters.AddWithValue("@no_of_children", newBook.NoOfChildren);
                cmd.Parameters.AddWithValue("@amount", newBook.BookingAmount);


                cmd.Connection.Open();
                bookingInserted = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return bookingInserted;
        }

        public static ObservableCollection<string> SearchHotelByCity(string city)
        {
         
            ObservableCollection<string> hotelNamesList = new ObservableCollection<string>();
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_SearchByCity";

                cmd.Parameters.AddWithValue("@cityCombo", city);

                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                //if (dr.HasRows)
                //{
                    // searchedHotelbycity = new Hotel();
                   // dr.Read();
                   while (dr.Read())
                    {
                        hotelNamesList.Add(dr["hotel_name"].ToString());
                    }
                //}
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return hotelNamesList;
        }


        public static ObservableCollection<string> GetAvailableRooms(string hotelid,string roomtype,DateTime dateFrom,DateTime dateTo)
        {

            ObservableCollection<string> roomNoList = new ObservableCollection<string>();
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_GetAvailableRoomsByHotelNameAndCity";

                cmd.Parameters.AddWithValue("@hotelId", hotelid);
                cmd.Parameters.AddWithValue("@roomType", roomtype);
                cmd.Parameters.AddWithValue("@dateFrom", dateFrom);
                cmd.Parameters.AddWithValue("@dateTo", dateTo);

                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                  //  dr.Read();

                    roomNoList.Add(dr["room_no"].ToString());

                }
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return roomNoList;
        }

        //public static ObservableCollection<string> SearchBookingByUserID(string userid)
        //{

        //    ObservableCollection<string> bookingList = new ObservableCollection<string>();
        //    try
        //    {
        //        SqlCommand cmd = CreateCommand();
        //        cmd.CommandText = "DisplayUserBookings";

        //        cmd.Parameters.AddWithValue("@userid", userid);

        //        cmd.Connection.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            bookingList.Add(dr["hotel_name"].ToString());
        //        }

        //        cmd.Connection.Close();
        //    }
        //    catch (SqlException ex)
        //    {

        //        throw ex;
        //    }
        //    catch (SystemException ex)
        //    {
        //        throw ex;
        //    }

        //    return bookingList;
        //}

        public static DataTable SearchBookingByUserID(string userid)
        {

            DataTable dtbooking= new DataTable();
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "DisplayUserBookings";
                cmd.Parameters.AddWithValue("@userid", userid);
           
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                dtbooking.Load(dr);
                cmd.Connection.Close();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return dtbooking;
        }


        public static int GetPerNigthRate(string roomID)
        {
            int rateFetched = 0;
          
            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_GetRoomPrice";

                cmd.Parameters.AddWithValue("@roomid", roomID);
                cmd.Parameters.Add("@perNightRate", SqlDbType.Int);
                cmd.Parameters["@perNightRate"].Direction = ParameterDirection.Output;


                cmd.Connection.Open();
                cmd.ExecuteReader();
                rateFetched = int.Parse(cmd.Parameters["@perNightRate"].Value.ToString());
                cmd.Connection.Close();
            }
            catch (SqlException ex)
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
            DataTable dtRoomImage = new DataTable();

            try
            {
                SqlCommand cmd = CreateCommand();
                cmd.CommandText = "usp_fetchPhoto";
                cmd.Parameters.AddWithValue("@roomid", roomid);
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dtRoomImage.Load(dr);
                cmd.Connection.Close();
            }
            catch (SqlException ex)
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