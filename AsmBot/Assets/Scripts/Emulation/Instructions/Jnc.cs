using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.JNC)]
    public class Jnc : JccBase
    {
        public Jnc(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            if (!cpu.registers.Flags.CF)
            {
                DoJump(cpu);
            }
        }
    }

    [InstructionInfo(MnemonicOpCode.JAE)]
    public class Jae : Jc { public Jae(Operand[] operands) : base(operands) { } }
    [InstructionInfo(MnemonicOpCode.JNB)]
    public class Jnb : Jc { public Jnb(Operand[] operands) : base(operands) { } }
}
