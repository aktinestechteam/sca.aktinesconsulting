using sca.aktinesconsulting.entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.core.PipeStream
{
    public class VolumePipeStream : IPipelineElement
    {
        public List<SCAException> Process(List<SCAException> scaRules, BookingEntry bookingEntry)
        {
            if (scaRules == null || scaRules.Count == 0)
                return null;
            var outputStream = new List<SCAException>();
            outputStream = scaRules.Where(r => (r.Volume == null || r.IsVolumeLessThan == null) || (
             r.IsVolumeLessThan == true && Convert.ToDecimal(bookingEntry.Volume) < r.Volume)).ToList();

            outputStream = outputStream.Where(r => (r.Volume == null || r.IsVolumeLessthanEqualTo == null) || (
             r.IsVolumeLessthanEqualTo == true && Convert.ToDecimal(bookingEntry.Volume) <= r.Volume)).ToList();

            outputStream = outputStream.Where(r => (r.Volume == null || r.IsVolumeEqualTo == null) || (
            r.IsVolumeEqualTo == true && Convert.ToDecimal(bookingEntry.Volume) == r.Volume)).ToList();

            outputStream = outputStream.Where(r => (r.Volume == null || r.IsVolumeGreaterThan == null) || (
            r.IsVolumeGreaterThan == true && Convert.ToDecimal(bookingEntry.Volume) > r.Volume)).ToList();

            outputStream= outputStream.Where(r => (r.Volume == null || r.IsVolumeGreaterThanEqualTo == null) || (
            r.IsVolumeGreaterThanEqualTo == true && Convert.ToDecimal(bookingEntry.Volume) >= r.Volume)).ToList();

            outputStream= outputStream.Where(r => (
            (r.VolumeRangeFrom == null && r.VolumeRangeTo == null) || r.IsVolumeRange == null) || 
            ((r.IsVolumeRange==true &&  Convert.ToDecimal(bookingEntry.Volume) >= r.VolumeRangeFrom) &&
            Convert.ToDecimal(bookingEntry.Volume) <= r.VolumeRangeTo)).ToList();

            return outputStream.Count > 0 ? outputStream : null;
        }
    }
}
