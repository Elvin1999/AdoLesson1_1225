CREATE PROCEDURE sp_ShowStudentsByGroupId
@groupId INT
AS
BEGIN
	SELECT S.Firstname , S.Lastname , G.[Name]
	FROM Students AS S
	INNER JOIN Groups AS G
	ON G.Id=S.Id_Group
	WHERE G.Id=@groupId
	
END
