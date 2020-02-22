create database MilcreekCapsite
use MilcreekCapsite

create table Campsite (
	ID int NOT NULL Identity(1,1),
	Location varchar(1000)not null,
	Name varchar(100) not null,
	Reserved int,
	Primary Key (ID),
	Unique(Reserved)
)

create table Customer (
	ID int not null Identity(1,1),
	Name varchar (60) not null,
	PhoneNum varchar (20),
	LastVisit DateTime not null,
	primary key (ID),
)

create table Reservation (
	ID int not null Identity(1,1),
	primary key (ID),
	CampID int not null,
	CustID int not null,
	ReserveTime timestamp default current_timestamp
	foreign key (CampID) references Campsite (Reserved) On Delete set null
	unique(CustID)
)

insert into Campsite (Location, Name)
values	('By the fallen oak', 'Oak Place'),
		('Large open Plains where Jain is buried', 'Plain Jain')

insert into Customer (name, LastVisit)
values				('Mike', GetDate()),
					('Tate', GetDate()),
					('Joline', GetDate()),
					('Jain', GetDate())

GO
CREATE PROC AddReservation
	@CustomerID INT,
	@CampID int
AS
	BEGIN
		insert into Reservation (CampID, CustID)
		values (@CampID, @CustomerID)
	END

GO
CREATE PROC DeleteReservation
	@CampID INT
AS
	BEGIN
		delete from Reservation where ID = @CampID
	END

Create View AvailableCamps as
select * from Campsite where reserved = null

-- Create a function that shows the most popular day to visit the canyon
