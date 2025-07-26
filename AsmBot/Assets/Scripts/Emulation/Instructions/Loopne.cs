using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.LOOPNE)]
    public class Loopne : JccBase
    {
        public Loopne(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            if (--cpu.registers.CX != 0 && !cpu.registers.Flags.ZF)
            {
                DoJump(cpu);
            }
        }
    }

    [InstructionInfo(MnemonicOpCode.LOOPNZ)]
    public class Loopnz : Loope { public Loopnz(Operand[] operands) : base(operands) { } }
}
