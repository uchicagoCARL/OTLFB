--STEP ONE: CREATE DATABASE
CREATE DATABASE calendarsurvey 
GO

--STEP TWO: CREATE SQL SERVER USER
CREATE LOGIN cs_dbo WITH PASSWORD='cs_dbo123321qweewq';
USE calendarsurvey;
GO
CREATE USER cs_dbo FOR LOGIN cs_dbo;
GO
EXEC sp_addrolemember N'db_owner', N'cs_dbo'
GO

--STEP THREE: CREATE DATABASE OBJECTS
/****** Object:  Table [dbo].[operation]     ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [calendarsurvey].[dbo].[operation](
        [id] [int] NOT NULL,
        [operation] [nvarchar](50) NULL,
        [operationLink] [nvarchar](50) NULL,
        [description] [nvarchar](500) NULL,
        [role] [int] NULL
) ON [PRIMARY]
GO

INSERT [calendarsurvey].[dbo].[operation] ([id], [operation], [operationLink], [description], [role]) VALUES (9, N'Data Management', N'~/dataManagement.aspx', N'Administrator', 21)
INSERT [calendarsurvey].[dbo].[operation] ([id], [operation], [operationLink], [description], [role]) VALUES (2, N'Instructions', N'~/instructions.aspx', N'Every one', 9)
INSERT [calendarsurvey].[dbo].[operation] ([id], [operation], [operationLink], [description], [role]) VALUES (3, N'Users and Privileges', N'~/user/insertUser.aspx', N'Administrator', 21)


/****** Object:  Table [dbo].[investigators]    ******/
CREATE TABLE [calendarsurvey].[dbo].[investigators](
        [id] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
        [piName] [nvarchar](50) NULL,
        [role] [int] NULL,
        [lName] [nvarchar](50) NULL,
        [fName] [nvarchar](50) NULL,
        [degree] [nvarchar](50) NULL,
        [votingMember] [bit] NULL,
        [userName] [nvarchar](50) NULL,
        [password] [nvarchar](50) NULL,
        [email] [nvarchar](50) NULL,
        [phone] [nvarchar](50) NULL,
        [address] [nvarchar](50) NULL,
        [department] [nvarchar](50) NULL,
        [startDate] [nvarchar](50) NULL,
        [endDate] [nvarchar](50) NULL,
        [isLoginCalendarBegin] [bit] NULL,
        [smoke] [bit] NULL,
        [drink] [bit] NULL,
        [alcohol] [bit] NULL,
        [confirmAnswer] [bit] NULL,
        [ecig] [bit] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [calendarsurvey].[dbo].[investigators] ON
	INSERT [calendarsurvey].[dbo].[investigators] ([id], [role], [userName], [password]) VALUES (1, 21, N'csadmin', N'csadmin123')
SET IDENTITY_INSERT [calendarsurvey].[dbo].[investigators] OFF


/****** Object:  Table [dbo].[events]    ******/
CREATE TABLE [calendarsurvey].[dbo].[events](
        [eventID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
        [eventDate] [datetime] NULL,
        [eventText] [nvarchar](4000) NULL,
        [userAutoID] [nvarchar](50) NULL,
        [drink] [nvarchar](50) NULL,
        [smoke] [nvarchar](50) NULL,
        [dataTouch] [bit] NULL,
        [ecig] [nvarchar](50) NULL
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[users]    ******/
CREATE TABLE [calendarsurvey].[dbo].[users](
        [autoID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
        [userID] [nvarchar](50) NOT NULL,
        [password] [nvarchar](50) NULL,
        [role] [nvarchar](50) NULL,
        [lName] [nvarchar](50) NULL,
        [fName] [nvarchar](50) NULL,
        [email] [nvarchar](50) NULL,
        [startDate] [datetime] NULL,
        [endDate] [datetime] NULL,
        [calculateDate] [bit] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
        [userID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[userProperty]    ******/
CREATE TABLE [calendarsurvey].[dbo].[userProperty](
        [autoID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
        [userAutoID] [nvarchar](50) NULL,
        [startDate] [datetime] NULL,
        [endDate] [datetime] NULL
) ON [PRIMARY]
GO


/****** Object:  Table [dbo].[tempTableSearch]    ******/
CREATE TABLE [calendarsurvey].[dbo].[tempTableSearch](
        [userAutoID] [int] NULL,
        [lName] [nvarchar](50) NULL,
        [fName] [nvarchar](50) NULL,
        [userName] [nvarchar](50) NULL,
        [eventID] [int] NOT NULL,
        [eventDate] [datetime] NULL,
        [eventText] [nvarchar](4000) NULL,
        [drink] [nvarchar](50) NULL,
        [smoke] [nvarchar](50) NULL,
        [ecig] [nvarchar](50) NULL
) ON [PRIMARY]
GO


/****** Object:  StoredProcedure [dbo].[spCustomerLogin]    ******/
CREATE Procedure [dbo].[spCustomerLogin]
    (
        @userID     nvarchar(50),
        @Password   nvarchar(50),
        @autoID		int OUTPUT
    )
    AS
    SELECT
        @autoID = autoID
    FROM
       users
    WHERE
       userID = @userID
      AND
        Password = @Password
    IF @@Rowcount < 1
    SELECT
        @autoID = 0
GO


/****** Object:  StoredProcedure [dbo].[CustomerLogin]     ******/
CREATE PROCEDURE [dbo].[CustomerLogin] 
        @userName	nvarchar(50),
        @Password	nvarchar(50),
        @ID			int OUTPUT
AS
SELECT
        @ID = ID
    FROM
        investigators
    WHERE
       userName = @userName
      AND
        Password = @Password
    IF @@Rowcount < 1
    SELECT
        @ID = 0
GO


/****** Object:  StoredProcedure [dbo].[CustomerDetail]     ******/
CREATE PROCEDURE [dbo].[CustomerDetail]
        @ID int,
        @userName   nvarchar(50) OUTPUT,
        @FullName   nvarchar(50) OUTPUT,
        @lName		nvarchar(50) OUTPUT,
        @fName		nvarchar(50) OUTPUT,
        @Email      nvarchar(50) OUTPUT,
        @startDate  nvarchar(50) OUTPUT,
        @endDate	nvarchar(50) OUTPUT,
        @role       int OUTPUT,
        @address    nvarchar(200) OUTPUT,
        @phone		nvarchar(50) OUTPUT,
        @degree     nvarchar(50) OUTPUT,
        @drink      int OUTPUT,
        @smoke      int OUTPUT
AS
  SELECT
		@userName	= userName,
        @FullName	= piName,
        @lName		= lName,
        @fName		= fName,
        @Email		= Email,
        @startDate	= startDate,
        @endDate	= endDate,
        @role       = role,
        @address    = address,
        @phone      = phone,
        @degree     = degree,
        @drink		= drink,
        @smoke		= smoke
    FROM
        investigators
    WHERE
        ID = @ID
GO


/****** Object:  StoredProcedure [dbo].[CalendarDetails]     ******/
CREATE PROCEDURE [dbo].[CalendarDetails] 
        @eventID	int,
		@eventText  nvarchar(4000) OUTPUT,
        @eventDate  nvarchar(50) OUTPUT,
        @drink		nvarchar(50) Output,
        @smoke		nvarchar(50) Output
AS
SELECT
		@eventText	= eventText,
        @eventDate	= eventDate,
        @drink		= drink,
        @smoke		= smoke
    FROM
        events
    WHERE
        eventID = @eventID
GO


/****** Object:  Default [DF_events_dataTouch]     ******/
ALTER TABLE [calendarsurvey].[dbo].[events] ADD  CONSTRAINT [DF_events_dataTouch]  DEFAULT ((0)) FOR [dataTouch]
GO
/****** Object:  Default [DF_investigators_smoke]     ******/
ALTER TABLE [calendarsurvey].[dbo].[investigators] ADD  CONSTRAINT [DF_investigators_smoke]  DEFAULT (0) FOR [smoke]
GO
/****** Object:  Default [DF_investigators_drink]    ******/
ALTER TABLE [calendarsurvey].[dbo].[investigators] ADD  CONSTRAINT [DF_investigators_drink]  DEFAULT (0) FOR [drink]
GO
/****** Object:  Default [DF_investigators_confirmAnswer]    ******/
ALTER TABLE [calendarsurvey].[dbo].[investigators] ADD  CONSTRAINT [DF_investigators_confirmAnswer]  DEFAULT (0) FOR [confirmAnswer]
GO
