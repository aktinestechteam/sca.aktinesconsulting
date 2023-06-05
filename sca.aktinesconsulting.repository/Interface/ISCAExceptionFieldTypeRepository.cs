using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.repository.Interface
{
    public interface ISCAExceptionFieldTypeRepository
    {
        Task<IList<SCAExceptionFieldType>> GetAll();
    }
}
