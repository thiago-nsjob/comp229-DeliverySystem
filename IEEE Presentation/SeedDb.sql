
select * from Restaurant
select * from RestaurantMenu
select * from RestaurantMenuItem
--seed menu
insert into RestaurantMenu
values(1,'Beverage','Cocktails')
insert into RestaurantMenu
values(1,'Appetizers','Vegetarian')
insert into RestaurantMenu
values(1,'Main course','Vegetarian')
--seed menu items
insert into RestaurantMenuItem
values(1,'Water','Awsome water',0.0)
insert into RestaurantMenuItem
values(1,'Orange Juice','Fresh made every day', 2.5)
insert into RestaurantMenuItem
values(1,'Pop','Ask for available brands', 2.0)
insert into RestaurantMenuItem
values(2,'Fries','Fresh cut fries', 4.5)
insert into RestaurantMenuItem
values(2,'Nachos','Served with grilled cheese and jalapenho', 2.5)
insert into RestaurantMenuItem
values(2,'Perogies','Salted with black pepper and bechamel sauce.', 5.0)
insert into RestaurantMenuItem
values(3,'Beyond meat burger','Generous beyond meat burger carefully seasoned', 9.5)
insert into RestaurantMenuItem
values(3,'Vegetarian Poutine','Our fresh fries and the secret house gravy', 8.5)
insert into RestaurantMenuItem
values(3,'Cheese Salad','Leaves mix with fresh parmisan cheese and feta cubes',7.0)


