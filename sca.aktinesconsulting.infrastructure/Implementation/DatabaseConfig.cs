using Microsoft.Extensions.Options;
using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.infrastructure.Implementation
{
    public class DatabaseConfig : IDatabaseConfig
    {
        private readonly IOptions<AppSettings> _setting;    

        public DatabaseConfig(IOptions<AppSettings> setting)
        {
            _setting = setting;
        }
        public string ConnectionString
        {
            get { return _setting.Value.ConnectionString; }
        }

    }
}   
