CREATE PROCEDURE [dbo].[BookingEntries_UpdateEmailDetails] 
@BookingEntryId INT,
@EmailWeight DECIMAL(18,4)=NULL,
@EmailVolume DECIMAL(18,4)=NULL,
@EmailRate DECIMAL(18,4)=NULL,
@EmailRevenue DECIMAL(18,4)=NULL,
@EmailIsCNFNReceived BIT=NULL,
@SCAIsApplicable BIT=NULL,
@EmailUpdatedBy INT=NULL
AS
BEGIN
	
	UPDATE [dbo].BookingEntries 
	SET EmailWeight=@EmailWeight, EmailVolume=@EmailVolume, EmailRate=@EmailRate,
		EmailRevenue=@EmailRevenue, EmailIsCNFNReceived=@EmailIsCNFNReceived,
		SCAIsApplicable=@SCAIsApplicable,EmailUpdatedBy=@EmailUpdatedBy,EmailUpdatedOn=GETUTCDATE()
	WHERE BookingEntryId=@BookingEntryId

	SELECT @@ROWCOUNT

END






