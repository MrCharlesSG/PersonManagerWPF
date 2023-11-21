CREATE or ALTER PROC DeletePerson (
    @IDPerson INT
)
AS
BEGIN
    DELETE FROM [dbo].Student WHERE IDPerson = @IDPerson;

    DELETE FROM [dbo].Teacher WHERE IDPerson = @IDPerson;

    DELETE FROM [dbo].Employee WHERE IDPerson = @IDPerson;

    DELETE FROM [dbo].[Person] WHERE IDPerson = @IDPerson;
END;
GO

CREATE or ALTER PROC GetStudents
AS
BEGIN
    SELECT
        S.StudentID,
        P.FirstName,
        P.LastName,
        P.Age,
		P.Picture,
        P.Email,
        S.GPA,
        S.Scholarship
    FROM
        Student AS S
    JOIN
        [dbo].[Person] AS P ON S.IDPerson = P.IDPerson;
END;
GO

CREATE or ALTER PROC GetEmployees
AS
BEGIN
    SELECT
        E.EmployeeID,
        P.FirstName,
        P.LastName,
        P.Age,
        P.Email,
		P.Picture,
        E.Salary,
        E.WorkHours
    FROM
        Employee AS E
    JOIN
        [dbo].[Person] AS P ON E.IDPerson = P.IDPerson;
END;
GO

CREATE or ALTER PROC GetTeachers
AS
BEGIN
    SELECT
        T.TeacherID,
        P.FirstName,
        P.LastName,
        P.Age,
        P.Email,
        T.Salary
    FROM
        Teacher AS T
    JOIN
        [dbo].[Person] AS P ON T.IDPerson = P.IDPerson
END;
GO

CREATE OR ALTER PROC AddClass (
    @SubjectName VARCHAR(255),
    @Room VARCHAR(50),
    @StartTime TIME,
    @EndTime TIME,
    @ClassID INT OUTPUT
)
AS
BEGIN
    INSERT INTO Class (SubjectName, Room, StartTime, EndTime)
    VALUES (@SubjectName, @Room, @StartTime, @EndTime);

    SET @ClassID = SCOPE_IDENTITY();
END;
GO

CREATE or ALTER PROC UpdateClass (
    @ClassID INT,
    @SubjectName VARCHAR(255),
    @Room VARCHAR(50),
    @StartTime TIME,
    @EndTime TIME
)
AS
BEGIN
    UPDATE Class
    SET
        SubjectName = @SubjectName,
        Room = @Room,
        StartTime = @StartTime,
        EndTime = @EndTime
    WHERE ClassID = @ClassID;
END;
GO

CREATE or ALTER PROC UpdateStudent (
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

CREATE or ALTER PROC UpdateTeacher (
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

CREATE or ALter PROC UpdateEmployee (
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

--AddTeacher procedure
CREATE OR ALTER PROCEDURE AddTeacher (
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

-- AddEmployee Procedure
CREATE OR ALTER PROCEDURE AddEmployee (
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

-- AddStudent Procedure
CREATE OR ALTER PROCEDURE AddStudent (
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


CREATE or Alter PROC GetClass (
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