using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Interface
{
    public interface IPermissionService
    {
        Task<IList<UserPermission>> GetByUserId(int userId);
    }
}
