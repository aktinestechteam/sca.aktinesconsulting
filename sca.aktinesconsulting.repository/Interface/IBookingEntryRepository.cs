using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.repository.Interface
{
    public interface IBookingEntryRepository
    {
        bool Add(DataTable dt);
        Task<IList<BookingEntry>> GetBySCAVersionId(int scaVersionId);
    }
}
