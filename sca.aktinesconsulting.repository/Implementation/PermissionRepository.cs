using AutoMapper;
using Dapper;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.infrastructure.Interface;
using sca.aktinesconsulting.repository.Common;
using sca.aktinesconsulting.repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.repository.Implementation
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly IDatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public PermissionRepository(IDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IList<UserPermission>> GetByUserId(int userId)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new { UserId = userId};
                    return (await SqlMapper.QueryAsync<UserPermission>(con, ConstantStoredProcedures.Permissions_GetByUserId, queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
