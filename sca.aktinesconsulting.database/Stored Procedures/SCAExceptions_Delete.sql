Create PROCEDURE [dbo].[SCAExceptions_Delete]
			@SCAExceptionId INT
			,@IsActive BIT=0
           ,@UpdatedOn  DATETIME = NULL
		   ,@UpdatedBy INT = NULL
AS
BEGIN
UPDATE [dbo].[SCAExceptions] SET
	   [IsActive]=@IsActive,
	   [UpdatedOn]=@UpdatedOn,
	   [UpdatedBy]=@UpdatedBy
	   WHERE SCAExceptionId=@SCAExceptionId
		SELECT @@ROWCOUNT
END
