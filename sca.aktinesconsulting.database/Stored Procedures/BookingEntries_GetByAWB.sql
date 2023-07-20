CREATE PROCEDURE [dbo].[BookingEntries_GetByAWB] 
@AWB VARCHAR(30),
@StartDate DATETIME=NULL,
@EndDate DATETIME=NULL
AS
BEGIN
	SELECT * FROM [dbo].BookingEntries be
	INNER JOIN (
		SELECT MAX(BookingEntryId) AS BookingEntryId,awbEntries.BookingDate FROM [dbo].BookingEntries be
		INNER JOIN (
						SELECT Count(be.BookingEntryId) IdCount, be.AWB, [dbo].fn_GetDateTime(be.BookingCreatedDate,be.BookingTime) as BookingDate
							FROM [dbo].BookingEntries be 	
							WHERE 
								(@StartDate IS NULL OR [dbo].fn_GetDateTime(be.BookingCreatedDate,be.BookingTime)>=@StartDate) AND 
								(@EndDate IS NULL OR [dbo].fn_GetDateTime(be.BookingCreatedDate,be.BookingTime)<=@EndDate) AND
								(@AWB IS NULL OR be.AWB=@AWB)
							GROUP BY be.AWB,[dbo].fn_GetDateTime(be.BookingCreatedDate,be.BookingTime)
					) awbEntries ON awbEntries.AWB= be.AWB AND [dbo].fn_GetDateTime(be.BookingCreatedDate,be.BookingTime)=awbEntries.BookingDate 
		GROUP BY awbEntries.BookingDate					
	) awbEntries ON be.BookingEntryId= awbEntries.BookingEntryId	
	ORDER BY awbEntries.BookingDate DESC
END	
