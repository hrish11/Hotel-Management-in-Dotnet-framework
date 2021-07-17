use HMS_DB
create table BookingDetails_Table(booking_id varchar(4)Constraint Pk_bkid Primary Key ,
											room_id varchar(4) Constraint u_rmid unique Not Null , 
											user_id varchar(4),constraint fk_usid Foreign Key (user_id) References Users_SC.Users_Table(user_id),
											 booked_from date Not Null, 
											 booked_to date not Null,
											 no_of_adults int Not Null, 
											 no_of_children int,
											amount int not Null)

 --drop table BookingDetails_Table
select * from BookingDetails_Table
----------------------------------------------------------------------------------------------------------
--New Booking Table
---------------------------------------------------------------------------------------------------------
create table BookingDetails_Table1(booking_id int identity(1000,1) Constraint Pk_bkautoid Primary Key ,
											room_id varchar(4) Constraint u_newrmid unique Not Null , 
											user_id varchar(4),constraint fk_newusid Foreign Key (user_id) References Users_SC.Users_Table(user_id),
											 booked_from date Not Null, 
											 booked_to date not Null,
											 no_of_adults int Not Null, 
											 no_of_children int,
											amount int not Null)

		select * from BookingDetails_Table									

CREATE PROC usp_Booking
(
	@room_id varchar(30),
	@user_id varchar(30),
	@booked_from             date,       
	@booked_to  		     date,
	@no_of_adults            int,
	@no_of_children  		 int,
	@amount  		         int
)
AS
BEGIN
	INSERT INTO BookingDetails_Table1(room_id,user_id,booked_from,booked_to,no_of_adults,no_of_children,amount)
	VALUES (@room_id,@user_id,@booked_from,@booked_to,@no_of_adults,@no_of_children,@amount)
END


-----------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROC usp_InsertBookingDetails
(
	@user_id  		         varchar(4),
	@booked_from             date,       
	@booked_to  		     date,
	@no_of_adults            int,
	@no_of_children  		 int,
	@amount  		         int
)
AS
BEGIN
	 DECLARE @booking_id VARCHAR(4);
	 DECLARE @room_id  	VARCHAR(4);
     DECLARE @PreFix   VARCHAR(1) = 'B';
	 DECLARE @RoomIdPreFix VARCHAR(1) = 'R';
     DECLARE @Id INT;
	 DECLARE @RmId INT;

SELECT @Id = ISNULL(MAX(booking_id),0) + 1 FROM BookingDetails_Table
--SELECT @RmId = ISNULL(MAX(room_id),0) + 1 FROM Hotels_SC.RommDetails_Table
 SELECT @booking_id = @PreFix + CAST(@Id AS VARCHAR(3))
  SELECT @room_id = @RoomIdPreFix + CAST(@Id AS VARCHAR(3))
	INSERT INTO BookingDetails_Table(booking_id,room_id,user_id,booked_from,booked_to,no_of_adults,no_of_children,amount)
	VALUES (@booking_id,@room_id,@user_id,@booked_from,@booked_to,@no_of_adults,@no_of_children,@amount)
END


--Search By City Procedure

create proc usp_SearchByCity(@cityCombo varchar(20))
as
select distinct(hotel_name) from Hotels_SC.Hotels_Table
where city=@cityCombo

exec usp_SearchByCity 'Bangalore'

drop procedure usp_SearchByCity


--new Seearch proc
create proc usp_SearchByCity1(@cityCombo varchar(20))
as
select CONCAT(hotel_name,'-',hotel_id) as hotel_name from Hotels_SC.Hotels_Table where 
hotel_id in (select hotel_id from Hotels_SC.Hotels_Table where city=@cityCombo)


------------------------------------------------------------------------------------------------------------------------
-----------------------------------------SearchRoomProc------------------------------------------------------------
create proc usp_GetAvailableRoomsByHotelNameAndCity
(
@city varchar(30),
@hotelName varchar(30),
@roomType varchar(30),
@dateFrom date,
@dateTo date
)
as
select r.room_no from Hotels_SC.Hotels_Table h,Hotels_SC.RommDetails_Table r,BookingDetails_Table b
where b.room_id=r.room_id and h.hotel_id = r.hotel_id and @dateFrom not between b.booked_from and b.booked_to 
and @dateTo not between b.booked_from and b.booked_to and r.room_type = @roomType and h.city = @city
and h.hotel_name=@hotelName

---New SearchRoom By PROC


create proc usp_GetAvailableRoomsByHotelNameAndCity1
(
@hotelId varchar(30),
@roomType varchar(30),
@dateFrom date,
@dateTo date
)
as

-- All rooms except booked rooms = unbooked rooms 
select  r.room_no from Hotels_SC.Hotels_Table h,Hotels_SC.RommDetails_Table r
where h.hotel_id = r.hotel_id
and h.hotel_id = @hotelId and r.room_type=@roomType
EXCEPT
select r.room_no from Hotels_SC.Hotels_Table h,Hotels_SC.RommDetails_Table r,BookingDetails_Table b
where b.room_id=r.room_id and h.hotel_id = r.hotel_id and r.room_type = @roomType and h.hotel_id = @hotelId 
and (@dateFrom between b.booked_from and b.booked_to 
or @dateTo between b.booked_from and b.booked_to)