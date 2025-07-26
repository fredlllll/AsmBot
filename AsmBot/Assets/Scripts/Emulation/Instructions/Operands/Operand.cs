using Assets.Scripts.Emulation.Compiling;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    public abstract class Operand
    {
        public virtual byte GetByte(CPU cpu) { return 0; }
        public virtual ushort GetWord(CPU cpu) { return 0; }
        public virtual void SetByte(CPU cpu, byte value) { }
        public virtual void SetWord(CPU cpu, ushort value) { }
        public virtual OperandSize GetSize() { return OperandSize.Any; }

        public abstract void GetBytes(BinaryWriter bw);

        public static Operand FromStream(BinaryReader br)
        {
            byte firstByte = br.ReadByte();
            byte typeId = (byte)(firstByte & 0b11);
            switch (typeId)
            {
                case OperandType.Register:
                    return new RegisterOperand(firstByte);
                case OperandType.Immediate:
                    return new ImmediateOperand(firstByte, br);
                case OperandType.MemoryRegister:
                    return new MemoryRegisterOperand(firstByte);
                case OperandType.MemoryImmediate:
                    return new MemoryImmediateOperand(firstByte, br);
                default:
                    throw new InvalidDataException("technically cant happen");
            }
        }

    }

    /// <summary>
    /// determines the type of the operand, register, immediate, memory register, memory immediate. 
    /// 0bxxxxxxMR 
    /// the M bit tells if its memory or not
    /// the R bit tells if its register or immediate
    /// </summary>
    public static class OperandType
    {
        public const byte Register = 0;
        public const byte Immediate = 1;
        public const byte MemoryRegister = 2;
        public const byte MemoryImmediate = 3;
    }

    public enum OperandSize
    {
        Any = 0,
        _8Bits = 1,
        _16Bits = 2,
    }
}
