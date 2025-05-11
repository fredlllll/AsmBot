using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo("MOV", 2)]
    public class Mov : Instruction
    {
        public Mov(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            var destination = Operands[0];
            var source = Operands[1];

            switch (destination.GetSize())
            {
                case OperandSize._8Bits:
                    destination.SetByte(cpu, source.GetByte(cpu)); break;
                case OperandSize._16Bits:
                    destination.SetWord(cpu, source.GetWord(cpu)); break;
                default:
                    switch (source.GetSize())
                    {
                        case OperandSize._8Bits:
                            destination.SetByte(cpu, source.GetByte(cpu)); break;
                        case OperandSize._16Bits:
                            destination.SetWord(cpu, source.GetWord(cpu)); break;
                        default:
                            throw new InvalidOperationException("cant determine operand size");
                            //destination.SetWord(cpu, source.GetWord(cpu)); break;
                    }
                    break;
            }
        }
    }
}
