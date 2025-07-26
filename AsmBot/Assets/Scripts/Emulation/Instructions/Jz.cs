using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.JZ)]
    public class Jz : JccBase
    {
        public Jz(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            if (cpu.registers.Flags.ZF)
            {
                DoJump(cpu);
            }
        }
    }

    [InstructionInfo(MnemonicOpCode.JE)]
    public class Je : Jz { public Je(Operand[] operands) : base(operands) { } }
}
