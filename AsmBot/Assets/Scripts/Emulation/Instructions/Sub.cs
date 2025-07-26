using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.SUB)]
    public class Sub : Instruction
    {
        public Sub(Operand[] operands) : base(operands) { }

        //sets OF,CF,ZF,SF

        private void Execute8Bit(CPU cpu, Operand destination, Operand source)
        {
            var b1 = destination.GetByte(cpu);
            var b2 = source.GetByte(cpu);
            var result = b1 - b2;

            cpu.registers.Flags.CF = ((byte)result) != result;
            cpu.registers.Flags.OF = ((sbyte)result) != result;
            cpu.registers.Flags.ZF = result == 0;
            cpu.registers.Flags.SF = (result & 0x80) != 0;

            destination.SetByte(cpu, (byte)result);
        }

        private void Execute16Bit(CPU cpu, Operand destination, Operand source)
        {
            var w1 = destination.GetWord(cpu);
            var w2 = source.GetWord(cpu);
            var result = w1 - w2;

            cpu.registers.Flags.CF = ((ushort)result) != result;
            cpu.registers.Flags.OF = ((short)result) != result;
            cpu.registers.Flags.ZF = result == 0;
            cpu.registers.Flags.SF = (result & 0x8000) != 0;

            destination.SetWord(cpu, (ushort)result);
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
