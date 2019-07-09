   	
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
		IdPaymentMethod		int not null primary key identity, 
		IdCustomer			int not null ,
		CardNumber			int not null, 
		ExpireDate			Datetime not null,
		SecurityCode		int not null,
		CONSTRAINT FK_PaymentMethod_Customer FOREIGN KEY (IdCustomer)     
		REFERENCES tbl_Customer(IdCustomer)   
	) 
go

if not exists (select * from sysobjects where name='tbl_DeliveryAddress' and xtype='U')
	create table dbo.tbl_DeliveryAddress
	(	
		IdAddress	int not null primary key identity,
		IdCustomer	int not null , 
		Street		varchar(100) not null,
		City		varchar(100) not null,
		Number		int not null,

		CONSTRAINT FK_DeliveryAddress_Customer FOREIGN KEY (IdCustomer)     
		REFERENCES tbl_Customer(IdCustomer)   
	) 
go

if not exists (select * from sysobjects where name='tbl_Restaurant' and xtype='U')
	create table dbo.tbl_Restaurant		
	(
		IdRestaurant	int not null primary key identity,
		Name			varchar(30),
		Cuisine			varchar(50),
		Description		varchar(1000),
	) 
go

if not exists (select * from sysobjects where name='tbl_OrderStatus' and xtype='U')
	create table dbo.tbl_OrderStatus
	(	
		IdOrderStatus	int not null primary key identity,
		StatusName		varchar(30),
	) 
go

if not exists (select * from sysobjects where name='tbl_RestaurantMenu' and xtype='U')
	create table dbo.tbl_RestaurantMenu		
	(
		IdRestaurantMenu	int not null primary key identity, 
		IdRestaurant		int not null,
		MenuName			varchar(30),
		MenuType			varchar(50),
		CONSTRAINT FK_RestaurantMenu_Restaurant FOREIGN KEY (IdRestaurant)     
		REFERENCES tbl_Restaurant(IdRestaurant)   
	) 
go

if not exists (select * from sysobjects where name='tbl_RestaurantMenuItem' and xtype='U')
	create table dbo.tbl_RestaurantMenuItem		
	(
		IdRestaurantMenuItem	int not null primary key identity,
		IdRestaurantMenu		int not null,
		ItemName				varchar(30),
		ItemDescription			varchar(50),
		ItemPrice				decimal not null,
		CONSTRAINT FK_RestaurantMenuItem_RestaurantMenu FOREIGN KEY (IdRestaurantMenu)     
		REFERENCES tbl_RestaurantMenu(IdRestaurantMenu)   
	) 
go

if not exists (select * from sysobjects where name='tbl_Order' and xtype='U')
	create table dbo.tbl_Order
	(	
		
		IdOrder				int not null primary key identity,
		IdCustomer			int not null,
		IdAddress			int not null,
		IdPaymentMethod		int not null,
		IdRestaurant		int not null,
		IdOrderStatus		int not null,
		OrderNetAmount		decimal not null,
		OrderTax			decimal not null,
		OrderGrossAmount	decimal not null,
		CustomerNotes		varchar(2000)
		
		CONSTRAINT FK_Order_Customer FOREIGN KEY (IdCustomer)     
		REFERENCES tbl_Customer(IdCustomer),   
		
		CONSTRAINT FK_Order_DeliveryAddress FOREIGN KEY (IdAddress)     
		REFERENCES tbl_DeliveryAddress(IdAddress),   
		
		CONSTRAINT FK_Order_PaymentMethod FOREIGN KEY (IdPaymentMethod)     
		REFERENCES tbl_PaymentMethod(IdPaymentMethod),   
		
		CONSTRAINT FK_Order_Restaurant FOREIGN KEY (IdRestaurant)     
		REFERENCES tbl_Restaurant(IdRestaurant),   
		
		CONSTRAINT FK_Order_Status FOREIGN KEY (IdOrderStatus)     
		REFERENCES tbl_OrderStatus(IdOrderStatus)   
	) 
go
if not exists (select * from sysobjects where name='tbl_OrderItem' and xtype='U')
	create table dbo.tbl_OrderItem
	(	
		IdOrderItem				int not null primary key identity,
		IdOrder					int not null , 
		IdRestaurantMenuItem	int not null , 
		Quantity				decimal not null,
		PricePerUnity			decimal not null,
		
		CONSTRAINT FK_OrderItem_Order FOREIGN KEY (IdOrder)     
		REFERENCES tbl_Order(IdOrder),   

		CONSTRAINT FK_OrderItem_RestaurantMenuItem FOREIGN KEY (IdRestaurantMenuItem)
		REFERENCES tbl_RestaurantMenuItem(IdRestaurantMenuItem)     
	) 
go

