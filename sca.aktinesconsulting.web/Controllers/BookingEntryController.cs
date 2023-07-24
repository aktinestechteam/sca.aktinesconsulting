using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.service.Interface;
using sca.aktinesconsulting.web.Common;
using sca.aktinesconsulting.web.Models;
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

        [Route("/bookingentries")]
        [HttpGet]
        public IActionResult BookingEntries()
        {
            if (!User.IsAllowed(Permissions.BookingEntries, PermissionType.View))
                return Redirect("/SCAException/Index");
            return View();
        }
        [HttpGet]
        public async Task<IList<BookingEntry>> GetBookingEntries([FromQuery] int versionId)
        {
            return await _bookingEntryService.GetBySCAVersionId(versionId);
        } 
        [HttpGet]
        public async Task<IList<BookingEntry>> GetBookingEntriesByDate([FromQuery] DateTime? fromDate,DateTime? toDate,string awb)
        {
            return await _bookingEntryService.GetByBookingDate(fromDate, toDate, awb);
        }

        [HttpPost]
        public async Task<int> UpdateEmailDetails([FromBody] BookingEntryEmailModel entity)
        {
            entity.EmailUpdatedBy = (int)HttpContext.User.GetUserId();
            return await _bookingEntryService.UpdateEmailDetails(entity.BookingEntryId, entity.EmailWeight, entity.EmailVolume, entity.EmailRate, entity.EmailRevenue, entity.EmailIsCNFNReceived, entity.SCAIsApplicable, entity.EmailUpdatedBy);
        }

        [HttpGet]
        public async Task<IList<BookingEntry>> GetBookingEntriesByAWB([FromQuery] DateTime? fromDate, DateTime? toDate, string awb)
        {
            return await _bookingEntryService.GetByBookingAWB(fromDate, toDate, awb);
        }

    }
}
