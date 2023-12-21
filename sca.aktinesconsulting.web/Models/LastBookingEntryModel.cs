using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.web.Models
{
    public class LastBookingEntryModel
    {
        public LastBookingEntryVersionBreakup Version { get; set; }
        public int LastBookingVersionYearId { get; set; }
        public int LastBookingVersionMonthId { get; set; }
        public int LastBookingVersionDayId { get; set; }
        public int BookingEntryId { get; set; }
        public bool IsConsidered { get; set; }
    }
}
