CREATE PROC AddEmployee (
    @PersonID INT,
    @Salary DECIMAL(10, 2),
    @WorkHours INT,
    @EmployeeID INT OUTPUT
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM [dbo].[Person] WHERE IDPerson = @PersonID)
    BEGIN
        INSERT INTO Employee (EmployeeID, Salary, WorkHours, PersonID)
        VALUES (NEXT VALUE FOR Sequence_EmployeeID, @Salary, @WorkHours, @PersonID);
        
        SET @EmployeeID = SCOPE_IDENTITY();
    END
    ELSE
    BEGIN
        SET @EmployeeID = -1; 
    END
END;
