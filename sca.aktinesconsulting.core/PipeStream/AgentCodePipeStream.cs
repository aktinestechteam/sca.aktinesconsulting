﻿using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.core.PipeStream
{
    public class AgentCodePipeStream : IPipelineElement
    {
        public List<SCAException> Process(List<SCAException> scaRules, BookingEntry bookingEntry)
        {
            if (scaRules == null || scaRules.Count == 0)
                return null;
            var outputStream = scaRules.Where(r => string.IsNullOrEmpty(r.AgentCode) ||
            (Convert.ToString(r.AgentCode).Split('|').Contains(bookingEntry.AgentCode)) ||
            (Convert.ToString(r.AgentCode).ToLower().Equals(bookingEntry.AgentCode.ToLower()))).ToList();
            return outputStream.Count > 0 ? outputStream : null;
        }
    }
}