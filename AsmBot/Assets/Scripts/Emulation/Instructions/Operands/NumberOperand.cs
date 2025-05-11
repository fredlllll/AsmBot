using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    public class NumberOperand : Operand
    {
        public ushort value;
        public NumberOperand(string str)
        {
            if (str.EndsWith('h'))
            {
                value = ushort.Parse(str.Substring(0, str.Length - 1), System.Globalization.NumberStyles.HexNumber);
            }
            else
            {
                value = ushort.Parse(str);
            }
        }

        public override byte GetByte(CPU cpu) { return (byte)value; }
        public override ushort GetWord(CPU cpu) { return value; }
        public override void SetByte(CPU cpu, byte value) { throw new InvalidOperationException("cant set constant"); }
        public override void SetWord(CPU cpu, ushort value) { throw new InvalidOperationException("cant set constant"); }

        public override OperandSize GetSize()
        {
            return OperandSize.Any;
        }
    }
}
