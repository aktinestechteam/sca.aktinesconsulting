CREATE PROCEDURE SCAExceptionFields_GetAll
AS
BEGIN
	SET NOCOUNT ON;
	SELECT SCAExceptionFieldId,SCAExceptionFieldTypeId,[Name] 
	FROM [dbo].SCAExceptionFields 
	ORDER BY SCAExceptionFieldTypeId,[Name] 
END
GO