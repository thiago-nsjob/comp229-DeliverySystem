
select * from tbl_Customer
select * from tbl_Order
select * from tbl_OrderItem
select * from tbl_OrderStatus


if not exists(select * from tbl_OrderStatus) 
begin
	insert into tbl_OrderStatus(StatusName) values('Pending');
	insert into tbl_OrderStatus(StatusName) values('Created');
	insert into tbl_OrderStatus(StatusName) values('Delivered');
	insert into tbl_OrderStatus(StatusName) values('Cancelled');
end
go

if not exists(select * from tbl_Restaurant) 

	insert into tbl_Restaurant(Name,Cuisine,Description,Image) 
	values('Some Restaurant','Italian','Some restaurant',null);
	
go


if not exists(select * from tbl_Customer) 

	insert into tbl_Customer(Name,Email,Password,Phone) 
	values('Test','someemail@email.com',Cast('11qq@@WW' as binary),192229293);
	
go

if not exists(select * from tbl_DeliveryAddress) 

	insert into tbl_DeliveryAddress(IdCustomer,Street,City,Number) 
	values(1,'Street name','Toronto',22);
	
go

if not exists(select * from tbl_PaymentMethod) 

	insert into tbl_PaymentMethod(CardNumber,ExpireDate,IdCustomer,SecurityCode) 
	values('227277334',GETDATE(),1,666);
	
go


if not exists(select * from tbl_RestaurantMenu) 
begin
	insert into tbl_RestaurantMenu(IdRestaurant,MenuName,MenuType) 
	values(1,'Awesome aptizers','Aptizers');
end
	
go

if not exists(select * from tbl_RestaurantMenuItem) 
begin
	insert into tbl_RestaurantMenuItem(IdRestaurantMenu,ItemDescription,ItemName,ItemPrice) 
	values(1,'Brocolli is life','Brocolli',1.50);
end
	
go


if not exists(select * from tbl_Order) 
begin
	insert into tbl_Order(IdAddress,IdCustomer,IdOrderStatus,IdPaymentMethod,IdRestaurant,OrderGrossAmount,OrderNetAmount,CustomerNotes,OrderTax) 
	values(1,1,1,1,1,1.50,1.50,'no comments',0);
end
	
go


if not exists(select * from tbl_OrderItem) 
begin
	insert into tbl_OrderItem(IdOrder,IdRestaurantMenuItem,PricePerUnity,Quantity) 
	values(1,1,1.50,1);
end
	
go