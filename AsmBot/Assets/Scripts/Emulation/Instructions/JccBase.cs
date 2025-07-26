using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    public abstract class JccBase : Instruction
    {
        public JccBase(Operand[] operands) : base(operands) { }

        protected void DoJump(CPU cpu)
        {
            var source = Operands[0];
            switch (source.GetSize())
            {
                case OperandSize._8Bits:
                    cpu.registers.IP = source.GetByte(cpu);
                    break;
                case OperandSize._16Bits:
                    cpu.registers.IP = source.GetWord(cpu);
                    break;
                default:
                    throw new Exception("cant determine operator size");
            }
        }
    }
}
