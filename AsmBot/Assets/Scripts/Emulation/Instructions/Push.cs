using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo("PUSH", 1)]
    public class Push : Instruction
    {
        public Push(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            var source = Operands[0];

            switch (source.GetSize())
            {
                case OperandSize._16Bits:
                case OperandSize.Any:
                    var value = source.GetWord(cpu);
                    cpu.registers.SP -= 2;
                    cpu.memory.WriteWord((uint)(cpu.registers.SS + cpu.registers.SP), value);
                    break;
                default:
                    throw new InvalidOperationException("push/pop only support word size operands");
            }
        }
    }
}
