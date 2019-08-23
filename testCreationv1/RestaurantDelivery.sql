
/****** Object:  Table [dbo].[MenuItem]    Script Date: 23/08/2019 12:12:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuItem](
	[IdMenuItem] [int] IDENTITY(1,1) NOT NULL,
	[IdRestaurant] [int] NOT NULL,
	[ItemName] [varchar](30) NULL,
	[ItemDescription] [varchar](50) NULL,
	[ItemPrice] [decimal](18, 0) NULL,
 CONSTRAINT [PK_MenuItems] PRIMARY KEY CLUSTERED 
(
	[IdMenuItem] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 23/08/2019 12:12:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[IdOrder] [int] IDENTITY(1,1) NOT NULL,
	[IdRestaurant] [int] NOT NULL,
	[IdMenuItem] [int] NOT NULL,
	[CustomerName] [varchar](30) NULL,
	[CustomerAddress] [varchar](50) NULL,
	[OrderNetAmount] [decimal](18, 0) NULL,
	[OrderTax] [decimal](18, 0) NULL,
	[OrderGrossAmount] [decimal](18, 0) NULL,
	[CustomerNotes] [varchar](2000) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[IdOrder] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Restaurant]    Script Date: 23/08/2019 12:12:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Restaurant](
	[IdRestaurant] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NULL,
	[Address] [nvarchar](50) NULL,
	[Description] [varchar](1000) NULL,
	[Cuisine] [nvarchar](30) NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_Restaurants] PRIMARY KEY CLUSTERED 
(
	[IdRestaurant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[MenuItem]  WITH CHECK ADD  CONSTRAINT [FK_MenuItems_Restaurants] FOREIGN KEY([IdRestaurant])
REFERENCES [dbo].[Restaurant] ([IdRestaurant])
GO
ALTER TABLE [dbo].[MenuItem] CHECK CONSTRAINT [FK_MenuItems_Restaurants]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Orders_MenuItems] FOREIGN KEY([IdMenuItem])
REFERENCES [dbo].[MenuItem] ([IdMenuItem])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Orders_MenuItems]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Restaurants] FOREIGN KEY([IdRestaurant])
REFERENCES [dbo].[Restaurant] ([IdRestaurant])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Orders_Restaurants]
GO
USE [master]
GO
ALTER DATABASE [RestaurantDelivery] SET  READ_WRITE 
GO
