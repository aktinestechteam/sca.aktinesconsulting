using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.repository.Interface;
using sca.aktinesconsulting.service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace sca.aktinesconsulting.service.Implementation
{
    public class SCAExceptionFieldService : ISCAExceptionFieldService
    {
        private readonly ISCAExceptionFieldRepository _scaExceptionFieldRepository;
        public SCAExceptionFieldService(ISCAExceptionFieldRepository scaExceptionFieldRepository)
        {
            _scaExceptionFieldRepository = scaExceptionFieldRepository;
        }

        public IList<SCAExceptionField> GetAll()
        {
            return _scaExceptionFieldRepository.GetAll();
        }

    }
}
