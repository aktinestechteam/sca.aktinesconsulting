using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Interface
{
    public interface IExceptionService
    {
        DataTable Identify(DataTable dt);
    }
}
