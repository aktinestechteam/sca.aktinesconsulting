CREATE PROCEDURE [dbo].[BookingEntries_GetByDate] 
@StartDate DATETIME=NULL,
@EndDate DATETIME=NULL,
@AWB VARCHAR(30)=NULL
AS
BEGIN
    DECLARE  @MaxBookingEntries TABLE(AWB VARCHAR(MAX),BookingDate DATETIME)
    DECLARE  @CountBookingEntries TABLE(AWB VARCHAR(MAX),AWBCount INT)

    INSERT INTO @MaxBookingEntries (AWB,BookingDate)
	    SELECT  AWB,MAX([dbo].fn_GetDateTime(be.BookingCreatedDate,be.BookingTime)) AS BookingDate	
	    FROM [dbo].BookingEntries be 
	    WHERE 
		    (@StartDate IS NULL OR [dbo].fn_GetDateTime(be.BookingCreatedDate,be.BookingTime)>=@StartDate) AND 
		    (@EndDate IS NULL OR [dbo].fn_GetDateTime(be.BookingCreatedDate,be.BookingTime)<=@EndDate) AND
		    (@AWB IS NULL OR be.AWB=@AWB) 
	    GROUP BY AWB 

    INSERT INTO @CountBookingEntries (AWB,AWBCount)
        SELECT AWB,COUNT(BookingDate) as AWBCount 
        FROM(
	        SELECT DISTINCT AWB,[dbo].fn_GetDateTime(be.BookingCreatedDate,be.BookingTime) as BookingDate
	        FROM [dbo].BookingEntries be 
	        WHERE 
		        (@StartDate IS NULL OR [dbo].fn_GetDateTime(be.BookingCreatedDate,be.BookingTime)>=@StartDate) AND 
		        (@EndDate IS NULL OR [dbo].fn_GetDateTime(be.BookingCreatedDate,be.BookingTime)<=@EndDate) AND
		        (@AWB IS NULL OR be.AWB=@AWB) 
	        ) AS t
        GROUP BY AWB

    SELECT be.[BookingEntryId]
          ,be.[SCAVersionId]
          ,be.[AWB]
          ,be.[BookingCreatedDate]
          ,be.[FlightDepartureDate]
          ,be.[BookingTime]
          ,be.[FlightDepartureTime]
          ,be.[BookingOrigin]
          ,be.[BookingDestination]
          ,be.[BookingRateType]
          ,be.[AgentCode]
          ,be.[AgentName]
          ,be.[BookingDestinationCountry]
          ,be.[BookingDestinationRegion]
          ,be.[BookingLastUpdatedBy]
          ,be.[BookingOriginCountry]
          ,be.[BookingOriginSalesArea]
          ,be.[BookingOriginRegion]
          ,be.[BookingReference]
          ,be.[Channel]
          ,be.[SpecialHandlingCodes]
          ,be.[ChargeableWeight]
          ,be.[Currency]
          ,be.[RevGBP]
          ,be.[RevForeign]
          ,be.[YieldGBP]
          ,be.[YieldForeign]
          ,be.[SCAVersionId]
          ,be.[AWB]
          ,be.[BookingCreatedDate]
          ,be.[FlightDepartureDate]
          ,be.[BookingTime]
          ,be.[FlightDepartureTime]
          ,be.[BookingOrigin]
          ,be.[BookingDestination]
          ,be.[BookingRateType]
          ,be.[AgentCode]
          ,be.[AgentName]
          ,be.[BookingDestinationCountry]
          ,be.[BookingDestinationRegion]
          ,be.[BookingLastUpdatedBy]
          ,be.[BookingOriginCountry]
          ,be.[BookingOriginSalesArea]
          ,be.[BookingOriginRegion]
          ,be.[BookingReference]
          ,be.[Channel]
          ,be.[SpecialHandlingCodes]
          ,be.[ChargeableWeight]
          ,be.[Currency]
          ,be.[RevGBP]
          ,be.[RevForeign]
          ,be.[YieldGBP]
          ,be.[YieldForeign]
          ,be.[Volume]
          ,be.[ProductCode]
          ,be.[ProductName]
          ,be.[FlightNumber]
          ,be.[MetalInfo]
          ,be.[CreatedOn]
          ,be.[ExceptionId]
          ,be.[ExceptionDescription]
          ,be.[ExceptionRuleExist]
          ,be.[Volume]
          ,be.[ProductCode]
          ,be.[ProductName]
          ,be.[FlightNumber]
          ,be.[MetalInfo]
          ,be.[CreatedOn]
          ,be.[ExceptionId]
          ,be.[ExceptionDescription]
          ,be.[ExceptionRuleExist] 
          ,be.EmailWeight 
          ,be.EmailVolume 
          ,be.EmailRate 
          ,be.EmailRevenue 
	      ,be.EmailIsCNFNReceived
	      ,be.SCAIsApplicable
	      ,cbe.AWBCount
          ,be.EmailWeight
	      ,be.EmailVolume
	      ,be.EmailRate
	      ,be.EmailRevenue
	      ,be.EmailIsCNFNReceived
	      ,be.SCAIsApplicable
    FROM [dbo].BookingEntries be 
	    INNER JOIN (
				    SELECT MAX(be.BookingEntryId) as BookingEntryId
				    FROM [dbo].BookingEntries be 
					    INNER JOIN @MaxBookingEntries b 
					    ON  b.AWB=b.AWB AND [dbo].fn_GetDateTime(be.BookingCreatedDate,be.BookingTime)=b.BookingDate
				    GROUP BY be.AWB
				    ) bk ON be.BookingEntryId=bk.BookingEntryId
	    INNER JOIN @CountBookingEntries cbe ON cbe.AWB=be.AWB

END




