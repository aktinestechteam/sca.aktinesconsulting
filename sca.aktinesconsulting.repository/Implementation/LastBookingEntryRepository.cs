using AutoMapper;
using Dapper;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.infrastructure.Interface;
using sca.aktinesconsulting.repository.Common;
using sca.aktinesconsulting.repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.repository.Implementation
{
    public class LastBookingEntryRepository : ILastBookingEntryRepository
    {
        private readonly IDatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public LastBookingEntryRepository(IDatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public bool Add(DataTable dt)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var bulkCopy = new SqlBulkCopy(con);
                    bulkCopy.BulkCopyTimeout = 0;
                    bulkCopy.DestinationTableName = ConstantStoredProcedures.Table_LastBookingEntries;
                    var schema = con.GetSchema("Columns", new[] { null, null, ConstantStoredProcedures.Table_LastBookingEntries, null });
                    foreach (DataColumn sourceColumn in dt.Columns)
                    {
                        foreach (DataRow row in schema.Rows)
                        {
                            if (string.Equals(sourceColumn.ColumnName, (string)row["COLUMN_NAME"], StringComparison.OrdinalIgnoreCase))
                            {
                                bulkCopy.ColumnMappings.Add(sourceColumn.ColumnName, (string)row["COLUMN_NAME"]);
                                break;
                            }
                        }
                    }
                    bulkCopy.WriteToServer(dt);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> Delete(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@LastBookingVersionYearId", lastBookingVersionYearId);
                    queryParameters.Add("@LastBookingVersionMonthId", lastBookingVersionMonthId);
                    queryParameters.Add("@LastBookingVersionDayId", lastBookingVersionDayId);
                    return (await SqlMapper.QueryAsync<int>(con, ConstantStoredProcedures.LastBookingEntries_Delete, queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<LastBookingEntry>> GetDuplicates(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@LastBookingVersionYearId", lastBookingVersionYearId);
                    queryParameters.Add("@LastBookingVersionMonthId", lastBookingVersionMonthId);
                    queryParameters.Add("@LastBookingVersionDayId", lastBookingVersionDayId);
                    return (await SqlMapper.QueryAsync<LastBookingEntry>(con, ConstantStoredProcedures.LastBookingEntries_GetDuplicates, queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<LastBookingEntry>> Get(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@LastBookingVersionYearId", lastBookingVersionYearId);
                    queryParameters.Add("@LastBookingVersionMonthId", lastBookingVersionMonthId);
                    queryParameters.Add("@LastBookingVersionDayId", lastBookingVersionDayId);
                    return (await SqlMapper.QueryAsync<LastBookingEntry>(con, ConstantStoredProcedures.LastBookingEntries_Get, queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> IsExist(int lastBookingVersionYearId, int lastBookingVersionMonthId, int lastBookingVersionDayId)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@LastBookingVersionYearId", lastBookingVersionYearId);
                    queryParameters.Add("@LastBookingVersionMonthId", lastBookingVersionMonthId);
                    queryParameters.Add("@LastBookingVersionDayId", lastBookingVersionDayId);
                    return (await SqlMapper.QueryAsync<bool>(con, ConstantStoredProcedures.LastBookingEntries_IsExist, queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<LastBookingEntryVersion>> GetVersions()
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    return (await SqlMapper.QueryAsync<LastBookingEntryVersion>(con, ConstantStoredProcedures.LastBookingVersions_Get, null, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateIsConsidered(int bookingEntryId, bool isConsidered)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new DynamicParameters();
                    queryParameters.Add("@BookingEntryId", bookingEntryId);
                    queryParameters.Add("@IsConsidered", isConsidered);
                    return (await SqlMapper.QueryAsync<int>(con, ConstantStoredProcedures.LastBookingEntries_UpdateIsConsidered, queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
