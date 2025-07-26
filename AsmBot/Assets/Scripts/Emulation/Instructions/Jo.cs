using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.JO)]
    public class Jo : JccBase
    {
        public Jo(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            if (cpu.registers.Flags.OF)
            {
                DoJump(cpu);
            }
        }
    }
}
