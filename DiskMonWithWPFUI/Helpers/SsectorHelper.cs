using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskMonWithWPFUI.Helpers
{
    public class SectorHelper
    {
        const ushort SECTOR_SIZE = 512; 
        public static long GetSectorPosition(long byteOffset)   => (byteOffset / SECTOR_SIZE);
    }
}
