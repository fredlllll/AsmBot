using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.JNLE)]
    public class Jnle : JccBase
    {
        public Jnle(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            if (!cpu.registers.Flags.ZF & (cpu.registers.Flags.SF == cpu.registers.Flags.OF))
            {
                DoJump(cpu);
            }
        }
    }

    [InstructionInfo(MnemonicOpCode.JG)]
    public class Jg : Jle { public Jg(Operand[] operands) : base(operands) { } }
}
