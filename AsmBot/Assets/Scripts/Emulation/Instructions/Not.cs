using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.NOT)]
    public class Not : Instruction
    {
        public Not(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            var destination = Operands[0];

            switch (destination.GetSize())
            {
                case OperandSize._8Bits:
                    destination.SetByte(cpu, (byte)~destination.GetByte(cpu));
                    break;
                case OperandSize._16Bits:
                    destination.SetWord(cpu, (ushort)~destination.GetWord(cpu));
                    break;
                default:
                    throw new InvalidOperationException("cant determine operand size");
            }
        }
    }
}
