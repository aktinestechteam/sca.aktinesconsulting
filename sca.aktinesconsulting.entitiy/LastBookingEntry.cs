using System;
using System.Collections.Generic;
using System.Text;

namespace sca.aktinesconsulting.entitiy
{
    public class LastBookingEntry
    {
        public int BookingEntryId { get; set; }
        public string AWB { get; set; }
        public string BookingLegStatus { get; set; }
        public string BookingCreatedDate { get; set; }
        public string FlightDepartureDate { get; set; }
        public string BookingTime { get; set; }//
        public string FlightDepartureTime { get; set; }//
        public string BookingOrigin { get; set; }
        public string BookingDestination { get; set; }
        public string BookingRateType { get; set; }
        public string AgentName { get; set; }
        public string BookingRowNumber { get; set; }
        public string BookingKey { get; set; }
        public string BookingDestinationRegion { get; set; }
        public string BookingLastUpdatedBy { get; set; }
        public string BookingLastUpdatedByGMT { get; set; }
        public string BookingOriginCountry { get; set; }
        public string BookingOriginSalesArea { get; set; }
        public string BookingOriginRegion { get; set; }
        public string BookingReference { get; set; }
        public string Channel { get; set; }
        public string SpecialHandlingCodes { get; set; }
        public string ChargeableWeight { get; set; }
        public string Currency { get; set; }
        public string RevGBP { get; set; }
        public string RevForeign { get; set; } //
        public string YieldGBP { get; set; }
        public string YieldForeign { get; set; } //
        public string BookingLegVolume { get; set; }
        public string Volume { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string FlightNumber { get; set; }
        public string MetalInfo { get; set; }
        public int LastBookingVersionYearId { get; set; }
        public int LastBookingVersionMonthId { get; set; }
        public int LastBookingVersionDayId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool isConsidered { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }


}
