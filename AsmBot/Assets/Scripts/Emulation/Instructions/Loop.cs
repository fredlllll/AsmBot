using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.LOOP)]
    public class Loop : JccBase
    {
        public Loop(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            if (--cpu.registers.CX != 0)
            {
                DoJump(cpu);
            }
        }
    }
}
