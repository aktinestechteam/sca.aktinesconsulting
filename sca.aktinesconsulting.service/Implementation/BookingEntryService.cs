using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.repository.Interface;
using sca.aktinesconsulting.service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Implementation
{
    public class BookingEntryService : IBookingEntryService
    {
        private readonly IBookingEntryRepository _bookingEntryRepository;
        private readonly ISCAVersionService _scaVersionService;
        public BookingEntryService(IBookingEntryRepository bookingEntryRepository, ISCAVersionService scaVersionService)
        {
            _bookingEntryRepository = bookingEntryRepository;
            _scaVersionService = scaVersionService;
        }
        public async Task<bool> Add(int userId,DataTable dt)
        {
            var scaVersionId = await _scaVersionService.Add(userId);
            AddCustomColumn("SCAVersionId", typeof(int), scaVersionId, dt);
            AddCustomColumn("EmailWeight", typeof(decimal), 0, dt);
            AddCustomColumn("EmailVolume", typeof(decimal), 0, dt);
            AddCustomColumn("EmailRate", typeof(decimal), 0, dt);
            AddCustomColumn("EmailRevenue", typeof(decimal), 0, dt);
            AddCustomColumn("EmailIsCNFNReceived", typeof(bool), false, dt);
            AddCustomColumn("SCAIsApplicable", typeof(bool), false, dt);
            for (int rw = 0; rw < dt.Rows.Count; rw++)
            {
                if (string.IsNullOrEmpty(Convert.ToString(dt.Rows[rw]["ExceptionId"])))
                    dt.Rows[rw]["SCAIsApplicable"] = true;
            }
            return _bookingEntryRepository.Add(dt);
        }

        private void AddCustomColumn(string name,Type dataType,object defaultValue,DataTable dt)
        {
            DataColumn column = new DataColumn(name, dataType);
            column.DefaultValue = defaultValue;
            dt.Columns.Add(column);
        }

        public Task<IList<BookingEntry>> GetBySCAVersionId(int scaVersionId)
        {
            return _bookingEntryRepository.GetBySCAVersionId(scaVersionId);
        }
        public Task<IList<BookingEntry>> GetByBookingDate(DateTime? fromDate, DateTime? toDate, string awb)
        {
            return _bookingEntryRepository.GetByBookingDate(fromDate, toDate, awb);
        }

        public Task<int> UpdateEmailDetails(int bookingEntryId, decimal emailWeight, decimal emailVolume, decimal emailRate, decimal emailRevenue, bool emailIsCNFNReceived, bool scaIsApplicable, int emailUpdatedBy)
        {
            return _bookingEntryRepository.UpdateEmailDetails(bookingEntryId, emailWeight, emailVolume, emailRate, emailRevenue, emailIsCNFNReceived, scaIsApplicable, emailUpdatedBy);
        }

        public Task<IList<BookingEntry>> GetByBookingAWB(DateTime? fromDate, DateTime? toDate, string awb)
        {
            return _bookingEntryRepository.GetByBookingAWB(fromDate, toDate, awb);
        }
    }
}
