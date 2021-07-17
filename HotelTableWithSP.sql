
 use HotelManagementSystem 


create table HMS_Schema.Hotels_Table(hotel_id varchar(4)Constraint Pk_htid Primary Key ,
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

									
									
--Insert Procedure
CREATE PROC usp_InsertHotelDetails
(
	@hotelid			varchar(4),
	@city 		        varchar(10),
	@hotelname 		    varchar(20),
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
	ELSE IF EXISTS (SELECT hotel_id From HMS_Schema.Hotels_Table
			WHERE hotel_id = @hotelid)
	BEGIN
		RAISERROR('Hotel ID already exists', 1, 1)
		RETURN
	END

	INSERT INTO HMS_Schema.Hotels_Table(hotel_id, city , hotel_name , address  ,description  , avg_rate_per_night  , phone_no1  ,phone_no2 ,rating ,email ,fax )
	VALUES (@hotelid, @city, @hotelname,@address, @description, @avg_rate_per_night, @phone_no1, @phone_no2,@rating,@email,@fax)
END



--Display procedure
CREATE PROCEDURE usp_DisplayHotel
  AS 
 SELECT * FROM HMS_Schema.Hotels_Table

 exec usp_DisplayHotel

 --Search procedure
  CREATE PROCEDURE usp_SearchHotel(@hotelid varchar(15))
   AS
   SELECT * FROM HMS_Schema.Hotels_Table WHERE hotel_id = @hotelid

   exec usp_SearchHotel 123

--Delete procedure
   CREATE PROCEDURE usp_DeleteHotel (@hotelid varchar(15))
   AS
   DELETE  FROM HMS_Schema.Hotels_Table 
   WHERE hotel_id = @hotelid

   exec usp_DeleteHotel 'H343'

--Update procedure

CREATE PROCEDURE usp_UpdateHotel
   (@hotelid			varchar(4),
	@city 		        varchar(10),
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
   update HMS_Schema.Hotels_Table set  city=@city , hotel_name=@hotelname , address =@address ,description=@description  , avg_rate_per_night=@avg_rate_per_night  , phone_no1=@phone_no1  ,phone_no2=@phone_no2 ,rating=@rating ,email=@email ,fax=@fax 
   where hotel_id = @hotelid
   
   
   
   usp_UpdateHotel 'H343','Chennai','UpdatedHotel','Airoli','Expensive',1500,'8888888888','9888888888',4,'hotelh343@gmail.com','hotel343fax'