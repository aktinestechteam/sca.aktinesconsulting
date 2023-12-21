using sca.aktinesconsulting.entitiy.Report;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.repository.Interface
{
    public interface IReportRepository
    {
        Task<List<OutlierReport>> GetOutlierReport();
    }
}
