﻿using AutoMapper;
using Dapper;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.infrastructure.Interface;
using sca.aktinesconsulting.repository.Common;
using sca.aktinesconsulting.repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace sca.aktinesconsulting.repository.Implementation
{
    public class BookingEntryRepository : IBookingEntryRepository
    {
        private readonly IDatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public BookingEntryRepository(IDatabaseContext dbContext, IMapper mapper)
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
                    bulkCopy.DestinationTableName = ConstantStoredProcedures.Table_BookingEntries;
                    var schema = con.GetSchema("Columns", new[] { null, null, ConstantStoredProcedures.Table_BookingEntries, null });
                    foreach (DataColumn sourceColumn in dt.Columns)
                    {
                        foreach (DataRow row in schema.Rows)
                        {
                            if(string.Equals(sourceColumn.ColumnName,(string)row["COLUMN_NAME"], StringComparison.OrdinalIgnoreCase))
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

        public async Task<IList<BookingEntry>> GetBySCAVersionId(int scaVersionId)
        {
            try
            {
                using (var con = _dbContext.Connection)
                {
                    var queryParameters = new  { SCAVersionId = scaVersionId };
                    var result = (await SqlMapper.QueryAsync<BookingEntry>(con, ConstantStoredProcedures.BookingEntries_GetBySCAVersionId, queryParameters, commandTimeout: 0, commandType: System.Data.CommandType.StoredProcedure)).ToList();
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
