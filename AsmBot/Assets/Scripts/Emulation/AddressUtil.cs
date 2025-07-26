using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation
{
    public static class AddressUtil
    {
        public static uint ToGlobalAddress(ushort segment, ushort offset)
        {
            return (uint)((segment << 16) | offset);
        }

        public static (ushort segment, ushort offset) ToSegmentAndOffset(uint globalAddress)
        {
            var offset = (ushort)(globalAddress & 0xffff);
            var segment = (ushort)(globalAddress >> 16);
            return (segment, offset);
        }
    }
}
