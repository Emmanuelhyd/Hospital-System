USE [Hospital]
GO
ALTER TABLE [dbo].[profiles] DROP CONSTRAINT [fk7]
GO
ALTER TABLE [dbo].[patient] DROP CONSTRAINT [foreignkey]
GO
ALTER TABLE [dbo].[modifiers] DROP CONSTRAINT [FK__modifiers__Servi__5BE2A6F2]
GO
ALTER TABLE [dbo].[MedicineAd] DROP CONSTRAINT [fk]
GO
/****** Object:  Table [dbo].[Ward]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Ward]
GO
/****** Object:  Table [dbo].[VisitTypes]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[VisitTypes]
GO
/****** Object:  Table [dbo].[vaccine]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[vaccine]
GO
/****** Object:  Table [dbo].[Usertypes]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Usertypes]
GO
/****** Object:  Table [dbo].[Userroles]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Userroles]
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[UserInfo]
GO
/****** Object:  Table [dbo].[SupportTickets]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[SupportTickets]
GO
/****** Object:  Table [dbo].[SheduleAd]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[SheduleAd]
GO
/****** Object:  Table [dbo].[ShedleAd]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[ShedleAd]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Service]
GO
/****** Object:  Table [dbo].[report]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[report]
GO
/****** Object:  Table [dbo].[RejectedDonors]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[RejectedDonors]
GO
/****** Object:  Table [dbo].[RejectedBloodRequests]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[RejectedBloodRequests]
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Registration]
GO
/****** Object:  Table [dbo].[profiles]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[profiles]
GO
/****** Object:  Table [dbo].[Prec]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Prec]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Payments]
GO
/****** Object:  Table [dbo].[patients]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[patients]
GO
/****** Object:  Table [dbo].[patientinfo]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[patientinfo]
GO
/****** Object:  Table [dbo].[PatientAd]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[PatientAd]
GO
/****** Object:  Table [dbo].[patient]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[patient]
GO
/****** Object:  Table [dbo].[Nurse]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Nurse]
GO
/****** Object:  Table [dbo].[modifiers]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[modifiers]
GO
/****** Object:  Table [dbo].[menu]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[menu]
GO
/****** Object:  Table [dbo].[MedicineAd]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[MedicineAd]
GO
/****** Object:  Table [dbo].[medicine]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[medicine]
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[invoices]
GO
/****** Object:  Table [dbo].[Insurance]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Insurance]
GO
/****** Object:  Table [dbo].[Inpatient]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Inpatient]
GO
/****** Object:  Table [dbo].[hsptl]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[hsptl]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Feedback]
GO
/****** Object:  Table [dbo].[Email]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Email]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Drivers]
GO
/****** Object:  Table [dbo].[driver]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[driver]
GO
/****** Object:  Table [dbo].[donorinfo]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[donorinfo]
GO
/****** Object:  Table [dbo].[doctortimeslots]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[doctortimeslots]
GO
/****** Object:  Table [dbo].[doctors]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[doctors]
GO
/****** Object:  Table [dbo].[discharge]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[discharge]
GO
/****** Object:  Table [dbo].[detailsoffamilyrelatives]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[detailsoffamilyrelatives]
GO
/****** Object:  Table [dbo].[DepartmentAd]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[DepartmentAd]
GO
/****** Object:  Table [dbo].[department]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[department]
GO
/****** Object:  Table [dbo].[complaints]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[complaints]
GO
/****** Object:  Table [dbo].[bookapp]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[bookapp]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Bill]
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Attendance]
GO
/****** Object:  Table [dbo].[ApproveBloodRequests]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[ApproveBloodRequests]
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Appointments]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Appointment]
GO
/****** Object:  Table [dbo].[AnnouncementAd]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[AnnouncementAd]
GO
/****** Object:  Table [dbo].[Ambulances]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Ambulances]
GO
/****** Object:  Table [dbo].[AmbulanceAd]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[AmbulanceAd]
GO
/****** Object:  Table [dbo].[Ambulance]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Ambulance]
GO
/****** Object:  Table [dbo].[Amb]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[Amb]
GO
/****** Object:  Table [dbo].[AdminMenu]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP TABLE [dbo].[AdminMenu]
GO
/****** Object:  StoredProcedure [dbo].[getmanage]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP PROCEDURE [dbo].[getmanage]
GO
/****** Object:  StoredProcedure [dbo].[Addprofile]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP PROCEDURE [dbo].[Addprofile]
GO
/****** Object:  StoredProcedure [dbo].[addmanage]    Script Date: 11/23/2024 10:19:29 PM ******/
DROP PROCEDURE [dbo].[addmanage]
GO
/****** Object:  StoredProcedure [dbo].[addmanage]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[addmanage]
	(@UserName varchar(30),
	@Password varchar(40))
AS
BEGIN
	SET NOCOUNT ON;

    -- Return 1 if the user exists, else return 0
    IF EXISTS (
        SELECT 1
        FROM dbo.manage
        WHERE UserName = @UserName AND Password = @Password
    )
    BEGIN
        SELECT 1 AS ValidUser;
    END
    ELSE
    BEGIN
        SELECT 0 AS ValidUser;
    END

   
END

GO
/****** Object:  StoredProcedure [dbo].[Addprofile]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE[dbo].[Addprofile]
( @Firstname varchar(40),
@LastName varchar(40),
@Email varchar(30),
@Password varchar(40),
@BloodGroup varchar(30),
@Gender varchar(30),
@Age varchar(30),
@PhoneNo varchar(30),
@Address varchar(30),
@EmergencyContact varchar(30))
	
AS
BEGIN
	 IF EXISTS (
        SELECT 1
        FROM profile
        WHERE Email = @Email)
		BEGIN
		
		Update profile 
        SET Firstname = @Firstname,
            LastName = @LastName,
            Password = @Password,
            BloodGroup = @BloodGroup,
            Gender = @Gender,
            Age = @Age,
            PhoneNo = @PhoneNo,
            Address = @Address,
            EmergencyContact = @EmergencyContact
        WHERE Email = @Email;
        END
		Else
		Begin

		 INSERT INTO Profile (Firstname, LastName, Email, Password, BloodGroup, Gender, Age, PhoneNo, Address, EmergencyContact)
        VALUES (@Firstname, @LastName, @Email, @Password, @BloodGroup, @Gender, @Age, @PhoneNo, @Address, @EmergencyContact);

		End  
   
END

GO
/****** Object:  StoredProcedure [dbo].[getmanage]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getmanage]
(

@Username varchar(30),
@Password varchar(30))

	
AS
BEGIN

	insert into manage(UserName,Password) values(@Username,@Password)

END

GO
/****** Object:  Table [dbo].[AdminMenu]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminMenu](
	[Id] [int] NOT NULL,
	[Name] [varchar](70) NULL,
	[Url] [varchar](200) NULL,
	[ParentId] [int] NULL,
	[Isactive] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Amb]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Amb](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[AmbulanceId] [varchar](50) NULL,
	[AmbulanceStatus] [varchar](50) NULL,
	[DriverName] [varchar](50) NULL,
	[DriverId] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ambulance]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ambulance](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[AmbulanceId] [int] NULL,
	[AmbulanceStatus] [varchar](50) NULL,
	[DriverName] [varchar](50) NULL,
	[DriverId] [int] NULL,
	[Contact] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[CNIC] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AmbulanceAd]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AmbulanceAd](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[AmbulanceId] [int] NULL,
	[AmbulanceStatus] [varchar](50) NULL,
	[AmbulanceDriver] [varchar](50) NULL,
	[AmbulanceDriverId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ambulances]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ambulances](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[AmbulanceId] [varchar](50) NULL,
	[AmbulanceStatus] [varchar](50) NULL,
	[DriverName] [varchar](50) NULL,
	[DriverId] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AnnouncementAd]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AnnouncementAd](
	[Id] [int] NOT NULL,
	[Announcement] [varchar](50) NULL,
	[AnnouncementFor] [varchar](50) NULL,
	[EndDate] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Appointment](
	[DoctorName] [varchar](50) NULL,
	[Speciality] [varchar](50) NULL,
	[Education] [varchar](50) NULL,
	[Timings] [varchar](50) NULL,
	[Status] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Appointments]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NOT NULL,
	[DoctorId] [int] NOT NULL,
	[AppointmentDate] [date] NULL,
	[Problem] [nvarchar](500) NULL,
	[Status] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ApproveBloodRequests]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ApproveBloodRequests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[EmailId] [varchar](100) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[BloodGroup] [varchar](50) NULL,
	[Quantity] [varchar](50) NULL,
	[Decease] [varchar](50) NULL,
	[StreetAddress] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[ZipCode] [varchar](40) NULL,
	[Country] [varchar](40) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Attendance]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Attendance](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Department] [varchar](50) NULL,
	[JobTitle] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[Shift] [varchar](50) NULL,
	[Time] [varchar](50) NULL,
	[LoginTime] [varchar](50) NULL,
	[LogoutTime] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Bill](
	[PatientId] [int] NOT NULL,
	[PatientName] [varchar](100) NULL,
	[Problem] [varchar](50) NULL,
	[BillingDate] [varchar](100) NULL,
	[DoctorFee] [decimal](18, 0) NULL,
	[TreatmentDuration] [int] NULL,
	[TreatmentCharges] [decimal](18, 0) NULL,
	[MedicineCharges] [decimal](18, 0) NULL,
	[RoomFee] [decimal](18, 0) NULL,
	[Others] [varchar](100) NULL,
	[OthersCost] [decimal](18, 0) NULL,
	[TotalBill] [decimal](18, 0) NULL,
	[GST] [decimal](18, 0) NULL,
	[TotalAmount] [decimal](18, 0) NULL,
	[InsuranceClaimed] [decimal](18, 0) NULL,
	[PaidBill] [decimal](18, 0) NULL,
	[Status] [varchar](40) NULL,
	[MethodOfPayment] [varchar](100) NULL,
	[BalanceAmount] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bookapp]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bookapp](
	[Id] [int] NOT NULL,
	[PatientName] [varchar](50) NULL,
	[PatientType] [varchar](30) NULL,
	[Gender] [varchar](20) NULL,
	[Problem] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[Date] [varchar](20) NULL,
	[Time] [varchar](30) NULL,
	[Description] [varchar](100) NULL,
	[City] [varchar](40) NULL,
	[AdmissionDate] [varchar](100) NULL,
	[DischargeDate] [varchar](40) NULL,
	[Typename] [varchar](40) NULL,
	[TreatmentDuration] [int] NULL,
	[Status] [varchar](40) NULL,
	[DoctorName] [varchar](40) NULL,
	[Dailycharge] [decimal](10, 2) NULL,
	[Totalcharge]  AS ([Treatmentduration]*[dailycharge]),
	[Department] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[complaints]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[complaints](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Replay] [varchar](500) NULL,
	[Complaint] [varchar](500) NULL,
	[PhoneNumber] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[department]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[department](
	[DepartmentId] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](500) NULL,
	[Status] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DepartmentAd]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DepartmentAd](
	[Id] [int] NOT NULL,
	[DepartmentName] [varchar](50) NULL,
	[DoctorName] [varchar](50) NULL,
	[Education] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[detailsoffamilyrelatives]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[detailsoffamilyrelatives](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NULL,
	[Name] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[EmailId] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[RelationWithDonor] [varchar](50) NULL,
	[StreetAddress] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[ZipCode] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[discharge]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[discharge](
	[PatientId] [int] NULL,
	[PatientName] [varchar](50) NULL,
	[Reason] [varchar](100) NULL,
	[Findings] [varchar](100) NULL,
	[LabReports] [varchar](100) NULL,
	[AdmissionDate] [varchar](40) NULL,
	[DischargeDate] [varchar](50) NULL,
	[ProcedureandTreatment] [varchar](100) NULL,
	[TreatmentDuration] [varchar](50) NULL,
	[FurtherInstruction] [varchar](300) NULL,
	[DischargeAmount] [varchar](50) NULL,
	[Followup] [varchar](30) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[doctors]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[doctors](
	[DoctorId] [int] NOT NULL,
	[FullName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Department] [varchar](50) NULL,
	[Designation] [varchar](50) NULL,
	[PhoneNo] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
	[Education] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[DoctorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[doctortimeslots]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[doctortimeslots](
	[TimeSlotId] [int] IDENTITY(1,1) NOT NULL,
	[DoctorId] [int] NULL,
	[Slot1] [time](7) NULL,
	[Slot2] [time](7) NULL,
	[Slot3] [time](7) NULL,
	[Slot4] [time](7) NULL,
	[Slot5] [time](7) NULL,
	[IsAvailable] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[TimeSlotId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[donorinfo]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[donorinfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[EmailId] [varchar](50) NULL,
	[DateOfBirth] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[BloodGroup] [varchar](50) NULL,
	[Quantity] [varchar](50) NULL,
	[Decease] [varchar](50) NULL,
	[StreetAddress] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[ZipCode] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[IsApproved] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[driver]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[driver](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[CNIC] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Drivers](
	[Id] [int] NOT NULL,
	[DriverName] [varchar](50) NULL,
	[DriverId] [varchar](50) NULL,
	[Contact] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[CNIC] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Email]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Email](
	[From] [varchar](40) NULL,
	[To] [varchar](40) NULL,
	[Subject] [varchar](300) NULL,
	[Body] [varchar](500) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Feedback](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[Age] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[phoneNumber] [varchar](50) NULL,
	[Feedback] [varchar](50) NULL,
	[Doctor] [varchar](50) NULL,
	[Staff] [varchar](50) NULL,
	[Cleaning] [varchar](50) NULL,
	[Review] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[hsptl]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hsptl](
	[Id] [numeric](30, 0) IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Inpatient]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Inpatient](
	[PatientId] [int] NOT NULL,
	[PatientName] [varchar](50) NULL,
	[AdmissionDate] [varchar](50) NULL,
	[Dischargedate] [varchar](50) NULL,
	[TypeName] [varchar](50) NULL,
	[TreatmentDuration] [varchar](50) NULL,
	[AppointmentDate] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[Problem] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
	[PhoenNumber] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Insurance]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Insurance](
	[InsuranceId] [int] NOT NULL,
	[ProviderName] [varchar](40) NULL,
	[CoverageDetails] [varchar](50) NULL,
	[CoPayAmount] [decimal](10, 2) NULL,
	[Deductible] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[InsuranceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[invoices]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[invoices](
	[InvoiceId] [int] IDENTITY(1,1) NOT NULL,
	[PatientId] [int] NULL,
	[DateOfService] [varchar](50) NULL,
	[TotalAmountDue] [decimal](18, 0) NULL,
	[DailyroomCharges] [decimal](18, 0) NULL,
	[TreatmentCharges] [decimal](18, 0) NULL,
	[MedicineCharges] [decimal](18, 0) NULL,
	[GST] [decimal](18, 0) NULL,
	[AdmissionDate] [varchar](100) NULL,
	[DischargeDate] [varchar](100) NULL,
	[TreatmentDuration] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[medicine]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[medicine](
	[PatientId] [int] NOT NULL,
	[PatientName] [varchar](50) NULL,
	[DoctorName] [varchar](50) NULL,
	[Problem] [varchar](50) NULL,
	[MedicineName] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[Morning] [varchar](50) NULL,
	[Afternoon] [varchar](50) NULL,
	[Night] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MedicineAd]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MedicineAd](
	[PatientId] [numeric](30, 0) NULL,
	[PatientName] [varchar](50) NULL,
	[DoctorName] [varchar](40) NULL,
	[Problem] [varchar](50) NULL,
	[Medicine] [varchar](50) NULL,
	[Morning] [varchar](50) NULL,
	[Afternoon] [varchar](50) NULL,
	[Evening] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[menu]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[menu](
	[Id] [int] NOT NULL,
	[Name] [varchar](100) NULL,
	[Url] [varchar](200) NULL,
	[ParentId] [int] NULL,
	[Isactive] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[modifiers]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[modifiers](
	[ModifierId] [int] NULL,
	[ServiceCode] [int] NULL,
	[ModifierDescription] [varchar](100) NULL,
	[AdjustmentAmount] [decimal](10, 2) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Nurse]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nurse](
	[NurseId] [int] NULL,
	[Name] [varchar](40) NULL,
	[DOB] [varchar](50) NULL,
	[Contact] [varchar](40) NULL,
	[Email] [varchar](40) NULL,
	[Address] [varchar](40) NULL,
	[DateofJoining] [varchar](50) NULL,
	[Specialization] [varchar](50) NULL,
	[ShiftType] [varchar](40) NULL,
	[Education] [varchar](50) NULL,
	[EmployeeStatus] [varchar](40) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[patient]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[patient](
	[PatientID] [int] NOT NULL,
	[FullName] [varchar](50) NULL,
	[DateOfBirth] [varchar](50) NULL,
	[PhoneNumber] [varchar](30) NULL,
	[Email] [varchar](40) NULL,
	[Address] [varchar](40) NULL,
	[InsuranceID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PatientAd]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PatientAd](
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[BloodGroup] [varchar](50) NULL,
	[Gender] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[patientinfo]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[patientinfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReferenceId] [int] NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[EmailId] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Gender] [varchar](50) NULL,
	[BloodGroup] [varchar](50) NULL,
	[Quantity] [varchar](50) NULL,
	[Decease] [varchar](50) NULL,
	[StreetAddress] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[ZipCode] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[IsApproved] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[patients]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[patients](
	[PatientId] [varchar](40) NULL,
	[FirstName] [varchar](40) NULL,
	[LastName] [varchar](40) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](40) NULL,
	[BloodGroup] [varchar](30) NULL,
	[Gender] [varchar](30) NULL,
	[PhoneNo] [varchar](40) NULL,
	[Address] [varchar](40) NULL,
	[EmergencyContact] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentId] [int] NOT NULL,
	[InvoiceId] [int] NULL,
	[PaymentMethod] [varchar](50) NULL,
	[TransactionId] [varchar](50) NULL,
	[Amountpaid] [decimal](10, 2) NULL,
	[PaymentDate] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Prec]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[profiles]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[profiles](
	[PatientId] [numeric](30, 0) IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[Email] [varchar](40) NULL,
	[Password] [varchar](50) NULL,
	[BloodGroup] [varchar](40) NULL,
	[Gender] [varchar](40) NULL,
	[Age] [varchar](30) NULL,
	[PhoneNo] [varchar](40) NULL,
	[Address] [varchar](40) NULL,
	[EmergencyContact] [varchar](40) NULL,
	[Type] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[PatientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Registration]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RejectedBloodRequests]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RejectedBloodRequests](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[EmailId] [varchar](50) NULL,
	[BloodGroup] [varchar](50) NULL,
	[Quantity] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RejectedDonors]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RejectedDonors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[EmailId] [varchar](50) NULL,
	[BloodGroup] [varchar](50) NULL,
	[Quantity] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[report]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[report](
	[ReportId] [int] NOT NULL,
	[ReportType] [varchar](40) NULL,
	[DateRangeStart] [date] NULL,
	[DateRangeEnd] [date] NULL,
	[ServiceUtilisation] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReportId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Service]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Service](
	[ServiceCode] [int] NOT NULL,
	[ServiceDescription] [varchar](50) NULL,
	[StandardCost] [varchar](50) NULL,
	[Modifiers] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ServiceCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ShedleAd]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ShedleAd](
	[Id] [int] NOT NULL,
	[DoctorName] [varchar](50) NULL,
	[StartTime] [varchar](20) NULL,
	[EndTime] [varchar](20) NULL,
	[status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SheduleAd]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SheduleAd](
	[Id] [int] NOT NULL,
	[DoctorName] [varchar](50) NULL,
	[StartTime] [varchar](20) NULL,
	[EndTime] [varchar](20) NULL,
	[status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SupportTickets]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SupportTickets](
	[TicketId] [int] NOT NULL,
	[IssueDescription] [varchar](200) NULL,
	[ResolutionStatus] [varchar](100) NULL,
	[CreatedAt] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserInfo]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[EmailId] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[DateOfBirth] [varchar](50) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[Address] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Userroles]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Userroles](
	[UserRoleId] [int] NOT NULL,
	[RoleName] [varchar](60) NULL,
	[AccessPermissions] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usertypes]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usertypes](
	[Id] [int] NULL,
	[Roles] [varchar](50) NULL,
	[Type] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[vaccine]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[vaccine](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[PatientName] [varchar](50) NULL,
	[Age] [varchar](40) NULL,
	[DoctorName] [varchar](40) NULL,
	[VaccineType] [varchar](40) NULL,
	[VaccineId] [varchar](50) NULL,
	[DateofVaccination] [varchar](40) NULL,
	[Dosage] [varchar](40) NULL,
	[FollowupDate] [varchar](40) NULL,
	[NextDueDate] [varchar](50) NULL,
	[ReactionType] [varchar](50) NULL,
	[Status] [varchar](50) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VisitTypes]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VisitTypes](
	[VisitTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Typename] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[VisitTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ward]    Script Date: 11/23/2024 10:19:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
SET ANSI_PADDING OFF
GO
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (1, N'Dashboard', N'/', NULL, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (2, N'Department', N'/', NULL, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (3, N'Doctors', N'/', NULL, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (4, N'Patients', N'/', NULL, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (5, N'Schedules', N'/', NULL, 0)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (6, N'Appointments', N'/', NULL, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (7, N'Announcements', N'/', NULL, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (8, N'Complaints', N'/', NULL, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (9, N'Prescription', N'/', NULL, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (10, N'Ambulance', N'/', NULL, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (11, N'Manage', N'/', NULL, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (12, N'Dashboard', N'/Dashboard/DashboardView', 1, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (13, N'Add Department', N'/Department/AddDepartment', 2, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (14, N'Department List', N'/Department/DepartmentList', 2, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (15, N'Add Doctor', N'/DoctorAd/AddDoctorAd', 3, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (16, N'Doctor List', N'/DoctorAd/DoctorListAd', 3, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (17, N'List of Patients', N'/PatientAd/PatientList', 4, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (19, N'Schedule List', N'/SheduleAd/SheduleList', 3, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (20, N'Add Schedule', N'/SheduleAd/AddSheduleAd', 3, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (21, N'List of Appointments', N'/AppointmentAd/AppointmentList', 6, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (22, N'Add Appointments', N'/AppointmentAd/AddAppointmentAd', 6, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (23, N'List of Announcements', N'/AnnouncementAd/AnnouncementList', 7, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (24, N'Add Announcements', N'/AnnouncementAd/AddAnnouncementAd', 7, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (25, N'List of Complaints', N'/ComplaintAd/ComplaintAdList', 8, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (26, N'Add Complaints', N'/ComplaintAd/AddComplaintAd', 8, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (27, N'Add Medicine', N'/MedicineAd/AddMedicineAd', 9, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (28, N'List of Medicine', N'/MedicineAd/MedicineAdList', 9, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (29, N'Add Ambulance', N'/AmbulanceAd/AddAmbulanceAd', 10, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (30, N'List of Ambulance', N'/AmbulanceAd/AmbulanceListAd', 10, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (31, N'Add Driver', N'/AmbulanceAd/AddDriverAd', 10, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (32, N'List of Driver', N'/AmbulanceAd/AmbulanceDriverAd', 10, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (33, N'UserRoles', N'/', NULL, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (34, N'Update Type', N'/UpdateProfile/UpdateList', 33, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (35, N'Add Type', N'/UpdateProfile/AddProfile', 33, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (36, N'Reception', N'/', NULL, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (37, N'Reception', N'/ReceptionAdmin/ReceptionFrontPage', 36, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (38, N'Logout', N'/home/index', 11, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (39, N'Blood Bank', N'/Admin/AdminHome', 36, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (40, N'Update Role', N'/RolesAdmin/RolesList', 33, 1)
INSERT [dbo].[AdminMenu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (41, N'New Role', N'/RolesAdmin/AddRole', 33, 1)
INSERT [dbo].[Amb] ([Id], [Name], [AmbulanceId], [AmbulanceStatus], [DriverName], [DriverId]) VALUES (1, N'Yashoda', N'108', N'Inactive', N'Zampa', N'1126')
INSERT [dbo].[Amb] ([Id], [Name], [AmbulanceId], [AmbulanceStatus], [DriverName], [DriverId]) VALUES (2, N'ambulanceb6', N'123', N'Active', N'marcus', N'4556')
INSERT [dbo].[Amb] ([Id], [Name], [AmbulanceId], [AmbulanceStatus], [DriverName], [DriverId]) VALUES (3, N'lakavath tharun', N'123', N'InActive', N'Zampa', N'13')
INSERT [dbo].[Amb] ([Id], [Name], [AmbulanceId], [AmbulanceStatus], [DriverName], [DriverId]) VALUES (4, N'QQQ', N'22', N'Inactive', N'Faf ', N'111')
INSERT [dbo].[Ambulance] ([Id], [Name], [AmbulanceId], [AmbulanceStatus], [DriverName], [DriverId], [Contact], [Address], [CNIC]) VALUES (1, N'tt', 222, N'Active', N'William', 222, N'uuuu', N'uuu', N'888')
INSERT [dbo].[Ambulance] ([Id], [Name], [AmbulanceId], [AmbulanceStatus], [DriverName], [DriverId], [Contact], [Address], [CNIC]) VALUES (2, N'Yashoda', 104, N'Active', N'Tembha Bhavuma', 456, N'8978568838', N'Sec-bad', N'77895')
INSERT [dbo].[AmbulanceAd] ([Id], [Name], [AmbulanceId], [AmbulanceStatus], [AmbulanceDriver], [AmbulanceDriverId]) VALUES (1, N'Yashodha Ambulance', 108, N'', N'Danush', 8978)
INSERT [dbo].[AmbulanceAd] ([Id], [Name], [AmbulanceId], [AmbulanceStatus], [AmbulanceDriver], [AmbulanceDriverId]) VALUES (2, N'Apollo', 104, N'', N'Gaguly', 9899)
INSERT [dbo].[AmbulanceAd] ([Id], [Name], [AmbulanceId], [AmbulanceStatus], [AmbulanceDriver], [AmbulanceDriverId]) VALUES (3, N'SunShine', 104, N'', N'Roma Shephard', 9798)
INSERT [dbo].[AmbulanceAd] ([Id], [Name], [AmbulanceId], [AmbulanceStatus], [AmbulanceDriver], [AmbulanceDriverId]) VALUES (4, N'Kims', 108, N'', N'HitMyre', 8879)
INSERT [dbo].[Ambulances] ([Id], [Name], [AmbulanceId], [AmbulanceStatus], [DriverName], [DriverId]) VALUES (1, N'lakavath tharun', N'7', N'InActive', N'7', N'7')
INSERT [dbo].[AnnouncementAd] ([Id], [Announcement], [AnnouncementFor], [EndDate]) VALUES (1, N'anand', N'mama', N'2024-10-20T22:01')
INSERT [dbo].[Appointment] ([DoctorName], [Speciality], [Education], [Timings], [Status]) VALUES (N'Anand', N'Cardio', N'MBBS', N'10Am-5Pm', N'Active')
INSERT [dbo].[Appointment] ([DoctorName], [Speciality], [Education], [Timings], [Status]) VALUES (N'Arun', N'Neuro', N'MBBS', N'10Am-5Pm', N'Active')
SET IDENTITY_INSERT [dbo].[Appointments] ON 

INSERT [dbo].[Appointments] ([Id], [PatientId], [DoctorId], [AppointmentDate], [Problem], [Status]) VALUES (1, 1002, 1, CAST(N'2024-09-15' AS Date), N'Flu symptoms', 1)
INSERT [dbo].[Appointments] ([Id], [PatientId], [DoctorId], [AppointmentDate], [Problem], [Status]) VALUES (2, 1002, 2001, CAST(N'2024-09-15' AS Date), N'Flu symptoms', 1)
INSERT [dbo].[Appointments] ([Id], [PatientId], [DoctorId], [AppointmentDate], [Problem], [Status]) VALUES (3, 1004, 3001, CAST(N'2024-09-14' AS Date), N'Heart problem', 1)
SET IDENTITY_INSERT [dbo].[Appointments] OFF
SET IDENTITY_INSERT [dbo].[ApproveBloodRequests] ON 

INSERT [dbo].[ApproveBloodRequests] ([Id], [Firstname], [LastName], [EmailId], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country]) VALUES (3002, N'Lakavath', N'Bindu', N'Bindu@123', N'8688841715', N'Female', N'A+', N'1.5L', N'HandSurgery', N'Hyderabad', N'Hyderabad', N'Telangana', N'500015', N'india')
INSERT [dbo].[ApproveBloodRequests] ([Id], [Firstname], [LastName], [EmailId], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country]) VALUES (3004, N'maloth', N'Bindu', N'rockey@123', N'9989511828', N'Female', N'A-', N'1.5L', N'Lung Cancer', N'hyd', N'hyd', N'Telangana', N'500003', N'india')
INSERT [dbo].[ApproveBloodRequests] ([Id], [Firstname], [LastName], [EmailId], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country]) VALUES (3005, N'Lakavath', N'Bindu', N'Bindu@123', N'8688841715', N'Female', N'A+', N'1.5L', N'HandSurgery', N'Hyderabad', N'Hyderabad', N'Telangana', N'500015', N'india')
INSERT [dbo].[ApproveBloodRequests] ([Id], [Firstname], [LastName], [EmailId], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country]) VALUES (4002, N'anand', N'sagar', N'Anand@gmail.com', N'9865647125', N'Male', N'AB+', N'0.600 L', N'desfghnj', N'krk thanda', N'Visakhapatnam', N'Andhra Pradesh', N'530001', N'India')
INSERT [dbo].[ApproveBloodRequests] ([Id], [Firstname], [LastName], [EmailId], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country]) VALUES (4004, N'lakavath', N'tharun', N'tharun@gmail.com', N'8566433422', N'Male', N'B+', N'0.050 L', N'tyf76t86t', N'anana', N'Visakhapatnam', N'Andhra Pradesh', N'India', N'530001')
INSERT [dbo].[ApproveBloodRequests] ([Id], [Firstname], [LastName], [EmailId], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country]) VALUES (4005, N'lakavath', N'tharun', N'tharun@gmail.com', N'8566433422', N'Male', N'B+', N'0.050 L', N'tyf76t86t', N'anana', N'Visakhapatnam', N'Andhra Pradesh', N'India', N'530001')
INSERT [dbo].[ApproveBloodRequests] ([Id], [Firstname], [LastName], [EmailId], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country]) VALUES (4006, N'Bhargavi', N'S', N'Bhargavi@gmail.com', N'8664633353', N'Female', N'AB+', N'70ml', N'no', N'anana', N'Visakhapatnam', N'Andhra Pradesh', N'India', N'500823')
SET IDENTITY_INSERT [dbo].[ApproveBloodRequests] OFF
INSERT [dbo].[Attendance] ([Id], [Name], [Department], [JobTitle], [Contact], [Shift], [Time], [LoginTime], [LogoutTime], [Status]) VALUES (1, N'linga', N'dermatalogist', N'qqq', N'6554586575', N'Morning', N'9:00 AM - 5:00 PM', N'03:03', N'03:02', N'Present')
INSERT [dbo].[Bill] ([PatientId], [PatientName], [Problem], [BillingDate], [DoctorFee], [TreatmentDuration], [TreatmentCharges], [MedicineCharges], [RoomFee], [Others], [OthersCost], [TotalBill], [GST], [TotalAmount], [InsuranceClaimed], [PaidBill], [Status], [MethodOfPayment], [BalanceAmount]) VALUES (1, N'Shahrukh', N'Fever', N'2024-11-22', CAST(500 AS Decimal(18, 0)), 1, CAST(1500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), N'scan', CAST(10 AS Decimal(18, 0)), CAST(3000 AS Decimal(18, 0)), CAST(540 AS Decimal(18, 0)), CAST(3540 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(2000 AS Decimal(18, 0)), N'paid', N'UPI', CAST(1450 AS Decimal(18, 0)))
INSERT [dbo].[Bill] ([PatientId], [PatientName], [Problem], [BillingDate], [DoctorFee], [TreatmentDuration], [TreatmentCharges], [MedicineCharges], [RoomFee], [Others], [OthersCost], [TotalBill], [GST], [TotalAmount], [InsuranceClaimed], [PaidBill], [Status], [MethodOfPayment], [BalanceAmount]) VALUES (2, N'jake Fresure McGurg', N'fever', N'2024-10-31', CAST(500 AS Decimal(18, 0)), 6, CAST(58000 AS Decimal(18, 0)), CAST(7000 AS Decimal(18, 0)), CAST(6000 AS Decimal(18, 0)), N'scanning', CAST(9000 AS Decimal(18, 0)), CAST(80500 AS Decimal(18, 0)), CAST(14490 AS Decimal(18, 0)), CAST(94990 AS Decimal(18, 0)), CAST(50000 AS Decimal(18, 0)), CAST(44990 AS Decimal(18, 0)), N'paid', N'Credit Card', NULL)
INSERT [dbo].[bookapp] ([Id], [PatientName], [PatientType], [Gender], [Problem], [PhoneNumber], [Address], [Date], [Time], [Description], [City], [AdmissionDate], [DischargeDate], [Typename], [TreatmentDuration], [Status], [DoctorName], [Dailycharge], [Department]) VALUES (1, N'wrrt', N'In Patient', N'Male', N'www', N'8566433422', N'www', N'2024-11-22', NULL, N'www', NULL, N'2024-11-23', N'2024-11-29', NULL, 6, N'discharged', NULL, NULL, NULL)
INSERT [dbo].[bookapp] ([Id], [PatientName], [PatientType], [Gender], [Problem], [PhoneNumber], [Address], [Date], [Time], [Description], [City], [AdmissionDate], [DischargeDate], [Typename], [TreatmentDuration], [Status], [DoctorName], [Dailycharge], [Department]) VALUES (2, N'VIRAT', N'', N'male', N'Fever', N'9182225321', N'Delhi', N'2024-11-22', N'21:14', N'dsdgdh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Cardiology')
INSERT [dbo].[bookapp] ([Id], [PatientName], [PatientType], [Gender], [Problem], [PhoneNumber], [Address], [Date], [Time], [Description], [City], [AdmissionDate], [DischargeDate], [Typename], [TreatmentDuration], [Status], [DoctorName], [Dailycharge], [Department]) VALUES (3, N'patient', N'', N'male', N'Fever', N'9182225321', N'Delhi', N'2024-11-23', N'22:00', N'ddfdfgd', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'General Medicine')
INSERT [dbo].[complaints] ([Id], [Name], [Replay], [Complaint], [PhoneNumber]) VALUES (1, N'Bhargavi', N'Sorry ', N'no service', N'6778454354')
INSERT [dbo].[complaints] ([Id], [Name], [Replay], [Complaint], [PhoneNumber]) VALUES (2, N'tharun', NULL, N'sss', N'8978568838')
INSERT [dbo].[complaints] ([Id], [Name], [Replay], [Complaint], [PhoneNumber]) VALUES (3, N'edfdgfhjkk', N'', N'fdgdhhkjl', N'9234567890')
INSERT [dbo].[complaints] ([Id], [Name], [Replay], [Complaint], [PhoneNumber]) VALUES (4, N'edfdgfhjkk', N'', N'fdgdhhkjl', N'9234567890')
INSERT [dbo].[department] ([DepartmentId], [Name], [Description], [Status]) VALUES (1, N'Infectious Disease', N'Management of fever and infections', N'Active')
INSERT [dbo].[department] ([DepartmentId], [Name], [Description], [Status]) VALUES (2, N'Cardiology', N'Diagnosis and treatment of heart problems', N'Active')
INSERT [dbo].[department] ([DepartmentId], [Name], [Description], [Status]) VALUES (3, N'Pediatrics', N'Care for children with fever-related issues', N'Active')
INSERT [dbo].[department] ([DepartmentId], [Name], [Description], [Status]) VALUES (4, N'Internal Medicine', N'General care for adult fever and heart conditions', N'Active')
INSERT [dbo].[department] ([DepartmentId], [Name], [Description], [Status]) VALUES (5, N'Emergency Medicine', N'Immediate care for acute fever and heart emergencies', N'Active')
INSERT [dbo].[DepartmentAd] ([Id], [DepartmentName], [DoctorName], [Education], [Description], [Gender], [Status]) VALUES (1, N'Cardio', N'Anand Sagar', N'MBBS', N'Heart', N'Female', N'Active')
INSERT [dbo].[DepartmentAd] ([Id], [DepartmentName], [DoctorName], [Education], [Description], [Gender], [Status]) VALUES (2, N'mbbs', N'tharun', N'BA LLB', N'kjbjrniur', N'Male', N'Active')
SET IDENTITY_INSERT [dbo].[detailsoffamilyrelatives] ON 

INSERT [dbo].[detailsoffamilyrelatives] ([Id], [ReferenceId], [Name], [PhoneNumber], [EmailId], [Gender], [RelationWithDonor], [StreetAddress], [City], [State], [ZipCode], [Country]) VALUES (1, 1, N'Gugulothu Naresh', N'9989511828', N'naresh@gmail.com', N'Female', N'Brother', N'hyderabad', N'chennai', N'tamilnadu', N'500285', N'India')
INSERT [dbo].[detailsoffamilyrelatives] ([Id], [ReferenceId], [Name], [PhoneNumber], [EmailId], [Gender], [RelationWithDonor], [StreetAddress], [City], [State], [ZipCode], [Country]) VALUES (2, 5, N'daravath radhika', N'9989511828', N'radhika@gmail.com', N'Male', N'Spouse', N'hyderabad', N'Bengaluru', N'Karnataka', N'560001', N'India')
INSERT [dbo].[detailsoffamilyrelatives] ([Id], [ReferenceId], [Name], [PhoneNumber], [EmailId], [Gender], [RelationWithDonor], [StreetAddress], [City], [State], [ZipCode], [Country]) VALUES (3, 3, N'Seetha', N'8566433422', N'raj@gmail.com', N'Male', N'Father', N'anana', N'Visakhapatnam', N'Andhra Pradesh', N'530001', N'India')
SET IDENTITY_INSERT [dbo].[detailsoffamilyrelatives] OFF
INSERT [dbo].[discharge] ([PatientId], [PatientName], [Reason], [Findings], [LabReports], [AdmissionDate], [DischargeDate], [ProcedureandTreatment], [TreatmentDuration], [FurtherInstruction], [DischargeAmount], [Followup]) VALUES (1, N'Pooja', N'Pneumonia', N'Crackles in lung, fever', N'WBC count elevated', N'2024-10-01', N'2024-10-04', N'IV antibiotics, chest X-ray', N'3 ', N'Continue antibiotics at home', N'500', N'Follow up in 1 week')
INSERT [dbo].[discharge] ([PatientId], [PatientName], [Reason], [Findings], [LabReports], [AdmissionDate], [DischargeDate], [ProcedureandTreatment], [TreatmentDuration], [FurtherInstruction], [DischargeAmount], [Followup]) VALUES (3, N'Ramya', N'ViralFever', N'Typhoid', N'Low Platelets', N'2024-11-22', N'2024-11-21', N'Ciprofloxacin', N'3', N'Drink Warm Water', N'400', N'no')
INSERT [dbo].[doctors] ([DoctorId], [FullName], [Email], [Department], [Designation], [PhoneNo], [ContactNo], [Education], [Gender], [Status]) VALUES (3, N'anand', N'anandasagar@iitsofttech.com', N'cardio', N'aaaa', N'6978568838', N'040-1234567', N'qqq', N'Male', N'Active')
INSERT [dbo].[doctors] ([DoctorId], [FullName], [Email], [Department], [Designation], [PhoneNo], [ContactNo], [Education], [Gender], [Status]) VALUES (5, N'mb sri', N'anandasagar@iitsofttech.com', N'cardio', N'aaaa', N'6978568838', N'040-1234567', N'qqq', N'Female', N'Active')
INSERT [dbo].[doctors] ([DoctorId], [FullName], [Email], [Department], [Designation], [PhoneNo], [ContactNo], [Education], [Gender], [Status]) VALUES (6, N'mb sri', N'anandasagar@iitsofttech.com', N'cardio', N'aaaa', N'8978568838', N'040-1234567', N'qqq', N'Male', N'Active')
SET IDENTITY_INSERT [dbo].[doctortimeslots] ON 

INSERT [dbo].[doctortimeslots] ([TimeSlotId], [DoctorId], [Slot1], [Slot2], [Slot3], [Slot4], [Slot5], [IsAvailable]) VALUES (2, 3, CAST(N'02:00:00' AS Time), CAST(N'03:00:00' AS Time), CAST(N'04:00:00' AS Time), CAST(N'05:00:00' AS Time), CAST(N'06:00:00' AS Time), 1)
INSERT [dbo].[doctortimeslots] ([TimeSlotId], [DoctorId], [Slot1], [Slot2], [Slot3], [Slot4], [Slot5], [IsAvailable]) VALUES (3, 5, CAST(N'10:00:00' AS Time), CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'02:00:00' AS Time), CAST(N'03:00:00' AS Time), 1)
INSERT [dbo].[doctortimeslots] ([TimeSlotId], [DoctorId], [Slot1], [Slot2], [Slot3], [Slot4], [Slot5], [IsAvailable]) VALUES (4, 6, CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'01:00:00' AS Time), CAST(N'02:00:00' AS Time), CAST(N'03:00:00' AS Time), 1)
INSERT [dbo].[doctortimeslots] ([TimeSlotId], [DoctorId], [Slot1], [Slot2], [Slot3], [Slot4], [Slot5], [IsAvailable]) VALUES (5, 7, CAST(N'11:00:00' AS Time), CAST(N'12:00:00' AS Time), CAST(N'01:00:00' AS Time), CAST(N'02:00:00' AS Time), CAST(N'03:00:00' AS Time), 1)
SET IDENTITY_INSERT [dbo].[doctortimeslots] OFF
SET IDENTITY_INSERT [dbo].[donorinfo] ON 

INSERT [dbo].[donorinfo] ([Id], [ReferenceId], [FirstName], [LastName], [EmailId], [DateOfBirth], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country], [IsApproved]) VALUES (2, 5, N'Lakavath', N'Yakesh', N'yakesh@gmail.com', N'06-11-2024', N'9989511828', N'Male', N'B-', N'200ml', N'no', N'hyderabad', N'Visakhapatnam', N'Andhra Pradesh', N'530001', N'Pakistan', N'Approved')
INSERT [dbo].[donorinfo] ([Id], [ReferenceId], [FirstName], [LastName], [EmailId], [DateOfBirth], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country], [IsApproved]) VALUES (3, 6, N'Lokesh', N'abc', N'lokesh@gmail.com', N'05-11-2024', N'9989511828', N'Male', N'B-', N'200ml', N'no', N'hyderabad', N'hyderabad', N'telengana', N'508223', N'india', N'Rejected')
INSERT [dbo].[donorinfo] ([Id], [ReferenceId], [FirstName], [LastName], [EmailId], [DateOfBirth], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country], [IsApproved]) VALUES (4, 5, N'Guguloth', N'Ram', N'ram@gmail.com', N'06-11-2024', N'9989511828', N'Male', N'B+', N'500ml', N'no', N'hyderabad', N'hyderabad', N'telengana', N'508223', N'india', N'Completed')
INSERT [dbo].[donorinfo] ([Id], [ReferenceId], [FirstName], [LastName], [EmailId], [DateOfBirth], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country], [IsApproved]) VALUES (6, 3, N'Radhika', N'P', N'raj@gmail.com', N'05-11-2024', N'8566433422', N'Male', N'O+', N'70ml', N'gry', N'Guntur', N'Visakhapatnam', N'Andhra Pradesh', N'530001', N'India', N'Approved')
INSERT [dbo].[donorinfo] ([Id], [ReferenceId], [FirstName], [LastName], [EmailId], [DateOfBirth], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country], [IsApproved]) VALUES (7, 3, N'Radhika', N'P', N'tharun@gmail.com', N'01-11-2024', N'8566433422', N'Male', N'A-', N'50ml', N'no', N'Guntur', N'Visakhapatnam', N'Andhra Pradesh', N'530001', N'India', N'Completed')
INSERT [dbo].[donorinfo] ([Id], [ReferenceId], [FirstName], [LastName], [EmailId], [DateOfBirth], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country], [IsApproved]) VALUES (10, 1, N'Radhika', N'P', N'linga@gmail.com', N'02-11-2024', N'8566433422', N'Male', N'B+', N'50ml', N'no', N'Guntur', N'Bengaluru', N'Karnataka', N'560001', N'India', N'pending')
SET IDENTITY_INSERT [dbo].[donorinfo] OFF
INSERT [dbo].[driver] ([Id], [Name], [Contact], [Address], [CNIC]) VALUES (1, N'C Gayle', N'8978568838', N'WestIndies', N'11099')
INSERT [dbo].[driver] ([Id], [Name], [Contact], [Address], [CNIC]) VALUES (2, N'Pollad', N'9182225321', N'Westndies', N'11222')
INSERT [dbo].[Drivers] ([Id], [DriverName], [DriverId], [Contact], [Address], [CNIC]) VALUES (1, N'Zampa', N'11', N'1234`', N'qqq', N'456')
INSERT [dbo].[Drivers] ([Id], [DriverName], [DriverId], [Contact], [Address], [CNIC]) VALUES (2, N'Marcus', N'123', N'123', N'hyd', N'1234')
INSERT [dbo].[Email] ([From], [To], [Subject], [Body]) VALUES (N'', N'', N'ddgfg', N'')
INSERT [dbo].[Email] ([From], [To], [Subject], [Body]) VALUES (N'', N'', N'', N'')
INSERT [dbo].[Feedback] ([Id], [Name], [Age], [Email], [phoneNumber], [Feedback], [Doctor], [Staff], [Cleaning], [Review]) VALUES (1, N'Anand', N'19', N'anband@gmail.com', N'9785688358', N'Avg Hospital', N'4', N'4', N'5', N'5')
INSERT [dbo].[Feedback] ([Id], [Name], [Age], [Email], [phoneNumber], [Feedback], [Doctor], [Staff], [Cleaning], [Review]) VALUES (2, N'Seetha', N'21', N'seetha@gmail.com', N'9785688358', N'poor', N'2', N'1', N'5', N'3')
INSERT [dbo].[Inpatient] ([PatientId], [PatientName], [AdmissionDate], [Dischargedate], [TypeName], [TreatmentDuration], [AppointmentDate], [Status], [Problem], [Description], [Gender], [Address], [PhoenNumber]) VALUES (1, N'S. khan', N'2024-10-07', N'2024-10-08', N'inPatient', N'1', N'2024-10-02', N'intreatment', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Insurance] ([InsuranceId], [ProviderName], [CoverageDetails], [CoPayAmount], [Deductible]) VALUES (123456, N'ABC Health Insurance', N'Basic Coverage', CAST(20.00 AS Decimal(10, 2)), CAST(500.00 AS Decimal(10, 2)))
INSERT [dbo].[Insurance] ([InsuranceId], [ProviderName], [CoverageDetails], [CoPayAmount], [Deductible]) VALUES (235678, N'XYZ Life Insurance', N'Comprehensive Coverage', CAST(30.00 AS Decimal(10, 2)), CAST(1000.00 AS Decimal(10, 2)))
INSERT [dbo].[Insurance] ([InsuranceId], [ProviderName], [CoverageDetails], [CoPayAmount], [Deductible]) VALUES (365475, N'LMN Health Plan', N'Family Coverage', CAST(15.00 AS Decimal(10, 2)), CAST(300.00 AS Decimal(10, 2)))
INSERT [dbo].[Insurance] ([InsuranceId], [ProviderName], [CoverageDetails], [CoPayAmount], [Deductible]) VALUES (4353446, N'OPQ Insurance Co.', N'Dental and Vision', CAST(10.00 AS Decimal(10, 2)), CAST(200.00 AS Decimal(10, 2)))
INSERT [dbo].[Insurance] ([InsuranceId], [ProviderName], [CoverageDetails], [CoPayAmount], [Deductible]) VALUES (5564574, N'RST Medical Group', N'Emergency Coverage', CAST(25.00 AS Decimal(10, 2)), CAST(750.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[invoices] ON 

INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1, 1, N'10/16/2024 4:40:24 PM', CAST(1950 AS Decimal(18, 0)), CAST(450 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(351 AS Decimal(18, 0)), N'01-10-2024', N'04-10-2024', 3)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (2, 3, N'10/16/2024 4:46:16 PM', CAST(1800 AS Decimal(18, 0)), CAST(300 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(324 AS Decimal(18, 0)), N'05-10-2024', N'07-10-2024', 2)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (3, 4, N'10/16/2024 4:49:18 PM', CAST(2100 AS Decimal(18, 0)), CAST(600 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(378 AS Decimal(18, 0)), N'04-10-2024', N'08-10-2024', 4)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (4, 2, N'10/16/2024 4:51:48 PM', CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (5, 2, N'10/16/2024 4:52:29 PM', CAST(1500 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (6, 2, N'10/16/2024 4:54:25 PM', CAST(1500 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (7, 2, N'10/16/2024 4:55:13 PM', CAST(1500 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (8, 1, N'10/16/2024 4:56:34 PM', CAST(1950 AS Decimal(18, 0)), CAST(450 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(351 AS Decimal(18, 0)), N'01-10-2024', N'04-10-2024', 3)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (9, 1, N'10/16/2024 5:00:05 PM', CAST(2301 AS Decimal(18, 0)), CAST(450 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(351 AS Decimal(18, 0)), N'01-10-2024', N'04-10-2024', 3)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (10, 2, N'10/16/2024 5:00:53 PM', CAST(1770 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (11, 1, N'10/16/2024 5:28:32 PM', CAST(2301 AS Decimal(18, 0)), CAST(450 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(351 AS Decimal(18, 0)), N'01-10-2024', N'04-10-2024', 3)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (12, 1, N'10/16/2024 5:59:39 PM', CAST(2301 AS Decimal(18, 0)), CAST(450 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(351 AS Decimal(18, 0)), N'01-10-2024', N'04-10-2024', 3)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (13, 1, N'10/16/2024 6:02:54 PM', CAST(2301 AS Decimal(18, 0)), CAST(450 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(351 AS Decimal(18, 0)), N'01-10-2024', N'04-10-2024', 3)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (14, 1, N'10/16/2024 6:03:47 PM', CAST(2301 AS Decimal(18, 0)), CAST(450 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(351 AS Decimal(18, 0)), N'01-10-2024', N'04-10-2024', 3)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1002, 4, N'10/24/2024 5:12:48 PM', CAST(2478 AS Decimal(18, 0)), CAST(600 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(378 AS Decimal(18, 0)), N'04-10-2024', N'08-10-2024', 4)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1003, 4, N'10/24/2024 5:13:25 PM', CAST(2478 AS Decimal(18, 0)), CAST(600 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(378 AS Decimal(18, 0)), N'04-10-2024', N'08-10-2024', 4)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1004, 4, N'10/24/2024 5:13:32 PM', CAST(2478 AS Decimal(18, 0)), CAST(600 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(378 AS Decimal(18, 0)), N'04-10-2024', N'08-10-2024', 4)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1005, 5, N'10/25/2024 12:53:26 PM', CAST(1947 AS Decimal(18, 0)), CAST(150 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(297 AS Decimal(18, 0)), N'24-10-2024', N'27-10-2024', 1)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1006, 2, N'10/25/2024 1:41:55 PM', CAST(1770 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1007, 2, N'10/25/2024 1:42:01 PM', CAST(1770 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1008, 2, N'10/25/2024 1:42:08 PM', CAST(1770 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1009, 4, N'10/25/2024 1:42:24 PM', CAST(2478 AS Decimal(18, 0)), CAST(600 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(378 AS Decimal(18, 0)), N'04-10-2024', N'08-10-2024', 4)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1010, 2, N'10/25/2024 1:43:34 PM', CAST(1770 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1011, 2, N'10/25/2024 1:43:44 PM', CAST(1770 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1012, 2, N'10/25/2024 1:43:51 PM', CAST(1770 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1013, 2, N'10/25/2024 1:43:52 PM', CAST(1770 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1014, 2, N'10/25/2024 1:43:52 PM', CAST(1770 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1015, 2, N'10/25/2024 1:43:53 PM', CAST(1770 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1016, 2, N'10/25/2024 1:43:56 PM', CAST(1770 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
INSERT [dbo].[invoices] ([InvoiceId], [PatientId], [DateOfService], [TotalAmountDue], [DailyroomCharges], [TreatmentCharges], [MedicineCharges], [GST], [AdmissionDate], [DischargeDate], [TreatmentDuration]) VALUES (1017, 2, N'10/25/2024 1:43:57 PM', CAST(1770 AS Decimal(18, 0)), CAST(0 AS Decimal(18, 0)), CAST(500 AS Decimal(18, 0)), CAST(1000 AS Decimal(18, 0)), CAST(270 AS Decimal(18, 0)), N'null', N'', 0)
SET IDENTITY_INSERT [dbo].[invoices] OFF
INSERT [dbo].[medicine] ([PatientId], [PatientName], [DoctorName], [Problem], [MedicineName], [Description], [Morning], [Afternoon], [Night]) VALUES (1, N'Skhan', N'Anand', N'fever', N'dolos', N'hhjjhhj', N'Yes', N'No', N'No')
INSERT [dbo].[medicine] ([PatientId], [PatientName], [DoctorName], [Problem], [MedicineName], [Description], [Morning], [Afternoon], [Night]) VALUES (2, N'A.Singh', N'Anand', N'fever', N'dolo', N'hhjjhhj', N'yes', N'no', N'yes')
INSERT [dbo].[medicine] ([PatientId], [PatientName], [DoctorName], [Problem], [MedicineName], [Description], [Morning], [Afternoon], [Night]) VALUES (3, N'M Shami', N'anand', N'hair', N'dolo', N'hhjjhhj', N'No', N'Yes', N'Yes')
INSERT [dbo].[medicine] ([PatientId], [PatientName], [DoctorName], [Problem], [MedicineName], [Description], [Morning], [Afternoon], [Night]) VALUES (4, N'ram', N'ss', N'fdhg', N'safgfgh', N'sdghjh', N'No', N'No', N'Yes')
INSERT [dbo].[MedicineAd] ([PatientId], [PatientName], [DoctorName], [Problem], [Medicine], [Morning], [Afternoon], [Evening]) VALUES (CAST(1 AS Numeric(30, 0)), N'Bhargavi', N'latha', N'Fever', N'Dollo', N'?', N'?', N'?')
INSERT [dbo].[MedicineAd] ([PatientId], [PatientName], [DoctorName], [Problem], [Medicine], [Morning], [Afternoon], [Evening]) VALUES (CAST(2 AS Numeric(30, 0)), N'mercy', N'Devi', N'Typhoid ', N'Ofloxacin', N'?', N'?', N'?')
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (1, N'Dashboard', N'/', NULL, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (2, N'Profile', N'/', NULL, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (3, N'Doctor', N'/', NULL, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (4, N'Appointment', N'/', NULL, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (5, N'Prescription', N'/', NULL, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (6, N'Complaint', N'/', NULL, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (7, N'Manage', N'/', NULL, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (8, N'Dashboard', N'/Patient/Dashboard', 1, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (9, N'Profile', N'/Patient/Updateprofile', 2, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (10, N'Available Doctors', N'/Doctor/DoctorList', 3, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (11, N'Request Appointment', N'/Appointment/AddBook', 4, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (12, N'Appointment List', N'/Appointment/BookList', 4, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (13, N'Your Prescription', N'/Patient/PrecList', 5, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (14, N'Add Complaints', N'/Complaint/RegisterComplaint', 6, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (15, N'List of Complaints', N'/Complaint/ComplaintList', 6, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (16, N'Change Password', N'/Patient/Changepassword', 7, 1)
INSERT [dbo].[menu] ([Id], [Name], [Url], [ParentId], [Isactive]) VALUES (17, N'Logout', N'/home/index', 7, 1)
INSERT [dbo].[Nurse] ([NurseId], [Name], [DOB], [Contact], [Email], [Address], [DateofJoining], [Specialization], [ShiftType], [Education], [EmployeeStatus]) VALUES (301, N'Rani', N'27-10-1995', N'678934521', N'rani23@gmail.com', N'Ranigunj', N'10-08-2017', N'critical care', N'Morning', N'ASN', N'Full-time')
INSERT [dbo].[Nurse] ([NurseId], [Name], [DOB], [Contact], [Email], [Address], [DateofJoining], [Specialization], [ShiftType], [Education], [EmployeeStatus]) VALUES (302, N'Priya', N'11-12-1998', N'8976543210', N'priya12@gmail.com', N'Kukatpally', N'10-05-2018', N'emergency care', N'Evening', N'BSN', N'Part-time')
INSERT [dbo].[Nurse] ([NurseId], [Name], [DOB], [Contact], [Email], [Address], [DateofJoining], [Specialization], [ShiftType], [Education], [EmployeeStatus]) VALUES (303, N'Ramu', N'18-09-2000', N'7891456761', N'ramu45@gmail.com', N'Secundrabad', N'01-04-2021', N'Information care', N'Night', N'MSN', N'Full-time')
INSERT [dbo].[patient] ([PatientID], [FullName], [DateOfBirth], [PhoneNumber], [Email], [Address], [InsuranceID]) VALUES (1, N'Ajith', N'21-10-1998', N'789324561', N'ajith4@gmail.com', N'Chennai', 123456)
INSERT [dbo].[PatientAd] ([Id], [Name], [PhoneNumber], [BloodGroup], [Gender]) VALUES (2, N'sadffg', N'43567890', N'AB+', N'Male')
SET IDENTITY_INSERT [dbo].[patientinfo] ON 

INSERT [dbo].[patientinfo] ([Id], [ReferenceId], [FirstName], [LastName], [EmailId], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country], [IsApproved]) VALUES (1, 1, N'lakavath', N'Mahesh', N'mahesh@gmail.com', N'9989511828', N'Male', N'A-', N'200ml', N'no', N'hyderabad', N'Visakhapatnam', N'Andhra Pradesh', N'530001', N'India', N'Approved')
INSERT [dbo].[patientinfo] ([Id], [ReferenceId], [FirstName], [LastName], [EmailId], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country], [IsApproved]) VALUES (2, 5, N'maloth', N'jyothi', N'jyothi@gmail.com', N'9989511828', N'Female', N'AB+', N'800ml', N'no', N'hyderabad', N'Visakhapatnam', N'Andhra Pradesh', N'530001', N'India', N'Rejected')
INSERT [dbo].[patientinfo] ([Id], [ReferenceId], [FirstName], [LastName], [EmailId], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country], [IsApproved]) VALUES (3, 1, N'Bhukya', N'manohar', N'manohar@gmail.com', N'9989511828', N'Male', N'A-', N'200ml', N'no', N'hyderabad', N'Visakhapatnam', N'Andhra Pradesh', N'530001', N'India', N'Approved')
INSERT [dbo].[patientinfo] ([Id], [ReferenceId], [FirstName], [LastName], [EmailId], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country], [IsApproved]) VALUES (4, 0, N'Radhika', N'P', N'radhika@gmail.com', N'8566433422', N'Female', N'B+', N'50ml', N'tyf76t86t', N'ananaaa', N'Visakhapatnam', N'Andhra Pradesh', N'530001', N'India', N'Rejected')
INSERT [dbo].[patientinfo] ([Id], [ReferenceId], [FirstName], [LastName], [EmailId], [PhoneNumber], [Gender], [BloodGroup], [Quantity], [Decease], [StreetAddress], [City], [State], [ZipCode], [Country], [IsApproved]) VALUES (5, 3, N'Radhika', N'P', N'tharun@gmail.com', N'8566433422', N'Male', N'B+', N'1.5l', N'no', N'ananaaa', N'Vijayawada', N'Andhra Pradesh', N'520001', N'India', N'Approved')
SET IDENTITY_INSERT [dbo].[patientinfo] OFF
INSERT [dbo].[patients] ([PatientId], [FirstName], [LastName], [Email], [Password], [BloodGroup], [Gender], [PhoneNo], [Address], [EmergencyContact]) VALUES (N'1002', N'karthik', N'Kumar', N'karth12@gmail.com', N'karthi!234', N'B+', N'Male', N'987612345', N'Chennai', N'6758943210')
INSERT [dbo].[Prec] ([PatientName], [DoctorName], [Problem], [Medicine], [Morning], [Afternoon], [Night]) VALUES (N'jack', N'sagar', N'fever', N'dolo', N'yes', N'yes', N'yes')
INSERT [dbo].[Prec] ([PatientName], [DoctorName], [Problem], [Medicine], [Morning], [Afternoon], [Night]) VALUES (N'jack', N'sagar', N'fever', N'dolo', N'yes', N'no', N'no')
SET IDENTITY_INSERT [dbo].[profiles] ON 

INSERT [dbo].[profiles] ([PatientId], [UserName], [FirstName], [LastName], [Email], [Password], [BloodGroup], [Gender], [Age], [PhoneNo], [Address], [EmergencyContact], [Type]) VALUES (CAST(1 AS Numeric(30, 0)), N'admin', N'Bhargavi', N'S', N'bhargavisangareddy@gmail.com', N'Admin@123', N'B+', N'Female', N'24', N'7095347770', N'Secunderabad,Telangana', N'', 1)
INSERT [dbo].[profiles] ([PatientId], [UserName], [FirstName], [LastName], [Email], [Password], [BloodGroup], [Gender], [Age], [PhoneNo], [Address], [EmergencyContact], [Type]) VALUES (CAST(2 AS Numeric(30, 0)), N'adminbloodbank', N'Mercy', N'Anthoni', N'mercyanthoni2@gmail.com', N'Admin@123', N'O+', N'Female', N'22', N'8976554221', N'Hyderabad', N'', 2)
INSERT [dbo].[profiles] ([PatientId], [UserName], [FirstName], [LastName], [Email], [Password], [BloodGroup], [Gender], [Age], [PhoneNo], [Address], [EmergencyContact], [Type]) VALUES (CAST(3 AS Numeric(30, 0)), N'patient', N'Virat', N'Kohli', N'virat@gmail.com', N'Admin@123', N'B+', N'Male', N'40', N'9182225321', N'Delhi', N'', 3)
INSERT [dbo].[profiles] ([PatientId], [UserName], [FirstName], [LastName], [Email], [Password], [BloodGroup], [Gender], [Age], [PhoneNo], [Address], [EmergencyContact], [Type]) VALUES (CAST(4 AS Numeric(30, 0)), N'receptionpatient', N'Virat', N'Kohli', N'anandkohli909@gmail.com', N'Admin@123', N'B+', N'Male', N'35', N'09182225321', N'Delhi', N'8978568838', 4)
INSERT [dbo].[profiles] ([PatientId], [UserName], [FirstName], [LastName], [Email], [Password], [BloodGroup], [Gender], [Age], [PhoneNo], [Address], [EmergencyContact], [Type]) VALUES (CAST(5 AS Numeric(30, 0)), N'receptionadmin', N'Andrew', N'Fletcher', N'Fletcher@gmail.com', N'Admin@123', N'B-', N'm', N'27', N'9182225321', N'jamica', N'987654321', 5)
SET IDENTITY_INSERT [dbo].[profiles] OFF
INSERT [dbo].[Registration] ([UserName], [FirstName], [LastName], [Password], [Email], [PhoneNumber], [Gender]) VALUES (N'Anand sagar', N'anand', N'sagar', N'badboy@123', N'anandasagar@iitsofttech.com', N'08978568838', N'M')
INSERT [dbo].[Registration] ([UserName], [FirstName], [LastName], [Password], [Email], [PhoneNumber], [Gender]) VALUES (N'anand', N'mb', N'sri', N'kjh', N'anandasagar@iitsofttech.com', N'08978568838', N'male')
INSERT [dbo].[Registration] ([UserName], [FirstName], [LastName], [Password], [Email], [PhoneNumber], [Gender]) VALUES (N'Anand sagar Matta', N'anand', N' sagar', N'anand@123', N'anandasagar@iitsofttech.com', N'9182225321', N'male')
INSERT [dbo].[Registration] ([UserName], [FirstName], [LastName], [Password], [Email], [PhoneNumber], [Gender]) VALUES (N'Anand sagar Matta', N'mb', N'sri', N'33333', N'anandasagar@iitsofttech.com', N'08978568838', N'male')
INSERT [dbo].[Registration] ([UserName], [FirstName], [LastName], [Password], [Email], [PhoneNumber], [Gender]) VALUES (N'King Kohli', N'virat', N'kohli', N'1818', N'virat@gmail.com', N'08978568838', N'male')
INSERT [dbo].[Registration] ([UserName], [FirstName], [LastName], [Password], [Email], [PhoneNumber], [Gender]) VALUES (N'', N'', N'', N'', N'', N'', N'')
INSERT [dbo].[Registration] ([UserName], [FirstName], [LastName], [Password], [Email], [PhoneNumber], [Gender]) VALUES (N'sdgh', N'fghjkj', N'sdfgh', N'fghj', N'asdfgh', N'dfdgh', N'female')
INSERT [dbo].[Registration] ([UserName], [FirstName], [LastName], [Password], [Email], [PhoneNumber], [Gender]) VALUES (N'Bhargavi', N'Bhargavi', N'S', N'B@rgavi123', N'bhargavi11@gmail.com', N'', N'')
INSERT [dbo].[Registration] ([UserName], [FirstName], [LastName], [Password], [Email], [PhoneNumber], [Gender]) VALUES (N'Bhargavi', N'Bhargavi', N'S', N'B@ru110299', N'bhargavi11@gmail.com', N'', N'')
SET IDENTITY_INSERT [dbo].[RejectedBloodRequests] ON 

INSERT [dbo].[RejectedBloodRequests] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (1, N'maloth', N'Bindu', N'rockey@123', N'A-', N'1.5L')
INSERT [dbo].[RejectedBloodRequests] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (2, N'Lakavath', N'Bindu', N'Bindu@123', N'A+', N'1.5L')
INSERT [dbo].[RejectedBloodRequests] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (3, N'Lakavath', N'Linga', N'linga@gmail.com', N'A+', N'2L')
INSERT [dbo].[RejectedBloodRequests] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (4, N'Bhukya', N'Linga', N'linga@gmail.com', N'B+', N'1.5L')
INSERT [dbo].[RejectedBloodRequests] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (5, N'Bhukya', N'Linga', N'linga@gmail.com', N'B+', N'1.5L')
INSERT [dbo].[RejectedBloodRequests] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (6, N'maloth', N'Bindu', N'rockey@123', N'A-', N'1.5L')
INSERT [dbo].[RejectedBloodRequests] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (7, N'Bhukya', N'Linga', N'linga@gmail.com', N'B+', N'1.5L')
INSERT [dbo].[RejectedBloodRequests] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (8, N'Lakavath', N'Linga', N'linga@gmail.com', N'A+', N'2L')
INSERT [dbo].[RejectedBloodRequests] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (1002, N'Bhukya', N'Linga', N'raj@gmail.com', N'A-', N'0.050 L')
INSERT [dbo].[RejectedBloodRequests] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (1003, N'lakavath', N'tharun', N'tharun@gmail.com', N'A-', N'0.050 L')
SET IDENTITY_INSERT [dbo].[RejectedBloodRequests] OFF
SET IDENTITY_INSERT [dbo].[RejectedDonors] ON 

INSERT [dbo].[RejectedDonors] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (1, N'Lakavath', N'Linga', N'linga@gmail.com', N'A+', N'500ml')
INSERT [dbo].[RejectedDonors] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (2, N'Lakavath', N'Linga', N'linga@gmail.com', N'A+', N'700ml')
INSERT [dbo].[RejectedDonors] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (3, N'Lakavath', N'Linga', N'linga@gmail.com', N'A+', N'0.200 L')
INSERT [dbo].[RejectedDonors] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (4, N'Bhukya', N'Linga', N'linganaik@gmail.com', N'AB+', N'0.050 L')
INSERT [dbo].[RejectedDonors] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (5, N'Lakavath', N'Linga', N'linga@gmail.com', N'A+', N'500ml')
INSERT [dbo].[RejectedDonors] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (6, N'Lakavath', N'Linga', N'linga@gmail.com', N'A+', N'500ml')
INSERT [dbo].[RejectedDonors] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (7, N'Lakavath', N'Linga', N'linga@gmail.com', N'A+', N'2L')
INSERT [dbo].[RejectedDonors] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (8, N'Bhukya', N'Linga', N'linganaik@gmail.com', N'AB+', N'0.050 L')
INSERT [dbo].[RejectedDonors] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (1002, N'Bhukya', N'Linga', N'linga@gmail.com', N'A-', N'0.600 L')
INSERT [dbo].[RejectedDonors] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (1003, N'RAj', N'Raj', N'raj@gmail.com', N'A-', N'0.050 L')
INSERT [dbo].[RejectedDonors] ([Id], [FirstName], [LastName], [EmailId], [BloodGroup], [Quantity]) VALUES (1004, N'dafdg', N'sfdg', N'wsg@gmail.com', N'A+', N'0.002 L')
SET IDENTITY_INSERT [dbo].[RejectedDonors] OFF
INSERT [dbo].[SheduleAd] ([Id], [DoctorName], [StartTime], [EndTime], [status]) VALUES (1, N'anand', N'18:41', N'19:41', N'Active')
INSERT [dbo].[SheduleAd] ([Id], [DoctorName], [StartTime], [EndTime], [status]) VALUES (2, N'Surya', N'15:00', N'20:02', N'Active')
SET IDENTITY_INSERT [dbo].[UserInfo] ON 

INSERT [dbo].[UserInfo] ([Id], [FirstName], [LastName], [EmailId], [Password], [DateOfBirth], [PhoneNumber], [Address]) VALUES (1, N'Bhukya', N'Linga', N'linga@gmail.com', N'Admin@123', N'2024-11-08', N'8688841715', N'Hyderabad')
INSERT [dbo].[UserInfo] ([Id], [FirstName], [LastName], [EmailId], [Password], [DateOfBirth], [PhoneNumber], [Address]) VALUES (2, N'Anand', N'Sagar', N'anand@gmail.com', N'1234', N'2024-11-05', N'9989511828', N'Hyderabad')
INSERT [dbo].[UserInfo] ([Id], [FirstName], [LastName], [EmailId], [Password], [DateOfBirth], [PhoneNumber], [Address]) VALUES (3, N'lakavath', N'tharun', N'tharun@gmail.com', N'1234', N'2024-11-01', N'8688841715', N'Hyderabad')
INSERT [dbo].[UserInfo] ([Id], [FirstName], [LastName], [EmailId], [Password], [DateOfBirth], [PhoneNumber], [Address]) VALUES (4, N'lokesh', N'kumar', N'lokesh@gmail.com', N'1234', N'2024-11-05', N'9989511828', N'Hyderabad')
SET IDENTITY_INSERT [dbo].[UserInfo] OFF
INSERT [dbo].[Usertypes] ([Id], [Roles], [Type]) VALUES (1, N'Admin', 1)
INSERT [dbo].[Usertypes] ([Id], [Roles], [Type]) VALUES (2, N'Doctor', 2)
INSERT [dbo].[Usertypes] ([Id], [Roles], [Type]) VALUES (3, N'Patient', 3)
INSERT [dbo].[Usertypes] ([Id], [Roles], [Type]) VALUES (4, N'Staff', 4)
INSERT [dbo].[Usertypes] ([Id], [Roles], [Type]) VALUES (5, N'Reception', 5)
INSERT [dbo].[Usertypes] ([Id], [Roles], [Type]) VALUES (6, N'Nurses', 6)
SET IDENTITY_INSERT [dbo].[vaccine] ON 

INSERT [dbo].[vaccine] ([PatientID], [PatientName], [Age], [DoctorName], [VaccineType], [VaccineId], [DateofVaccination], [Dosage], [FollowupDate], [NextDueDate], [ReactionType], [Status]) VALUES (1, N'Arjun', N'35', N'Adhiti', N'covi-shield', N'1', N'2024-11-13', N'1st Dose', N'2025-06-11', N'2025-09-10', N'No', N'Not-Vaccinated')
INSERT [dbo].[vaccine] ([PatientID], [PatientName], [Age], [DoctorName], [VaccineType], [VaccineId], [DateofVaccination], [Dosage], [FollowupDate], [NextDueDate], [ReactionType], [Status]) VALUES (12, N'fgdg', N'sf', N'sdgddfh', N'Covishield', N'4', N'2024-11-01', N'1', N'2024-11-23', N'2024-11-26', N'no', N'Vaccinated')
SET IDENTITY_INSERT [dbo].[vaccine] OFF
SET IDENTITY_INSERT [dbo].[VisitTypes] ON 

INSERT [dbo].[VisitTypes] ([VisitTypeId], [Typename]) VALUES (1, N'InPatient')
INSERT [dbo].[VisitTypes] ([VisitTypeId], [Typename]) VALUES (2, N'OutPatient')
SET IDENTITY_INSERT [dbo].[VisitTypes] OFF
INSERT [dbo].[Ward] ([Id], [Name], [Department], [Designation], [Education], [PhoneNumber], [Gender], [Status]) VALUES (1, N'sagar', N'cardio', N'doctor', N'Mbbs', N'7655342375', N'Male', N'Active')
INSERT [dbo].[Ward] ([Id], [Name], [Department], [Designation], [Education], [PhoneNumber], [Gender], [Status]) VALUES (2, N'sagar', N'cardio', N'hhh', N'bn', N'08978568838', N'm', N'uy')
INSERT [dbo].[Ward] ([Id], [Name], [Department], [Designation], [Education], [PhoneNumber], [Gender], [Status]) VALUES (3, N'sagar', N'cardio', N'hhh', N'bn', N'08978568838', N'm', N'uy')
INSERT [dbo].[Ward] ([Id], [Name], [Department], [Designation], [Education], [PhoneNumber], [Gender], [Status]) VALUES (4, N'mb sri', N'w', N'hhh', N'bn', N'08978568838', N'm', N'AAAA')
INSERT [dbo].[Ward] ([Id], [Name], [Department], [Designation], [Education], [PhoneNumber], [Gender], [Status]) VALUES (11, N'arun', N'cardio', N'hhh', N's', N'09182225321', N'male', N'opp')
ALTER TABLE [dbo].[MedicineAd]  WITH CHECK ADD  CONSTRAINT [fk] FOREIGN KEY([PatientId])
REFERENCES [dbo].[profiles] ([PatientId])
GO
ALTER TABLE [dbo].[MedicineAd] CHECK CONSTRAINT [fk]
GO
ALTER TABLE [dbo].[modifiers]  WITH CHECK ADD FOREIGN KEY([ServiceCode])
REFERENCES [dbo].[Service] ([ServiceCode])
GO
ALTER TABLE [dbo].[patient]  WITH CHECK ADD  CONSTRAINT [foreignkey] FOREIGN KEY([InsuranceID])
REFERENCES [dbo].[Insurance] ([InsuranceId])
GO
ALTER TABLE [dbo].[patient] CHECK CONSTRAINT [foreignkey]
GO
ALTER TABLE [dbo].[profiles]  WITH CHECK ADD  CONSTRAINT [fk7] FOREIGN KEY([Type])
REFERENCES [dbo].[Usertypes] ([Type])
GO
ALTER TABLE [dbo].[profiles] CHECK CONSTRAINT [fk7]
GO
