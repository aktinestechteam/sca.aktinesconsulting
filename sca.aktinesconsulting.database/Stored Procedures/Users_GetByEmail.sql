CREATE PROCEDURE [dbo].[Users_GetByEmail] @Email varchar(30), @Password nvarchar(50)
AS
BEGIN
SELECT * FROM [dbo].[Users] WHERE Email=@Email AND [Password]=@Password
END