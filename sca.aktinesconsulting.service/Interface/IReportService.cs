using sca.aktinesconsulting.entitiy.Report;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Interface
{
    public interface IReportService
    {
        Task<List<OutlierReport>> GetOutlierReport();
    }
}
