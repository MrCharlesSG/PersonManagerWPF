CREATE TABLE Class (
    ClassID int primary key identity,
    SubjectName VARCHAR(255),
    Room VARCHAR(50),
    StartTime TIME,
    EndTime TIME
);

-- Create the 'Student' table
CREATE TABLE Student (
    StudentID int primary key identity,
    GPA INT,
    Scholarship INT,
    IDPerson INT,
    FOREIGN KEY (IDPerson) REFERENCES [dbo].[Person](IDPerson)
);

-- Create the 'Teacher' table
CREATE TABLE Teacher (
    TeacherID int primary key identity,
    Salary INT,
    IDPerson INT,
    ClassID INT,
    FOREIGN KEY (IDPerson) REFERENCES [dbo].[Person](IDPerson),
    FOREIGN KEY (ClassID) REFERENCES Class(ClassID)
);

-- Create the 'Employee' table
CREATE TABLE Employee (
    EmployeeID int primary key identity,
    Salary INT,
    WorkHours INT,
    IDPerson INT,
    FOREIGN KEY (IDPerson) REFERENCES [dbo].[Person](IDPerson)
);
