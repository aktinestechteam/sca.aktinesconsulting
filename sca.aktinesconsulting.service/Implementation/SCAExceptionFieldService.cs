using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.repository.Interface;
using sca.aktinesconsulting.service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Implementation
{
    public class SCAExceptionFieldService : ISCAExceptionFieldService
    {
        private readonly ISCAExceptionFieldRepository _scaExceptionFieldRepository;
        public SCAExceptionFieldService(ISCAExceptionFieldRepository scaExceptionFieldRepository)
        {
            _scaExceptionFieldRepository = scaExceptionFieldRepository;
        }

        public async Task<IList<SCAExceptionField>> GetAll()
        {
            return await _scaExceptionFieldRepository.GetAll();
        }

        public async Task<IList<SCAExceptionField>> GetBySCAExceptionFieldTypeId(int? scaExceptionFieldTypeId)
        {
            return await _scaExceptionFieldRepository.GetBySCAExceptionFieldTypeId(scaExceptionFieldTypeId);
        }

    }
}
