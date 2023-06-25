using AutoMapper;
using Dapper;
using sca.aktinesconsulting.infrastructure.Interface;
using sca.aktinesconsulting.repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using sca.aktinesconsulting.repository.Interface;
using sca.aktinesconsulting.entitiy;

namespace sca.aktinesconsulting.repository.Implementation
{
    public class SCAVersionRepository : ISCAVersionRepository
    {
        private readonly IDatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public SCAVersionRepository(IDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<int> Add(int userId)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new { UserId = userId };
                   return await SqlMapper.QuerySingleAsync<int>(con, ConstantStoredProcedures.SCAVersions_Add, queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<SCAVersion>> GetAll()
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    return (await SqlMapper.QueryAsync<SCAVersion>(con, ConstantStoredProcedures.SCAVersions_GetAll, null, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
