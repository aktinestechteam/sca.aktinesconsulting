using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.core.PipeStream
{
    public class BookingDestinationCountryPipeStream : IPipelineElement
    {
        public List<SCAException> Process(List<SCAException> scaRules, BookingEntry bookingEntry)
        {
            if (scaRules == null || scaRules.Count == 0)
                return null;
            var outputStream = scaRules.Where(r => string.IsNullOrEmpty(r.BookingDestinationCountry) ||
            (Convert.ToString(r.BookingDestinationCountry).Split('|').Contains(bookingEntry.BookingDestinationCountry)) ||
            (Convert.ToString(r.BookingDestinationCountry).ToLower().Equals(bookingEntry.BookingDestinationCountry.ToLower()))).ToList();
            return outputStream.Count > 0 ? outputStream : null;
        }
    }
}
