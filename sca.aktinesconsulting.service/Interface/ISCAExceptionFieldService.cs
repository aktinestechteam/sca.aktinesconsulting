using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Text;

namespace sca.aktinesconsulting.service.Interface
{
    public interface ISCAExceptionFieldService
    {
        IList<SCAExceptionField> GetAll();
    }
}
