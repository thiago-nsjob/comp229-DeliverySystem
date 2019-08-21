

CREATE TABLE [dbo].[Restaurant](
	[IdRestaurant] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](30) NULL,
	[Cuisine] [varchar](50) NULL,
	[Description] [varchar](1000) NULL,
	[Image] [varbinary](max) NULL,
 CONSTRAINT [PK_Restaurant] PRIMARY KEY CLUSTERED 
([IdRestaurant] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_RestaurantMenu]    Script Date: 2019-08-06 3:24:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantMenu](
	[IdRestaurantMenu] [int] IDENTITY(1,1) NOT NULL,
	[IdRestaurant] [int] NOT NULL,
	[MenuName] [varchar](30) NULL,
	[MenuType] [varchar](50) NULL,
 CONSTRAINT [PK_RestaurantMenu] PRIMARY KEY CLUSTERED 
([IdRestaurantMenu] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_RestaurantMenuItem]    Script Date: 2019-08-06 3:24:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RestaurantMenuItem](
	[IdRestaurantMenuItem] [int] IDENTITY(1,1) NOT NULL,
	[IdRestaurantMenu] [int] NOT NULL,
	[ItemName] [varchar](30) NULL,
	[ItemDescription] [varchar](50) NULL,
	[ItemPrice] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_RestaurantMenuItem] PRIMARY KEY CLUSTERED 
([IdRestaurantMenuItem] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


ALTER TABLE [dbo].[RestaurantMenu]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantMenu_Restaurant] FOREIGN KEY([IdRestaurant])
REFERENCES [dbo].[Restaurant] ([IdRestaurant])
GO
ALTER TABLE [dbo].[RestaurantMenu] CHECK CONSTRAINT [FK_RestaurantMenu_Restaurant]
GO
ALTER TABLE [dbo].[RestaurantMenuItem]  WITH CHECK ADD  CONSTRAINT [FK_RestaurantMenuItem_RestaurantMenu] FOREIGN KEY([IdRestaurantMenu])
REFERENCES [dbo].[RestaurantMenu] ([IdRestaurantMenu])
GO
ALTER TABLE [dbo].[RestaurantMenuItem] CHECK CONSTRAINT [FK_RestaurantMenuItem_RestaurantMenu]
GO