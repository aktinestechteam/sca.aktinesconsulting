CREATE PROCEDURE [dbo].[LastBookingEntries_Get]
@LastBookingVersionYearId INT,
@LastBookingVersionMonthId INT,
@LastBookingVersionDayId INT
AS   
BEGIN
SELECT * FROM [dbo].LastBookingEntries lbe 
WHERE lbe.LastBookingVersionYearId= @LastBookingVersionYearId
	AND lbe.LastBookingVersionMonthId= @LastBookingVersionMonthId
	AND lbe.LastBookingVersionDayId = @LastBookingVersionDayId 
END  