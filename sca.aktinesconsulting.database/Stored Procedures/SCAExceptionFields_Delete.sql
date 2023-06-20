CREATE PROCEDURE [dbo].[SCAExceptionFields_Delete]
		   @SCAExceptionFieldId INT
AS
BEGIN
UPDATE [dbo].SCAExceptionFields  SET IsActive=0 
WHERE SCAExceptionFieldId=@SCAExceptionFieldId
END