using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo("POP", 1)]
    public class Pop : Instruction
    {
        public Pop(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            var destination = Operands[0];

            switch (destination.GetSize())
            {
                case OperandSize._16Bits:
                case OperandSize.Any:
                    var value = cpu.memory.ReadWord((uint)(cpu.registers.SS + cpu.registers.SP));
                    destination.SetWord(cpu, value);
                    cpu.registers.SP += 2;
                    break;
                default:
                    throw new InvalidOperationException("push/pop only support word size operands");
            }
        }
    }
}
