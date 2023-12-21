using sca.aktinesconsulting.entitiy.Report;
using sca.aktinesconsulting.repository.Interface;
using sca.aktinesconsulting.service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Implementation
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }


        public async Task<List<OutlierReport>> GetOutlierReport()
        {
            return await _reportRepository.GetOutlierReport();
        }
    }
}
