using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace sca.aktinesconsulting.repository.Interface
{
    public interface IBookingEntryRepository
    {
        bool Add(DataTable dt);
    }
}
