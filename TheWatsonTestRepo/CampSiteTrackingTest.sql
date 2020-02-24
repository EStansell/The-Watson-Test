create database MilcreekCapsite
use MilcreekCapsite

create table Campsite (
	ID int not null primary key Identity(1,1),
	Name varchar(60) not null,
)

create table Reservation (
	ID int not null primary key Identity(1,1),
	Campsite int not null foreign key (Campsite) 
	references Campsite (ID),
	HoldDate dateTime
)

insert into Campsite (Name)
values	('Creak C1'),
		('Creak C2'),
		('Clearing W1'),
		('Clearing W2'),
		('Tree Line TL1'),
		('Tree Line TL2'),
		('Burn Pit 1')
select * from Campsite

insert into Reservation (Campsite, HoldDate)
values	(1, GetDate()),
		(5, GetDate()),
		(5, DateAdd(day, 1, GetDate())),
		(3, GetDate())
select * from Reservation

Go
create Proc Add_Reservation
	@Campsite int,
	@HoldDate DateTime
As
	Begin
		insert into Reservation (Campsite, HoldDate)
		values (@Campsite, @HoldDate)
	End
	
exec Add_Reservation @Campsite = 3, @HoldDate = '2020-02-24 19:45:19.620'

Go
create Proc Del_Reservation
	@CampID int
As
	Begin
		delete from Reservation where ID = @CampID
	End

exec Del_Reservation @CampID = 6

Go
create View FreeCamps
As
	select C.ID, C.Name, DateAdd(day, 1, R.HoldDate) as NextAvailable from Campsite As C
	Left Join Reservation As R on R.Campsite = C.ID
	where R.HoldDate < GetDate()

select * from FreeCamps

Go
Create Function BusiestDay()
Returns DateTime   
as   
Begin  
    Declare @ret DateTime;  

    Select Top(1) @ret = HoldDate   
    From Reservation
	group by HoldDate
	order by Count(HoldDate) desc

    Return @ret;  
End; 
