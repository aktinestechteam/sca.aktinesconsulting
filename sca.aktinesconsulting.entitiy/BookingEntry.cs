using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.entitiy
{
    public class BookingEntry
    {
        public string AWB { get; set; }
        public string BookingCreatedDate { get; set; }
        public string FlightDepartureDate { get; set; }
        public string BookingTime { get; set; }//
        public string FlightDepartureTime { get; set; }//
        public string BookingOrigin { get; set; }
        public string BookingDestination { get; set; }
        public string BookingRateType { get; set; }
        public string AgentCode { get; set; }
        public string AgentName { get; set; }
        public string BookingDestinationCountry { get; set; }
        public string BookingDestinationRegion { get; set; }
        public string BookingLastUpdatedBy { get; set; }
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
        public string Volume { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string FlightNumber { get; set; }
        public string MetalInfo { get; set; }
        public IList<SCAException> Exceptions { get; set; }
        public bool IsDateExcetionExist { get; set; }
        //Not required
        public string RevCurrency { get; set; }
        public string ExceptionId { get; set; }
        public string ExceptionDescription { get; set; }
        public string ExceptionRuleExist { get; set; }

    }
}
