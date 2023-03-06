using sca.aktinesconsulting.infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.infrastructure.Implementation
{
    public class DatabaseContext : IDatabaseContext
    {
        private IDatabaseConfig _databaseConfig { get; }
        public DatabaseContext(IDatabaseConfig databaseConfig)
        {
            _databaseConfig = databaseConfig;
        }
        public SqlConnection Connection
        {
            get
            {
                var cn = new SqlConnection(_databaseConfig.ConnectionString);
                cn.Open();
                return cn;
            }
        }
    }

}

