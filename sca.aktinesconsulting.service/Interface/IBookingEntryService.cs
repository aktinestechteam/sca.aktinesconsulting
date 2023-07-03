﻿using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Interface
{
    public interface IBookingEntryService
    {
        Task<bool> Add(int userId, DataTable dt);
        Task<IList<BookingEntry>> GetBySCAVersionId(int scaVersionId);
    }
}