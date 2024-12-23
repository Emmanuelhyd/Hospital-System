--USE [Hospital]
--GO
--/****** Object:  Table [dbo].[Ward]    Script Date: 13/9/2024 9:06:54 pm ******/
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ward]') AND type in (N'U'))
--DROP TABLE [dbo].[Ward]
--GO
--/****** Object:  Table [dbo].[Registration]    Script Date: 13/9/2024 9:06:54 pm ******/
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Registration]') AND type in (N'U'))
--DROP TABLE [dbo].[Registration]
--GO
--/****** Object:  Table [dbo].[Prec]    Script Date: 13/9/2024 9:06:54 pm ******/
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Prec]') AND type in (N'U'))
--DROP TABLE [dbo].[Prec]
--GO
--/****** Object:  Table [dbo].[BookApp]    Script Date: 13/9/2024 9:06:54 pm ******/
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BookApp]') AND type in (N'U'))
--DROP TABLE [dbo].[BookApp]
--GO
--/****** Object:  Table [dbo].[Appointment]    Script Date: 13/9/2024 9:06:54 pm ******/
--IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Appointment]') AND type in (N'U'))
--DROP TABLE [dbo].[Appointment]
--GO
--/****** Object:  Table [dbo].[Appointment]    Script Date: 13/9/2024 9:06:54 pm ******/
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
CREATE TABLE [dbo].[Appointment](
	[DoctorName] [varchar](50) NULL,
	[Speciality] [varchar](50) NULL,
	[Education] [varchar](50) NULL,
	[Timings] [varchar](50) NULL,
	[Status] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BookApp]    Script Date: 13/9/2024 9:06:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookApp](
	[PatientName] [varchar](50) NULL,
	[PatientType] [varchar](50) NULL,
	[Problem] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Date] [varchar](50) NULL,
	[Time] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Prec]    Script Date: 13/9/2024 9:06:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prec](
	[PatientName] [varchar](50) NULL,
	[DoctorName] [varchar](50) NULL,
	[Problem] [varchar](50) NULL,
	[Medicine] [varchar](50) NULL,
	[Morning] [varchar](50) NULL,
	[Afternoon] [varchar](50) NULL,
	[Night] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 13/9/2024 9:06:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registration](
	[UserName] [varchar](50) NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Gender] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ward]    Script Date: 13/9/2024 9:06:54 pm ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ward](
	[Id] [int] NULL,
	[Name] [varchar](50) NULL,
	[Department] [varchar](50) NULL,
	[Designation] [varchar](50) NULL,
	[Education] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[Status] [varchar](50) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Appointment] ([DoctorName], [Speciality], [Education], [Timings], [Status]) VALUES (N'Anand', N'Cardio', N'MBBS', N'10Am-5Pm', N'Active')
INSERT [dbo].[Appointment] ([DoctorName], [Speciality], [Education], [Timings], [Status]) VALUES (N'Arun', N'Neuro', N'MBBS', N'10Am-5Pm', N'Active')
GO
INSERT [dbo].[BookApp] ([PatientName], [PatientType], [Problem], [PhoneNumber], [Address], [Date], [Time]) VALUES (N'nnn', N'jjjah', N'kjjshsh', N'khjskjh', N'jlksh', N'hkhsh', N'hkh')
INSERT [dbo].[BookApp] ([PatientName], [PatientType], [Problem], [PhoneNumber], [Address], [Date], [Time]) VALUES (N'srrr', N'jjjah', N'kjjshsh', N'khjskjh', N'jlksh', N'hkhsh', N'hkh')
INSERT [dbo].[BookApp] ([PatientName], [PatientType], [Problem], [PhoneNumber], [Address], [Date], [Time]) VALUES (N'nnn', N'jjjah', N'kjjshsh', N'08978568838', N'jlksh', N'hkhsh', N'hkh')
INSERT [dbo].[BookApp] ([PatientName], [PatientType], [Problem], [PhoneNumber], [Address], [Date], [Time]) VALUES (N'', N'', N'', N'', N'', N'', N'')
GO
INSERT [dbo].[Prec] ([PatientName], [DoctorName], [Problem], [Medicine], [Morning], [Afternoon], [Night]) VALUES (N'jack', N'sagar', N'fever', N'dolo', N'yes', N'yes', N'yes')
INSERT [dbo].[Prec] ([PatientName], [DoctorName], [Problem], [Medicine], [Morning], [Afternoon], [Night]) VALUES (N'jack', N'sagar', N'fever', N'dolo', N'yes', N'no', N'no')
GO
INSERT [dbo].[Registration] ([UserName], [FirstName], [LastName], [Password], [Email], [PhoneNumber], [Gender]) VALUES (N'Anand sagar', N'anand', N'sagar', N'badboy@123', N'anandasagar@iitsofttech.com', N'08978568838', N'M')
INSERT [dbo].[Registration] ([UserName], [FirstName], [LastName], [Password], [Email], [PhoneNumber], [Gender]) VALUES (N'anand', N'mb', N'sri', N'kjh', N'anandasagar@iitsofttech.com', N'08978568838', N'male')
INSERT [dbo].[Registration] ([UserName], [FirstName], [LastName], [Password], [Email], [PhoneNumber], [Gender]) VALUES (N'Anand sagar Matta', N'anand', N' sagar', N'anand@123', N'anandasagar@iitsofttech.com', N'9182225321', N'male')
GO
INSERT [dbo].[Ward] ([Id], [Name], [Department], [Designation], [Education], [PhoneNumber], [Gender], [Status]) VALUES (1, N'mb sri', N'cardio', N'hhh', N'bn', N'0000', N'rr', N'act')
INSERT [dbo].[Ward] ([Id], [Name], [Department], [Designation], [Education], [PhoneNumber], [Gender], [Status]) VALUES (2, N'sagar', N'cardio', N'hhh', N'bn', N'08978568838', N'm', N'uy')
INSERT [dbo].[Ward] ([Id], [Name], [Department], [Designation], [Education], [PhoneNumber], [Gender], [Status]) VALUES (3, N'sagar', N'cardio', N'hhh', N'bn', N'08978568838', N'm', N'uy')
INSERT [dbo].[Ward] ([Id], [Name], [Department], [Designation], [Education], [PhoneNumber], [Gender], [Status]) VALUES (4, N'mb sri', N'w', N'hhh', N'bn', N'08978568838', N'm', N'AAAA')
INSERT [dbo].[Ward] ([Id], [Name], [Department], [Designation], [Education], [PhoneNumber], [Gender], [Status]) VALUES (11, N'arun', N'cardio', N'hhh', N's', N'09182225321', N'male', N'opp')
GO
