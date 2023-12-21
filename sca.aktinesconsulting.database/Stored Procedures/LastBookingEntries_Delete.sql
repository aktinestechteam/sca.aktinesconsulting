Create PROCEDURE [dbo].[LastBookingEntries_Delete]
@LastBookingVersionYearId INT,
@LastBookingVersionMonthId INT,
@LastBookingVersionDayId INT
AS
BEGIN
	DELETE FROM [dbo].LastBookingEntries 
	WHERE LastBookingVersionYearId=@LastBookingVersionYearId
		AND LastBookingVersionMonthId=@LastBookingVersionMonthId
		AND LastBookingVersionDayId=@LastBookingVersionDayId
END
