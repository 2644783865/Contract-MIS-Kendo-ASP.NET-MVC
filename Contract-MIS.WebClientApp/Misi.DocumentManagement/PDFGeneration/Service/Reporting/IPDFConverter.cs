using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misi.DocumentManagement.PDFGeneration.Service.Reporting 
{
    public interface IPDFConverter  
    { 
        byte[] Convert(string source, string commandLocation);
        byte[] ConvertDetail(string source, string commandLocation);
        
    }
}
