using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.HLT)]
    public class Hlt : Instruction
    {
        public Hlt(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            cpu.IsHalted = true;
        }
    }
}
