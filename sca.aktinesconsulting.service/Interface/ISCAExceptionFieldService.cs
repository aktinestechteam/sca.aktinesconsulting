using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Interface
{
    public interface ISCAExceptionFieldService
    {
        Task<IList<SCAExceptionField>> GetAll();
    }
}
