using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskMonWithWPFUI.Model
{
    internal class DiskIoModel
    {
     
        public string? Time { get; set; }
   
        public int DiskNumber { get; set; }
        public string? Request { get; set; }

        public long Sector { get; set; }
        public int Length { get; set; }


    }
}
