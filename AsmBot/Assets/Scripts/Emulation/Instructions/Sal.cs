using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.SAL)]
    public class Sal : Instruction
    {
        public Sal(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            var destination = Operands[0];
            var bits = Operands[1].GetByte(cpu);
            switch (destination.GetSize())
            {
                case OperandSize._8Bits:
                    destination.SetByte(cpu, (byte)(((sbyte)destination.GetByte(cpu)) << bits));
                    break;
                case OperandSize._16Bits:
                    destination.SetWord(cpu, (ushort)(((short)destination.GetWord(cpu)) << bits));
                    break;
                default:
                    throw new InvalidOperationException("cant determine operand size");
            }
        }
    }
}
