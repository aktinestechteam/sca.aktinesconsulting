CREATE PROCEDURE [dbo].[SCAExceptions_GetAll]
AS
BEGIN
SELECT * FROM [dbo].[SCAExceptions] WHERE IsActive=1
END
