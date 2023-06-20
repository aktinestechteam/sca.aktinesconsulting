using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.web.Models
{
    public class SCAExceptionFieldModel
    {
        public int SCAExceptionFieldId { get; set; }
        public int  SCAExceptionFieldTypeId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
    }
}
