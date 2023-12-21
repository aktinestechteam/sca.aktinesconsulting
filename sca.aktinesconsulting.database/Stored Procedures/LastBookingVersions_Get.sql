CREATE PROCEDURE [dbo].[LastBookingVersions_Get]
AS   
BEGIN
	SELECT LastBookingVersionId, [Type], [Value] 
	FROM [dbo].LastBookingVersions 
	ORDER BY LastBookingVersionId
END