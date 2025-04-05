using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    public class Operand
    {
        public byte GetByte() { return 0; }
        public ushort GetWord() { return 0; }
        public void SetByte(byte value) { }
        public void SetWord(ushort value) { }
    }
}
