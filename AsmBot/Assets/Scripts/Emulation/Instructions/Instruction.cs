using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    public abstract class Instruction
    {
        public Operand[] Operands { get; }

        public Instruction(Operand[] operands)
        {
            Operands = operands;
        }

        public abstract void Execute(CPU cpu);
    }

    public class InstructionInfoAttribute : System.Attribute
    {
        public readonly string mnemonic;
        public readonly int operandCount;
        public InstructionInfoAttribute(string mnemonic, int operandCount) { 
            this.mnemonic = mnemonic.ToUpper(); 
            this.operandCount = operandCount;
        }
    }
}
