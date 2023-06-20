using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.repository.Interface
{
    public interface ISCAExceptionFieldRepository
    {
        Task<IList<SCAExceptionField>> GetAll();
        Task<IList<SCAExceptionField>> GetBySCAExceptionFieldTypeId(int? scaExceptionFieldTypeId);
        Task<int> AddUpdate(int scaExceptionFieldTypeId, string name, int userId);
        Task<int> Delete(int scaExceptionFieldId);

    }
}
