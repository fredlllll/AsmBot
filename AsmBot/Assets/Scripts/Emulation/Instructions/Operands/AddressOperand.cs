using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    public class AddressOperand : Operand
    {
        Registers.Register register;
        public AddressOperand(string registerName)
        {
            register = Registers.RegisterNameToRegister(registerName);
        }

        public override byte GetByte(CPU cpu)
        {
            return cpu.memory.ReadByte((uint)(cpu.registers.DS + cpu.registers.GetRegisterWord(register)));
        }
        public override ushort GetWord(CPU cpu)
        {
            return cpu.memory.ReadWord((uint)(cpu.registers.DS + cpu.registers.GetRegisterWord(register)));
        }
        public override void SetByte(CPU cpu, byte value)
        {
            cpu.memory.WriteByte((uint)(cpu.registers.DS + cpu.registers.GetRegisterWord(register)), value);
        }
        public override void SetWord(CPU cpu, ushort value)
        {
            cpu.memory.WriteWord((uint)(cpu.registers.DS + cpu.registers.GetRegisterWord(register)), value);
        }

        public override OperandSize GetSize()
        {
            return OperandSize.Any;
        }
    }
}
