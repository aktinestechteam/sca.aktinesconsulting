using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.core.PipeStream
{
    public class BookingOriginSalesAreaPipeStream : IPipelineElement
    {
        public List<SCAException> Process(List<SCAException> scaRules, BookingEntry bookingEntry)
        {
            if (scaRules == null || scaRules.Count == 0)
                return null;
            var outputStream = scaRules.Where(r => string.IsNullOrEmpty(r.BookingOriginSalesArea) ||
            (Convert.ToString(r.BookingOriginSalesArea).Split('|').Contains(bookingEntry.BookingOriginSalesArea)) ||
            (Convert.ToString(r.BookingOriginSalesArea).ToLower().Equals(bookingEntry.BookingOriginSalesArea.ToLower()))).ToList();
            return outputStream.Count > 0 ? outputStream : null;
        }
    }
}
