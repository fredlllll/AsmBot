using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.JMP)]
    public class Jmp : Instruction
    {
        public Jmp(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            var source = Operands[0];
            switch (source.GetSize())
            {
                case OperandSize._8Bits:
                    cpu.registers.IP = source.GetByte(cpu);
                    break;
                case OperandSize._16Bits:
                    cpu.registers.IP = source.GetWord(cpu);
                    break;
                default:
                    throw new Exception("cant determine operator size");
            }
        }
    }
}
