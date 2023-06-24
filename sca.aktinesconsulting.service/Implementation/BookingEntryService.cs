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
            DataColumn scaVersionIdColumn = new DataColumn("SCAVersionId", typeof(System.Int32));
            scaVersionIdColumn.DefaultValue = scaVersionId;
            dt.Columns.Add(scaVersionIdColumn);
            return _bookingEntryRepository.Add(dt);
        }
    }
}
