using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.infrastructure.Interface
{
    public interface IDatabaseContext
    {
        SqlConnection Connection { get; }
    }
}
