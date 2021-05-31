CREATE PROCEDURE spGetStudents
AS
BEGIN
     SELECT Id, fullName, Birthday, CIN
  FROM Student
END	