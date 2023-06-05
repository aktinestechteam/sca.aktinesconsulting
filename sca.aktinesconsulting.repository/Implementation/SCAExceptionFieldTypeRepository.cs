using Dapper;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.infrastructure.Interface;
using sca.aktinesconsulting.repository.Common;
using sca.aktinesconsulting.repository.Interface;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.repository.Implementation
{
    public class SCAExceptionFieldTypeRepository : ISCAExceptionFieldTypeRepository
    {
        private readonly IDatabaseContext _dbContext;
        public SCAExceptionFieldTypeRepository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<SCAExceptionFieldType>> GetAll()
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new DynamicParameters();
                    return (await SqlMapper.QueryAsync<SCAExceptionFieldType>(con, ConstantStoredProcedures.SCAExceptionFieldTypes_GetAll, queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
