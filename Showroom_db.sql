




create table CarType
(
Id int not null primary key identity,
Name varchar(100),
Description varchar(max)
)

create table Company
(
Id int not null primary key identity,
Name varchar(100) not null,
Description varchar(max)
)

create table Car
(
Id int not null primary key identity,
Name varchar(100) not null,
Description varchar(max),
SittingCapacity int not null,
CarTypeId int foreign key references CarType(Id) on delete set null on update set null,
CompanyId int foreign key references Company(Id) on delete set null on update set null,
EngineCapacity decimal not null,
HoursePower decimal,
HasPowerSteering bit,
HasAntiLockBreakingSystem bit,
TransmissionType bit,
HasPowerWindows bit,
HasAirbags bit,
HasAutoClimControl bit,
HasFogLights bit,
HasAlloyRims bit,
HasCruiseCOntrol bit,
IsHybrid bit,
CarImage1 varchar(max),
CarImage2 varchar(max),
CarImage3 varchar(max)
)


create table Vendors
(
Id int not null primary key identity,
Name varchar(100) not null,
Address varchar(250)
)

create table Purchase
(
Id int not null primary key identity ,
PurchaseDate Date not null,
CarId int foreign key references Car(Id),
VendorId int foreign key references Vendors(Id),
Quantity int ,
TotalAmount money,
AmountPaid money,
AmountDue money
)

create table Stock(
Id int not null primary key identity,
CarId int foreign key references Car(Id),
Available int 
)

create table NewCars
(
Id int not null primary key identity,
CarId int foreign key references Car(Id),
ModelYear int,
CurrentPrice money,
)

Create table UsedCars(
Id int not null primary key identity,
CarId int foreign key references Car(Id),
Demand money,
ModelYear int
) 


create table CustomerDetails
(
Id int not null primary key identity,
FirstName varchar(50) not null,
LastName varchar(50),
Address varchar(250),
Email varchar(25),
Contact varchar(15),
CNIC varchar(17),
PhoneNumber nvarchar(11)
)

create table Employee
(
Id int not null primary key identity,
FirstName varchar(50) not null,
LastName varchar(50),
Address varchar(250),
Email varchar(25),
Qualification varchar(25),
Department varchar(25),
ImagePath  varchar(max),
DateOfBirth nvarchar(25),
Contact varchar(15),
CNIC varchar(17),
Image varchar(max),
PhoneNumber nvarchar(11)
)

create table Invoice
(
Id int not null primary key identity,
InvoiceNumber varchar(50),
InvoiceDate date ,
CarId int foreign key references Car(Id),
TotalAmount money,
AmountPaid money,
AmountDue money,
TotalInstallments int,
InstallmentAmount money,
EngineNo varchar(100),
InvoiceGeneratedBy nvarchar(450) foreign key references AspNetUsers(Id) ,
CustomerId int foreign key references CustomerDetails(Id)
)


create table Intersts
(
Id int not null primary key identity ,
UserId nvarchar(450) foreign key references AspNetUsers(Id),
IsNotified bit,
)


create table RegisteredCars
(
Id int not null primary key identity,
RegistrationDate date,
CarId int foreign key references Car(Id),
RegistrationNo varchar(10)
)


create table Accessories
(
Id int not null primary key identity,
Name varchar(50) not null,
Price money,
ImagePath varchar(max)
)

create table AccessoriesStock(
Id int not null primary key identity,
AccessoryId int foreign key references Accessories(Id),
Quantity int ,
)

create table Orders
(
Id int not null primary key identity,
OrderCode varchar(20),
OrderedBy nvarchar(450) foreign key references AspNetUsers(Id),
OrdereAccessoryId int foreign key references Accessories(Id),
TotalAmount money,
OrderDate date,
Status bit,
DeliveryDate date 
)