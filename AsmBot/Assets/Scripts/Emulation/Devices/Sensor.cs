using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Devices

{
    public class Sensor : IDevice
    {
        public Memory MappedMemory => null;

        public ushort[] Ports => new ushort[] { 0x456 };

        public byte ReadPortByte(ushort port)
        {
            return 7;
        }

        public ushort ReadPortWord(ushort port)
        {
            return 7;
        }

        public void WritePortByte(ushort port, byte value)
        {
            throw new NotImplementedException();
        }

        public void WritePortWord(ushort port, ushort value)
        {
            throw new NotImplementedException();
        }
    }
}
