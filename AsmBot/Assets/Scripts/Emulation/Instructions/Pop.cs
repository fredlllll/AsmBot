using Assets.Scripts.Emulation.Instructions.Operands;
using System;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.POP)]
    public class Pop : Instruction
    {
        public Pop(Operand[] operands) : base(operands) { }

        public static ushort DoPop(CPU cpu)
        {
            var value = cpu.memory.ReadWord(AddressUtil.ToGlobalAddress(cpu.registers.SS, cpu.registers.SP));
            cpu.registers.SP += 2;
            return value;
        }

        public override void Execute(CPU cpu)
        {
            var destination = Operands[0];

            switch (destination.GetSize())
            {
                case OperandSize._16Bits:
                case OperandSize.Any:
                    destination.SetWord(cpu,DoPop(cpu));
                    break;
                default:
                    throw new InvalidOperationException("push/pop only support word size operands");
            }
        }
    }
}
