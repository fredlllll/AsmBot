using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.INT)]
    public class Int : Instruction
    {
        public Int(Operand[] operands) : base(operands) { }

        public static void DoInterrupt(CPU cpu, byte number)
        {
            //TODO: interrupts will not be present as code in a ROM, but instead directly call functions, probably need a static dictionary with the functions
        }

        public override void Execute(CPU cpu)
        {
            var op = Operands[0];
            if(op.GetSize() != OperandSize._8Bits)
            {
                throw new Exception("only supporting 8 bit interrupt ids");
            }
            var number = op.GetByte(cpu);

            DoInterrupt(cpu, number);
        }
    }
}
