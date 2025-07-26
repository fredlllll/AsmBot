using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Unity.VisualScripting.Member;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.PUSH)]
    public class Push : Instruction
    {
        public Push(Operand[] operands) : base(operands) { }

        public static void DoPush(CPU cpu, ushort word)
        {
            cpu.registers.SP -= 2;
            cpu.memory.WriteWord(AddressUtil.ToGlobalAddress(cpu.registers.SS, cpu.registers.SP), word);
        }

        public override void Execute(CPU cpu)
        {
            var source = Operands[0];

            switch (source.GetSize())
            {
                case OperandSize._16Bits:
                case OperandSize.Any:
                    var value = source.GetWord(cpu);
                    DoPush(cpu, value);
                    break;
                default:
                    throw new InvalidOperationException("push/pop only support word size operands");
            }
        }
    }
}
