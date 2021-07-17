create database HMS_DB
use HMS_DB 
create schema Users_SC
create table Users_SC.Users_Table(user_id varchar(4) Constraint Pk_user Primary Key, 
								password char(8)CONSTRAINT CK_pass CHECK (password LIKE '[a-z]%[@#$&*][0-9]'),
								 role varchar(10) Not Null, 
								  user_name varchar (20) Constraint u_user unique Not Null,
								  mobile_no varchar(10) Not Null, 
								  phone varchar(10), 
								 address varchar(25)Not Null,
								 email varchar(15)Constraint Em_user unique Not Null )

								 select * from Users_SC.Users_Table

								 create schema Hotels_SC
create table Hotels_SC.Hotels_Table(hotel_id varchar(4)Constraint Pk_htid Primary Key ,
									city varchar(10) Not Null,
									hotel_name varchar(20) Not Null,
									address varchar(25) Not Null, 
									description varchar(50),
									avg_rate_per_night int Not Null,
									phone_no1 varchar(10) Not Null, 
									phone_no2 varchar(10), 
									rating varchar(4), 
									email varchar(15)Constraint u_em unique Not Null,
									fax varchar(15))

									create schema Booking_SC
create table Booking_SC.BookingDetails_Table(booking_id varchar(4)Constraint Pk_bkid Primary Key ,
											room_id varchar(4) Constraint u_rmid unique Not Null , 
											user_id varchar(4),constraint fk_usid Foreign Key (user_id) References Users_SC.Users_Table(user_id),
											 booked_from date Not Null, 
											 booked_to date not Null,
											 no_of_adults int Not Null, 
											 no_of_children int,
											amount int not Null)

											
create table Hotels_SC.RommDetails_Table (	hotel_id varchar(4), constraint fk_hid Foreign Key (hotel_id) References Hotels_SC.Hotels_Table(hotel_id),
											room_id varchar(4), constraint fk_rid Foreign Key (room_id) References Booking_SC.BookingDetails_Table(room_id),
											room_no varchar(3), 
											room_type varchar(20), 
											per_night_rate int,
											availability bit,
											photo image)

CREATE PROC usp_InsertUser
(
	@Id			varchar(4),
	@Pass		CHAR(8),
	@role		varchar(10),
	@username   varchar(20),       
	@Mob		varchar(10),
	@Phone		varchar(10),
	@Addrs		VARCHAR(25),
	@Email		VARCHAR(15)
	
)
AS
BEGIN
	IF(@Id IS NULL)
	BEGIN
		RAISERROR('User ID cannot be NULL',1,1)
		RETURN
	END
	ELSE IF EXISTS (SELECT user_id From Users_SC.Users_Table 
			WHERE user_id = @Id)
	BEGIN
		RAISERROR('User ID already exists', 1, 1)
		RETURN
	END

	INSERT INTO Users_SC.Users_Table(user_id, password , role , user_name ,mobile_no , phone , address ,email )
	VALUES (@Id, @Pass, @role,@username, @Mob, @Phone, @Addrs, @Email)
END

exec usp_InsertUser 'Hrih','hrishh@11','Backchod','hrish11','1222334454','2122334454','Sion','hrish@cap.com'


CREATE PROC usp_InsertHotelDetails
(
	@hotelid			varchar(4),
	@city 		        CHAR(8),
	@hotelname 		    varchar(10),
	@address            varchar(25),       
	@description 		varchar(50),
	@avg_rate_per_night int,
	@phone_no1 		    VARCHAR(10),
	@phone_no2 		    VARCHAR(10),
	@rating              varchar(4),
	@email                varchar(15),
	@fax                 varchar(15)
	
)
AS
BEGIN
	IF(@hotelid IS NULL)
	BEGIN
		RAISERROR('Hotel ID cannot be NULL',1,1)
		RETURN
	END
	ELSE IF EXISTS (SELECT hotel_id From Hotels_SC.Hotels_Table
			WHERE hotel_id = @hotelid)
	BEGIN
		RAISERROR('Hotel ID already exists', 1, 1)
		RETURN
	END

	INSERT INTO Hotels_SC.Hotels_Table(hotel_id, city , hotel_name , address  ,description  , avg_rate_per_night  , phone_no1  ,phone_no2 ,rating ,email ,fax )
	VALUES (@hotelid, @city, @hotelname,@address, @description, @avg_rate_per_night, @phone_no1, @phone_no2,@rating,@email,@fax)
END

CREATE PROC usp_InsertBookingDetails
(
	@booking_id 			varchar(4),
	@room_id  		        varchar(4),
	@user_id  		         varchar(4),
	@booked_from             date,       
	@booked_to  		     date,
	@no_of_adults               int,
	@no_of_children  		    int,
	@amount  		             int
	
	
)
AS
BEGIN
	IF(@booking_id IS NULL)
	BEGIN
		RAISERROR('Booking ID cannot be NULL',1,1)
		RETURN
	END
	ELSE IF EXISTS (SELECT booking_id From Booking_SC.BookingDetails_Table
			WHERE booking_id = @booking_id)
	BEGIN
		RAISERROR('Booking ID already exists', 1, 1)
		RETURN
	END

	INSERT INTO Booking_SC.BookingDetails_Table(booking_id,room_id,user_id,booked_from,booked_to,no_of_adults,no_of_children,amount)
	VALUES (@booking_id,@room_id,@user_id,@booked_from,@booked_to,@no_of_adults,@no_of_children,@amount)
END

CREATE PROC usp_InsertRoomDetails
(
	@hotel_id  			varchar(4),
	@room_id  		        varchar(4),
	@room_no   		         varchar(3),
	@room_type              varchar(20),       
	@per_night_rate   		     int,
	@availability                bit,
	@photo   		    image
	
	
	
)
AS
BEGIN
	IF(@room_id IS NULL)
	BEGIN
		RAISERROR('Room ID cannot be NULL',1,1)
		RETURN
	END
	ELSE IF EXISTS (SELECT room_id From Hotels_SC.RommDetails_Table
			WHERE room_id = @room_id)
	BEGIN
		RAISERROR('Room ID already exists', 1, 1)
		RETURN
	END

	INSERT INTO Hotels_SC.RommDetails_Table(hotel_id ,room_id ,room_no ,room_type ,per_night_rate ,availability ,photo)
	VALUES (@hotel_id ,@room_id ,@room_no ,@room_type ,@per_night_rate ,@availability ,@photo)
END


create procedure usp_DisplayUser
as
select * from Users_SC.Users_Table

create procedure usp_LoginUser
as
select * from Users_SC.Users_Table

    alter PROCEDURE usp_LoginUser(@userID varchar(4),@password char(8))
   AS
   SELECT * FROM Users_SC.Users_Table WHERE user_id =@userID  and password =@password

   exec usp_LoginUser 'Cust1','Qwerty@1'

   ------------------------------------------------

   CREATE procedure login_pro

(

        @userID varchar(50),

        @Password varchar(50)

)

as

declare @status int

if exists(select * from Users_SC.Users_Table where user_id=@userID and Password=@Password)

       set @status=1

else

       set @status=0

select @status

exec login_pro 'Cust1','Qwerty@1'

											

									
