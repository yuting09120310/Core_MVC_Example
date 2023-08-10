/****** Object:  Table [dbo].[Admin]    Script Date: 2023/5/8 下午 05:30:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminNum] [bigint] IDENTITY(1,1) NOT NULL,
	[GroupNum] [int] NULL,
	[AdminAcc] [nvarchar](max) NULL,
	[AdminPwd] [nvarchar](max) NULL,
	[AdminName] [nvarchar](max) NULL,
	[AdminPublish] [int] NULL,
	[LastLogin] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [int] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [int] NULL,
	[IP] [nvarchar](max) NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED
(
	[AdminNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminGroup]    Script Date: 2023/5/8 下午 05:30:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminGroup](
	[GroupNum] [bigint] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](max) NULL,
	[GroupInfo] [nvarchar](max) NULL,
	[GroupPublish] [int] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [int] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [int] NULL,
	[IP] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoginGroup] PRIMARY KEY CLUSTERED
(
	[GroupNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AdminRole]    Script Date: 2023/5/8 下午 05:30:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminRole](
	[RoleNum] [bigint] IDENTITY(1,1) NOT NULL,
	[GroupNum] [int] NULL,
	[MenuSubNum] [nvarchar](max) NULL,
	[Role] [nvarchar](max) NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [int] NULL,
	[IP] [nvarchar](max) NULL,
 CONSTRAINT [PK_LoginRole] PRIMARY KEY CLUSTERED
(
	[RoleNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Banner]    Script Date: 2023/5/8 下午 05:30:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Banner](
	[BannerNum] [bigint] IDENTITY(1,1) NOT NULL,
	[Lang] [nvarchar](max) NULL,
	[ProductClass] [int] NULL,
	[BannerSort] [int] NULL,
	[BannerTitle] [nvarchar](max) NULL,
	[BannerDescription] [nvarchar](max) NULL,
	[BannerContxt] [nvarchar](max) NULL,
	[BannerImg1] [nvarchar](max) NULL,
	[BannerImgUrl] [nvarchar](max) NULL,
	[BannerImgAlt] [nvarchar](max) NULL,
	[BannerPublish] [int] NULL,
	[BannerPutTime] [datetime] NULL,
	[BannerOffTime] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [int] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [int] NULL,
	[IP] [nvarchar](max) NULL,
 CONSTRAINT [PK_Banner] PRIMARY KEY CLUSTERED
(
	[BannerNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 2023/5/8 下午 05:30:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[ContactNum] [bigint] IDENTITY(1,1) NOT NULL,
	[ContactName] [nvarchar](max) NULL,
	[ContactPhone] [nvarchar](max) NULL,
	[ContactMail] [nvarchar](max) NULL,
	[ContactTxt] [nvarchar](max) NULL,
	[ContactReTxt] [nvarchar](max) NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [int] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [int] NULL,
	[IP] [nvarchar](max) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED
(
	[ContactNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 2023/5/8 下午 05:30:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[MemberNum] [bigint] IDENTITY(1,1) NOT NULL,
	[MemberAccount] [nvarchar](max) NULL,
	[MemberPassword] [nvarchar](max) NULL,
	[MemberName] [nvarchar](max) NULL,
	[MemberPhone] [nvarchar](max) NULL,
	[MemberEmail] [nvarchar](max) NULL,
	[MemberPublish] [int] NULL,
	[LastLogin] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [int] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [int] NULL,
	[IP] [nvarchar](max) NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED
(
	[MemberNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuGroup]    Script Date: 2023/5/8 下午 05:30:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuGroup](
	[MenuGroupNum] [bigint] IDENTITY(1,1) NOT NULL,
	[MenuGroupSort] [int] NULL,
	[MenuGroupId] [nvarchar](max) NULL,
	[MenuGroupName] [nvarchar](max) NULL,
	[MenuGroupIcon] [nvarchar](max) NULL,
	[MenuGroupInfo] [nvarchar](max) NULL,
	[MenuGroupUrl] [nvarchar](max) NULL,
	[MenuGroupPublish] [int] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [int] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [int] NULL,
	[IP] [nvarchar](max) NULL,
 CONSTRAINT [PK_MenuGroup] PRIMARY KEY CLUSTERED
(
	[MenuGroupNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MenuSub]    Script Date: 2023/5/8 下午 05:30:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuSub](
	[MenuSubNum] [bigint] IDENTITY(1,1) NOT NULL,
	[MenuGroupId] [nvarchar](max) NULL,
	[MenuSubSort] [int] NULL,
	[MenuSubId] [nvarchar](max) NULL,
	[MenuSubName] [nvarchar](max) NULL,
	[MenuSubRole] [nvarchar](max) NULL,
	[MenuSubIcon] [nvarchar](max) NULL,
	[MenuSubInfo] [nvarchar](max) NULL,
	[MenuSubUrl] [nvarchar](max) NULL,
	[MenuSubPublish] [int] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [int] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [int] NULL,
	[IP] [nvarchar](max) NULL,
 CONSTRAINT [PK_MenuSub] PRIMARY KEY CLUSTERED
(
	[MenuSubNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 2023/5/8 下午 05:30:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsNum] [bigint] IDENTITY(1,1) NOT NULL,
	[Lang] [nvarchar](max) NULL,
	[NewsClass] [int] NULL,
	[NewsSort] [int] NULL,
	[NewsTitle] [nvarchar](max) NULL,
	[NewsDescription] [nvarchar](max) NULL,
	[NewsContxt] [nvarchar](max) NULL,
	[NewsImg1] [nvarchar](max) NULL,
	[NewsImgUrl] [nvarchar](max) NULL,
	[NewsImgAlt] [nvarchar](max) NULL,
	[NewsPublish] [int] NULL,
	[NewsViews] [int] NULL,
	[NewsPutTime] [datetime] NULL,
	[NewsOffTime] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [int] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [int] NULL,
	[IP] [nvarchar](max) NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED
(
	[NewsNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NewsClass]    Script Date: 2023/5/8 下午 05:30:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsClass](
	[NewsClassNum] [bigint] IDENTITY(1,1) NOT NULL,
	[NewsClassSort] [int] NULL,
	[NewsClassId] [nvarchar](max) NULL,
	[NewsClassName] [nvarchar](max) NULL,
	[NewsClassLevel] [int] NULL,
	[NewsClassPre] [int] NULL,
	[NewsClassPublish] [int] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [int] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [int] NULL,
	[IP] [nvarchar](max) NULL,
 CONSTRAINT [PK_NewsClass] PRIMARY KEY CLUSTERED
(
	[NewsClassNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2023/5/8 下午 05:30:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductNum] [bigint] IDENTITY(1,1) NOT NULL,
	[Lang] [nvarchar](max) NULL,
	[ProductClass] [int] NULL,
	[ProductSort] [int] NULL,
	[ProductDepartment] [nvarchar](max) NULL,
	[ProductId] [nvarchar](max) NULL,
	[ProductTitle] [nvarchar](max) NULL,
	[ProductDescription] [nvarchar](max) NULL,
	[ProductContxt] [nvarchar](max) NULL,
	[ProductImg1] [nvarchar](max) NULL,
	[ProductImgUrl] [nvarchar](max) NULL,
	[ProductImgAlt] [nvarchar](max) NULL,
	[ProductImgList] [nvarchar](max) NULL,
	[ProductImgListAlt] [nvarchar](max) NULL,
	[ProductVideo1] [nvarchar](max) NULL,
	[ProductPublish] [int] NULL,
	[ProductPutTime] [datetime] NULL,
	[ProductOffTime] [datetime] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [int] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [int] NULL,
	[IP] [nvarchar](max) NULL,
 CONSTRAINT [PK_Product_1] PRIMARY KEY CLUSTERED
(
	[ProductNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductClass]    Script Date: 2023/5/8 下午 05:30:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductClass](
	[ProductClassNum] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductClassSort] [int] NULL,
	[ProductClassId] [nvarchar](max) NULL,
	[ProductClassName] [nvarchar](max) NULL,
	[ProductClassLevel] [int] NULL,
	[ProductClassPre] [int] NULL,
	[ProductClassPublish] [int] NULL,
	[CreateTime] [datetime] NULL,
	[Creator] [int] NULL,
	[EditTime] [datetime] NULL,
	[Editor] [int] NULL,
	[IP] [nvarchar](max) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED
(
	[ProductClassNum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON

INSERT [dbo].[Admin] ([AdminNum], [GroupNum], [AdminAcc], [AdminPwd], [AdminName], [AdminPublish], [LastLogin], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, 1, N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'admin', 1, CAST(N'2023-05-08T17:04:31.000' AS DateTime), CAST(N'2011-03-23T11:29:00.000' AS DateTime), 1, CAST(N'2023-03-03T15:56:09.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[Admin] ([AdminNum], [GroupNum], [AdminAcc], [AdminPwd], [AdminName], [AdminPublish], [LastLogin], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, 2, N'test', N'a0a475cf454cf9a06979034098167b9e', N'test', 1, CAST(N'2023-02-08T10:43:36.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-02-07T18:01:52.000' AS DateTime), 1, N'192.168.1.26')
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
SET IDENTITY_INSERT [dbo].[AdminGroup] ON

INSERT [dbo].[AdminGroup] ([GroupNum], [GroupName], [GroupInfo], [GroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, N'系統管理者', N'最高管理員', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-03-03T11:50:09.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminGroup] ([GroupNum], [GroupName], [GroupInfo], [GroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, N'一般管理者', N'一般功能管理', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-03-09T16:12:48.000' AS DateTime), 1, N'192.168.1.26')
SET IDENTITY_INSERT [dbo].[AdminGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[AdminRole] ON

INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (44, 1, N'1', N'V,L,N,M,D', CAST(N'2023-03-03T11:50:09.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (45, 1, N'2', N'V,L,N,M,D', CAST(N'2023-03-03T11:50:09.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (46, 1, N'3', N'V,M', CAST(N'2023-03-03T11:50:09.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (47, 1, N'4', N'V,L,N,M,D', CAST(N'2023-03-03T11:50:09.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (48, 1, N'5', N'V,L,N,M,D', CAST(N'2023-03-03T11:50:09.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (49, 1, N'6', N'V,L,N,M,D', CAST(N'2023-03-03T11:50:09.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (50, 1, N'7', N'V,L,N,M,D', CAST(N'2023-03-03T11:50:09.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (51, 1, N'8', N'V,L,N,M,D', CAST(N'2023-03-03T11:50:09.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (52, 1, N'11', N'V,L,N,M,D', CAST(N'2023-03-03T11:50:09.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (142, 2, N'4', N'V,L,N,M,D', CAST(N'2023-03-09T16:12:48.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (143, 2, N'5', N'V,L,N,M,D', CAST(N'2023-03-09T16:12:48.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (144, 2, N'6', N'V,L,N,M,D', CAST(N'2023-03-09T16:12:48.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (145, 2, N'7', N'V,L,N,M,D', CAST(N'2023-03-09T16:12:48.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (146, 2, N'8', N'V,L,N,M,D', CAST(N'2023-03-09T16:12:48.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[AdminRole] ([RoleNum], [GroupNum], [MenuSubNum], [Role], [CreateTime], [Creator], [IP]) VALUES (147, 2, N'11', N'V,L,N,M,D', CAST(N'2023-03-09T16:12:48.000' AS DateTime), 1, N'192.168.1.26')
SET IDENTITY_INSERT [dbo].[AdminRole] OFF
GO
SET IDENTITY_INSERT [dbo].[Banner] ON

INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [BannerOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, NULL, NULL, NULL, N'初饌淬魚精', N'初饌淬魚精', N'初饌淬魚精', N'/upimg/202301161151461673841106016.jpg', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-02-04T15:38:25.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [BannerOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, NULL, NULL, NULL, N'初饌淬魚精慶開幕8折起', N'初饌淬魚精慶開幕8折起', N'初饌淬魚精慶開幕8折起', N'/upimg/202301161155171673841317942.jpg', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [BannerOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, NULL, NULL, NULL, N'永樂扶輪社', N'永樂扶輪社', N'永樂扶輪社', N'/upimg/202301161352211673848341493.jpg', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [BannerOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (4, NULL, NULL, NULL, N'過年特輯', N'過年特輯', N'過年特輯', N'/upimg/202301161402471673848967240.jpg', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[Banner] ([BannerNum], [Lang], [ProductClass], [BannerSort], [BannerTitle], [BannerDescription], [BannerContxt], [BannerImg1], [BannerImgUrl], [BannerImgAlt], [BannerPublish], [BannerPutTime], [BannerOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (5, NULL, NULL, NULL, N'兔年免運', N'兔年免運', N'&lt;s&gt;&lt;u&gt;&lt;em&gt;&lt;strong&gt;兔年免運&lt;/strong&gt;&lt;/em&gt;&lt;/u&gt;&lt;/s&gt;', N'/upimg/202301161403271673849007464.png', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-03-16T17:58:45.000' AS DateTime), 1, N'192.168.1.26')
SET IDENTITY_INSERT [dbo].[Banner] OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON

INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, N'test', N'0922123456', N'user@gmail.com', N'測試留言訊息', N'回覆用戶訊息', CAST(N'2023-01-16T12:00:00.000' AS DateTime), NULL, CAST(N'2023-02-04T18:34:31.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, N'edward', N'0912345678', N'xoxo@email.com.tw', N'ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?', N'&lt;table&gt;
	&lt;tbody&gt;
		&lt;tr&gt;
			&lt;td&gt;2&lt;/td&gt;
			&lt;td&gt;Edward&lt;/td&gt;
			&lt;td&gt;ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?&lt;/td&gt;
			&lt;td&gt;0912345678&lt;/td&gt;
			&lt;td&gt;a.cv4922@yahoo.com.tw&lt;/td&gt;
			&lt;td&gt;2023-01-16&nbsp;10:34:59.000&lt;/td&gt;
			&lt;td&gt;&nbsp;&lt;/td&gt;
			&lt;td&gt;&lt;em&gt;&lt;em&gt;●&lt;/em&gt;&lt;/em&gt;&lt;/td&gt;
		&lt;/tr&gt;
		&lt;tr&gt;
		&lt;/tr&gt;
	&lt;/tbody&gt;
&lt;/table&gt;', CAST(N'2023-01-16T12:00:00.000' AS DateTime), NULL, CAST(N'2023-01-16T12:30:00.000' AS DateTime), -1, N'172.16.1.200')
INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, N'ed', N'0912345678', N'xoxo@yahoo.com.tw', N'ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?', N'&lt;table&gt;
	&lt;tbody&gt;
		&lt;tr&gt;
			&lt;td&gt;3&lt;/td&gt;
			&lt;td&gt;Edward&lt;/td&gt;
			&lt;td&gt;ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?ooo...?&lt;/td&gt;
			&lt;td&gt;0912345678&lt;/td&gt;
			&lt;td&gt;a.cv4922@yahoo.com.tw&lt;/td&gt;
			&lt;td&gt;2023-10-16&nbsp;10:55:00.000&lt;/td&gt;
			&lt;td&gt;&nbsp;&lt;/td&gt;
			&lt;td&gt;&lt;em&gt;&lt;em&gt;●&lt;/em&gt;&lt;/em&gt;&lt;/td&gt;
		&lt;/tr&gt;
		&lt;tr&gt;
		&lt;/tr&gt;
	&lt;/tbody&gt;
&lt;/table&gt;', CAST(N'2023-01-16T12:00:00.000' AS DateTime), NULL, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 0, N'172.16.1.200')
INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (4, N'aaaaaa', N'0912345678', N'oxox@email.com.tw', N'aabbccddeeffgghhiijj', NULL, CAST(N'2023-01-16T12:00:00.000' AS DateTime), NULL, NULL, NULL, N'118.163.120.169')
INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (5, N'bbbbbb', N'0912345678', N'oxox@yahoo.com.tw', N'aabbccddeeffgghhiijj', NULL, CAST(N'2023-01-16T12:00:00.000' AS DateTime), NULL, NULL, NULL, N'118.163.120.169')
INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (6, N'Edward', N'0912345678', N'xoxo@email.com', N'詢問edtest', NULL, CAST(N'2023-03-03T18:56:49.000' AS DateTime), NULL, NULL, NULL, N'192.168.1.26')
INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (7, N'Edward', N'0912345678', N'xoxo@email.com', N'詢問edtest', NULL, CAST(N'2023-03-03T18:57:20.000' AS DateTime), NULL, NULL, NULL, N'192.168.1.26')
INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (8, N'Edward', N'0912345678', N'xoxo@email.com', N'詢問edtest', N'&lt;table&gt;
	&lt;tbody&gt;
		&lt;tr&gt;
			&lt;td&gt;8&lt;/td&gt;
			&lt;td&gt;Edward&lt;/td&gt;
			&lt;td&gt;詢問edtest&lt;/td&gt;
			&lt;td&gt;0912345678&lt;/td&gt;
			&lt;td&gt;xoxo@email.com&lt;/td&gt;
			&lt;td&gt;2023/03/03&nbsp;18:58:14&lt;/td&gt;
			&lt;td&gt;&nbsp;&lt;/td&gt;
			&lt;td&gt;&lt;em&gt;&lt;em&gt;●&lt;/em&gt;&lt;/em&gt;&lt;/td&gt;
		&lt;/tr&gt;
		&lt;tr&gt;
		&lt;/tr&gt;
	&lt;/tbody&gt;
&lt;/table&gt;', CAST(N'2023-03-03T18:58:14.000' AS DateTime), NULL, CAST(N'2023-03-03T18:58:47.000' AS DateTime), -1, N'192.168.1.26')
INSERT [dbo].[Contact] ([ContactNum], [ContactName], [ContactPhone], [ContactMail], [ContactTxt], [ContactReTxt], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (9, N'Edward', N'0912345678', N'xoxo@email.com', N'詢問edtest', NULL, CAST(N'2023-03-08T09:59:02.000' AS DateTime), NULL, NULL, NULL, N'192.168.1.26')
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[Member] ON

INSERT [dbo].[Member] ([MemberNum], [MemberAccount], [MemberPassword], [MemberName], [MemberPhone], [MemberEmail], [MemberPublish], [LastLogin], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, N'admin', N'e10adc3949ba59abbe56e057f20f883e', N'admin', N'0912345678', N'admin@obiz.com.tw', 1, CAST(N'2023-05-08T17:03:29.000' AS DateTime), CAST(N'2023-05-08T12:00:00.000' AS DateTime), 26, CAST(N'2023-05-08T12:30:00.000' AS DateTime), 1, N'192.168.1.26')
SET IDENTITY_INSERT [dbo].[Member] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuGroup] ON

INSERT [dbo].[MenuGroup] ([MenuGroupNum], [MenuGroupSort], [MenuGroupId], [MenuGroupName], [MenuGroupIcon], [MenuGroupInfo], [MenuGroupUrl], [MenuGroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, 1, N'A', N'帳號管理', N'fa-users', N'帳號管理', N'#', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuGroup] ([MenuGroupNum], [MenuGroupSort], [MenuGroupId], [MenuGroupName], [MenuGroupIcon], [MenuGroupInfo], [MenuGroupUrl], [MenuGroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, 2, N'B', N'廣告管理', N'fa-photo', N'廣告管理', N'#', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuGroup] ([MenuGroupNum], [MenuGroupSort], [MenuGroupId], [MenuGroupName], [MenuGroupIcon], [MenuGroupInfo], [MenuGroupUrl], [MenuGroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, 3, N'C', N'消息管理', N'fa-newspaper-o', N'消息管理', N'#', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuGroup] ([MenuGroupNum], [MenuGroupSort], [MenuGroupId], [MenuGroupName], [MenuGroupIcon], [MenuGroupInfo], [MenuGroupUrl], [MenuGroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (4, 4, N'D', N'產品管理', N'fa-gift', N'產品管理', N'#', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuGroup] ([MenuGroupNum], [MenuGroupSort], [MenuGroupId], [MenuGroupName], [MenuGroupIcon], [MenuGroupInfo], [MenuGroupUrl], [MenuGroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (5, 5, N'E', N'檔案下載', N'fa-mortar-board', N'檔案下載', N'#', 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuGroup] ([MenuGroupNum], [MenuGroupSort], [MenuGroupId], [MenuGroupName], [MenuGroupIcon], [MenuGroupInfo], [MenuGroupUrl], [MenuGroupPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (6, 6, N'F', N'聯絡我們', N'fa fa-envelope', N'連絡我們管理', N'#', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
SET IDENTITY_INSERT [dbo].[MenuGroup] OFF
GO
SET IDENTITY_INSERT [dbo].[MenuSub] ON

INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, N'A', 0, N'A01', N'帳號設定', N'V,L,N,M,D', NULL, NULL, N'/admin/users/list', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, N'A', 0, N'A02', N'群組設定', N'V,L,N,M,D', NULL, NULL, N'/admin/group/list', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, N'A', 0, N'A03', N'帳號修改', N'V,,,M,', NULL, NULL, N'/admin/users/indivi', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (4, N'B', 0, N'B02', N'廣告設定', N'V,L,N,M,D', NULL, NULL, N'/admin/banner/list', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (5, N'C', 0, N'C02', N'消息設定', N'V,L,N,M,D', NULL, NULL, N'/admin/news/list', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (6, N'C', 0, N'C01', N'消息類別', N'V,L,N,M,D', NULL, NULL, N'/admin/newsclass/list', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (7, N'D', 0, N'D02', N'產品設定', N'V,L,N,M,D', NULL, NULL, N'/admin/product/list', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (8, N'D', 0, N'D01', N'產品類別', N'V,L,N,M,D', NULL, NULL, N'/admin/productclass/list', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (9, N'E', 0, N'E02', N'檔案設定', N'V,L,N,M,D', NULL, NULL, N'/admin/download/list', 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (10, N'E', 0, N'E01', N'檔案類別', N'V,L,N,M,D', NULL, NULL, N'/admin/downloadclass/list', 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[MenuSub] ([MenuSubNum], [MenuGroupId], [MenuSubSort], [MenuSubId], [MenuSubName], [MenuSubRole], [MenuSubIcon], [MenuSubInfo], [MenuSubUrl], [MenuSubPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (11, N'F', 0, N'F02', N'聯絡我們', N'V,L,N,M,D', NULL, NULL, N'/admin/contact/list', 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
SET IDENTITY_INSERT [dbo].[MenuSub] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON

INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [NewsOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, NULL, 1, NULL, N'【知識】這幾種狀況，可能是缺乏蛋白質，如何補充我們教你！', N'魚精豐富營養 補充蛋白質', N'蛋白質是人體重要的組成成分之一，如果說人體的60%-70%是水，那蛋白質便占了20%，蛋白質是肌肉的組成關鍵，可以幫助肌肉的合成與組織修復，也能幫助人體維持生理基本功能運作，但我們如何知道自己是否需要補充蛋白質呢?以下幾種情況，是身體在向你發出警告，要提醒主人多補充蛋白質啦！&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;狀況一：免疫力下降&lt;/strong&gt;&lt;br /&gt;
蛋白質是形成抗體的主要成分，蛋白質不夠時，免疫力容易下降，被細菌病毒趁虛而入。&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;狀況二：傷口恢復困難&lt;/strong&gt;&lt;br /&gt;
身體出現傷口時，需要靠蛋白質加以合成，重建細胞、組織、皮膚，若蛋白質不足，可能會癒合的較慢，故許多術後患者都會需要多補充蛋白質。&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;狀況三：皮膚狀況不佳、指甲斷裂、髮質變差&lt;/strong&gt;&lt;br /&gt;
蛋白質不足也會顯化在我們的外觀上，皮膚失去彈性、光澤、頭髮枯黃掉落；甚或是指甲斷裂。&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;狀況四：肌肉無力、關節疼痛、骨頭脆弱&lt;/strong&gt;&lt;br /&gt;
人體缺乏蛋白質容易導致肌肉質量下降(所以很多運動健身愛好者，會時常補充乳清蛋白)缺乏蛋白質的化，軟骨與關節間也容易因摩擦而疼痛。&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;狀況五：容易感到飢餓&lt;/strong&gt;&lt;br /&gt;
身體缺乏蛋白質，容易感到飢餓，就算攝取高熱量的食物，但蛋白質不足也沒有太大用處，反而徒增肥肉，補足足夠蛋白質，產生飽足感，便有助控制體重。&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;狀況六：頭腦昏沉、反應能力下降&lt;/strong&gt;&lt;br /&gt;
無法長時間集中注意力、腦袋經常感到昏沉，影響反映判斷能力的下降，也可能是蛋白質攝取不足的緣故。&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;狀況七：水腫&lt;/strong&gt;&lt;br /&gt;
血液中的白蛋白能把水分留在血管，避免水腫，一旦蛋白質不夠時，水分就會累積在組織內，導致肚子小腿浮腫。&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;優質蛋白質從何而來?&lt;/strong&gt;&lt;br /&gt;
大豆、魚肉、雞胸肉、瘦牛豬雞肉、鴨肉、蝦、奇亞籽、雞蛋，都是攝取優質蛋白質的好選擇，隨時留意身體狀況，適度補充蛋白質，同時提升工作效率、維持身體健康，初饌關心您。', N'/upimg/202301161420521673850052428.jpg', NULL, NULL, 1, 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [NewsOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, NULL, 2, NULL, N'【海鮮冬粉煲】鮮香下飯！全家人都愛的海鮮料理', N'魚精入菜 海鮮冬粉煲', N'&nbsp;&lt;br /&gt;
新廚房料理神器！一包提鮮，營養美味一次滿足！&lt;br /&gt;
滴精類型的保健食品還能怎麼吃?『魚精』光聽就腥，不敢喝怎麼辦?!&lt;br /&gt;
把魚精加入海鮮料理讓味道更鮮更美味吧~&lt;br /&gt;
香氣四溢又簡單容易製作的美味【海鮮豆腐煲】，立刻跟小編一起動手做&lt;br /&gt;
保證大人小朋友都搶著暴風吸入的驚艷美食這樣做！&lt;br /&gt;
&lt;br /&gt;
【食材準備】6人份&lt;br /&gt;
初饌淬魚精6包/冬粉6份/蝦10尾/金目鱸魚1尾/蛤蜊20顆/白精靈菇適量/玉米筍一小盒&lt;br /&gt;
大干貝6顆/芹菜2根/蔥1根/蒜4瓣&lt;br /&gt;
【調味料】&lt;br /&gt;
鹽適量/白胡椒適量/蠔油20ml/醬油20ml/米酒30ml&lt;br /&gt;
【烹調辦法】&lt;br /&gt;
1.&nbsp;將冬粉泡水，泡軟後剪成小段好入口&lt;br /&gt;
2.&nbsp;將蝦子與蝦頭分離&lt;br /&gt;
3.&nbsp;放入適量油，將蝦子下鍋煎至紅色&lt;br /&gt;
4.&nbsp;將蝦頭放入鍋中，將蝦膏逼出，煎至可聞到蝦香&lt;br /&gt;
5.&nbsp;把拍碎後的蒜末與段蔥丟入，與蝦頭一起炒&lt;br /&gt;
&gt;&gt;&gt;可依喜好加入辣椒(有小朋友可以不加)&lt;br /&gt;
6.&nbsp;接著倒入魚精與水，水量要能覆蓋食材，待其煮滾，滾後將雜質撈出&lt;br /&gt;
7.&nbsp;另外準備一個鍋子，將玉米筍、白精靈菇再將泡軟的冬粉瀝乾後放入鍋中&lt;br /&gt;
8.&nbsp;將剛剛煮滾的鮮美湯頭倒入，加上蠔油、鹽、白胡椒調味&lt;br /&gt;
9.&nbsp;再將鱸魚片放入，上方擺上煎的半熟的蝦子，開大火煮滾，滾後轉小火&nbsp;悶10分鐘&lt;br /&gt;
(※期間須注意底部避免黏鍋，可以適度晃動鍋身。)&lt;br /&gt;
10.&nbsp;10分鐘後放上大干貝、蛤蜊，再悶煮5分鐘，直至蛤蜊都開了，最後撒上蔥末、芹菜末、大辣椒(可放可不放)悶蓋一分鐘即可起鍋。&lt;br /&gt;
&lt;br /&gt;
美味又下飯的海鮮冬粉煲就完成啦~加入魚精提味，可以讓海鮮的鮮甜更濃郁，吸附滿滿湯汁的冬粉，把營養美味都滴滴鎖住，害怕直接喝魚精的人，一樣可以透過入菜，幫全家人把營養補好補滿。', N'/upimg/202301161422371673850157115.jpg', NULL, NULL, 1, 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [NewsOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, NULL, 1, NULL, N'【知識】魚隻營養成分PK台灣鯛、虱目魚、鱸魚', N'魚隻營養成分PK 台灣鯛、虱目魚、鱸魚', N'術後調理或是孕期前後，在我們華人社會裡都習慣通過飲用燉湯來滋補養身&lt;br /&gt;
過去我們比較常聽到的便是鱸魚湯，家長也習慣燉補雞湯、魚湯為成長中的小朋友添補元氣跟營養，但是為什麼初饌會選用台灣鯛來製作魚精呢?&lt;br /&gt;
顛覆你對台灣鯛的營養認知，超營養高CP值得國民魚，讓我們一起通過衛服部食品營養資料庫的資料一探究竟!&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
&lt;strong&gt;#營養國民魚，優質蛋白質x豐富牛磺酸!鈣比雞多7倍&lt;/strong&gt;&lt;br /&gt;
擁有優質蛋白質、天然魚膠原蛋白以及豐富牛磺酸，台灣鯛強壯健康充滿精力的特性也能幫助食用者增加活力來源，初饌將其通過高溫萃取成一包包魚精後，液體濃縮營養的特性，營養密度高不佔胃，尤其適合術後及養胎、做月子時飲用，補充關鍵營養！鮮甜味美的初饌淬魚精，隨開即飲也可以加熱飲用，省去燉補魚湯的麻煩，輕鬆補充高營養。', N'/upimg/202301161423261673850206220.jpg', NULL, NULL, 1, 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [NewsOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (4, NULL, 2, NULL, N'【海鮮味噌湯】鯛魚精入菜．這樣煮最鮮甜的味噌鮮魚湯', N'鯛魚精入菜．鮮甜的味噌鮮魚湯', N'以往對味噌湯的印象都只有死鹹&lt;br /&gt;
最多加上海帶跟豆腐，口感毫無美味可言&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
今天我們就以#台灣鯛魚精粹入菜&lt;br /&gt;
讓鯛魚精的鮮味結合味噌做出一道完美的鮮魚湯&lt;br /&gt;
滿滿的營養美味，除了大人愛喝，小孩也愛不釋手唷&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
【食材準備】：&lt;br /&gt;
初饌淬魚精、味噌、海帶、蔥花、豆腐、鮮魚(可加可不加)&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
【烹調辦法】&lt;br /&gt;
步驟一：如有鮮魚，可先將其稍微煸炒釋出油脂&lt;br /&gt;
步驟二：將鍋內放入七分滿的水，並把泡軟的海帶及鮮魚放入鍋內，加入一包#初饌淬魚精&lt;br /&gt;
步驟三：加入適量的味噌（依個人喜好）&lt;br /&gt;
步驟四：燉煮約20分鐘後加入少許鹽巴調味&lt;br /&gt;
步驟五：加入豆腐&lt;br /&gt;
步驟六：攪拌約2-5分鐘，將鍋底味噌均勻攪散&lt;br /&gt;
步驟七：最後放上蔥花點綴即可完成！&lt;br /&gt;
&lt;br /&gt;
&lt;br /&gt;
趕快來用簡單的食材把美味送上桌吧❤', N'/upimg/202301161436471673851007183.jpg', NULL, NULL, 1, 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[News] ([NewsNum], [Lang], [NewsClass], [NewsSort], [NewsTitle], [NewsDescription], [NewsContxt], [NewsImg1], [NewsImgUrl], [NewsImgAlt], [NewsPublish], [NewsViews], [NewsPutTime], [NewsOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (5, NULL, 1, NULL, N'【知識】雞精魚精差在哪?選擇最適合你的營養補充！', N'雞精魚精差在哪', N'&lt;p&gt;&lt;strong&gt;&lt;u&gt;#養生新選．100%完整的全魚精華&lt;/u&gt;&lt;/strong&gt;&lt;/p&gt;
大部分人一定聽過雞精，也可以將雞精很直覺得與健康、營養保健相連，但是對於近期市面上越來越廣泛出現的『魚精』則仍相當陌生，實際上魚精和雞精一樣含有相當豐富的優質蛋白質、膠原蛋白、牛磺酸及其他多種胺基酸，能夠補充身體所需的關鍵營養；其次在魚隻本身與雞隻本身的差異外，魚隻還多了雞所沒有的DHA、EPA等維生素，看準魚隻不輸雞隻的高營養，市場上逐漸有了魚精的出現，不用親自料理整隻魚去獲得營養，可以快速且方便的讓現代人隨開即飲，隨時為身體補充能量。&lt;br /&gt;
&lt;br /&gt;
&nbsp;
&lt;p&gt;&lt;strong&gt;&lt;u&gt;營養價值高．根據自身狀況選擇自己適合的進補方式&lt;/u&gt;&lt;/strong&gt;&lt;/p&gt;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;在滴精類型產品都含有豐富蛋白質、胺基酸的前題下，針對大部分人作為日常營養保健的選擇，都是相當不錯的。&lt;br /&gt;
但要特別注意！補品可不是都適合每個人，魚精和雞精由於根本性質上的差異，魚精在補充營養時，更能降低越補越燥熱的狀況，相對適合更廣泛的族群作為進補首選，如：『術後調理、孕期前後/哺乳期的媽咪族群、樂齡長輩抑或是發育時期的兒童/青少年、身負各種疲勞壓力上班族』都相當合適，尤其針對部分手術前後患者胃口低落，但又需要透過進食補充營養所需時，尤為合適。&lt;br /&gt;
但若本身屬於虛寒、氣虛體質的人在選擇保健補品時，雞精可能就會更加合適。總而言之，魚精屬於老少咸宜，針對多種調理狀況都相當合適的保健食品選擇，但在選擇購買時，還是可以根據不同的體質，選擇更合適的食補方式。', N'/upimg/202301161438151673851095007.jpg', NULL, NULL, 1, 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-02-23T18:10:31.000' AS DateTime), 1, N'192.168.1.26')
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[NewsClass] ON

INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, 0, N'0', N'最新消息', 1, 0, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, 0, N'1', N'好初食堂', 2, 1, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-02-14T13:43:04.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, 0, N'1,2', N'好評推薦', 3, 2, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-02-04T15:42:54.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (7, 0, N'1,2,3', N'最新消息2', 4, 3, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (8, 0, N'1,2,3,7', N'好初食堂2', 5, 7, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (9, 1, N'1,2,3,7,8', N'好評推薦2.1', 6, 8, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-03-03T18:31:50.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (12, 0, N'1,2,3,7,8', N'好評推薦2.2', 6, 8, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-03-03T18:31:50.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (13, 0, N'1,2,3,7,8,9', N'好評推薦2.1.1', 7, 9, 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-03-03T18:31:50.000' AS DateTime), 1, N'192.168.1.26')
INSERT [dbo].[NewsClass] ([NewsClassNum], [NewsClassSort], [NewsClassId], [NewsClassName], [NewsClassLevel], [NewsClassPre], [NewsClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (14, 0, N'1,2,3,7,8,12', N'好評推薦2.2.1', 7, 12, 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-03-03T18:31:50.000' AS DateTime), 1, N'192.168.1.26')
SET IDENTITY_INSERT [dbo].[NewsClass] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON

INSERT [dbo].[Product] ([ProductNum], [Lang], [ProductClass], [ProductSort], [ProductDepartment], [ProductId], [ProductTitle], [ProductDescription], [ProductContxt], [ProductImg1], [ProductImgUrl], [ProductImgAlt], [ProductImgList], [ProductImgListAlt], [ProductVideo1], [ProductPublish], [ProductPutTime], [ProductOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, NULL, 2, NULL, NULL, NULL, N'初饌淬魚精 貼心禮盒5包入', N'初饌淬魚精5包入', N'&lt;ul&gt;
	&lt;li&gt;慢火精煉．全魚精淬&lt;/li&gt;
	&lt;li&gt;無人工添加物&lt;/li&gt;
	&lt;li&gt;低負擔．高營養&lt;/li&gt;
	&lt;li&gt;容量：50毫升/包，共5包&lt;/li&gt;
	&lt;li&gt;產地：台灣花蓮&lt;/li&gt;
	&lt;li&gt;保存方法：常溫保存，避免陽光直射&lt;/li&gt;
	&lt;li&gt;保存期限：24個月&lt;/li&gt;
&lt;/ul&gt;', NULL, NULL, NULL, N'/upimg/202301161526091673853969446.jpg,/upimg/202301161526091673853969223.jpg,/upimg/202301161526091673853969076.jpg', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[Product] ([ProductNum], [Lang], [ProductClass], [ProductSort], [ProductDepartment], [ProductId], [ProductTitle], [ProductDescription], [ProductContxt], [ProductImg1], [ProductImgUrl], [ProductImgAlt], [ProductImgList], [ProductImgListAlt], [ProductVideo1], [ProductPublish], [ProductPutTime], [ProductOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, NULL, 2, NULL, NULL, NULL, N'初饌淬魚精 寵愛禮盒7包入', N'初饌淬魚精7包入', N'&lt;ul&gt;
	&lt;li&gt;慢火精煉．全魚精淬&lt;/li&gt;
	&lt;li&gt;無人工添加物&lt;/li&gt;
	&lt;li&gt;低負擔．高營養&lt;/li&gt;
	&lt;li&gt;容量：50毫升/包，共7包&lt;/li&gt;
	&lt;li&gt;產地：台灣花蓮&lt;/li&gt;
	&lt;li&gt;保存方法：常溫保存，避免陽光直射&lt;/li&gt;
	&lt;li&gt;保存期限：12個月&lt;/li&gt;
&lt;/ul&gt;', NULL, NULL, NULL, N'/upimg/202301161535341673854534802.jpg,/upimg/202301161535341673854534951.jpg,/upimg/202301161535351673854535176.jpg', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[Product] ([ProductNum], [Lang], [ProductClass], [ProductSort], [ProductDepartment], [ProductId], [ProductTitle], [ProductDescription], [ProductContxt], [ProductImg1], [ProductImgUrl], [ProductImgAlt], [ProductImgList], [ProductImgListAlt], [ProductVideo1], [ProductPublish], [ProductPutTime], [ProductOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, NULL, 2, NULL, NULL, NULL, N'初饌淬魚精環保包裝組(30包入裝)', N'初饌淬魚精環保包裝組(30包入裝)', N'&lt;ul&gt;
	&lt;li&gt;慢火精煉．全魚精淬&lt;/li&gt;
	&lt;li&gt;無人工添加物&lt;/li&gt;
	&lt;li&gt;低負擔．高營養&lt;/li&gt;
	&lt;li&gt;容量：50毫升/包，共30包&lt;/li&gt;
	&lt;li&gt;產地：台灣花蓮&lt;/li&gt;
	&lt;li&gt;保存方法：常溫保存，避免陽光直射&lt;/li&gt;
	&lt;li&gt;保存期限：12個月&lt;/li&gt;
&lt;/ul&gt;', NULL, NULL, NULL, N'/upimg/202301161537211673854641645.jpg,/upimg/202301161537211673854641792.jpg', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[Product] ([ProductNum], [Lang], [ProductClass], [ProductSort], [ProductDepartment], [ProductId], [ProductTitle], [ProductDescription], [ProductContxt], [ProductImg1], [ProductImgUrl], [ProductImgAlt], [ProductImgList], [ProductImgListAlt], [ProductVideo1], [ProductPublish], [ProductPutTime], [ProductOffTime], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (4, NULL, 2, NULL, NULL, NULL, N'初饌淬魚精環保包裝組(60包入裝)', N'初饌淬魚精環保包裝組(60包入裝)', N'&lt;ul&gt;
	&lt;li&gt;慢火精煉．全魚精淬&lt;/li&gt;
	&lt;li&gt;無人工添加物&lt;/li&gt;
	&lt;li&gt;低負擔．高營養&lt;/li&gt;
	&lt;li&gt;容量：50毫升/包，共60包&lt;/li&gt;
	&lt;li&gt;產地：台灣花蓮&lt;/li&gt;
	&lt;li&gt;保存方法：常溫保存，避免陽光直射&lt;/li&gt;
	&lt;li&gt;保存期限：24個月&lt;/li&gt;
&lt;/ul&gt;', NULL, NULL, NULL, N'/upimg/202301161540281673854828308.jpg,/upimg/202301161540341673854834957.jpg', NULL, NULL, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), CAST(N'2053-01-01T00:00:00.000' AS DateTime), CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-03-22T10:27:19.000' AS DateTime), 1, N'192.168.1.26')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductClass] ON

INSERT [dbo].[ProductClass] ([ProductClassNum], [ProductClassSort], [ProductClassId], [ProductClassName], [ProductClassLevel], [ProductClassPre], [ProductClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (1, 0, N'0', N'初饌魚精old', 1, 0, 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-02-08T10:26:23.000' AS DateTime), 6, N'192.168.1.26')
INSERT [dbo].[ProductClass] ([ProductClassNum], [ProductClassSort], [ProductClassId], [ProductClassName], [ProductClassLevel], [ProductClassPre], [ProductClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (2, 1, N'0', N'初饌魚精', 1, 0, 1, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[ProductClass] ([ProductClassNum], [ProductClassSort], [ProductClassId], [ProductClassName], [ProductClassLevel], [ProductClassPre], [ProductClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (3, 2, N'0', N'永樂扶輪社', 1, 0, 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[ProductClass] ([ProductClassNum], [ProductClassSort], [ProductClassId], [ProductClassName], [ProductClassLevel], [ProductClassPre], [ProductClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (4, 3, N'0', N'思佳專屬賣場', 1, 0, 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
INSERT [dbo].[ProductClass] ([ProductClassNum], [ProductClassSort], [ProductClassId], [ProductClassName], [ProductClassLevel], [ProductClassPre], [ProductClassPublish], [CreateTime], [Creator], [EditTime], [Editor], [IP]) VALUES (5, 4, N'0', N'Paul與咪咪的專屬賣場', 1, 0, 0, CAST(N'2023-01-16T12:00:00.000' AS DateTime), 1, CAST(N'2023-01-16T12:30:00.000' AS DateTime), 1, N'192.168.1.34')
SET IDENTITY_INSERT [dbo].[ProductClass] OFF
GO
ALTER TABLE [dbo].[Admin] ADD  CONSTRAINT [DF_Admin_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[AdminGroup] ADD  CONSTRAINT [DF_LoginGroup_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[AdminRole] ADD  CONSTRAINT [DF_LoginRole_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[Member] ADD  CONSTRAINT [DF_Member_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[MenuGroup] ADD  CONSTRAINT [DF_MenuGroup_MenuGroupSort]  DEFAULT ((0)) FOR [MenuGroupSort]
GO
ALTER TABLE [dbo].[MenuGroup] ADD  CONSTRAINT [DF_MenuGroup_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[MenuSub] ADD  CONSTRAINT [DF_MenuSub_MenuSubSort]  DEFAULT ((0)) FOR [MenuSubSort]
GO
ALTER TABLE [dbo].[MenuSub] ADD  CONSTRAINT [DF_MenuSub_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_NewsViews]  DEFAULT ((0)) FOR [NewsViews]
GO
ALTER TABLE [dbo].[News] ADD  CONSTRAINT [DF_News_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Banner', @level2type=N'COLUMN',@level2name=N'BannerContxt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Contact', @level2type=N'COLUMN',@level2name=N'ContactReTxt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsClass'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsSort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsTitle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsContxt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsImg1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsImgUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsImgAlt'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsPublish'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsPutTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'NewsOffTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'Editor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'News', @level2type=N'COLUMN',@level2name=N'IP'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'ProductImgUrl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Product', @level2type=N'COLUMN',@level2name=N'ProductImgAlt'
GO
