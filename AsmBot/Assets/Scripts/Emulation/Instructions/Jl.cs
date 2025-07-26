using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.JL)]
    public class Jl : JccBase
    {
        public Jl(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            if (cpu.registers.Flags.SF != cpu.registers.Flags.OF)
            {
                DoJump(cpu);
            }
        }
    }

    [InstructionInfo(MnemonicOpCode.JNGE)]
    public class Jnge : Jl { public Jnge(Operand[] operands) : base(operands) { } }
}
