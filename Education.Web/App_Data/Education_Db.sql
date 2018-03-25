USE [Education_Db]
GO
/****** Object:  Table [dbo].[StudentInformation]    Script Date: 03/24/2018 15:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentInformation](
	[StudentId] [int] IDENTITY(1,1) NOT NULL,
	[StudentCode] [varchar](50) NOT NULL,
	[StudentName] [nvarchar](150) NOT NULL,
	[FatherName] [nvarchar](150) NOT NULL,
	[MotherName] [nvarchar](150) NOT NULL,
	[DateOfBirth] [datetime] NOT NULL,
	[RollNo] [nvarchar](50) NOT NULL,
	[Pic] [image] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_StudentInformation] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentAttendance]    Script Date: 03/24/2018 15:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAttendance](
	[AttendanceId] [int] IDENTITY(1,1) NOT NULL,
	[AttendanceStudentId] [int] NOT NULL,
	[AttendanceDate] [datetime] NOT NULL,
	[IsPresent] [bit] NOT NULL,
	[Status] [int] NOT NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_StudentAttendance] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[StudentAttendanceView]    Script Date: 03/24/2018 15:58:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentAttendanceView]
AS
SELECT     dbo.StudentAttendance.AttendanceId, dbo.StudentAttendance.AttendanceStudentId, dbo.StudentInformation.StudentCode, dbo.StudentInformation.StudentName, 
                      dbo.StudentAttendance.AttendanceDate, dbo.StudentAttendance.IsPresent
FROM         dbo.StudentAttendance INNER JOIN
                      dbo.StudentInformation ON dbo.StudentAttendance.AttendanceStudentId = dbo.StudentInformation.StudentId
GO

/****** Object:  ForeignKey [FK_StudentAttendance_StudentInformation]    Script Date: 03/24/2018 15:58:47 ******/
ALTER TABLE [dbo].[StudentAttendance]  WITH CHECK ADD  CONSTRAINT [FK_StudentAttendance_StudentInformation] FOREIGN KEY([AttendanceStudentId])
REFERENCES [dbo].[StudentInformation] ([StudentId])
GO
ALTER TABLE [dbo].[StudentAttendance] CHECK CONSTRAINT [FK_StudentAttendance_StudentInformation]
GO
