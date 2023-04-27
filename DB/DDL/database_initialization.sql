create database HoltinCompany
go
use HoltinCompany 
go

create table Hotel ( 
Id int identity (1,1) primary key,
[Name] varchar(20),
City varchar(50),
)

create table Room (
Id int identity (1,1) not null primary key,
HotelId int foreign key references Hotel(Id),
Number int not null,
Booked bit not null,
SingleBeds int not null,
DoubleBeds int not null,
WiFi bit not null ,
RoomService bit not null,
AirConditioning bit not null,
TV bit not null,
NightPrice decimal not null,
)

create table Restaurant (
Id int not null identity (1,1) primary key,
HotelId int not null foreign key references Hotel(Id),
TableSeats int not null check (TableSeats>0)
)

create table Client ( 
Id int identity (1,1) primary key,
[Name] varchar(50) not null,
Surname varchar(50) not null,
BirthDate Date not null,
TaxIdCode varchar(16),
PhoneNumber varchar(15)not null,
Email varchar(50),
Fidelity bit default 0,
)

create table Reservation(
Id int identity (1,1) primary key not null,
HotelId int not null foreign key references Hotel (Id), 
RoomId int not null foreign key references Room (Id),
RoomNumber int not null,
ClientId int not null foreign key references Client (Id),
Guests int not null,
CheckIn DateTime not null,
CheckOut DateTime not null,
TotalPrice decimal not null,
)

-- FILL TABLE HOTEL
insert into Hotel ([Name], City)
values 
   ('Hilton', 'New York'),
   ('Marriott', 'Paris'),
   ('Sheraton', 'London'),
   ('Hyatt', 'Tokyo'),
   ('Four Seasons', 'Barcelona'),
   ('InterContinental', 'Sydney'),
   ('Ritz-Carlton', 'Rome'),
   ('Waldorf Astoria', 'Los Angeles'),
   ('Mandarin Oriental', 'Berlin'),
   ('St. Regis', 'Hong Kong'),
   ('Westin', 'Vienna'),
   ('Sofitel', 'San Francisco'),
   ('Fairmont', 'Dubai'),
   ('Rosewood', 'Amsterdam'),
   ('W Hotels', 'Bangkok'),
   ('Shangri-La', 'Shanghai'),
   ('Park Hyatt', 'Toronto'),
   ('Le Meridien', 'Rio de Janeiro'),
   ('Kempinski', 'Cairo'),
   ('Radisson Blu', 'Mumbai'),
   ('Renaissance', 'Seoul'),
   ('Grand Hyatt', 'Moscow'),
   ('Andaz', 'Cape Town'),
   ('Banyan Tree', 'Hanoi'),
   ('Conrad', 'Athens'),
   ('Jumeirah', 'Dublin'),
   ('Peninsula', 'Budapest'),
   ('SLS', 'Edinburgh'),
   ('Edition', 'Melbourne'),
   ('Anantara', 'Montreal')

-- FILL TABLE ROOM
DECLARE @hotelCount int = (SELECT COUNT(*) FROM Hotel)
DECLARE @i int = 1

WHILE @i <= 3000
BEGIN
    DECLARE @hotelId INT = CAST(RAND() * @hotelCount + 1 AS INT)
    DECLARE @number INT = CAST(RAND() * 100 + 1 AS INT)
    DECLARE @booked BIT = ROUND(RAND(), 0)
    DECLARE @singleBeds INT = ROUND(RAND() * 3, 0)
    DECLARE @doubleBeds INT = ROUND(RAND() * 2, 0);
	DECLARE @wifi BIT = ROUND(RAND(), 0)
	DECLARE @roomService BIT = ROUND(RAND(), 0)
	DECLARE @airConditioning BIT = ROUND(RAND(), 0)
	DECLARE @tv BIT = ROUND(RAND(), 0)
    DECLARE @nightPrice DECIMAL(8,2) = CAST(RAND() * 900 + 80 AS DECIMAL(8,2))
    
    INSERT INTO Room (HotelId, Number, Booked, SingleBeds, DoubleBeds, WiFi, RoomService, AirConditioning, TV, NightPrice)
    VALUES (@hotelId, @number, @booked, @singleBeds, @doubleBeds, @wifi, @roomService, @airConditioning, @tv, @nightPrice)
    
    SET @i = @i + 1
END

-- FILL TABLE RESTAURANT
insert into Restaurant(HotelId, TableSeats)
values
(1, 50),
(1, 30),
(2, 40),
(2, 25),
(3, 35),
(3, 20),
(4, 20),
(4, 15),
(5, 45),
(6, 30),
(7, 25),
(7, 15),
(8, 40),
(8, 20),
(9, 30),
(9, 25),
(10, 20),
(11, 35),
(12, 45),
(12, 30),
(13, 50),
(13, 25),
(14, 30),
(15, 25),
(16, 20),
(16, 15),
(17, 40),
(18, 30),
(19, 35),
(20, 20),
(21, 25),
(22, 30),
(22, 20),
(23, 15),
(24, 40),
(25, 25),
(26, 20),
(27, 35),
(28, 30),
(29, 40),
(30, 25);


