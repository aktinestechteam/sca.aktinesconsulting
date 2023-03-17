using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.repository.Interface
{
    public interface ISCAExceptionRepository
    {
        Task<IEnumerable<SCAException>> GetAll();
        Task<SCAException> GetById(int scaExceptionId);
        Task<bool> Add(SCAException scaException);
        Task<bool> Update(SCAException scaException);
        Task<bool> Delete(int scaExceptionId, int updatedBy);
    }
}
