using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.web.Models
{
    public class SCAExceptionModal
    {
        public int? SCAExceptionId { get; set; }
        public string[] BookingOrigins { get; set; }
        public string[] BookingDestinations { get; set; }
        public string[] BookingRateTypes { get; set; }
        public string[] Currencys { get; set; }
        public string[] AgentCodes { get; set; }
        public string[] BookingDestinationCountries { get; set; }
        public string[] BookingDestinationRegions { get; set; }
        public string[] BookingOriginCountries { get; set; }
        public string[] BookingOriginSalesAreas { get; set; }
        public string[] BookingOriginRegions { get; set; }
        public string[] BookingReferences { get; set; }
        public string[] Channels { get; set; }
        public string[] SpecialHandlingCodes { get; set; }

        public string[] ProductCodes { get; set; }
        public string[] MetalInfos { get; set; }
        public string[] ExcludeBookingOrigins { get; set; }
        public string[] ExcludeBookingDestinations { get; set; }
        public string[] ExcludeBookingRateTypes { get; set; }
        public string[] ExcludeBookingDestinationRegions { get; set; }
        public string[] ExcludeAgentCodes { get; set; }
        public string[] ExcludeBookingDestinationCountries { get; set; }
        public string[] ExcludeBookingOriginCountries { get; set; }
        public string[] ExcludeBookingOriginSalesAreas { get; set; }
        public string[] ExcludeBookingOriginRegions { get; set; }
        public string[] ExcludeChannels { get; set; }
        public string[] ExcludeSpecialHandlingCodes { get; set; }
        public string[] ExcludeProductCodes { get; set; }
        public string[] ExcludeMetalInfos { get; set; }

        public decimal? ChargeableWeight { get; set; }
        public bool? IsChargeableWeightLessThan { get; set; }
        public bool? IsChargeableWeightEqualTo { get; set; }
        public bool? IsChargeableWeightLessthanEqualTo { get; set; }
        public bool? IsChargeableWeightGreaterThan { get; set; }
        public bool? IsChargeableWeightGreaterThanEqualTo { get; set; }
        public bool? IsChargeableWeightRange { get; set; }
        public decimal? ChargeableWeightRangeFrom { get; set; }
        public decimal? ChargeableWeightRangeTo { get; set; }

        public decimal? Volume { get; set; }
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
        public string? Description { get; set; }
        public string StartDateText { get; set; }
        public string EndDateText { get; set; } 


    }

}
