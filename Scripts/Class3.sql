Create or Alter Proc DeleteStudentClass
@ClassID INT,
@StudentID INT
AS
BEGIN
    DELETE FROM StudentClass WHERE ClassID = @ClassID and @StudentID = StudentID;
END;
GO

CREATE OR ALTER PROCEDURE DeletePerson
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

CREATE OR ALTER PROCEDURE UpdateClass
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


