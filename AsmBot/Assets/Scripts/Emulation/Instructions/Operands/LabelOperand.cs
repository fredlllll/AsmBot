using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    public class LabelOperand : Operand
    {
        public readonly string name;
        public LabelOperand(string name)
        {
            this.name = name;
        }
    }
}
