using System;
using System.Collections.Generic;
using System.Text;

namespace sca.aktinesconsulting.entitiy
{
    public class LastBookingEntryVersion
    {
        public int LastBookingVersionId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class LastBookingEntryVersionBreakup
    {
        public List<LastBookingEntryVersionYear> Years { get; set; }
        public List<LastBookingEntryVersionMonth> Months { get; set; }
        public List<LastBookingEntryVersionDay> Days { get; set; }

    }

    public class LastBookingEntryVersionYear
    {
        public int LastBookingVersionId { get; set; }
        public int Year { get; set; }
    }
    public class LastBookingEntryVersionMonth
    {
        public int LastBookingVersionId { get; set; }
        public string Month { get; set; }
    }
    public class LastBookingEntryVersionDay
    {
        public int LastBookingVersionId { get; set; }
        public string Day { get; set; }
    }

}
