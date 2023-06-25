using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sca.aktinesconsulting.service.Interface;
using sca.aktinesconsulting.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.web.Controllers
{
    [Authorize]
    public class SCAVersionController : Controller
    {

        private readonly ISCAVersionService _scaVersion;
        public SCAVersionController(ISCAVersionService scaVersion)
        {
            _scaVersion = scaVersion;
        }
        [Route("/sca/bookingentry/versionhistory")]
        public async Task<IActionResult> GetBookingEntryVersion()
        {
            var model = new SCAVersionModel();
            model.Versions = await _scaVersion.GetAll();
            return View("BookingEntryVersion", model);
        }
    }
}
