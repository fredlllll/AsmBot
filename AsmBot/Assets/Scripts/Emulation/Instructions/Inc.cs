using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.INC)]
    public class Inc : Instruction
    {
        public Inc(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            var destination = Operands[0];
            switch (destination.GetSize())
            {
                case OperandSize._8Bits:
                    destination.SetByte(cpu,(byte)(destination.GetByte(cpu) + 1));
                    break;
                case OperandSize._16Bits:
                    destination.SetWord(cpu, (ushort)(destination.GetWord(cpu) + 1));
                    break;
                default:
                    throw new InvalidOperationException("cant determine operand size");
            }
        }
    }
}
