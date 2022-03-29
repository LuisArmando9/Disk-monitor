using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiskMonWithWPFUI.Model;

namespace DiskMonWithWPFUI.Helpers
{
    class DiskIoHelper
    {
        const int KB = 1024;

        public static DiskIoModel GetDiskIoModel(DiskIOTraceData diskIOTraceData)
        {
            var eventNames = diskIOTraceData.EventName.Split("/");
            return new()
            {
                Sector = SectorHelper.GetSectorPosition(diskIOTraceData.ByteOffset),
                DiskNumber = diskIOTraceData.DiskNumber,
                Length = diskIOTraceData.TransferSize / KB,
                Request = eventNames[eventNames.Length-1],
                Time = string.Format("{0:hh:mm:ss tt}", DateTime.Now)


            };
        }


    }
}
