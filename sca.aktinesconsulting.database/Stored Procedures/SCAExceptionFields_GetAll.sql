CREATE PROCEDURE SCAExceptionFields_GetAll
AS
BEGIN
	SET NOCOUNT ON;
	SELECT SCAExceptionFieldId,SCAExceptionFieldTypeId,[Name] 
	FROM [dbo].SCAExceptionFields WHERE IsActive=1
	ORDER BY SCAExceptionFieldTypeId,[Name] 
END
GO