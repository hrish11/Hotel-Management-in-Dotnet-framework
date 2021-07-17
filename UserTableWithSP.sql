create database HotelManagementSystem
use HotelManagementSystem 
--Table
create schema HMS_Schema

create table HMS_Schema.Users_Table(user_id varchar(30) Constraint Pk_user Primary Key, 
								password varchar(30),
								 role varchar(10) Not Null, 
								  user_name varchar (20),
								  mobile_no varchar(10) Not Null, 
								  phone varchar(10), 
								 address varchar(25)Not Null,
								 email varchar(15)Constraint Em_user unique Not Null )
					


--Insert Procedure
alter PROC usp_InsertUser
(
	@Id			varchar(30),
	@Pass		varchar(30),
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
	ELSE IF EXISTS (SELECT user_id From HMS_Schema.Users_Table 
			WHERE user_id = @Id)
	BEGIN
		RAISERROR('User ID already exists', 1, 1)
		RETURN
	END

	INSERT INTO HMS_Schema.Users_Table(user_id, password , role , user_name ,mobile_no , phone , address ,email )
	VALUES (@Id, @Pass, @role,@username, @Mob, @Phone, @Addrs, @Email)
END

exec usp_InsertUser 'Hrih','hrishh@11','Backchod','hrish11','1222334454','2122334454','Sion','hrish@cap.com'

--Display procedure

create procedure usp_DisplayUser
as
select * from HMS_Schema.Users_Table

--Search Procedure

create procedure usp_SearchUser(@userID varchar(4))
as
select * from HMS_Schema.Users_Table where user_id = @userID

exec usp_SearchUser 111


--Update Procedure

 --CREATE PROCEDURE usp_UpdateUser
 --  (@CustID INT, @Name VARCHAR(30), @City VARCHAR(20), @Age INT, @Phone VARCHAR(10), @Pincode VARCHAR(6))
 --  AS
 --  UPDATE HMS_Schema.Users_Table SET Name = @Name, City = @City, Age = @Age, Phone = @Phone, Pincode = @Pincode
 --  WHERE CustomerID = @CustID

--Login procedure

create procedure usp_checkUserExist
@userID varchar(50),
@Password varchar(50),
@StatusCount int output
as
begin select @StatusCount = count(*)
from HMS_Schema.Users_Table
where user_id = @userID and password = @Password
end