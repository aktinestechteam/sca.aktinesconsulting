CREATE PROCEDURE [dbo].[SCAExceptionFieldTypes_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT SCAExceptionFieldTypeId,[Name] 
	FROM [dbo].SCAExceptionFieldTypes 
	ORDER BY [Name] 
END