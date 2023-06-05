using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.repository.Interface;
using sca.aktinesconsulting.service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Implementation
{
    public class SCAExceptionFieldTypeService : ISCAExceptionFieldTypeService
    {
        private readonly ISCAExceptionFieldTypeRepository _scaExceptionFieldTypeRepository;
        public SCAExceptionFieldTypeService(ISCAExceptionFieldTypeRepository scaExceptionFieldTypeRepository)
        {
            _scaExceptionFieldTypeRepository = scaExceptionFieldTypeRepository;
        }
        public async Task<IList<SCAExceptionFieldType>> GetAll()
        {
            return await _scaExceptionFieldTypeRepository.GetAll();
        }
    }
}
