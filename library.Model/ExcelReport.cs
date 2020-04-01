using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace library.Model
{
    public class ExcelReport
    {
        public MemoryStream memoryStream { get; set; }
        public string fileName { get; set; }
    }
}
