/****** Object:  Database [carlos-algebra]    Script Date: 11/27/2023 5:52:32 PM ******/
CREATE DATABASE [carlos-algebra]  (EDITION = 'Basic', SERVICE_OBJECTIVE = 'Basic', MAXSIZE = 2 GB) WITH CATALOG_COLLATION = SQL_Latin1_General_CP1_CI_AS, LEDGER = OFF;
GO
ALTER DATABASE [carlos-algebra] SET COMPATIBILITY_LEVEL = 150
GO
ALTER DATABASE [carlos-algebra] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [carlos-algebra] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [carlos-algebra] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [carlos-algebra] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [carlos-algebra] SET ARITHABORT OFF 
GO
ALTER DATABASE [carlos-algebra] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [carlos-algebra] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [carlos-algebra] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [carlos-algebra] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [carlos-algebra] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [carlos-algebra] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [carlos-algebra] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [carlos-algebra] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [carlos-algebra] SET ALLOW_SNAPSHOT_ISOLATION ON 
GO
ALTER DATABASE [carlos-algebra] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [carlos-algebra] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [carlos-algebra] SET  MULTI_USER 
GO
ALTER DATABASE [carlos-algebra] SET ENCRYPTION ON
GO
ALTER DATABASE [carlos-algebra] SET QUERY_STORE = ON
GO
ALTER DATABASE [carlos-algebra] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 7), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 10, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
/*** The scripts of database scoped configurations in Azure should be executed inside the target database connection. ***/
GO
-- ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 8;
GO
/****** Object:  Table [dbo].[Class]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [varchar](255) NULL,
	[Room] [varchar](50) NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[TeacherID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Salary] [decimal](10, 2) NULL,
	[WorkHours] [int] NULL,
	[IDPerson] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[IDPerson] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[Age] [int] NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Picture] [varbinary](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPerson] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[GPA] [decimal](4, 2) NULL,
	[Scholarship] [decimal](10, 2) NULL,
	[IDPerson] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentClass]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentClass](
	[StudentID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[Grade] [float] NULL,
 CONSTRAINT [PK_StudentClass] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC,
	[ClassID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[Salary] [decimal](10, 2) NULL,
	[IDPerson] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [FK_Class_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [FK_Class_Teacher]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([IDPerson])
REFERENCES [dbo].[Person] ([IDPerson])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([IDPerson])
REFERENCES [dbo].[Person] ([IDPerson])
GO
ALTER TABLE [dbo].[StudentClass]  WITH CHECK ADD  CONSTRAINT [FK_StudentClass_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO
ALTER TABLE [dbo].[StudentClass] CHECK CONSTRAINT [FK_StudentClass_Class]
GO
ALTER TABLE [dbo].[StudentClass]  WITH CHECK ADD  CONSTRAINT [FK_StudentClass_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
GO
ALTER TABLE [dbo].[StudentClass] CHECK CONSTRAINT [FK_StudentClass_Student]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD FOREIGN KEY([IDPerson])
REFERENCES [dbo].[Person] ([IDPerson])
GO
/****** Object:  StoredProcedure [dbo].[AddClass]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[AddClass]
    @StartTime TIME,
    @EndTime TIME,
    @Room NVARCHAR(50),
    @SubjectName NVARCHAR(255),
    @TeacherID INT,
	@ClassID INT OUTPUT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Teacher WHERE TeacherID = @TeacherID)
    BEGIN
        SELECT -1 AS ClassID;  
        RETURN;
    END

    INSERT INTO Class (StartTime, EndTime, Room, SubjectName, TeacherID)
    VALUES (@StartTime, @EndTime, @Room, @SubjectName, @TeacherID);

    SET @ClassID = SCOPE_IDENTITY();
    SELECT @ClassID AS ClassID;
END;
GO
/****** Object:  StoredProcedure [dbo].[AddEmployee]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- AddEmployee Procedure
CREATE   PROCEDURE [dbo].[AddEmployee] (
    @IDPerson INT,
    @Salary DECIMAL(10, 2),
    @WorkHours INT,
    @EmployeeID INT OUTPUT
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [dbo].[Person] WHERE IDPerson = @IDPerson)
    BEGIN
        INSERT INTO Employee (Salary, WorkHours, IDPerson)
        VALUES (@Salary, @WorkHours, @IDPerson);
        
        SET @EmployeeID = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        SET @EmployeeID = -1; 
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[AddPerson]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[AddPerson]
	@firstname nvarchar(20),
	@lastname nvarchar(20),
	@age int,
	@email nvarchar(30),
	@picture varbinary(max),
	@idPerson INT OUTPUT
AS 
BEGIN
INSERT INTO Person VALUES (@firstname, @lastname, @age, @email, @picture)
	SET @idPerson = SCOPE_IDENTITY()
END
GO
/****** Object:  StoredProcedure [dbo].[AddStudent]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- AddStudent Procedure
CREATE   PROCEDURE [dbo].[AddStudent] (
    @IDPerson INT,
    @GPA DECIMAL(4, 2),
    @Scholarship DECIMAL(10, 2),
    @StudentID INT OUTPUT
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [dbo].[Person] WHERE IDPerson = @IDPerson)
    BEGIN
        INSERT INTO Student (GPA, Scholarship, IDPerson)
        VALUES (@GPA, @Scholarship, @IDPerson);
        
        SET @StudentID = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        SET @StudentID = -1;
    END

    IF @StudentID IS NULL
    BEGIN
        SET @StudentID = -1;
    END

    SELECT @StudentID;
END;

GO
/****** Object:  StoredProcedure [dbo].[AddStudentToClass]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[AddStudentToClass]
    @StudentID INT,
    @ClassID INT,
    @Grade FLOAT 
AS
BEGIN
    INSERT INTO StudentClass (StudentID, ClassID, Grade)
    VALUES (@StudentID, @ClassID, @Grade);
END;
GO
/****** Object:  StoredProcedure [dbo].[AddTeacher]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--AddTeacher procedure
CREATE   PROCEDURE [dbo].[AddTeacher] (
    @IDPerson INT,
    @Salary DECIMAL(10, 2),
    @TeacherID INT OUTPUT
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [dbo].[Person] WHERE IDPerson = @IDPerson)
    BEGIN
            INSERT INTO Teacher (Salary, IDPerson)
            VALUES (@Salary, @IDPerson);
            
            SET @TeacherID = SCOPE_IDENTITY();
        END
    ELSE
    BEGIN
        SET @TeacherID = -1; 
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteClass]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[DeleteClass]
    @ClassID INT
AS
BEGIN
    DELETE FROM StudentClass WHERE ClassID = @ClassID;

    DELETE FROM Class WHERE ClassID = @ClassID;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeletePerson]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[DeletePerson]
    @IDPerson INT,
    @Result INT OUTPUT
AS
BEGIN
    SET @Result = -1;

    IF NOT EXISTS (SELECT 1 FROM [dbo].[Class] C INNER JOIN [dbo].[Teacher] T ON C.TeacherID = T.TeacherID WHERE T.IDPerson = @IDPerson)
    BEGIN
	    DELETE FROM [dbo].StudentClass WHERE StudentID IN (SELECT StudentID FROM [dbo].Student WHERE IDPerson = @IDPerson);
        DELETE FROM [dbo].Student WHERE IDPerson = @IDPerson;
        DELETE FROM [dbo].Teacher WHERE IDPerson = @IDPerson;
        DELETE FROM [dbo].Employee WHERE IDPerson = @IDPerson;
        DELETE FROM [dbo].[Person] WHERE IDPerson = @IDPerson;
        SET @Result = 1;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteStudentClass]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create   Proc [dbo].[DeleteStudentClass]
@ClassID INT,
@StudentID INT
AS
BEGIN
    DELETE FROM StudentClass WHERE ClassID = @ClassID and @StudentID = StudentID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetClass]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE   PROC [dbo].[GetClass] (
    @ClassID INT
)
AS
BEGIN
    SELECT
        ClassID,
        SubjectName,
        Room,
        StartTime,
        EndTime
    FROM
        Class
    WHERE
        ClassID = @ClassID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetClasses]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE   PROCEDURE [dbo].[GetClasses]
AS
BEGIN
    SELECT
        C.ClassID,
        C.SubjectName,
        C.StartTime,
        C.EndTime,
        C.Room,
        C.TeacherID AS TeacherID
    FROM
        Class AS C;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetClassesOfStudent]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[GetClassesOfStudent]
    @StudentID INT
AS
BEGIN
    SELECT
        C.ClassID,
        C.SubjectName,
		C.EndTime,
		C.StartTime,
		C.Room,
        SC.Grade,
        T.TeacherID
    FROM
        Class AS C
    JOIN
        StudentClass AS SC ON C.ClassID = SC.ClassID
    JOIN
        Teacher AS T ON C.TeacherID = T.TeacherID
    WHERE
        SC.StudentID = @StudentID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetClassesOfTeacher]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[GetClassesOfTeacher]
    @TeacherID INT
AS
BEGIN
    SELECT
        ClassID,
        SubjectName,
		StartTime,
		EndTime,
		Room,
		TeacherID
    FROM
        Class
    WHERE
        TeacherID = @TeacherID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetEmployees]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[GetEmployees]
AS
BEGIN
    SELECT
        E.EmployeeID,
        P.FirstName,
        P.LastName,
        P.Age,
		P.Picture,
		P.IDPerson,
        P.Email,
        E.Salary,
        E.WorkHours
    FROM
        Employee AS E
    JOIN
        [dbo].[Person] AS P ON E.IDPerson = P.IDPerson;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetEmployeeWithIDPerson]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[GetEmployeeWithIDPerson]
	@idPerson int
AS
SELECT * FROM Employee WHERE IDPerson = @idPerson
GO
/****** Object:  StoredProcedure [dbo].[GetPeople]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[GetPeople]
AS
SELECT * FROM Person
GO
/****** Object:  StoredProcedure [dbo].[GetPerson]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[GetPerson]
	@idPerson int
AS
SELECT * FROM Person WHERE IDPerson = @idPerson
GO
/****** Object:  StoredProcedure [dbo].[GetStudents]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[GetStudents]
AS
BEGIN
    SELECT
        S.StudentID,
        P.FirstName,
        P.LastName,
        P.Age,
		P.Picture,
		P.IDPerson,
        P.Email,
        S.GPA,
        S.Scholarship
    FROM
        Student AS S
    JOIN
        [dbo].[Person] AS P ON S.IDPerson = P.IDPerson;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetStudentsByClass]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[GetStudentsByClass]
    @ClassID INT
AS
BEGIN
    SELECT
        S.StudentID,
        P.FirstName,
        P.LastName,
        P.Age,
        P.Email,
        P.Picture,
        S.GPA,
        S.Scholarship,
		P.IDPerson
    FROM
        dbo.StudentClass AS SC
    JOIN
        Student AS S ON SC.StudentID = S.StudentID
    JOIN
        Person AS P ON S.IDPerson = P.IDPerson
    WHERE
        SC.ClassID = @ClassID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetStudentWithIDPerson]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetStudentWithIDPerson]
	@idPerson int
AS
SELECT * FROM Student WHERE IDPerson = @idPerson
GO
/****** Object:  StoredProcedure [dbo].[GetTeacher]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE   PROCEDURE [dbo].[GetTeacher]
    @TeacherID INT
AS
BEGIN
    SELECT
        T.TeacherID,
        P.FirstName,
        P.LastName,
        P.Age,
        P.Picture,
        P.IDPerson,
        P.Email,
        T.Salary
    FROM
        Teacher AS T
    JOIN
        [dbo].[Person] AS P ON T.IDPerson = P.IDPerson
    WHERE
        T.TeacherID = @TeacherID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetTeachers]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[GetTeachers]
AS
BEGIN
    SELECT
        T.TeacherID,
        P.FirstName,
        P.LastName,
        P.Age,
		P.Picture,
		P.IDPerson,
        P.Email,
        T.Salary
    FROM
        Teacher AS T
    JOIN
        [dbo].[Person] AS P ON T.IDPerson = P.IDPerson
END;
GO
/****** Object:  StoredProcedure [dbo].[GetTeacherWithIDPerson]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[GetTeacherWithIDPerson]
	@idPerson int
AS
SELECT * FROM Teacher WHERE IDPerson = @idPerson
GO
/****** Object:  StoredProcedure [dbo].[UpdateClass]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[UpdateClass]
    @ClassID INT,
    @StartTime TIME,
    @EndTime TIME,
    @Room NVARCHAR(MAX),
    @SubjectName NVARCHAR(MAX),
    @TeacherID INT
AS
BEGIN

    -- Verificar si el profesor existe
    IF NOT EXISTS (SELECT 1 FROM [dbo].[Teacher] WHERE TeacherID = @TeacherID)
    BEGIN
        RETURN;
    END

    UPDATE [dbo].[Class]
    SET
        StartTime = @StartTime,
        EndTime = @EndTime,
        Room = @Room,
        SubjectName = @SubjectName,
        TeacherID = @TeacherID
    WHERE ClassID = @ClassID;
END;


GO
/****** Object:  StoredProcedure [dbo].[UpdateEmployee]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[UpdateEmployee] (
    @EmployeeID INT,
    @Salary DECIMAL(10, 2),
	@WorkHours int
)
AS
BEGIN
    UPDATE Employee
    SET
        Salary = @Salary,
		WorkHours = @WorkHours
    WHERE EmployeeID = @EmployeeID;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdatePerson]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[UpdatePerson]
	@firstname nvarchar(20),
	@lastname nvarchar(20),
	@age int,
	@email nvarchar(30),
	@picture varbinary(max),
	@idPerson int
AS
UPDATE Person SET 
		FirstName = @firstname,
		LastName = @lastname,
		Age = @age,
		Email = @email,
		Picture = @picture
	WHERE 
		IDPerson = @idPerson
GO
/****** Object:  StoredProcedure [dbo].[UpdateStudent]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[UpdateStudent] (
    @StudentID INT,
    @GPA DECIMAL(4, 2),
    @Scholarship DECIMAL(10, 2)
)
AS
BEGIN
    UPDATE Student
    SET
        GPA = @GPA,
        Scholarship = @Scholarship
    WHERE StudentID = @StudentID;
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateTeacher]    Script Date: 11/27/2023 5:52:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROC [dbo].[UpdateTeacher] (
    @TeacherID INT,
    @Salary DECIMAL(10, 2)
)
AS
BEGIN
    UPDATE Teacher
    SET
        Salary = @Salary
    WHERE TeacherID = @TeacherID;
END;
GO
ALTER DATABASE [carlos-algebra] SET  READ_WRITE 
GO
