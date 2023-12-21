using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.repository.Interface
{
    public interface ILastBookingEntryRepository
    {
        bool Add(DataTable dt);
        Task<int> Delete(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId);
        Task<List<LastBookingEntry>> GetDuplicates(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId);
        Task<List<LastBookingEntry>> Get(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId);
        Task<bool> IsExist(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId);
        Task<List<LastBookingEntryVersion>> GetVersions();
        Task<int> UpdateIsConsidered(int bookingEntryId, bool isConsidered);

    }
}
