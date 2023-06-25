CREATE PROCEDURE [dbo].[SCAVersions_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT u.UserName, SCAVersionId,v.CreatedOn,v.UserId,u.FirstName,u.LastName 
	FROM [dbo].[SCAVersions] v
	INNER JOIN [dbo].Users u ON u.UserId=v.UserId Order BY SCAVersionId
END