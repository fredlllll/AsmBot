using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    public abstract class Operand
    {
        public virtual byte GetByte(CPU cpu) { return 0; }
        public virtual ushort GetWord(CPU cpu) { return 0; }
        public virtual void SetByte(CPU cpu, byte value) { }
        public virtual void SetWord(CPU cpu, ushort value) { }
        public virtual OperandSize GetSize() { return OperandSize.Any; }
    }
    public enum OperandSize
    {
        Any = 0,
        _8Bits = 1,
        _16Bits = 2,
    }
}
