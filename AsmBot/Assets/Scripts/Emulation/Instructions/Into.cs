using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.INTO)]
    public class Into : Instruction
    {
        public Into(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            if (!cpu.registers.Flags.OF)
            {
                return;
            }

            var op = Operands[0];
            if (op.GetSize() != OperandSize._8Bits)
            {
                throw new Exception("only supporting 8 bit interrupt ids");
            }
            var number = op.GetByte(cpu);

            Int.DoInterrupt(cpu, number);
        }
    }
}
