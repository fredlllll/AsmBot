using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.OUT)]
    public class Out : Instruction
    {
        public Out(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            var destinationPortOp = Operands[0];
            var source = Operands[1];

            ushort port = 0;
            switch (destinationPortOp.GetSize())
            {
                case OperandSize._8Bits:
                    port = destinationPortOp.GetByte(cpu);
                    break;
                case OperandSize._16Bits:
                    port = destinationPortOp.GetWord(cpu);
                    break;
                default:
                    throw new InvalidOperationException("cant determine operand size");
            }

            switch (source.GetSize())
            {
                case OperandSize._16Bits:
                    cpu.bus.WritePort(port,source.GetWord(cpu));
                    break;
                case OperandSize._8Bits:
                    cpu.bus.WritePort(port, source.GetByte(cpu));
                    break;
                default:
                    throw new InvalidOperationException("cant determine operand size");
            }
        }
    }
}
