CREATE OR ALTER PROCEDURE DeleteClass
    @ClassID INT
AS
BEGIN
    DELETE FROM StudentClass WHERE ClassID = @ClassID;

    DELETE FROM Class WHERE ClassID = @ClassID;
END;
GO

CREATE or ALTER PROCEDURE DeleteStudentClass
	@StudentID int,
	@ClassID int
AS
BEGIN
    DELETE FROM StudentClass WHERE StudentID = @StudentID AND ClassID = @ClassID;
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
        DELETE FROM [dbo].Student WHERE IDPerson = @IDPerson;
        DELETE FROM [dbo].Teacher WHERE IDPerson = @IDPerson;
        DELETE FROM [dbo].Employee WHERE IDPerson = @IDPerson;
        DELETE FROM [dbo].[Person] WHERE IDPerson = @IDPerson;
        SET @Result = 1;
    END
END;
GO



