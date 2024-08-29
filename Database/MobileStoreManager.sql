
Create database MobileStoreManagerDb;

Use MobileStoreManagerDb;

Create table Roles(
	RoleId INT Primary key Identity(1,1),
	RoleName Varchar(25) Not Null
);


TRUNCATE TABLE Roles;

Insert into Roles
Values ('StoreOwner'),('Manager');

select * from Roles;
select * from Users;
select * from Brands;

select * from Products;
select * from Orders;

Create table Users(
	UserId Int Primary key Identity(1,1),
	UserName Varchar(25) Not Null,
	EmailId Varchar(50) Not Null,
	Password Varchar(50) Not Null,
	RoleId int Not Null,
	IsActive int Not Null,
	Foreign key (RoleId) References Roles(RoleId),
);



Create table Brands(
	BrandId Int Primary key Identity(1,1),
	BrandName Varchar(50) Not Null,
	IsActive int Not Null
);

Create table Products(
	ProductId Int Primary key Identity(1,1),
	BrandId int Not Null,
	Model Varchar(50) Not Null,
	Price Decimal(12,2) not null,
	IsActive int not null,
	AddedDate date null,
	ModifiedDate date null,
	Foreign key (BrandId) References Brands(BrandId),
);



Create table Orders(
	OrderId Int Primary key Identity(1,1),
	ProductId int Not Null,
	SalePrice Decimal(12,2) not null,
	Discount decimal(5,2) not null,
	Quantity int Not Null,
	OrderDate date not null,
	IsActive int not null,
	Foreign key (ProductId) References Products(ProductId),
);

