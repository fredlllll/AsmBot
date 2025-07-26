using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.MUL)]
    public class Mul : Instruction
    {
        public Mul(Operand[] operands) : base(operands) { }

        //sets OF,CF
        /**
IF (Byte operation) THEN
    AX := AL ∗ SRC;
ELSE IF (* Word or doubleword operation *)
    DX:AX := AX ∗ SRC;
FI
        */

        private void Execute8Bit(CPU cpu, Operand multiplier)
        {
            var b1 = cpu.registers.GetRegisterByte(Register.R8_AL);
            var b2 = multiplier.GetByte(cpu);
            var result = b1 * b2;

            cpu.registers.Flags.CF = cpu.registers.Flags.OF = result > byte.MaxValue;

            cpu.registers.SetRegisterWord(Register.R16_AX, (ushort)result);
        }

        private void Execute16Bit(CPU cpu, Operand multiplier)
        {
            uint w1 = cpu.registers.GetRegisterWord(Register.R16_AX);
            uint w2 = multiplier.GetWord(cpu);
            var result = w1 * w2;

            cpu.registers.Flags.CF = cpu.registers.Flags.OF = result > ushort.MaxValue;

            cpu.registers.SetRegisterWord(Register.R16_AX, (ushort)result);
            cpu.registers.SetRegisterWord(Register.R16_DX, (ushort)(result >> 16));
        }

        public override void Execute(CPU cpu)
        {
            var multiplier = Operands[0];

            switch (multiplier.GetSize())
            {
                case OperandSize._8Bits:
                    Execute8Bit(cpu, multiplier); break;
                case OperandSize.Any:
                case OperandSize._16Bits:
                    Execute16Bit(cpu, multiplier); break;
            }
        }
    }
}
