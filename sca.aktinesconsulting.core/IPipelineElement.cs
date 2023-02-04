using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.core
{
    public interface IPipelineElement
    {
        List<SCAException> Process(List<SCAException> scaRules, BookingEntry bookingEntry);
    }
}
