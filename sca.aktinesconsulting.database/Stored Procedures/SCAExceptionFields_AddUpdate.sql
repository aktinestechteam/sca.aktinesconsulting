CREATE PROCEDURE [dbo].[SCAExceptionFields_AddUpdate]
		   @SCAExceptionFieldTypeId INT,
		   @Name VARCHAR(100),
		   @UserId INT

AS
BEGIN

DECLARE @SCAExceptionFieldId INT
SELECT @SCAExceptionFieldId=SCAExceptionFieldId 
FROM [dbo].[SCAExceptionFields] 
WHERE SCAExceptionFieldTypeId=@SCAExceptionFieldTypeId AND [Name]=@Name

IF ISNULL(@SCAExceptionFieldId,0)>0
BEGIN
UPDATE [dbo].[SCAExceptionFields] SET UpdatedOn=GETUTCDATE(),UpdatedBy=@UserId
WHERE SCAExceptionFieldTypeId=@SCAExceptionFieldTypeId AND [Name]=@Name
SELECT @SCAExceptionFieldId
END
ELSE
BEGIN
INSERT INTO [dbo].[SCAExceptionFields]
           (SCAExceptionFieldTypeId
		    ,[Name]
           ,[CreatedOn]
		   ,[CreatedBy])
VALUES
			(
			@SCAExceptionFieldTypeId
           ,@Name
           ,GETUTCDATE()
           ,@UserId
			)
SELECT CAST(SCOPE_IDENTITY() as INT)
END
END


