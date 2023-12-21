CREATE PROCEDURE [dbo].[Report_GetOutlierReport]
AS  
BEGIN
DECLARE @AWB TABLE (AWB VARCHAR(20));
DECLARE @BookingEntries TABLE (BookingEntryId INT);
DECLARE @LastBookingEntries TABLE (AWB VARCHAR(20), ChargeableWeight Decimal(18,4), RevForeign Decimal(18,4));

-- Populate @AWB table
INSERT INTO @AWB
SELECT AWB 
FROM [dbo].LastBookingEntries lbe
WHERE Year(lbe.FlightDepartureDateTime) = 2023
    AND Month(lbe.FlightDepartureDateTime) = 6
    AND BookingLegStatus IN ('SS', 'UU')
    AND IsConsidered = 1 
GROUP BY BookingOrigin, BookingDestination, AWB, AgentName;

-- Populate @BookingEntries table with the latest BookingEntryId for each AWB
WITH Ranked AS (
    SELECT 
        BookingEntryId,
        be.AWB,
        ROW_NUMBER() OVER (PARTITION BY be.AWB ORDER BY BookingCreatedDate DESC) AS RowNum
    FROM [dbo].BookingEntries be
    INNER JOIN @AWB awb ON awb.AWB = be.AWB  
	WHERE be.SCAIsApplicable=1
)
INSERT INTO @BookingEntries (BookingEntryId)
SELECT BookingEntryId
FROM Ranked
WHERE RowNum = 1;

-- Retrieve the required data
SELECT 
    lbe.AWB,
    lbe.BookingOrigin,
    lbe.BookingDestination,
    lbe.AgentName,
	lbe.ChargeableWeight AS LEChargeableWeight,
	lbe.RevForeign AS LERevForeign,
    be.ChargeableWeight  AS BEChargeableWeight,
    be.EmailWeight AS BEEmailWeight,
    be.RevForeign AS BERevForeign,
    be.EmailRevenue  AS BEEmailRevenue
FROM (
    SELECT 
        AWB,
        BookingOrigin,
        BookingDestination,
        AgentName,
        SUM(CASE WHEN ISNUMERIC(lbe.ChargeableWeight) = 1 THEN lbe.ChargeableWeight ELSE 0 END) AS ChargeableWeight, 
        SUM(CASE WHEN ISNUMERIC(lbe.RevForeign) = 1 THEN lbe.RevForeign ELSE 0 END) AS RevForeign
    FROM [dbo].LastBookingEntries lbe
    WHERE lbe.AWB IN (SELECT AWB FROM @AWB)
    GROUP BY AWB, BookingOrigin, BookingDestination, AgentName
) lbe 
LEFT JOIN (
    SELECT 
        AWB, 
        CASE WHEN ISNUMERIC(be.ChargeableWeight) = 1 THEN be.ChargeableWeight ELSE 0 END AS ChargeableWeight, 
        be.EmailWeight,
        CASE WHEN ISNUMERIC(be.RevForeign) = 1 THEN be.RevForeign ELSE 0 END AS RevForeign,
        be.EmailRevenue
    FROM [dbo].BookingEntries be
    INNER JOIN @BookingEntries tbe ON tbe.BookingEntryId = be.BookingEntryId
) be ON lbe.AWB = be.AWB;

END