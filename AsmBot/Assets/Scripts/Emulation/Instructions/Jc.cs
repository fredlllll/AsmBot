using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.JC)]
    public class Jc : JccBase
    {
        public Jc(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            if (cpu.registers.Flags.CF)
            {
                DoJump(cpu);
            }
        }
    }

    [InstructionInfo(MnemonicOpCode.JB)]
    public class Jb : Jc { public Jb(Operand[] operands) : base(operands) { } }
    [InstructionInfo(MnemonicOpCode.JNAE)]
    public class Jnae : Jc { public Jnae(Operand[] operands) : base(operands) { } }
}
