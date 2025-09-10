CREATE DATABASE ADODemoDB;
GO

USE ADODemoDB;
GO

CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Age INT,
    Course NVARCHAR(50)
);
GO

-- Insert sample data
INSERT INTO Students (Name, Age, Course) VALUES 
('Rushikesh', 22, 'Computer Science'),
('Anita', 21, 'IT'),
('Rohan', 23, 'Electronics');
GO

-- Stored Procedure
CREATE PROCEDURE GetStudentsByCourse
    @Course NVARCHAR(50)
AS
BEGIN
    SELECT * FROM Students WHERE Course = @Course;
END;
GO

USE ADODemoDB;
SELECT * FROM Students;


SELECT Name, Age, Course, COUNT(*) AS CountOfDuplicates
FROM Students
GROUP BY Name, Age, Course
HAVING COUNT(*) > 1;

;WITH CTE AS (
    SELECT 
        Id,
        ROW_NUMBER() OVER (PARTITION BY Name, Age, Course ORDER BY Id) AS RowNum
    FROM Students
)
DELETE FROM CTE WHERE RowNum > 1;


USE ADODemoDB;  
GO  




-- Example 1: Select query
SELECT * 
FROM Students 
WHERE Age > 21 
ORDER BY Name;

-- Example 2: Create stored procedure
CREATE PROCEDURE GetAllEmployees  
AS  
BEGIN  
    SELECT * FROM Employee;  
END;
GO
