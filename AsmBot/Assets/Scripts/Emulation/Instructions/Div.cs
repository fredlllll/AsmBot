using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.DIV)]
    public class Div : Instruction
    {
        public Div(Operand[] operands) : base(operands) { }

        /**
IF OperandSize = 8 (* Word/Byte Operation *) THEN
    temp := AX / SRC;
    IF temp > FFH
        THEN #DE; (* Divide error *)
    ELSE
        AL := temp;
        AH := AX MOD SRC;
    FI;
ELSE IF OperandSize = 16 (* Doubleword/word operation *) THEN
    temp := DX:AX / SRC;
    IF temp > FFFFH
        THEN #DE; (* Divide error *)
    ELSE
        AX := temp;
        DX := DX:AX MOD SRC;
    FI;
FI;
        */

        private void Execute8Bit(CPU cpu, Operand opDivisor)
        {
            var dividend = cpu.registers.GetRegisterWord(Register.R16_AX);
            var divisor = opDivisor.GetByte(cpu);
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }
            var result = dividend / divisor;
            var remainder = dividend % divisor;
            if (result > byte.MaxValue)
            {
                throw new Exception("TODO: divide error");
            }

            cpu.registers.SetRegisterByte(Register.R8_AL, (byte)result);
            cpu.registers.SetRegisterByte(Register.R8_AH, (byte)remainder);
        }

        private void Execute16Bit(CPU cpu, Operand opDivisor)
        {
            long dividend = (cpu.registers.GetRegisterWord(Register.R16_DX) << 16) & cpu.registers.GetRegisterWord(Register.R16_AX);
            var divisor = opDivisor.GetWord(cpu);
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }
            var result = Math.DivRem(dividend, divisor, out var remainder);
            if (result > ushort.MaxValue)
            {
                throw new Exception("TODO: divide error");
            }

            cpu.registers.SetRegisterWord(Register.R16_AX, (ushort)result);
            cpu.registers.SetRegisterWord(Register.R16_DX, (ushort)remainder);
        }

        public override void Execute(CPU cpu)
        {
            var divisor = Operands[0];

            switch (divisor.GetSize())
            {
                case OperandSize._8Bits:
                    Execute8Bit(cpu, divisor); break;
                case OperandSize.Any:
                case OperandSize._16Bits:
                    Execute16Bit(cpu, divisor); break;
            }
        }
    }
}
