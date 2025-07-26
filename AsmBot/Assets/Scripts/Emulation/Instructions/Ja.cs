using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.JA)]
    public class Ja : JccBase
    {
        public Ja(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            if (!cpu.registers.Flags.CF && !cpu.registers.Flags.ZF)
            {
                DoJump(cpu);
            }
        }
    }

    [InstructionInfo(MnemonicOpCode.JNBE)]
    public class Jnbe : Ja { public Jnbe(Operand[] operands) : base(operands) { } }
}
