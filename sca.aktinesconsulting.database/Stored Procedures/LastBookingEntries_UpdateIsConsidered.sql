CREATE PROCEDURE [dbo].[LastBookingEntries_UpdateIsConsidered]
@BookingEntryId INT,
@IsConsidered bit
AS   
BEGIN
		UPDATE [dbo].LastBookingEntries SET IsConsidered=@IsConsidered
		WHERE BookingEntryId=@BookingEntryId
END


