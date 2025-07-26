using System;
using System.IO;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    public class RegisterOperand : Operand
    {
        Register register;


        public RegisterOperand(Register register)
        {
            this.register = register;
        }

        public RegisterOperand(byte firstByte)
        {
            register = (Register)(firstByte >> 2);
        }

        public override byte GetByte(CPU cpu) { return cpu.registers.GetRegisterByte(register); }
        public override ushort GetWord(CPU cpu) { return cpu.registers.GetRegisterWord(register); }
        public override void SetByte(CPU cpu, byte value) { cpu.registers.SetRegisterByte(register, value); }
        public override void SetWord(CPU cpu, ushort value) { cpu.registers.SetRegisterWord(register, value); }

        public override OperandSize GetSize()
        {
            var size = RegistersUtil.GetRegisterSize(register);
            switch (size)
            {
                case RegisterSize._8Bit:
                    return OperandSize._8Bits;
                case RegisterSize._16Bit:
                    return OperandSize._16Bits;
                default:
                    throw new Exception("cant determine register size");
            }
        }

        public override void GetBytes(BinaryWriter bw)
        {
            byte data = OperandType.Register; //0bxxxxxx00
            data |= (byte)(((byte)register) << 2);// 0bx00000xx
            bw.Write(data);
        }

        public override string ToString()
        {
            return RegistersUtil.registerToName[register];
        }
    }
}
