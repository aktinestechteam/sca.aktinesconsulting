using Dapper;
using sca.aktinesconsulting.infrastructure.Interface;
using sca.aktinesconsulting.repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.repository.Implementation
{
    public class ExceptionRepository : IExceptionRepository
    {
        private readonly IDatabaseContext _dbContext;

        public ExceptionRepository(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool GetAll()
        {
            try
            {
                using(var con = _dbContext.Connection)
                {
                    var queryParameters = new DynamicParameters();
                    //queryParameters.Add("@UserId", userId);
                    var result = SqlMapper.Query<dynamic>(con, "SCAExceptionRules_Get", queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    if (result.Count > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
