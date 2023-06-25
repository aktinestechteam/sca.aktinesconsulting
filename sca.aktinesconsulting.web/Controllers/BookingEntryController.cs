using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.web.Controllers
{
    [Authorize]
    public class BookingEntryController : Controller
    {
        private readonly IBookingEntryService _bookingEntryService;
        public BookingEntryController(IBookingEntryService bookingEntryService)
        {
            _bookingEntryService = bookingEntryService;
        }
        [HttpGet]
        public async Task<IList<BookingEntry>> GetBookingEntries([FromQuery] int versionId)
        {
            return await _bookingEntryService.GetBySCAVersionId(versionId);
        }
    }
}
