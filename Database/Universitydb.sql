USE [master]
GO
/****** Object:  Database [UniversityManagementDB]    Script Date: 3/23/2020 7:23:53 AM ******/
CREATE DATABASE [UniversityManagementDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'UniversityManagementDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityManagementDB.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'UniversityManagementDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\UniversityManagementDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [UniversityManagementDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [UniversityManagementDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [UniversityManagementDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [UniversityManagementDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [UniversityManagementDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [UniversityManagementDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [UniversityManagementDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [UniversityManagementDB] SET  MULTI_USER 
GO
ALTER DATABASE [UniversityManagementDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [UniversityManagementDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [UniversityManagementDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [UniversityManagementDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [UniversityManagementDB]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 3/23/2020 7:23:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseCode] [varchar](50) NOT NULL,
	[CourseName] [varchar](100) NOT NULL,
	[Credit] [float] NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[DeptId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CourseAssignTeacher]    Script Date: 3/23/2020 7:23:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CourseAssignTeacher](
	[CourseAssignId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
	[DeptId] [int] NOT NULL,
	[RemainingCredit] [float] NOT NULL,
 CONSTRAINT [PK_CourseAssignTeacher] PRIMARY KEY CLUSTERED 
(
	[CourseAssignId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 3/23/2020 7:23:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Departments](
	[DeptId] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Deparments] PRIMARY KEY CLUSTERED 
(
	[DeptId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Designation]    Script Date: 3/23/2020 7:23:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Designation](
	[DesignationId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
 CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
(
	[DesignationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaveTeacher]    Script Date: 3/23/2020 7:23:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaveTeacher](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NULL,
	[Address] [varchar](250) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Contact] [varchar](50) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DeptId] [int] NOT NULL,
	[Credit] [float] NOT NULL,
 CONSTRAINT [PK_SaveTeacher] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Semester]    Script Date: 3/23/2020 7:23:53 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Semester](
	[SemesterId] [int] IDENTITY(1,1) NOT NULL,
	[SemesterName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Semester] PRIMARY KEY CLUSTERED 
(
	[SemesterId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [Credit], [Description], [DeptId], [SemesterId]) VALUES (7, N'CSE-101', N'Computer Fundamental', 2, N'Basic Introductory of Computer', 1, 1)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [Credit], [Description], [DeptId], [SemesterId]) VALUES (8, N'CSE-201', N'Data Structure', 3, N'Basic Introductory of Algorithm', 1, 2)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [Credit], [Description], [DeptId], [SemesterId]) VALUES (9, N'CSE-202', N'Data Structure Sessional', 1.5, N'Basic Introductory of Algorithm', 1, 2)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [Credit], [Description], [DeptId], [SemesterId]) VALUES (10, N'CSE-201', N'Data Structure', 3, N'Basic Introductory of Algorithm', 2, 2)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [Credit], [Description], [DeptId], [SemesterId]) VALUES (11, N'CSE-201', N'Data Structure', 2, N'Basic Introductory of Algorithm', 3, 2)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [Credit], [Description], [DeptId], [SemesterId]) VALUES (12, N'CSE-203', N'Object Oriented Programming', 3, N'Opp concept', 1, 2)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [Credit], [Description], [DeptId], [SemesterId]) VALUES (13, N'CSE-203', N'Object Oriented Programming', 2, N'Opp concept', 2, 2)
INSERT [dbo].[Course] ([CourseId], [CourseCode], [CourseName], [Credit], [Description], [DeptId], [SemesterId]) VALUES (14, N'CSE-103', N'Object Oriented Programming', 2, N'Opp concept', 3, 1)
SET IDENTITY_INSERT [dbo].[Course] OFF
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([DeptId], [Code], [Name]) VALUES (1, N'CSE', N'Computer Science & Engineering')
INSERT [dbo].[Departments] ([DeptId], [Code], [Name]) VALUES (2, N'EEE', N'Electrical & Electronic Engineering')
INSERT [dbo].[Departments] ([DeptId], [Code], [Name]) VALUES (3, N'ETE', N'Electrical & Telecommunication Engineering')
INSERT [dbo].[Departments] ([DeptId], [Code], [Name]) VALUES (4, N'BBA', N'Business Administration')
INSERT [dbo].[Departments] ([DeptId], [Code], [Name]) VALUES (5, N'EB', N'Economic & Banking')
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[Designation] ON 

INSERT [dbo].[Designation] ([DesignationId], [Name]) VALUES (1, N'Professor')
INSERT [dbo].[Designation] ([DesignationId], [Name]) VALUES (2, N'Associate Professor')
INSERT [dbo].[Designation] ([DesignationId], [Name]) VALUES (3, N'Assitant Professor')
INSERT [dbo].[Designation] ([DesignationId], [Name]) VALUES (4, N'Lecturer')
INSERT [dbo].[Designation] ([DesignationId], [Name]) VALUES (5, N'Adj  Facutly')
SET IDENTITY_INSERT [dbo].[Designation] OFF
SET IDENTITY_INSERT [dbo].[SaveTeacher] ON 

INSERT [dbo].[SaveTeacher] ([TeacherId], [TeacherName], [Address], [Email], [Contact], [DesignationId], [DeptId], [Credit]) VALUES (3, NULL, N'Raf Raf Villa, Baizid Thana Road', N'khairulislam.azam@gmail.com', N'01829606862', 1, 1, 12)
INSERT [dbo].[SaveTeacher] ([TeacherId], [TeacherName], [Address], [Email], [Contact], [DesignationId], [DeptId], [Credit]) VALUES (4, NULL, N'Roksana Villa, Baizid Thana Road', N'misbah321@gmail.com', N'01829656454', 1, 2, 11)
INSERT [dbo].[SaveTeacher] ([TeacherId], [TeacherName], [Address], [Email], [Contact], [DesignationId], [DeptId], [Credit]) VALUES (5, NULL, N'Roksana Villa, Chawk Bazar', N'misbah1020@gmail.com', N'01725689450', 1, 3, 10)
INSERT [dbo].[SaveTeacher] ([TeacherId], [TeacherName], [Address], [Email], [Contact], [DesignationId], [DeptId], [Credit]) VALUES (6, NULL, N'1 kilo meter road, BohoddarHat', N'kalimchy@gmail.com', N'018269745955', 2, 1, 12)
INSERT [dbo].[SaveTeacher] ([TeacherId], [TeacherName], [Address], [Email], [Contact], [DesignationId], [DeptId], [Credit]) VALUES (7, N'Nazim Uddin', N'Raf Raf Villa, Baizid Thana Road', N'nazimUddin@gmail.com', N'01847238744', 3, 1, 12)
INSERT [dbo].[SaveTeacher] ([TeacherId], [TeacherName], [Address], [Email], [Contact], [DesignationId], [DeptId], [Credit]) VALUES (8, N'alom', N'Roksana Villa, Chawk Bazar', N'alom@gmail.com', N'0154564455', 4, 3, 15)
SET IDENTITY_INSERT [dbo].[SaveTeacher] OFF
SET IDENTITY_INSERT [dbo].[Semester] ON 

INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (1, N'1st')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (2, N'2nd')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (3, N'3rd')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (4, N'4th')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (5, N'5th')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (6, N'6th')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (7, N'7th')
INSERT [dbo].[Semester] ([SemesterId], [SemesterName]) VALUES (8, N'8th')
SET IDENTITY_INSERT [dbo].[Semester] OFF
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Departments] FOREIGN KEY([DeptId])
REFERENCES [dbo].[Departments] ([DeptId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Departments]
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Semester] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[Semester] ([SemesterId])
GO
ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Semester]
GO
ALTER TABLE [dbo].[CourseAssignTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignTeacher_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[CourseAssignTeacher] CHECK CONSTRAINT [FK_CourseAssignTeacher_Course]
GO
ALTER TABLE [dbo].[CourseAssignTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignTeacher_Departments] FOREIGN KEY([DeptId])
REFERENCES [dbo].[Departments] ([DeptId])
GO
ALTER TABLE [dbo].[CourseAssignTeacher] CHECK CONSTRAINT [FK_CourseAssignTeacher_Departments]
GO
ALTER TABLE [dbo].[CourseAssignTeacher]  WITH CHECK ADD  CONSTRAINT [FK_CourseAssignTeacher_SaveTeacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[SaveTeacher] ([TeacherId])
GO
ALTER TABLE [dbo].[CourseAssignTeacher] CHECK CONSTRAINT [FK_CourseAssignTeacher_SaveTeacher]
GO
USE [master]
GO
ALTER DATABASE [UniversityManagementDB] SET  READ_WRITE 
GO
