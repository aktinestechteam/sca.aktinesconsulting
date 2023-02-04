using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.core
{
    public class Pipeline
    {
        public List<IPipelineElement> pipeline = new List<IPipelineElement>();
        private IList<SCAException> _scaRules = null;
        private BookingEntry _bookingEntry = null;
        
        public void SetRules(IList<SCAException> scaRules)
        {
            _scaRules = scaRules;
        }
        public void SetInput(BookingEntry bookingEntry)
        {
            _bookingEntry = bookingEntry;
        }
        public void Add(IPipelineElement anElement)
        {
            pipeline.Add(anElement);
        }
        public BookingEntry Run()
        {
            var inputRules = _scaRules.ToList();
            for (int i = 0; i < pipeline.Count; i++)
            {
                inputRules = pipeline[i].Process(inputRules, _bookingEntry);
            }
            _bookingEntry.Exceptions = inputRules;
            return _bookingEntry;
        }
    }
}
