using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.repository.Interface;
using sca.aktinesconsulting.service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Implementation
{
    public class LastBookingEntryService : ILastBookingEntryService
    {
        private readonly ILastBookingEntryRepository _lastBookingEntryRepository;
        public LastBookingEntryService(ILastBookingEntryRepository lastBookingEntryRepository)
        {
            _lastBookingEntryRepository = lastBookingEntryRepository;
        }
        public async Task<bool> Add(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId, int userId, DataTable dt)
        {
            await _lastBookingEntryRepository.Delete(lastBookingVersionYearId, lastBookingVersionMonthId, lastBookingVersionDayId);
            AddCustomColumn("LastBookingVersionYearId", typeof(int), lastBookingVersionYearId, dt);
            AddCustomColumn("LastBookingVersionMonthId", typeof(int), lastBookingVersionMonthId, dt);
            AddCustomColumn("LastBookingVersionDayId", typeof(int), lastBookingVersionDayId, dt);
            AddCustomColumn("CreatedBy", typeof(int), userId, dt);
            AddCustomColumn("CreatedOn", typeof(DateTime), DateTime.UtcNow, dt);
            AddCustomColumn("IsConsidered", typeof(bool), true, dt);
            dt.Columns.Add("FlightDepartureDateTime");
            dt.Columns.Add("BookingCreatedDateTime");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["BookingCreatedDateTime"] = Convert.ToDateTime($"{dt.Rows[i]["BookingCreatedDate"]} {dt.Rows[i]["BookingTime"]}");
                dt.Rows[i]["FlightDepartureDateTime"] = Convert.ToDateTime($"{dt.Rows[i]["FlightDepartureDate"]} {dt.Rows[i]["FlightDepartureTime"]}");
            }
            return _lastBookingEntryRepository.Add(dt);
        }
        public async Task<List<LastBookingEntry>> Get(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId)
        {
            return await _lastBookingEntryRepository.Get(lastBookingVersionYearId, lastBookingVersionMonthId, lastBookingVersionDayId);
        }
        public async Task<List<LastBookingEntry>> GetDuplicates(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId)
        {
            return await _lastBookingEntryRepository.GetDuplicates(lastBookingVersionYearId, lastBookingVersionMonthId, lastBookingVersionDayId);
        }

        public async Task<List<LastBookingEntryVersion>> GetVersions()
        {
            return await _lastBookingEntryRepository.GetVersions();
        }

        public async Task<LastBookingEntryVersionBreakup> GetVersionsBrekup()
        {
            var versions = await _lastBookingEntryRepository.GetVersions();
            var versionBrekup = new LastBookingEntryVersionBreakup();
            versionBrekup.Years = versions.Where(v => v.Type == "Year")
                                 .Select(v => new LastBookingEntryVersionYear
                                 {
                                     LastBookingVersionId = v.LastBookingVersionId,
                                     Year = Convert.ToInt32(v.Value)
                                 }).ToList();

            versionBrekup.Months = versions.Where(v => v.Type == "Month")
                               .Select(v => new LastBookingEntryVersionMonth
                               {
                                   LastBookingVersionId = v.LastBookingVersionId,
                                   Month = v.Value
                               }).ToList();

            versionBrekup.Days = versions.Where(v => v.Type == "Day")
                    .Select(v => new LastBookingEntryVersionDay
                    {
                        LastBookingVersionId = v.LastBookingVersionId,
                        Day = v.Value
                    }).ToList();


            return versionBrekup;
        }

        public async Task<bool> ValidateDateRang(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId, DataTable dt)
        {
            var versions = await _lastBookingEntryRepository.GetVersions();
            var selectedVersionYear = versions.Where(v => v.LastBookingVersionId == lastBookingVersionYearId).Select(v=>v.Value).FirstOrDefault();
            var selectedVersionMonth = versions.Where(v => v.LastBookingVersionId == lastBookingVersionMonthId).Select(v => v.Value).FirstOrDefault();
            var selectedVersionDay = versions.Where(v => v.LastBookingVersionId == lastBookingVersionDayId).Select(v => v.Value).FirstOrDefault();
            var monthYear = Convert.ToDateTime($"{selectedVersionYear}-{selectedVersionMonth}-01");
            var startDay = selectedVersionDay.Equals("Fortnight - 1") || selectedVersionDay.Equals("Entire Month") ? 1 : 16;
            var endDay = selectedVersionDay.Equals("Fortnight - 2") || selectedVersionDay.Equals("Entire Month") ? DateTime.DaysInMonth(monthYear.Year, monthYear.Month) : 15;
            var startDate= Convert.ToDateTime($"{selectedVersionYear}-{selectedVersionMonth}-{startDay}");
            var endDate = Convert.ToDateTime($"{selectedVersionYear}-{selectedVersionMonth}-{endDay}").AddHours(23).AddMinutes(59).AddSeconds(59);

            return CheckDataExistsInDateRange(dt, startDate, endDate, "FlightDepartureDate");
        }
        private bool CheckDataExistsInDateRange(DataTable dataTable, DateTime startDate, DateTime endDate,string columnName)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                DateTime dateValue;
                if (DateTime.TryParse(row[columnName].ToString(), out dateValue))
                {
                    if (dateValue >= startDate && dateValue <= endDate)
                    {
                        return true; // Data found in the specified date range
                    }
                }
                else
                {
                    //return false; // No data found in the specified date range
                }

            }
            return false; // No data found in the specified date range
        }


        public async Task<bool> IsExist(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId)
        {
            return await _lastBookingEntryRepository.IsExist(lastBookingVersionYearId, lastBookingVersionMonthId, lastBookingVersionDayId);
        }

        public async Task<int> UpdateIsConsidered(int bookingEntryId, bool isConsidered)
        {
            return await _lastBookingEntryRepository.UpdateIsConsidered(bookingEntryId, isConsidered);
        }

        private void AddCustomColumn(string name, Type dataType, object defaultValue, DataTable dt)
        {
            DataColumn column = new DataColumn(name, dataType);
            column.DefaultValue = defaultValue;
            dt.Columns.Add(column);
        }

        public void ReplaceColumnNames(DataTable dt)
        {
            if (dt.Rows.Count > 1)
            {
                for (int col = 1; col < dt.Columns.Count; col++)
                {
                    dt.Columns[col].ReadOnly = false;
                    var colName = Convert.ToString(dt.Rows[0][col]).ToUpper();
                    switch (colName)
                    {
                        case "FULL_AWB":
                            colName = "AWB";
                            break;
                        case "BKG_LEG_STATUS":
                            colName = "BookingLegStatus";
                            break;
                        case "BOOKING_DATE":
                            colName = "BookingCreatedDate";
                            break;
                        case "FLIGHT_DEP_DATE":
                            colName = "FlightDepartureDate";
                            break;
                        case "BOOKING_TIME":
                            colName = "BookingTime";
                            break;
                        case "FLIGHT_DEP_TIME":
                            colName = "FlightDepartureTime";
                            break;
                        case "BKG_ORIGIN":
                            colName = "BookingOrigin";
                            break;
                        case "BKG_DESTN":
                            colName = "BookingDestination";
                            break;
                        case "BKG_RATE_CLASS":
                            colName = "BookingRateType";
                            break;
                        case "AGENT_NAME":
                            colName = "AgentName";
                            break;
                        case "BKG_ROW_NUM":
                            colName = "BookingRowNumber";
                            break;
                        case "BKG_KEY":
                            colName = "BookingKey";
                            break;
                        case "BKG_DEST_REGION":
                            colName = "BookingDestinationRegion";
                            break;
                        case "BKG_LAST_UPDATED_BY":
                            colName = "BookingLastUpdatedBy";
                            break;
                        case "BKG_LAST_UPDATED_GMT_DT":
                            colName = "BookingLastUpdatedByGMT";
                            break;
                        case "ORIGIN_COUNTRY":
                            colName = "BookingOriginCountry";
                            break;
                        case "ORIGIN_SALES_AREA":
                            colName = "BookingOriginSalesArea";
                            break;
                        case "ORIGIN_REGION":
                            colName = "BookingOriginRegion";
                            break;
                        case "BKG_REF":
                            colName = "BookingReference";
                            break;
                        case "CHANNEL_CD":
                            colName = "Channel";
                            break;
                        case "SPH_CODES":
                            colName = "SpecialHandlingCodes";
                            break;
                        case "CHARGEABLE_WT":
                            colName = "ChargeableWeight";
                            break;
                        case "CURRENCY_CD":
                            colName = "Currency";
                            break;
                        case "REV GBP":
                            colName = "RevGBP";
                            break;
                        case "REV FOREIGN":
                            colName = "RevForeign";
                            break;
                        case "YIELD GBP":
                            colName = "YieldGBP";
                            break;
                        case "YIELD FOREIGN":
                            colName = "YieldForeign";
                            break;
                        case "BKG_LEG_VOLUME":
                            colName = "BookingLegVolume";
                            break;
                        case "VOLUME":
                            colName = "Volume";
                            break;
                        case "PRODUCT_CODE":
                            colName = "ProductCode";
                            break;
                        case "PRODUCT_NAME":
                            colName = "ProductName";
                            break;
                        case "FLIGHT_NUMBER":
                            colName = "FlightNumber";
                            break;
                        case "FLIGHT_METAL":
                            colName = "MetalInfo";
                            break;
                    }
                    dt.Columns[col].ColumnName = colName;
                }
                dt.Rows[0].Delete();
                dt.AcceptChanges();
            }


        }



    }
}
