CREATE PROCEDURE [dbo].[LastBookingEntries_IsExist]
@LastBookingVersionYearId INT,
@LastBookingVersionMonthId INT,
@LastBookingVersionDayId INT
AS   
BEGIN
IF(
		(	SELECT TOP 1 BookingEntryId FROM [dbo].LastBookingEntries lbe 
			WHERE lbe.LastBookingVersionYearId= @LastBookingVersionYearId
			AND lbe.LastBookingVersionMonthId= @LastBookingVersionMonthId
			AND lbe.LastBookingVersionDayId = @LastBookingVersionDayId 
		) > 0
	)
	SELECT 1
	ELSE
	SELECT 0
END
