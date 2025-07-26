using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    public class ImmediateOperand : Operand
    {
        public ushort value;

        public ImmediateOperand(ushort value)
        {
            this.value = value;
        }

        public ImmediateOperand(byte firstByte, BinaryReader br)
        {
            this.value = br.ReadUInt16();
        }

        public override byte GetByte(CPU cpu) { return (byte)value; }
        public override ushort GetWord(CPU cpu) { return value; }
        public override void SetByte(CPU cpu, byte value) { throw new InvalidOperationException("cant set constant"); }
        public override void SetWord(CPU cpu, ushort value) { throw new InvalidOperationException("cant set constant"); }

        public override OperandSize GetSize()
        {
            return OperandSize.Any;
        }

        public override void GetBytes(BinaryWriter bw)
        {
            //cant really use any of the other bits in the operand type
            bw.Write(OperandType.Immediate);
            bw.Write(value);
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
