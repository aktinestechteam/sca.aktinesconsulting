using AutoMapper;
using Dapper;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.infrastructure.Interface;
using sca.aktinesconsulting.repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly IDatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public UserRepository(IDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<User> Validate(string email, string password)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new  { Email = email,Password= password };
                    var result = (await SqlMapper.QueryAsync<User>(con, "Users_GetByEmail", queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
