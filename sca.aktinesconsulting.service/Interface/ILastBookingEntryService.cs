using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Interface
{
    public interface ILastBookingEntryService
    {
        Task<bool> Add(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId, int userId, DataTable dt);
        Task<List<LastBookingEntry>> GetDuplicates(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId);
        Task<List<LastBookingEntry>> Get(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId);
        Task<bool> IsExist(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId);
        Task<List<LastBookingEntryVersion>> GetVersions();
        Task<LastBookingEntryVersionBreakup> GetVersionsBrekup();
        Task<bool> ValidateDateRang(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId, DataTable dt);
        void ReplaceColumnNames(DataTable dt);
        Task<int> UpdateIsConsidered(int bookingEntryId, bool isConsidered);

    }
}
