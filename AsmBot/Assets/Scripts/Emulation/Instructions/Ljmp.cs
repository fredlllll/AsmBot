using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.LJMP)]
    public class LJmp : Instruction
    {
        public LJmp(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            var segment = Operands[0];
            var offset = Operands[1];
            cpu.registers.CS = segment.GetWord(cpu);
            cpu.registers.IP = offset.GetWord(cpu);
        }
    }
}
