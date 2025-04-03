using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation
{
    public static class EmuUtil
    {
        public static uint ConvertAddress(ushort segment, ushort offset)
        {
            return ((uint)(segment << 16)) + offset;
        }
    }
}
