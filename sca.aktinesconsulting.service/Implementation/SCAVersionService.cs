using sca.aktinesconsulting.entitiy;
using sca.aktinesconsulting.repository.Interface;
using sca.aktinesconsulting.service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sca.aktinesconsulting.infrastructure.Common;
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
        public async Task<IList<SCAVersion>> GetAll()
        {
            var scaVersions= await _scaVersionRepository.GetAll();
            if (scaVersions != null)
            {
                scaVersions = BuildVersionName(scaVersions);
            }
            return scaVersions;
        }
        private List<SCAVersion> BuildVersionName(List<SCAVersion> scaVersions)
        {
            int ISTToUTCDifferenceSec = 19800;
            int counter = 0;
            var currVersion = string.Empty;
            var prevVersion = string.Empty;

            foreach (var version in scaVersions)
            {
                version.CreatedOn= version.CreatedOn.AddSeconds(ISTToUTCDifferenceSec);
                currVersion = version.CreatedOn.ToString("yyyy-MMM-dd");
                if (currVersion == prevVersion && prevVersion != string.Empty)
                    counter++;
                else
                    counter = 0;

                version.Name =$"SCA_RAW_DATA_{Utilities.GetDateSuffix(version.CreatedOn)}_VER_1.{counter} : {version.UserName}";
                prevVersion = currVersion;
            }
            return scaVersions.OrderByDescending(s=>s.SCAVersionId).ToList();
        }

    }
}
