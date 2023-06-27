using System;
using System.Collections.Generic;
using System.Text;

namespace sca.aktinesconsulting.entitiy
{
    public class UserPermission
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string PermissionName { get; set; }
        public int PermissionId { get; set; }
        public bool View { get; set; }
        public bool Create { get; set; }
        public bool Modify { get; set; }
        public bool Delete { get; set; }
    }
}
