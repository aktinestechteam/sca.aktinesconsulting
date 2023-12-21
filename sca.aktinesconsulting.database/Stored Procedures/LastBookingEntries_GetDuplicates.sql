CREATE PROCEDURE [dbo].[LastBookingEntries_GetDuplicates]
@LastBookingVersionYearId INT,
@LastBookingVersionMonthId INT,
@LastBookingVersionDayId INT
AS   
BEGIN
		WITH DuplicatesCTE AS (
      							SELECT *,ROW_NUMBER() OVER(PARTITION BY AWB ORDER BY BookingEntryId) AS RowNum,
								COUNT(*) OVER (PARTITION BY AWB) AS DuplicateCount
								FROM LastBookingEntries 
								WHERE LastBookingVersionYearId=@LastBookingVersionYearId 
									AND LastBookingVersionMonthId=@LastBookingVersionMonthId
									AND LastBookingVersionDayId=@LastBookingVersionDayId 
									AND BookingLegStatus IN('SS','UU')
								)
	SELECT * FROM DuplicatesCTE
	WHERE DuplicateCount > 1 
	ORDER BY AWB
END




