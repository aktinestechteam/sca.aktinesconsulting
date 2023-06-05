using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.web.Common;
using sca.aktinesconsulting.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.web.FieldMapper
{   
    public static class Mapper
    {

        public static SCAException MapSCAException(SCAExceptionModel source)
        {
            var scaException = new SCAException();
            scaException.SCAExceptionId = source.SCAExceptionId;
            scaException.StartDate = source.StartDateText.StringToDate();
            scaException.EndDate = source.EndDateText.StringToDate();
            scaException.Description = source.Description;
            //String Field
            scaException.BookingOrigin = source.BookingOrigins.JoinString();
            scaException.BookingDestination = source.BookingDestinations.JoinString();
            scaException.BookingRateType = source.BookingRateTypes.JoinString();
            scaException.AgentCode = source.AgentCodes.JoinString();
            scaException.BookingDestinationCountry = source.BookingDestinationCountries.JoinString();
            scaException.BookingDestinationRegion = source.BookingDestinationRegions.JoinString();
            scaException.BookingOriginCountry = source.BookingOriginCountries.JoinString();
            scaException.BookingOriginSalesArea = source.BookingOriginSalesAreas.JoinString();
            scaException.BookingOriginRegion = source.BookingOriginRegions.JoinString();
            scaException.Channel = source.Channels.JoinString();
            scaException.SpecialHandlingCodes = source.SpecialHandlingCodes.JoinString();
            scaException.ProductCode = source.ProductCodes.JoinString();
            scaException.MetalInfo = source.MetalInfos.JoinString();
            scaException.ExcludeBookingOrigin = source.ExcludeBookingOrigins.JoinString();
            scaException.ExcludeBookingDestination = source.ExcludeBookingDestinations.JoinString();
            scaException.ExcludeBookingRateType = source.ExcludeBookingRateTypes.JoinString();
            scaException.ExcludeBookingDestinationRegion = source.ExcludeBookingDestinationRegions.JoinString();
            scaException.ExcludeAgentCode = source.ExcludeAgentCodes.JoinString();
            scaException.ExcludeBookingDestinationCountry = source.ExcludeBookingDestinationCountries.JoinString();
            scaException.ExcludeBookingOriginCountry = source.ExcludeBookingOriginCountries.JoinString();
            scaException.ExcludeBookingOriginSalesArea = source.ExcludeBookingOriginSalesAreas.JoinString();
            scaException.ExcludeBookingOriginRegion = source.ExcludeBookingOriginRegions.JoinString();
            scaException.ExcludeChannel = source.ExcludeChannels.JoinString();
            scaException.ExcludeSpecialHandlingCodes = source.ExcludeSpecialHandlingCodes.JoinString();
            scaException.ExcludeProductCode = source.ExcludeProductCodes.JoinString();
            scaException.ExcludeMetalInfo = source.ExcludeMetalInfos.JoinString();

            //ChargeableWeight
            scaException.IsChargeableWeightRange = source.IsChargeableWeightRange;
            scaException.ChargeableWeight = source.ChargeableWeight;
            scaException.ChargeableWeightRangeFrom = source.ChargeableWeightRangeFrom;
            scaException.ChargeableWeightRangeTo = source.ChargeableWeightRangeTo;
            scaException.IsChargeableWeightLessThan = source.IsChargeableWeightLessThan;
            scaException.IsChargeableWeightEqualTo = source.IsChargeableWeightEqualTo;
            scaException.IsChargeableWeightLessthanEqualTo = source.IsChargeableWeightLessthanEqualTo;
            scaException.IsChargeableWeightGreaterThan = source.IsChargeableWeightGreaterThan;
            scaException.IsChargeableWeightGreaterThanEqualTo = source.IsChargeableWeightGreaterThanEqualTo;

            //Volume
            scaException.IsVolumeRange = source.IsVolumeRange;
            scaException.Volume = source.Volume;
            scaException.VolumeRangeFrom = source.VolumeRangeFrom;
            scaException.VolumeRangeTo = source.VolumeRangeTo;
            scaException.IsVolumeLessThan = source.IsVolumeLessThan;
            scaException.IsVolumeEqualTo = source.IsVolumeEqualTo;
            scaException.IsVolumeLessthanEqualTo = source.IsVolumeLessthanEqualTo;
            scaException.IsVolumeGreaterThan = source.IsVolumeGreaterThan;
            scaException.IsVolumeGreaterThanEqualTo = source.IsVolumeGreaterThanEqualTo;

            return scaException;
        }
        public static BookingEntry MapBookingEntry(SCAException scaException)
        {
            var bookingEntry = new BookingEntry();
            bookingEntry.AWB = scaException.AWB.NullToEmpty();
            bookingEntry.BookingCreatedDate = scaException.StartDate==null?string.Empty: scaException.StartDate.ToString();
            bookingEntry.FlightDepartureDate = null;
            bookingEntry.BookingOrigin = scaException.BookingOrigin.NullToEmpty();
            bookingEntry.BookingDestination = scaException.BookingDestination.NullToEmpty();
            bookingEntry.BookingRateType = scaException.BookingRateType.NullToEmpty();
            bookingEntry.Currency = scaException.Currency.NullToEmpty();
            bookingEntry.AgentCode = scaException.AgentCode.NullToEmpty();
            bookingEntry.AgentName = scaException.AgentName.NullToEmpty();
            bookingEntry.BookingDestinationCountry = scaException.BookingDestinationCountry.NullToEmpty();
            bookingEntry.BookingDestinationRegion = scaException.BookingDestinationRegion.NullToEmpty();
            bookingEntry.BookingLastUpdatedBy = scaException.BookingLastUpdatedBy.NullToEmpty();
            bookingEntry.BookingOriginCountry = scaException.BookingOriginCountry.NullToEmpty();
            bookingEntry.BookingOriginSalesArea = scaException.BookingOriginSalesArea.NullToEmpty();
            bookingEntry.BookingOriginRegion = scaException.BookingOriginRegion.NullToEmpty();
            bookingEntry.BookingReference = scaException.BookingReference.NullToEmpty();
            bookingEntry.Channel = scaException.Channel.NullToEmpty();
            bookingEntry.SpecialHandlingCodes = scaException.SpecialHandlingCodes.NullToEmpty();
            bookingEntry.ChargeableWeight = scaException.ChargeableWeight==null?string.Empty:scaException.ChargeableWeight.ToString();
            bookingEntry.RevGBP = scaException.RevGBP == null ? string.Empty : scaException.RevGBP.ToString();
            bookingEntry.YieldGBP = scaException.YieldGBP == null ? string.Empty : scaException.RevGBP.ToString();
            bookingEntry.ProductCode = scaException.ProductCode.NullToEmpty();
            bookingEntry.ProductName = scaException.ProductName.NullToEmpty();
            bookingEntry.FlightNumber = scaException.FlightNumber.NullToEmpty();
            bookingEntry.MetalInfo = scaException.MetalInfo.NullToEmpty();
            bookingEntry.Volume = scaException.Volume == null ? null : scaException.Volume.ToString();

            return bookingEntry;
        }



    }
}
