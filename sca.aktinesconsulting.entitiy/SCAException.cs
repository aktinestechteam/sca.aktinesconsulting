using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.entitiy
{
    public class SCAException
    {
        public int? SCAExceptionId { get; set; }
        public string AWB { get; set; }
        public DateTime? BookingCreatedDate { get; set; }
        public DateTime? FlightDepartureDate { get; set; }
        public string BookingOrigin { get; set; }
        public string BookingDestination { get; set; }
        public string BookingRateType { get; set; }
        public string Currency { get; set; }
        public string AgentCode { get; set; }
        public string AgentName { get; set; }  //Rule not Required
        public string BookingDestinationCountry { get; set; }
        public string BookingDestinationRegion { get; set; }   
        public string BookingLastUpdatedBy { get; set; } //Rule not Required
        public string BookingOriginCountry { get; set; }
        public string BookingOriginSalesArea { get; set; }
        public string BookingOriginRegion { get; set; }
        public string BookingReference { get; set; }
        public string Channel { get; set; }
        public string SpecialHandlingCodes { get; set; }
        public decimal? ChargeableWeight { get; set; }
        public decimal? RevGBP { get; set; }
        public decimal? Volume { get; set; }
        public decimal? RevCurrency { get; set; }
        public decimal? YieldGBP { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string FlightNumber { get; set; }
        public string MetalInfo { get; set; }


        public string ExcludeBookingOrigin { get; set; }
        public string ExcludeBookingDestination { get; set; }
        public string ExcludeBookingRateType { get; set; }
        public string ExcludeBookingDestinationRegion { get; set; }
        public string ExcludeAgentCode { get; set; }
        public string ExcludeBookingDestinationCountry { get; set; }
        public string ExcludeBookingOriginCountry { get; set; }
        public string ExcludeBookingOriginSalesArea { get; set; }
        public string ExcludeBookingOriginRegion { get; set; }
        public string ExcludeChannel { get; set; }
        public string ExcludeSpecialHandlingCodes { get; set; }
        public string ExcludeProductCode { get; set; }
        public string ExcludeFlightNumber { get; set; }
        public string ExcludeMetalInfo { get; set; }



        public bool? IsChargeableWeightLessThan { get; set; }
        public bool? IsChargeableWeightEqualTo { get; set; }
        public bool? IsChargeableWeightLessthanEqualTo { get; set; }
        public bool? IsChargeableWeightGreaterThan { get; set; }
        public bool? IsChargeableWeightGreaterThanEqualTo { get; set; }
        public bool? IsChargeableWeightRange { get; set; }
        public decimal? ChargeableWeightRangeFrom { get; set; }
        public decimal? ChargeableWeightRangeTo { get; set; }

        public bool? IsVolumeLessThan { get; set; }
        public bool? IsVolumeEqualTo { get; set; }
        public bool? IsVolumeLessthanEqualTo { get; set; }
        public bool? IsVolumeGreaterThan { get; set; }
        public bool? IsVolumeGreaterThanEqualTo { get; set; }

        public bool? IsVolumeRange { get; set; }
        public decimal? VolumeRangeFrom { get; set; }
        public decimal? VolumeRangeTo { get; set; }


        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }        
        public string Description { get; set; }


    }
}
