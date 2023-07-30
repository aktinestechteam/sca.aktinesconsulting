﻿CREATE TABLE [dbo].[BookingEntries](
[BookingEntryId] [int] IDENTITY(1,1) NOT NULL,
[SCAVersionId] int NOT NULL,
AWB varchar(20),
BookingCreatedDate varchar(max),
FlightDepartureDate  varchar(max),
BookingTime  varchar(max),
FlightDepartureTime  varchar(max),
BookingOrigin varchar(max),
BookingDestination varchar(max),
BookingRateType varchar(max),
AgentCode varchar(max),
AgentName varchar(max),
BookingDestinationCountry varchar(max),
BookingDestinationRegion varchar(max),
BookingLastUpdatedBy varchar(max),
BookingOriginCountry varchar(max),
BookingOriginSalesArea varchar(max),
BookingOriginRegion varchar(max),
BookingReference varchar(max),
Channel varchar(max),
SpecialHandlingCodes varchar(max),
ChargeableWeight varchar(max),
Currency varchar(max),
RevGBP varchar(max),
RevForeign varchar(max),
YieldGBP varchar(max),
YieldForeign varchar(max),
Volume varchar(max),
ProductCode varchar(max),
ProductName varchar(max),
FlightNumber varchar(max),
MetalInfo varchar(max),

[ExceptionId] VARCHAR(MAX) NULL, 
[ExceptionDescription] VARCHAR(MAX) NULL, 
[ExceptionRuleExist] VARCHAR(MAX) NULL, 
CreatedOn [Datetime] DEFAULT GETUTCDATE(),
[EmailWeight] DECIMAL(18, 4) NULL, 
    [EmailVolume] DECIMAL(18, 4) NULL, 
    [EmailRate] DECIMAL(18, 4) NULL, 
    [EmailRevenue] DECIMAL(18, 4) NULL, 
    [EmailIsCNFNReceived] BIT NULL, 
    [SCAIsApplicable] BIT NULL, 
    [EmailUpdatedBy] INT NULL, 
    [EmailUpdatedOn] DATETIME NULL, 
    PRIMARY KEY (BookingEntryId),
FOREIGN KEY (SCAVersionId) REFERENCES SCAVersions(SCAVersionId)
)