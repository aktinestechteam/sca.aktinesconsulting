using System;
using System.Collections.Generic;
using System.Text;

namespace sca.aktinesconsulting.entitiy.QueryParameter
{
    public class SCAExceptionDelete
    {
        public int SCAExceptionId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
