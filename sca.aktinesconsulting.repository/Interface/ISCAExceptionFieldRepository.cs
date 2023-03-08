using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace sca.aktinesconsulting.repository.Interface
{
    public interface ISCAExceptionFieldRepository
    {
        IList<SCAExceptionField> GetAll();
    }
}
