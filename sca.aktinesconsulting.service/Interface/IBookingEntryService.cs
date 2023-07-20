using sca.aktinesconsulting.entitiy;
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
        Task<IList<BookingEntry>> GetByBookingDate(DateTime? fromDate, DateTime? toDate, string awb);
        Task<int> UpdateEmailDetails(int bookingEntryId, decimal emailWeight, decimal emailVolume, decimal emailRate, decimal emailRevenue, bool emailIsCNFNReceived, bool scaIsApplicable, int emailUpdatedBy);
        Task<IList<BookingEntry>> GetByBookingAWB(DateTime? fromDate, DateTime? toDate, string awb);

    }
}
