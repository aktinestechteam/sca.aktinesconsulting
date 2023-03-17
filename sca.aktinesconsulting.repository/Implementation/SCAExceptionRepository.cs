using AutoMapper;
using Dapper;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.entitiy.QueryParameter;
using sca.aktinesconsulting.infrastructure.Interface;
using sca.aktinesconsulting.repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.repository.Implementation
{
    public class SCAExceptionRepository : ISCAExceptionRepository
    {
        private readonly IDatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public SCAExceptionRepository(IDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SCAException>> GetAll()
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var result = (await SqlMapper.QueryAsync<SCAException>(con, "SCAExceptions_GetAll", null, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).AsEnumerable();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<SCAException> GetById(int scaExceptionId)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new SCAExceptionGet() { SCAExceptionId = scaExceptionId };
                    var result = (await SqlMapper.QueryAsync<SCAException>(con, "SCAExceptions_GetById", queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Add(SCAException scaException)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = _mapper.Map<SCAExceptionAdd>(scaException);
                    queryParameters.CreatedOn = DateTime.UtcNow;
                    queryParameters.IsActive = true;
                    var result = await SqlMapper.QuerySingleAsync<int>(con, "SCAExceptions_Add", queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure);
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> Update(SCAException scaException)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = _mapper.Map<SCAExceptionUpdate>(scaException);
                    queryParameters.UpdatedOn = DateTime.UtcNow;
                    queryParameters.IsActive = true;
                    var result = await SqlMapper.QuerySingleAsync<int>(con, "SCAExceptions_Update", queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure);
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> Delete(int scaExceptionId, int updatedBy)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new SCAExceptionDelete() { SCAExceptionId = scaExceptionId, UpdatedBy = updatedBy, UpdatedOn = DateTime.UtcNow, IsActive = false };
                    var result = await SqlMapper.QuerySingleAsync<int>(con, "SCAExceptions_Delete", queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure);
                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
