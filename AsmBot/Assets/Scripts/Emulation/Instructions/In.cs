using Assets.Scripts.Emulation.Instructions.Operands;
using System;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.IN)]
    public class In : Instruction
    {
        public In(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            var destination = Operands[0];
            var sourcePortOp = Operands[1];

            ushort port = 0;
            switch (sourcePortOp.GetSize())
            {
                case OperandSize._8Bits:
                    port = sourcePortOp.GetByte(cpu);
                    break;
                case OperandSize._16Bits:
                    port = sourcePortOp.GetWord(cpu);
                    break;
                default:
                    throw new InvalidOperationException("cant determine operand size");
            }

            switch (destination.GetSize())
            {
                case OperandSize._16Bits:
                    destination.SetWord(cpu, cpu.bus.ReadPortWord(port));
                    break;
                case OperandSize._8Bits:
                    destination.SetByte(cpu, cpu.bus.ReadPortByte(port));
                    break;
                default:
                    throw new InvalidOperationException("cant determine operand size");
            }
        }
    }
}
