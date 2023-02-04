using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.core.PipeStream
{
    public class BookingDestinationRegionPipeStream : IPipelineElement
    {
        public List<SCAException> Process(List<SCAException> scaRules, BookingEntry bookingEntry)
        {
            if (scaRules == null || scaRules.Count == 0)
                return null;
            var outputStream = scaRules.Where(r => string.IsNullOrEmpty(r.BookingDestinationRegion) ||
            (Convert.ToString(r.BookingDestinationRegion).Split('|').Contains(bookingEntry.BookingDestinationRegion)) ||
            (Convert.ToString(r.BookingDestinationRegion).ToLower().Equals(bookingEntry.BookingDestinationRegion.ToLower()))).ToList();
            return outputStream.Count > 0 ? outputStream : null;
        }
    }
}
