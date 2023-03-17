CREATE PROCEDURE [dbo].[SCAExceptions_Add]
		    @StartDate DATETIME = NULL
           ,@EndDate  DATETIME = NULL
           ,@Description VARCHAR(MAX)=NULL
           ,@BookingOrigin VARCHAR(MAX)=NULL
           ,@BookingDestination VARCHAR(MAX)=NULL
           ,@BookingRateType VARCHAR(MAX)=NULL
           ,@AgentCode VARCHAR(MAX)=NULL
           ,@BookingDestinationCountry VARCHAR(MAX)=NULL
           ,@BookingDestinationRegion VARCHAR(MAX)=NULL
           ,@BookingOriginCountry VARCHAR(MAX)=NULL
           ,@BookingOriginSalesArea VARCHAR(MAX)=NULL
           ,@BookingOriginRegion VARCHAR(MAX)=NULL
           ,@Channel VARCHAR(MAX)=NULL
           ,@SpecialHandlingCodes VARCHAR(MAX)=NULL
		   ,@ProductCode VARCHAR(MAX)=NULL
           ,@MetalInfo VARCHAR(MAX)=NULL
           ,@ExcludeBookingOrigin VARCHAR(MAX)=NULL
           ,@ExcludeBookingDestination VARCHAR(MAX)=NULL
           ,@ExcludeBookingRateType VARCHAR(MAX)=NULL
           ,@ExcludeBookingDestinationRegion VARCHAR(MAX)=NULL
           ,@ExcludeAgentCode VARCHAR(MAX)=NULL
           ,@ExcludeBookingDestinationCountry VARCHAR(MAX)=NULL
           ,@ExcludeBookingOriginCountry VARCHAR(MAX)=NULL
           ,@ExcludeBookingOriginSalesArea VARCHAR(MAX)=NULL
           ,@ExcludeBookingOriginRegion VARCHAR(MAX)=NULL
           ,@ExcludeChannel VARCHAR(MAX)=NULL
           ,@ExcludeSpecialHandlingCodes VARCHAR(MAX)=NULL
           ,@ExcludeProductCode VARCHAR(MAX)=NULL
           ,@ExcludeMetalInfo VARCHAR(MAX)=NULL
           ,@ChargeableWeight DECIMAL(18,4)=NULL
           ,@IsChargeableWeightRange BIT=0
           ,@IsChargeableWeightLessThan BIT=0
           ,@IsChargeableWeightEqualTo BIT=0
           ,@IsChargeableWeightLessthanEqualTo BIT=0
           ,@IsChargeableWeightGreaterThan BIT=0
           ,@IsChargeableWeightGreaterThanEqualTo BIT=0
           ,@ChargeableWeightRangeFrom DECIMAL(18,4)=NULL
           ,@ChargeableWeightRangeTo DECIMAL(18,4)=NULL
           ,@Volume DECIMAL(18,4)=NULL
           ,@IsVolumeRange BIT=0
           ,@IsVolumeLessThan BIT=0
           ,@IsVolumeEqualTo BIT=0
           ,@IsVolumeLessthanEqualTo BIT=0
           ,@IsVolumeGreaterThan BIT=0
           ,@IsVolumeGreaterThanEqualTo BIT=0
           ,@VolumeRangeFrom DECIMAL(18,4)=NULL
           ,@VolumeRangeTo DECIMAL(18,4)=NULL
           ,@IsActive BIT=0
           ,@CreatedOn  DATETIME = NULL
		   ,@CreatedBy INT = NULL
AS
BEGIN
INSERT INTO [dbo].[SCAExceptions]
           ([StartDate]
           ,[EndDate]
           ,[Description]
           ,[BookingOrigin]
           ,[BookingDestination]
           ,[BookingRateType]
           ,[AgentCode]
           ,[BookingDestinationCountry]
           ,[BookingDestinationRegion]
           ,[BookingOriginCountry]
           ,[BookingOriginSalesArea]
           ,[BookingOriginRegion]
           ,[Channel]
           ,[SpecialHandlingCodes]
		   ,[ProductCode]
		   ,[MetalInfo]
           ,[ExcludeBookingOrigin]
           ,[ExcludeBookingDestination]
           ,[ExcludeBookingRateType]
           ,[ExcludeBookingDestinationRegion]
           ,[ExcludeAgentCode]
           ,[ExcludeBookingDestinationCountry]
           ,[ExcludeBookingOriginCountry]
           ,[ExcludeBookingOriginSalesArea]
           ,[ExcludeBookingOriginRegion]
           ,[ExcludeChannel]
           ,[ExcludeSpecialHandlingCodes]
           ,[ExcludeProductCode]
           ,[ExcludeMetalInfo]
           ,[ChargeableWeight]
           ,[IsChargeableWeightRange]
           ,[IsChargeableWeightLessThan]
           ,[IsChargeableWeightEqualTo]
           ,[IsChargeableWeightLessthanEqualTo]
           ,[IsChargeableWeightGreaterThan]
           ,[IsChargeableWeightGreaterThanEqualTo]
           ,[ChargeableWeightRangeFrom]
           ,[ChargeableWeightRangeTo]
           ,[Volume]
           ,[IsVolumeRange]
           ,[IsVolumeLessThan]
           ,[IsVolumeEqualTo]
           ,[IsVolumeLessthanEqualTo]
           ,[IsVolumeGreaterThan]
           ,[IsVolumeGreaterThanEqualTo]
           ,[VolumeRangeFrom]
           ,[VolumeRangeTo]
           ,[IsActive]
           ,[CreatedOn]
		   ,[CreatedBy])
	VALUES
			(
			@StartDate
           ,@EndDate
           ,@Description
           ,@BookingOrigin
           ,@BookingDestination
           ,@BookingRateType
           ,@AgentCode
           ,@BookingDestinationCountry
           ,@BookingDestinationRegion
           ,@BookingOriginCountry
           ,@BookingOriginSalesArea
           ,@BookingOriginRegion
           ,@Channel
           ,@SpecialHandlingCodes
		   ,@ProductCode
		   ,@MetalInfo
           ,@ExcludeBookingOrigin
           ,@ExcludeBookingDestination
           ,@ExcludeBookingRateType
           ,@ExcludeBookingDestinationRegion
           ,@ExcludeAgentCode
           ,@ExcludeBookingDestinationCountry
           ,@ExcludeBookingOriginCountry
           ,@ExcludeBookingOriginSalesArea
           ,@ExcludeBookingOriginRegion
           ,@ExcludeChannel
           ,@ExcludeSpecialHandlingCodes
           ,@ExcludeProductCode
           ,@ExcludeMetalInfo
           ,@ChargeableWeight
           ,@IsChargeableWeightRange
           ,@IsChargeableWeightLessThan
           ,@IsChargeableWeightEqualTo
           ,@IsChargeableWeightLessthanEqualTo
           ,@IsChargeableWeightGreaterThan
           ,@IsChargeableWeightGreaterThanEqualTo
           ,@ChargeableWeightRangeFrom
           ,@ChargeableWeightRangeTo
           ,@Volume
           ,@IsVolumeRange
           ,@IsVolumeLessThan
           ,@IsVolumeEqualTo
           ,@IsVolumeLessthanEqualTo
           ,@IsVolumeGreaterThan
           ,@IsVolumeGreaterThanEqualTo
           ,@VolumeRangeFrom
           ,@VolumeRangeTo
           ,@IsActive
           ,@CreatedOn
           ,@CreatedBy
			)
	SELECT CAST(SCOPE_IDENTITY() as INT)
END
