CREATE PROCEDURE [dbo].[SCAExceptions_GetById] @SCAExceptionId INT
AS
BEGIN
SELECT * FROM [dbo].[SCAExceptions] WHERE SCAExceptionId=@SCAExceptionId
END