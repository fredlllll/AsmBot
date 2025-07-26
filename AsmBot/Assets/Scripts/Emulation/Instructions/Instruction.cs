using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    public abstract class Instruction
    {
        public string Mnemonic { get; protected set; }
        public ushort OpCode { get; protected set; }

        public Operand[] Operands { get; protected set; }

        public int Address { get; set; }

        public Instruction()
        {
            var attr = GetType().GetCustomAttribute<InstructionInfoAttribute>();
            Mnemonic = attr.Mnemonic;
            OpCode = attr.OpCode;
        }

        public Instruction(Operand[] operands) : this()
        {
            Operands = operands;
        }

        public abstract void Execute(CPU cpu);

        public virtual int GetSizeInBytes()
        {
            return GetBytes().Length;
        }

        public virtual byte[] GetBytes()
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter bw = new BinaryWriter(ms);

            bw.Write7BitEncodedInt(OpCode);
            foreach (Operand operand in Operands)
            {
                operand.GetBytes(bw);
            }

            return ms.ToArray();
        }

        public override string ToString()
        {
            return Mnemonic + " " + string.Join(", ", Operands.Select(x => x.ToString()));
        }
    }

    public class InstructionInfoAttribute : System.Attribute
    {
        public string Mnemonic { get; private set; }
        public ushort OpCode { get; private set; }
        public InstructionInfoAttribute(MnemonicOpCode mnemonic)
        {
            Mnemonic = mnemonic.ToString().ToUpper();
            OpCode = (ushort)mnemonic;
        }
    }
}
