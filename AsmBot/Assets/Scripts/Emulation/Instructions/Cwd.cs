using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.CWD)]
    public class Cwd : Instruction
    {
        public Cwd(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            int val = (short)cpu.registers.AX;
            val <<= 16;
            cpu.registers.DX = (ushort)((val & 0xFFFF0000) >> 16);
            cpu.registers.AX = (ushort)(val & 0xFFFF);
        }
    }
}
