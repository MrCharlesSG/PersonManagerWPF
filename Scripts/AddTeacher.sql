CREATE PROCEDURE AddTeacher (
    @PersonID INT,
    @Salary DECIMAL(10, 2),
    @ClassID INT,
    @TeacherID INT OUTPUT
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [dbo].[Person] WHERE IDPerson = @PersonID)
    BEGIN
        IF EXISTS (SELECT 1 FROM Class WHERE ClassID = @ClassID)
        BEGIN
            INSERT INTO Teacher (TeacherID, Salary, PersonID, ClassID)
            VALUES (NEXT VALUE FOR Sequence_TeacherID, @Salary, @PersonID, @ClassID);
            
            SET @TeacherID = SCOPE_IDENTITY();
        END
        ELSE
        BEGIN
            SET @TeacherID = -2; 
        END
    END
    ELSE
    BEGIN
        SET @TeacherID = -1; 
    END
END;
