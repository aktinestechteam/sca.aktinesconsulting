using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.core.PipeStream
{
    public class AWBPipeStream : IPipelineElement
    {
        public List<SCAException> Process(List<SCAException> scaRules, BookingEntry bookingEntry)
        {
            if (scaRules == null || scaRules.Count == 0)
                return null;
            var outputStream = scaRules.Where(r => string.IsNullOrEmpty(r.AWB) ||
            (Convert.ToString(r.AWB).Split('|').Contains(bookingEntry.AWB)) ||
            (Convert.ToString(r.AWB).ToLower().Equals(bookingEntry.AWB.ToLower()))).ToList();
            return outputStream.Count > 0 ? outputStream : null;
        }
    }
}
