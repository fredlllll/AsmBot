using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    public abstract class Instruction
    {
        public byte Opcode { get; }
        public string InstructionDescription { get; }

        public Instruction(byte opcode, string instructionDescription)
        {
            Opcode = opcode;
            InstructionDescription = instructionDescription;
        }

        public abstract void Execute(CPU cpu);
    }
}
