using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Interface
{
    public interface ISCAExceptionFieldTypeService
    {
        Task<IList<SCAExceptionFieldType>> GetAll();
    }
}
