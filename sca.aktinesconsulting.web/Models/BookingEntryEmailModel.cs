using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.web.Models
{
    public class BookingEntryEmailModel
    {
        public int BookingEntryId { get; set; }
        public decimal EmailWeight { get; set; }
        public decimal EmailVolume { get; set; }
        public decimal EmailRate { get; set; }
        public decimal EmailRevenue { get; set; }
        public bool EmailIsCNFNReceived { get; set; }
        public bool SCAIsApplicable { get; set; }
        public int EmailUpdatedBy { get; set; }
        public DateTime? EmailUpdatedOn { get; set; }
    }
}
