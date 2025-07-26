using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Compiling
{
    public class InstructionLine : IProgramLine
    {
        public string Mnemonic { get; set; }
        public List<Operand> Operands { get; } = new List<Operand>();

        public override string ToString()
        {
            return Mnemonic + " " + string.Join(", ", Operands.Select(x => x.ToString()));
        }
    }
}
