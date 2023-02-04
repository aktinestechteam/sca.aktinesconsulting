﻿using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.core.PipeStream
{
    public class StartDateEndDatePipeStream : IPipelineElement
    {
        public List<SCAException> Process(List<SCAException> scaRules, BookingEntry bookingEntry)
        {
            if (scaRules == null || scaRules.Count == 0)
                return null;
            var outputStream = scaRules.Where(r =>
             (r.StartDate == null ||  Convert.ToDateTime(bookingEntry.BookingCreatedDate).Date >= Convert.ToDateTime(r.StartDate).Date)
            &&
             (r.EndDate == null || Convert.ToDateTime(bookingEntry.BookingCreatedDate).Date <=  Convert.ToDateTime(r.EndDate).Date)
            ).ToList();
            if (outputStream.Count > 0)
                bookingEntry.IsDateExcetionExist = true;
            return outputStream.Count > 0 ? outputStream : null;
        }

    }
}
