use HotelManagementSystem
create schema HMS_Schema

create table HMS_Schema.BookingDetails_Table(booking_id int identity(1000,1) Constraint Pk_bkididen Primary Key ,
											room_id varchar(30), 
											user_id varchar(30),constraint fk_usidnew Foreign Key (user_id) References HMS_Schema.Users_Table(user_id),
											 booked_from date Not Null, 
											 booked_to date not Null,
											 no_of_adults int Not Null, 
											 no_of_children int,
											amount int not Null)

									

											select * from HMS_Schema.BookingDetails_Table
											 

select * from BookingDetails_Table where booking_id=1000

create PROC usp_Booking
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
	INSERT INTO HMS_Schema.BookingDetails_Table(room_id,user_id,booked_from,booked_to,no_of_adults,no_of_children,amount)
	VALUES (@room_id,@user_id,@booked_from,@booked_to,@no_of_adults,@no_of_children,@amount)
END


-----------------------------------
--Search By City Procedure
create proc usp_SearchByCity(@cityCombo varchar(20))
as
select CONCAT(hotel_name,'-',hotel_id) as hotel_name from HMS_Schema.Hotels_Table where 
hotel_id in (select hotel_id from HMS_Schema.Hotels_Table where city=@cityCombo)
---------------------------------------
---New SearchRoom By PROC
alter proc usp_GetAvailableRoomsByHotelNameAndCity
(
@hotelId varchar(30),
@roomType varchar(30),
@dateFrom date,
@dateTo date
)
as

-- All rooms except booked rooms = unbooked rooms 
select  r.room_no from HMS_Schema.Hotels_Table h,HMS_Schema.RommDetails_Table r
where h.hotel_id = r.hotel_id
and h.hotel_id = @hotelId and r.room_type=@roomType
EXCEPT
select r.room_no from HMS_Schema.Hotels_Table h,HMS_Schema.RommDetails_Table r,HMS_Schema.BookingDetails_Table b
where b.room_id=r.room_id and h.hotel_id = r.hotel_id and r.room_type = @roomType and h.hotel_id = @hotelId 
and (@dateFrom between b.booked_from and b.booked_to 
or @dateTo between b.booked_from and b.booked_to)

------------------------------------------------------------------
--Display Bookings By UserID Proc
alter proc DisplayUserBookings(@userid varchar(20))
as
begin
select * from HMS_Schema.BookingDetails_Table where user_id = @userid
end

exec DisplayUserBookings abcd


-------------------------------------------------------------------
--Get Price of Room Proc
--create proc usp_GetRoomPrice(@roomid varchar(30))
--as
--begin
--select per_night_rate from Hotels_SC.RommDetails_Table where room_id=@roomid
--end

--new
ALTER proc [dbo].[usp_GetRoomPrice](@roomid varchar(30) ,@perNightRate int output)
as
begin
select @perNightRate=per_night_rate from HMS_Schema.RommDetails_Table where room_id=@roomid
end
--------------------------------------------------------------------------------------

create proc usp_fetchPhoto(@roomid varchar(20))
as
begin
select photo from HMS_Schema.RommDetails_Table where room_id = @roomid
end

exec usp_fetchPhoto 'H345R90'