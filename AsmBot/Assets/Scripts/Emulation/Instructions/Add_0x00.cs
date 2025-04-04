using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    public class Add_0x00 : Instruction
    {
        public static readonly string description = "ADD r/m8, r8";

        public Add_0x00() : base(0x00, description) { }

        private byte Add(byte one, byte two)
        {
            return checked((byte)(one + two));
        }

        public override void Execute(CPU cpu)
        {
            ModRM modRM = new(cpu.FetchNextCodeByte());

            // r8 (source)
            byte operand2 = cpu.registers.GetRegisterByte(modRM.Register);
            uint address = 0;
            byte operand1 = 0;
            byte result = 0;
            if (modRM.IsMemoryOperand)
            {//m8
                address = modRM.CalculateEffectiveAddress(cpu);
                operand1 = cpu.bus.ReadByte(address);
            }
            else
            {//r8
                operand1 = cpu.registers.GetRegisterByte(modRM.RM);
            }
            int tmp = operand1 + operand2;
            result = (byte)tmp;
            cpu.registers.Flags.CF = tmp > byte.MaxValue; //exceeded register size
            cpu.registers.Flags.OF = ((byte)tmp & 0x80) != (operand1 & 0x80); //sign bit flipped
            cpu.registers.Flags.ZF = tmp == 0; //is zero
            cpu.registers.Flags.SF = result > sbyte.MaxValue; //is sign bit set
            //TODO: AF: when there is a carry from the lower 4 bits to the higher 4 bits
            //TODO: PF: parity of result, 1= parity even

            if (modRM.IsMemoryOperand)
            {
                cpu.bus.Write(address, result);
            }
            else
            {
                cpu.registers.SetRegisterByte(modRM.RM, result);
            }
        }
    }
}
