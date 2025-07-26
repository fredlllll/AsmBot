using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.TEST)]
    public class Test : Instruction
    {
        public Test(Operand[] operands) : base(operands) { }

        //sets OF,CF,ZF,SF

        private void Execute8Bit(CPU cpu, Operand destination, Operand source)
        {
            var b1 = destination.GetByte(cpu);
            var b2 = source.GetByte(cpu);
            var result = b1 & b2;

            cpu.registers.Flags.CF = false;
            cpu.registers.Flags.OF = false;
            cpu.registers.Flags.ZF = result == 0;
            cpu.registers.Flags.SF = (result & 0x80) != 0;
        }

        private void Execute16Bit(CPU cpu, Operand destination, Operand source)
        {
            var w1 = destination.GetWord(cpu);
            var w2 = source.GetWord(cpu);
            var result = w1 & w2;

            cpu.registers.Flags.CF = false;
            cpu.registers.Flags.OF = false;
            cpu.registers.Flags.ZF = result == 0;
            cpu.registers.Flags.SF = (result & 0x8000) != 0;
        }

        public override void Execute(CPU cpu)
        {
            var destination = Operands[0];
            var source = Operands[1];

            switch (destination.GetSize())
            {
                case OperandSize._8Bits:
                    Execute8Bit(cpu, destination, source); break;
                case OperandSize._16Bits:
                    Execute16Bit(cpu, destination, source); break;
                default:
                    switch (source.GetSize())
                    {
                        case OperandSize._8Bits:
                            Execute8Bit(cpu, destination, source); break;
                        case OperandSize._16Bits:
                            Execute16Bit(cpu, destination, source); break;
                        default:
                            throw new InvalidOperationException("cant determine operand size");
                    }
                    break;
            }
        }
    }
}
