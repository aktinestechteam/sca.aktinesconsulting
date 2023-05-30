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


            outputStream = scaRules.Where(r => (
            r.IsVolumeRange == false 
            && (r.Volume == null || string.IsNullOrEmpty(bookingEntry.Volume) || r.IsVolumeLessThan == null) || (
             r.IsVolumeLessThan == true && Convert.ToDecimal(bookingEntry.Volume) < r.Volume))).ToList();
            
           
            outputStream.AddRange(scaRules.Where(r => (r.IsVolumeRange == false && (r.Volume == null || string.IsNullOrEmpty(bookingEntry.Volume) || r.IsVolumeLessthanEqualTo == null) || (
             r.IsVolumeLessthanEqualTo == true && Convert.ToDecimal(bookingEntry.Volume) <= r.Volume))).ToList().Distinct());


            outputStream.AddRange(scaRules.Where(r => (r.IsVolumeRange == false && (r.Volume == null || string.IsNullOrEmpty(bookingEntry.Volume) || r.IsVolumeEqualTo == null) || (
            r.IsVolumeEqualTo == true && Convert.ToDecimal(bookingEntry.Volume) == r.Volume))).ToList().Distinct());

            outputStream.AddRange(scaRules.Where(r => (r.IsVolumeRange == false && (r.Volume == null || string.IsNullOrEmpty(bookingEntry.Volume) || r.IsVolumeGreaterThan == null) || (
            r.IsVolumeGreaterThan == true && Convert.ToDecimal(bookingEntry.Volume) > r.Volume))).ToList().Distinct());

            outputStream.AddRange(scaRules.Where(r => (r.IsVolumeRange == false && (r.Volume == null || string.IsNullOrEmpty(bookingEntry.Volume) || r.IsVolumeGreaterThanEqualTo == null) || (
            r.IsVolumeGreaterThanEqualTo == true && Convert.ToDecimal(bookingEntry.Volume) >= r.Volume))).ToList().Distinct());

            
            outputStream.AddRange(scaRules.Where(r => r.IsVolumeRange==true  && ((string.IsNullOrEmpty(bookingEntry.Volume) ||
            (r.VolumeRangeFrom == null && r.VolumeRangeTo == null)) || 
            ((r.IsVolumeRange==true &&  Convert.ToDecimal(bookingEntry.Volume) >= r.VolumeRangeFrom) &&
            Convert.ToDecimal(bookingEntry.Volume) <= r.VolumeRangeTo))).ToList().Distinct());

            return outputStream.Count > 0 ? outputStream.Distinct().ToList() : null;
        }



    }
}
