using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Experimental.GraphView;

namespace Assets.Scripts.Emulation
{
    public interface IDevice
    {
        Memory MappedMemory { get; }
        ushort[] Ports { get; }

        byte ReadPortByte(ushort port);
        ushort ReadPortWord(ushort port);
        void WritePortByte(ushort port, byte value);
        void WritePortWord(ushort port, ushort value);
    }
}
