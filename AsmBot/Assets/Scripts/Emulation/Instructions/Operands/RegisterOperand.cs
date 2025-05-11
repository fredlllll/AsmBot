using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityEngine.Rendering.DebugUI;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    public class RegisterOperand : Operand
    {
        Registers.Register register;

        public RegisterOperand(string name)
        {
            register = Registers.RegisterNameToRegister(name);
        }

        public RegisterOperand(Registers.Register register)
        {
            this.register = register;
        }

        public override byte GetByte(CPU cpu) { return cpu.registers.GetRegisterByte(register); }
        public override ushort GetWord(CPU cpu) { return cpu.registers.GetRegisterWord(register); }
        public override void SetByte(CPU cpu, byte value) { cpu.registers.SetRegisterByte(register, value); }
        public override void SetWord(CPU cpu, ushort value) { cpu.registers.SetRegisterWord(register, value); }

        public override OperandSize GetSize()
        {
            var size = Registers.GetRegisterSize(register);
            switch (size)
            {
                case Registers.RegisterSize._8Bit:
                    return OperandSize._8Bits;
                case Registers.RegisterSize._16Bit:
                    return OperandSize._16Bits;
                default:
                    throw new Exception("cant determine register size");
            }
        }
    }
}
