using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sca.aktinesconsulting.entitiy.Report;
using sca.aktinesconsulting.service.Interface;
using sca.aktinesconsulting.web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.web.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly ILastBookingEntryService _lastBookingEntryService;
        private readonly IReportService _reportService;

        public ReportController(ILastBookingEntryService lastBookingEntryService, IReportService reportService)
        {
            _lastBookingEntryService = lastBookingEntryService;
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> OutlierReport()
        {
            LastBookingEntryModel model = new LastBookingEntryModel();
            model.Version = await _lastBookingEntryService.GetVersionsBrekup();
            return View(model);
        }

        [HttpPost]
        public async Task<List<OutlierReport>> OutlierReport([FromBody] LastBookingEntryModel filter)
        {
            return await _reportService.GetOutlierReport();
        }
    }
}
