using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sca.aktinesconsulting.service.Interface
{
    public interface IFileService
    {
        List<DataTable> ExcelDataReader(string fileToRead, string sheetName, string col);
        List<DataTable> ExcelDataReader(MemoryStream file, string sheetName, string col);
    }
}
