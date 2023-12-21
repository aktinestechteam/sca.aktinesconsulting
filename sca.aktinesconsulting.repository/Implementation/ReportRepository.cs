using AutoMapper;
using Dapper;
using sca.aktinesconsulting.entitiy.Report;
using sca.aktinesconsulting.infrastructure.Interface;
using sca.aktinesconsulting.repository.Common;
using sca.aktinesconsulting.repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.repository.Implementation
{
    public class ReportRepository : IReportRepository
    {
        private readonly IDatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public ReportRepository(IDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<OutlierReport>> GetOutlierReport()
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    return (await SqlMapper.QueryAsync<OutlierReport>(con, ConstantStoredProcedures.Report_GetOutlierReport, null, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
