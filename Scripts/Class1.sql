CREATE OR ALTER PROCEDURE GetTeacher
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

CREATE OR ALTER PROCEDURE GetStudentsByClass
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
        S.Scholarship
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

CREATE OR ALTER PROCEDURE AddStudentToClass
    @StudentID INT,
    @ClassID INT,
    @Grade FLOAT 
AS
BEGIN
    INSERT INTO StudentClass (StudentID, ClassID, Grade)
    VALUES (@StudentID, @ClassID, @Grade);
END;
GO

CREATE OR ALTER PROCEDURE GetClassesOfStudent
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

CREATE OR ALTER PROCEDURE GetClassesOfTeacher
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

CREATE OR ALTER PROCEDURE AddClass
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



CREATE OR ALTER PROCEDURE GetClasses
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

