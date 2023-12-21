using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OfficeOpenXml;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.service.Interface;
using sca.aktinesconsulting.web.Common;
using sca.aktinesconsulting.web.Models;

namespace sca.aktinesconsulting.web.Controllers
{
    [Authorize]
    public class LastBookingEntryController : Controller
    {
        private readonly IFileService _fileService;
        private readonly ILastBookingEntryService _lastBookingEntryService;
        public LastBookingEntryController(IFileService fileService, ILastBookingEntryService lastBookingEntryService)
        {
            _fileService = fileService;
            _lastBookingEntryService = lastBookingEntryService;
        }
        public async Task<IActionResult> Index()
        {
            LastBookingEntryModel model = new LastBookingEntryModel();
            model.Version = await _lastBookingEntryService.GetVersionsBrekup();
            return View(model);
        }

        [HttpPost]
        public async Task<List<LastBookingEntry>> Upload([FromForm] IFormFile file, [FromForm] int lastBookingVersionYearId, [FromForm] int lastBookingVersionMonthId, [FromForm] int lastBookingVersionDayId)
        {
            var userId = (int)HttpContext.User.GetUserId();
            if (file == null)
                return null;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream).ConfigureAwait(false);
                var dt = _fileService.ExcelDataReader(memoryStream, string.Empty, "X").FirstOrDefault();
                if (dt != null)
                {
                    _lastBookingEntryService.ReplaceColumnNames(dt);
                    if (await _lastBookingEntryService.ValidateDateRang(lastBookingVersionYearId, lastBookingVersionMonthId, lastBookingVersionDayId, dt))
                    {
                        await _lastBookingEntryService.Add(lastBookingVersionYearId, lastBookingVersionMonthId, lastBookingVersionDayId, userId, dt);
                        return await _lastBookingEntryService.GetDuplicates(lastBookingVersionYearId, lastBookingVersionMonthId, lastBookingVersionDayId);
                    }
                }
            }
            return null;
        }

        [HttpGet]
        public async Task<List<LastBookingEntry>> GetDuplicates([FromQuery] LastBookingEntryModel model)
        {
            return await _lastBookingEntryService.GetDuplicates(model.LastBookingVersionYearId, model.LastBookingVersionMonthId, model.LastBookingVersionDayId);
        }
        [HttpGet]
        public async Task<bool> IsExist([FromQuery] LastBookingEntryModel model)
        {
            return await _lastBookingEntryService.IsExist(model.LastBookingVersionYearId, model.LastBookingVersionMonthId, model.LastBookingVersionDayId);
        }

        [HttpGet]
        public async Task<IActionResult> ExportToExcel([FromQuery] LastBookingEntryModel model)
        {
            // Sample list of objects (replace with your actual data retrieval logic)
            List<LastBookingEntry> entries = await _lastBookingEntryService.Get(model.LastBookingVersionYearId, model.LastBookingVersionMonthId, model.LastBookingVersionDayId);

            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Specify the column order and custom column names
                var columnOrder = new Dictionary<string, string>
            {
                { nameof(LastBookingEntry.AWB), "FULL_AWB" },
                { nameof(LastBookingEntry.BookingLegStatus), "BKG_LEG_STATUS" },
                { nameof(LastBookingEntry.BookingCreatedDate), "BOOKING_DATE" },
                { nameof(LastBookingEntry.FlightDepartureDate), "FLIGHT_DEP_DATE" },
                { nameof(LastBookingEntry.BookingTime), "BOOKING_TIME" },
                { nameof(LastBookingEntry.FlightDepartureTime), "FLIGHT_DEP_TIME" },
                { nameof(LastBookingEntry.BookingOrigin), "BKG_ORIGIN" },
                { nameof(LastBookingEntry.BookingDestination), "BKG_DESTN" },
                { nameof(LastBookingEntry.BookingRateType), "BKG_RATE_CLASS" },
                { nameof(LastBookingEntry.AgentName), "AGENT_NAME" },
                { nameof(LastBookingEntry.BookingRowNumber), "BKG_ROW_NUM" },
                { nameof(LastBookingEntry.BookingKey), "BKG_KEY" },
                { nameof(LastBookingEntry.BookingDestinationRegion), "BKG_DEST_REGION" },
                { nameof(LastBookingEntry.BookingLastUpdatedBy), "BKG_LAST_UPDATED_BY" },
                { nameof(LastBookingEntry.BookingLastUpdatedByGMT), "BKG_LAST_UPDATED_GMT_DT" },
                { nameof(LastBookingEntry.BookingOriginCountry), "ORIGIN_COUNTRY" },
                { nameof(LastBookingEntry.BookingOriginSalesArea), "ORIGIN_SALES_AREA" },
                { nameof(LastBookingEntry.BookingOriginRegion), "ORIGIN_REGION" },
                { nameof(LastBookingEntry.BookingReference), "BKG_REF" },
                { nameof(LastBookingEntry.Channel), "CHANNEL_CD" },
                { nameof(LastBookingEntry.SpecialHandlingCodes), "SPH_CODES" },
                { nameof(LastBookingEntry.ChargeableWeight), "CHARGEABLE_WT" },
                { nameof(LastBookingEntry.Currency), "CURRENCY_CD" },
                { nameof(LastBookingEntry.RevGBP), "REV GBP" },
                { nameof(LastBookingEntry.RevForeign), "REV FOREIGN" },
                { nameof(LastBookingEntry.YieldGBP), "YIELD GBP" },
                { nameof(LastBookingEntry.YieldForeign), "YIELD FOREIGN" },
                { nameof(LastBookingEntry.BookingLegVolume), "BKG_LEG_VOLUME" },
                { nameof(LastBookingEntry.Volume), "VOLUME" },
                { nameof(LastBookingEntry.ProductCode), "PRODUCT_CODE" },
                { nameof(LastBookingEntry.ProductName), "PRODUCT_NAME" },
                { nameof(LastBookingEntry.FlightNumber), "FLIGHT_NUMBER" },
                { nameof(LastBookingEntry.MetalInfo), "FLIGHT_METAL" },
            };

                // Add custom column headers
                int columnIndex = 1;
                foreach (var kvp in columnOrder)
                {
                    worksheet.Cells[1, columnIndex].Value = kvp.Value;
                    columnIndex++;
                }

                // Load data with specific column order
                var properties = columnOrder.Select(kvp => kvp.Key).ToList();
                var dataRows = new List<object[]>();
                foreach (var item in entries)
                {
                    dataRows.Add(properties.Select(prop => item.GetType().GetProperty(prop).GetValue(item)).ToArray());
                }
                worksheet.Cells["A2"].LoadFromArrays(dataRows);
                var memoryStream = new MemoryStream();
                package.SaveAs(memoryStream);
                memoryStream.Position = 0;
                var byteArray = memoryStream.ToArray();
                // Set the content type and file name for the download
                return File(byteArray, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "data.xlsx");
            }

        }

        [HttpPost]
        public async Task<int> UpdateIsConsidered([FromBody] LastBookingEntryModel model)
        {
            return await _lastBookingEntryService.UpdateIsConsidered(model.BookingEntryId, model.IsConsidered);
        }



    }
}

