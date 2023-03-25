using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.core.PipeStream
{
    public class ChargeableWeightPipeStream : IPipelineElement
    {
        public List<SCAException> Process(List<SCAException> scaRules, BookingEntry bookingEntry)
        {
            if (scaRules == null || scaRules.Count == 0)
                return null;

            var outputStream = new List<SCAException>();
            outputStream = scaRules.Where(r => (r.ChargeableWeight == null || string.IsNullOrEmpty(bookingEntry.ChargeableWeight) || r.IsChargeableWeightLessThan == null) || (
              r.IsChargeableWeightLessThan == true && Convert.ToDecimal(bookingEntry.ChargeableWeight) < r.ChargeableWeight)).ToList();

            outputStream = outputStream.Where(r => (r.ChargeableWeight == null || string.IsNullOrEmpty(bookingEntry.ChargeableWeight) || r.IsChargeableWeightLessthanEqualTo == null) || (
             r.IsChargeableWeightLessthanEqualTo == true && Convert.ToDecimal(bookingEntry.ChargeableWeight) <= r.ChargeableWeight)).ToList();

            outputStream = outputStream.Where(r => (r.ChargeableWeight == null || string.IsNullOrEmpty(bookingEntry.ChargeableWeight) || r.IsChargeableWeightEqualTo == null) || (
            r.IsChargeableWeightEqualTo == true && Convert.ToDecimal(bookingEntry.ChargeableWeight) == r.ChargeableWeight)).ToList();

            outputStream = outputStream.Where(r => (r.ChargeableWeight == null || string.IsNullOrEmpty(bookingEntry.ChargeableWeight) || r.IsChargeableWeightGreaterThan == null) || (
            r.IsChargeableWeightGreaterThan == true && Convert.ToDecimal(bookingEntry.ChargeableWeight) > r.ChargeableWeight)).ToList();

            outputStream = outputStream.Where(r => (r.ChargeableWeight == null || string.IsNullOrEmpty(bookingEntry.ChargeableWeight) || r.IsChargeableWeightGreaterThanEqualTo == null) || (
             r.IsChargeableWeightGreaterThanEqualTo == true && Convert.ToDecimal(bookingEntry.ChargeableWeight) >= r.ChargeableWeight)).ToList();

            outputStream = outputStream.Where(r => (string.IsNullOrEmpty(bookingEntry.ChargeableWeight) ||
             (r.ChargeableWeightRangeFrom == null && r.ChargeableWeightRangeTo == null) || r.IsChargeableWeightRange == null) ||
             ((r.IsChargeableWeightRange == true && Convert.ToDecimal(bookingEntry.ChargeableWeight) >= r.ChargeableWeightRangeFrom) &&
             Convert.ToDecimal(bookingEntry.ChargeableWeight) <= r.ChargeableWeightRangeTo)).ToList();

            return outputStream.Count > 0 ? outputStream : null;
        }
    }
}
