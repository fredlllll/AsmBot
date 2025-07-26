using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.Rendering.DebugUI;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    public class MemoryRegisterOperand : Operand, IMemoryOperand
    {
        Register register;
        public MemoryRegisterOperand(Register register)
        {
            this.register = register;
        }

        public MemoryRegisterOperand(byte firstByte)
        {
            register = (Register)(firstByte >> 2);
        }

        private ushort GetRegisterValue(CPU cpu)
        {
            if (RegistersUtil.GetRegisterSize(register) == RegisterSize._8Bit)
            {
                return cpu.registers.GetRegisterByte(register);
            }
            return cpu.registers.GetRegisterWord(register);
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
            //TODO: memory access probably always word? or determined by other operand?
            return RegistersUtil.GetRegisterSize(register) == RegisterSize._8Bit ? OperandSize._8Bits : OperandSize._16Bits;
        }

        public override void GetBytes(BinaryWriter bw)
        {
            byte data = OperandType.MemoryRegister; // 0bxxxxxx00
            data |= (byte)(((byte)register) << 2); //  0bx00000xx
            bw.Write(data);
        }

        public override string ToString()
        {
            return "[" + RegistersUtil.registerToName[register] + "]";
        }

        public uint GetEffectiveAddress(CPU cpu)
        {
            return AddressUtil.ToGlobalAddress(cpu.registers.DS, GetRegisterValue(cpu));
        }
    }
}
