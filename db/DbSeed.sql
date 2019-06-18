   	
if not exists (select * from sysobjects where name='tbl_Customer' and xtype='U')
    create table dbo.tbl_Customer
	(	
		IdCustomer	int not null primary key identity,
		Name		varchar(100) not null,
		Phone		int	not null,		
		Email		varchar(150),
		Password	varbinary(max) not null,
	);
go


if not exists (select * from sysobjects where name='tbl_PaymentMethod' and xtype='U')
    create table dbo.tbl_PaymentMethod
	(	
		IdAddress	int not null primary key identity, 
		IdCustomer  int not null ,
		Street		varchar(100) not null, 
		City		varchar(100) not null,
		Number		int not null,
		CONSTRAINT FK_PaymentMethod_Customer FOREIGN KEY (IdCustomer)     
		REFERENCES tbl_Customer(IdCustomer)   
	) 
go;

if not exists (select * from sysobjects where name='tbl_PaymentMethod' and xtype='U')
 	
create table dbo.tbl_DeliveryAddress
(	

) 
go;

create table dbo.tbl_OrderItem	
create table dbo.tbl_Restaurant		
create table dbo.tbl_RestaurantMenu
create table dbo.tbl_Order 		
create table dbo.tbl_CustomerAddress	
create table dbo.tbl_OrderStatus
create table dbo.tbl_RestaurantMenuItem
