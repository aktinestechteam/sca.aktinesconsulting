using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.core.PipeStream
{
    public class SpecialHandlingCodesPipeStream : IPipelineElement
    {
        public List<SCAException> Process(List<SCAException> scaRules, BookingEntry bookingEntry)
        {
            if (scaRules == null || scaRules.Count == 0)
                return null;

            if (bookingEntry.SpecialHandlingCodes == null)
                bookingEntry.SpecialHandlingCodes = string.Empty;

            var shcs = bookingEntry.SpecialHandlingCodes.Split(',');
            List<SCAException> exceptions = new List<SCAException>();
            foreach (var shc in shcs)
            {

                var outputStream = scaRules.Where(r => string.IsNullOrEmpty(r.SpecialHandlingCodes) ||
                        (Convert.ToString(r.SpecialHandlingCodes.Trim()).Split('|').Contains(shc.Trim())) ||
                        (Convert.ToString(r.SpecialHandlingCodes.Trim()).ToLower().Equals(shc.Trim().ToLower()))).ToList();
                exceptions.AddRange(outputStream);
            }
            exceptions = exceptions.Distinct().ToList();
            return exceptions.Count > 0 ? exceptions : null;
        }
    }

}