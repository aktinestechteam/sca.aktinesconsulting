using sca.aktinesconsulting.repository.Interface;
using sca.aktinesconsulting.service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Implementation
{
    public class SCAVersionService : ISCAVersionService
    {
        private readonly ISCAVersionRepository _scaVersionRepository;
        public SCAVersionService(ISCAVersionRepository scaVersionRepository)
        {
            _scaVersionRepository = scaVersionRepository;
        }
        public async Task<int> Add(int userId)
        {
            return await _scaVersionRepository.Add(userId);
        }
    }
}
