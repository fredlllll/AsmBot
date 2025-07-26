using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.JLE)]
    public class Jle : JccBase
    {
        public Jle(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            if (cpu.registers.Flags.ZF || (cpu.registers.Flags.SF != cpu.registers.Flags.OF))
            {
                DoJump(cpu);
            }
        }
    }

    [InstructionInfo(MnemonicOpCode.JNG)]
    public class Jng : Jle { public Jng(Operand[] operands) : base(operands) { } }
}
