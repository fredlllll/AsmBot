using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    public class MemoryImmediateOperand : Operand, IMemoryOperand
    {
        ushort value;
        public MemoryImmediateOperand(ushort value)
        {
            this.value = value;
        }

        public MemoryImmediateOperand(byte firstByte, BinaryReader br)
        {
            this.value = br.ReadUInt16();
        }

        public override byte GetByte(CPU cpu)
        {
            return cpu.memory.ReadByte(GetEffectiveAddress(cpu));
        }
        public override ushort GetWord(CPU cpu)
        {
            return cpu.memory.ReadWord(GetEffectiveAddress(cpu));
        }
        public override void SetByte(CPU cpu, byte value)
        {
            cpu.memory.WriteByte(GetEffectiveAddress(cpu), value);
        }
        public override void SetWord(CPU cpu, ushort value)
        {
            cpu.memory.WriteWord(GetEffectiveAddress(cpu), value);
        }

        public override OperandSize GetSize()
        {
            return OperandSize.Any;
        }

        public override void GetBytes(BinaryWriter bw)
        {
            //cant really use any of the other bits in the operand type
            bw.Write(OperandType.MemoryImmediate);
            bw.Write(value);
        }

        public override string ToString()
        {
            return "[" + value + "]";
        }

        public uint GetEffectiveAddress(CPU cpu)
        {
            return AddressUtil.ToGlobalAddress(cpu.registers.DS, value);
        }
    }
}
