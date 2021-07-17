 use HotelManagementSystem


create table HMS_Schema.RommDetails_Table (	hotel_id varchar(4), constraint fk_hid Foreign Key (hotel_id) References HMS_Schema.Hotels_Table(hotel_id) on delete cascade,
											room_id varchar(20) constraint uk_roomid unique, 
											room_no varchar(3) constraint CompKey_hotelid_roomno PRIMARY KEY (hotel_id, room_no), 
											room_type varchar(20), 
											per_night_rate int,
											availability int,
											photo image)

											
select * from HMS_Schema.RommDetails_Table

--drop table Hotels_SC.RommDetails_Table
--Insert Procedure
CREATE PROC usp_InsertRoomDetails
(
	@hotel_id  			    varchar(4),
	@room_id  		        varchar(20),
	@room_no   		         varchar(3),
	@room_type              varchar(20),       
	@per_night_rate   		     int,
	@availability                bit,
	@photo   		            image
	
	
	
)
AS
BEGIN
	IF(@room_id IS NULL)
	BEGIN
		RAISERROR('Room ID cannot be NULL',1,1)
		RETURN
	END
	ELSE IF EXISTS (SELECT room_id From HMS_Schema.RommDetails_Table
			WHERE room_id = @room_id)
	BEGIN
		RAISERROR('Room ID already exists', 1, 1)
		RETURN
	END

	INSERT INTO HMS_Schema.RommDetails_Table(hotel_id ,room_id ,room_no ,room_type ,per_night_rate ,availability ,photo)
	VALUES (@hotel_id ,@room_id ,@room_no ,@room_type ,@per_night_rate ,@availability ,@photo)
END

exec usp_InsertRoomDetails 'H343','R123','123','AC Room',300,1,'3232323232'



--Display procedure
CREATE PROCEDURE usp_DisplayRoom
  AS 
 SELECT * FROM HMS_Schema.RommDetails_Table

 exec usp_DisplayRoom

 --Search procedure
  alter PROCEDURE usp_SearchRoom(@roomid varchar(15))
   AS
   SELECT hotel_id,room_id,room_no,room_type,per_night_rate,availability FROM HMS_Schema.RommDetails_Table WHERE room_id = @roomid

   exec usp_SearchRoom 'H345R90'

  --Delete Room proc 

  create proc usp_DeleteRoom(@roomid varchar(20))
  as
  begin
  delete from HMS_Schema.RommDetails_Table WHERE room_id=@roomid
  end