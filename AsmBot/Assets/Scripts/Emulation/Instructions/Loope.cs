using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.LOOPE)]
    public class Loope : JccBase
    {
        public Loope(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            if (--cpu.registers.CX != 0 && cpu.registers.Flags.ZF)
            {
                DoJump(cpu);
            }
        }
    }

    [InstructionInfo(MnemonicOpCode.LOOPZ)]
    public class Loopz : Loope { public Loopz(Operand[] operands) : base(operands) { } }
}
