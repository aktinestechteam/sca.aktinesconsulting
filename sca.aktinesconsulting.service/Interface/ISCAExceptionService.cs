using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Interface
{
    public interface ISCAExceptionService
    {
        Task<IEnumerable<SCAException>> GetAll();
        Task<SCAException> GetById(int scaExceptionId);

        Task<bool> Add(SCAException scaException);
        Task<bool> Update(SCAException scaException);
        Task<bool> Delete(int scaExceptionId, int updatedBy);
        Task<BookingEntry> Validate(BookingEntry bookingEntry);
        Task<DataTable> Identify(int userId,DataTable dt);
    }
}
