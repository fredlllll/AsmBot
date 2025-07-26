using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.JNZ)]
    public class Jnz : JccBase
    {
        public Jnz(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            if (!cpu.registers.Flags.ZF)
            {
                DoJump(cpu);
            }
        }
    }

    [InstructionInfo(MnemonicOpCode.JNE)]
    public class Jne : Jnz { public Jne(Operand[] operands) : base(operands) { } }
}
