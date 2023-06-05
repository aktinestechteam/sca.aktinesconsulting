using Dapper;
using sca.aktinesconsulting.entitiy;
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
    public class SCAExceptionFieldRepository : ISCAExceptionFieldRepository
    {
        private readonly IDatabaseContext _dbContext;
        public SCAExceptionFieldRepository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<SCAExceptionField>> GetAll()
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new DynamicParameters();
                    return (await SqlMapper.QueryAsync<SCAExceptionField>(con, ConstantStoredProcedures.SCAExceptionFields_GetAll, queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<IList<SCAExceptionField>> GetBySCAExceptionFieldTypeId(int? scaExceptionFieldTypeId)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@SCAExceptionFieldTypeId", scaExceptionFieldTypeId);
                    return (await SqlMapper.QueryAsync<SCAExceptionField>(con, ConstantStoredProcedures.SCAExceptionFields_GetBySCAExceptionFieldTypeId, queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
