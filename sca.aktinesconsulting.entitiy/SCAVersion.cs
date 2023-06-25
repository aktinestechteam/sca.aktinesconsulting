using System;
using System.Collections.Generic;
using System.Text;

namespace sca.aktinesconsulting.entitiy
{
    public class SCAVersion
    {
        public int SCAVersionId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

