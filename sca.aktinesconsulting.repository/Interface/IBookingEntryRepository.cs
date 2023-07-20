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
        Task<IList<BookingEntry>> GetByBookingDate(DateTime? fromDate, DateTime? toDate, string awb);
        Task<int> UpdateEmailDetails(int bookingEntryId, decimal emailWeight, decimal emailVolume, decimal emailRate, decimal emailRevenue, bool emailIsCNFNReceived, bool scaIsApplicable, int emailUpdatedBy);
        Task<IList<BookingEntry>> GetByBookingAWB(DateTime? fromDate, DateTime? toDate, string awb);


    }
}
