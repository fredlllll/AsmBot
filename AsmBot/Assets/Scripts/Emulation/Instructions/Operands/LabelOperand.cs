using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    /// <summary>
    /// this is a placeholder to be replaced at compiletime
    /// </summary>
    public class LabelOperand : Operand
    {
        public readonly string label;
        public LabelOperand(string label)
        {
            this.label = label;
        }

        public override void GetBytes(BinaryWriter bw)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return label;
        }
    }
}
