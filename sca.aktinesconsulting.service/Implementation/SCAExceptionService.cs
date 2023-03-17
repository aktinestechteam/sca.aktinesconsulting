using sca.aktinesconsulting.core;
using sca.aktinesconsulting.core.PipeStream;
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
    public class SCAExceptionService : ISCAExceptionService
    {
        private readonly ISCAExceptionRepository _scaExceptionRepository;
        public SCAExceptionService(ISCAExceptionRepository scaExceptionRepository)
        {
            _scaExceptionRepository = scaExceptionRepository;
        }

        public async Task<IEnumerable<SCAException>> GetAll()
        {
            return await _scaExceptionRepository.GetAll();
        }

        public async Task<SCAException> GetById(int scaExceptionId)
        {
            return await _scaExceptionRepository.GetById(scaExceptionId);
        }
        public async Task<bool> Add(SCAException scaException)
        {
            return await _scaExceptionRepository.Add(scaException);
        }
        public async Task<bool> Update(SCAException scaException)
        {
            return await _scaExceptionRepository.Update(scaException);
        }
        public async Task<bool> Delete(int scaExceptionId, int updatedBy)
        {
            return await _scaExceptionRepository.Delete(scaExceptionId, updatedBy);
        }
        public DataTable Identify(DataTable dt)
        {
            ReplaceColumnNames(dt);
            List<BookingEntry> bookingEntries = ConvertDataTable<BookingEntry>(dt);
            var pipeline = BuildPipeLine();
            foreach (var bookingEntry in bookingEntries)
            {
                pipeline.SetInput(bookingEntry);
                pipeline.Run();
            }
            return CreateOutputTable(dt,bookingEntries);
        }
        private Pipeline BuildPipeLine()
        {
            var scaExceptions = GetExceptions();
            Pipeline pipeline = new Pipeline();
            //Include
            pipeline.Add(new StartDateEndDatePipeStream());
            pipeline.Add(new AgentCodePipeStream());
            pipeline.Add(new AWBPipeStream());
            pipeline.Add(new BookingDestinationRegionPipeStream());
            pipeline.Add(new BookingDestinationCountryPipeStream());
            pipeline.Add(new BookingDestinationPipeStream());
            pipeline.Add(new BookingOriginCountryPipeStream());
            pipeline.Add(new BookingOriginPipeStream());
            pipeline.Add(new BookingOriginRegionPipeStream());
            pipeline.Add(new BookingOriginSalesAreaPipeStream());
            pipeline.Add(new BookingRateTypePipeStream());
            pipeline.Add(new BookingReferencePipeStream());
            pipeline.Add(new ChannelPipeStream());
            pipeline.Add(new ChargeableWeightPipeStream());
            pipeline.Add(new CurrencyPipeStream());
            pipeline.Add(new FlightDepartureDatePipeStream());
            pipeline.Add(new RevCurrencyPipeStream());
            pipeline.Add(new SpecialHandlingCodesPipeStream());
            pipeline.Add(new VolumePipeStream());
            pipeline.Add(new YieldGBPPipeStream());
            pipeline.Add(new ProductCodePipeStream());
            pipeline.Add(new ProductNamePipeStream());
            pipeline.Add(new FlightNumberPipeStream());
            pipeline.Add(new MetalInfoPipeStream());
            //Exclude
            pipeline.Add(new ExcludeBookingOriginPipeStream());
            pipeline.Add(new ExcludeBookingDestinationPipeStream());
            pipeline.Add(new ExcludeBookingRateTypePipeStream());
            pipeline.Add(new ExcludeBookingDestinationRegionPipeStream());
            pipeline.Add(new ExcludeAgentCodePipeStream());
            pipeline.Add(new ExcludeBookingDestinationCountryPipeStream());
            pipeline.Add(new ExcludeBookingOriginCountryPipeStream());
            pipeline.Add(new ExcludeBookingOriginSalesAreaPipeStream());
            pipeline.Add(new ExcludeBookingOriginRegionPipeStream());
            pipeline.Add(new ExcludeChannelPipeStream());
            pipeline.Add(new ExcludeProductCodePipeStream());
            pipeline.Add(new ExcludeFlightNumberPipeStream());
            pipeline.Add(new ExcludeMetalInfoPipeStream());
            pipeline.Add(new ExcludeSpecialHandlingCodesPipeStream());
            pipeline.SetRules(scaExceptions.ToList());
            return pipeline;
        }
        private List<SCAException>GetExceptions()
        {
            //var exceptions=_scaExceptionRepository.GetAll().Result;
            return new List<SCAException>()
            {
                new SCAException() {SCAExceptionId=1,StartDate=new DateTime(2022,1,1),EndDate=new DateTime(2023,12,31),
                    BookingOriginCountry="India",
                    IsVolumeRange=true,
                    VolumeRangeFrom=1,
                    VolumeRangeTo=33,
                    ExcludeBookingDestination="IAH",
                    ExcludeBookingDestinationRegion="LATAM|Africa",
                    Description="Bookings < 33 mc all destinations (exclude ATL, ORD, LATAM and Africa) for all products" },


                    //new SCAException() {Id=1,StartDate=new DateTime(2022,1,1),EndDate=new DateTime(2023,12,31),
                    //BookingOriginCountry="India",
                    //IsVolumeLessThan=true,
                    //Volume=10,
                    //ExcludeBookingDestination="ALT|ORD",
                    //ExcludeBookingDestinationRegion="LATAM|Africa",
                    //Description="Bookings < 33 mc all destinations (exclude ATL, ORD, LATAM and Africa) for all products" },

                new SCAException() {SCAExceptionId=2,StartDate=new DateTime(2022,1,1),
                    EndDate=new DateTime(2023,12,31),BookingOriginCountry="India",
                    SpecialHandlingCodes="COU",
                    Description="Products -  Courier"},

                 new SCAException() {SCAExceptionId=3,StartDate=new DateTime(2022,1,1),
                    EndDate=new DateTime(2023,12,31),BookingOriginCountry="India",
                    SpecialHandlingCodes="RMD|AVI",
                    Description="Specialist"},

                new SCAException() {SCAExceptionId=4,StartDate=new DateTime(2022,1,1),EndDate=new DateTime(2023,12,31),
                    BookingOriginCountry="India",   
                    Volume=22,
                    IsVolumeLessThan=true,
                    SpecialHandlingCodes="ACT|PCT|XPS",
                    ExcludeAgentCode="14346150022|14335440000|14335440022|14335440033|14335440044|14335440055|14335449052",
                    Description="CC / XPS <22mc no SCA required to the Americas (exclude Agiligy, Expeditors , Kuehne Nagel)"},
                
                new SCAException() {SCAExceptionId=5,StartDate=new DateTime(2022,1,1),EndDate=new DateTime(2023,12,31),
                    BookingOriginCountry="India",
                    SpecialHandlingCodes="BSU|BSL|BSC|CPU|CPL",
                    Description="BSA (SHC - BSU or BSL/BSC) and CPA (SHC - CPU or CPL) is exempted"},
            };
        }
        private void ReplaceColumnNames(DataTable dt)
        {
            if (dt.Rows.Count > 1)
            {
                for (int col = 1; col < dt.Columns.Count; col++)
                {
                    dt.Columns[col].ReadOnly = false;
                    var colName =Convert.ToString(dt.Rows[0][col]).ToUpper();
                    switch (colName)
                    {
                        case "FULL_AWB":
                            colName = "AWB";
                            break;
                        case "BOOKING_DATE":
                            colName = "BookingCreatedDate";
                            break;
                        case "FLIGHT_DEP_DATE":
                            colName = "FlightDepartureDate";
                            break;
                        case "BKG_ORIGIN":
                            colName = "BookingOrigin";
                            break;
                        case "BKG_DESTN":
                            colName = "BookingDestination";
                            break;
                        case "BKG_RATE_TYPE":
                            colName = "BookingRateType";
                            break;
                        case "CURRENCY":
                            colName = "CurrencyCD";
                            break;
                        case "AGENT":
                            colName = "AgentCode";
                            break;
                        case "AGENT_NAME":
                            colName = "AgentName";
                            break;
                        case "BKG_DEST_COUNTRY":
                            colName = "BookingDestinationCountry";
                            break;
                        case "BKG_DEST_REGION":
                            colName = "BookingDestinationRegion";
                            break;
                        case "BKG_LAST_UPDATED_BY":
                            colName = "BookingLastUpdatedBy";
                            break;
                        case "BKG_ORIGIN_COUNTRY":
                            colName = "BookingOriginCountry";
                            break;
                        case "BKG_ORIGIN_EXT_SALES_AREA":
                            colName = "BookingOriginSalesArea";
                            break;
                        case "BKG_ORI_REGION":
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
                        case "REV GBP":
                            colName = "RevGBP";
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
                        case "METAL_INFO":
                            colName = "MetalInfo";
                            break;
                    }
                    dt.Columns[col].ColumnName = colName;
                }
                dt.Rows[0].Delete();
                dt.AcceptChanges();
            }


        }
        private  List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private  T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        private DataTable CreateOutputTable(DataTable dt, List<BookingEntry> bookingEntries)
        {
            dt.Columns.Add("ExceptionId");
            dt.Columns.Add("ExceptionDescription");
            dt.Columns.Add("ExceptionRuleExist");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (bookingEntries[i].Exceptions != null && bookingEntries[i].Exceptions.Count > 0)
                {
                    var exceptionId = string.Empty;
                    var exceptionDescription = string.Empty;

                    for (int exp = 0; exp < bookingEntries[i].Exceptions.Count; exp++)
                    {
                        exceptionId = exceptionId + "EXP-" + bookingEntries[i].Exceptions[exp].SCAExceptionId + ";";
                        exceptionDescription = exceptionDescription + bookingEntries[i].Exceptions[exp].Description + ";";
                    }
                    dt.Rows[i]["ExceptionId"] = exceptionId;
                    dt.Rows[i]["ExceptionDescription"] = exceptionDescription;
                    dt.Rows[i]["ExceptionRuleExist"] = bookingEntries[i].IsDateExcetionExist;
                }

            }
            return dt;
        }
    }
}
