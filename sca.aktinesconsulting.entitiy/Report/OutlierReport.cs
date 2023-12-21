using System;
using System.Collections.Generic;
using System.Text;

namespace sca.aktinesconsulting.entitiy.Report
{
    public class OutlierReport
    {
        public string BookingOrigin { get; set; }
        public string BookingDestination { get; set; }
        public string AWB { get; set; }
        public string AgentName { get; set; }
        public decimal LEChargeableWeight { get; set; }
        public decimal LERevForeign { get; set; }
        public decimal BEChargeableWeight { get; set; }
        public decimal BEEmailWeight { get; set; }
        public decimal BERevForeign { get; set; }
        public decimal BEEmailRevenue { get; set; }
        public decimal RevVariancePer { get; set; }
        public decimal RevVariance { get; set; }

    }
}
