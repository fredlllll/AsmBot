using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation
{
    public class Registers
    {
        public ushort AX; //(primary accumulator)
        public byte AL { get { return (byte)AX; } set { AX = (ushort)((AX & 0xFF00) | value); } }
        public byte AH { get { return (byte)(AX >> 8); } set { AX = (ushort)((AX & 0xFF) | value << 8); } }
        public ushort BX; //(base, accumulator)
        public byte BL { get { return (byte)BX; } set { BX = (ushort)((BX & 0xFF00) | value); } }
        public byte BH { get { return (byte)(BX >> 8); } set { BX = (ushort)((BX & 0xFF) | value << 8); } }
        public ushort CX; //(counter, accumulator)
        public byte CL { get { return (byte)CX; } set { CX = (ushort)((CX & 0xFF00) | value); } }
        public byte CH { get { return (byte)(CX >> 8); } set { CX = (ushort)((CX & 0xFF) | value << 8); } }
        public ushort DX; //(accumulator, extended acc)
        public byte DL { get { return (byte)DX; } set { DX = (ushort)((DX & 0xFF00) | value); } }
        public byte DH { get { return (byte)(DX >> 8); } set { DX = (ushort)((DX & 0xFF) | value << 8); } }

        public ushort SI; //Source Index
        public ushort DI; //Destination Index

        public ushort BP; //Stack Base Pointer
        public ushort SP; //Stack Pointer

        public ushort CS; //Code Segment
        public ushort DS; //Data Segment
        //public ushort ES; //Extra Segment
        public ushort SS; //Stack Segment

        public ushort IP; //Instruction Pointer/Program Counter (not accessible via normal means)

        public FlagsRegister Flags;

        public byte GetRegisterByte(Register register)
        {
            return register switch
            {
                Register.R8_AL => (byte)AX,
                Register.R8_BL => (byte)BX,
                Register.R8_CL => (byte)CX,
                Register.R8_DL => (byte)DX,
                Register.R8_AH => (byte)(AX >> 8),
                Register.R8_BH => (byte)(BX >> 8),
                Register.R8_CH => (byte)(CX >> 8),
                Register.R8_DH => (byte)(DX >> 8),
                _ => throw new Exception("unknown 8 bit register: " + register)
            };
        }

        public void SetRegisterByte(Register register, byte value)
        {
            switch (register)
            {
                case Register.R8_AL:
                    AX = (ushort)((AX & 0xF0) | value);
                    break;
                case Register.R8_BL:
                    BX = (ushort)((BX & 0xF0) | value);
                    break;
                case Register.R8_CL:
                    CX = (ushort)((CX & 0xF0) | value);
                    break;
                case Register.R8_DL:
                    DX = (ushort)((DX & 0xF0) | value);
                    break;
                case Register.R8_AH:
                    AX = (ushort)((AX & 0x0F) | (value << 8));
                    break;
                case Register.R8_BH:
                    BX = (ushort)((BX & 0x0F) | (value << 8));
                    break;
                case Register.R8_CH:
                    CX = (ushort)((CX & 0x0F) | (value << 8));
                    break;
                case Register.R8_DH:
                    DX = (ushort)((DX & 0x0F) | (value << 8));
                    break;
                default:
                    throw new Exception("unknown register: " + register);
            }
        }

        public ushort GetRegisterWord(Register register)
        {
            return register switch
            {
                Register.R16_AX => AX,
                Register.R16_BX => BX,
                Register.R16_CX => CX,
                Register.R16_DX => DX,
                Register.R16_SI => SI,
                Register.R16_DI => DI,
                Register.R16_BP => BP,
                Register.R16_SP => SP,
                Register.R16_CS => CS,
                Register.R16_DS => DS,
                Register.R16_SS => SS,
                _ => throw new Exception("unknown 16 bit register: " + register)
            };
        }

        public void SetRegisterWord(Register register, ushort value)
        {
            switch (register)
            {
                case Register.R16_AX:
                    AX = value;
                    break;
                case Register.R16_BX:
                    BX = value;
                    break;
                case Register.R16_CX:
                    CX = value;
                    break;
                case Register.R16_DX:
                    DX = value;
                    break;
                case Register.R16_SI:
                    SI = value;
                    break;
                case Register.R16_DI:
                    DI = value;
                    break;
                case Register.R16_BP:
                    BP = value;
                    break;
                case Register.R16_SP:
                    SP = value;
                    break;
                case Register.R16_CS:
                    CS = value;
                    break;
                case Register.R16_DS:
                    DS = value;
                    break;
                case Register.R16_SS:
                    SS = value;
                    break;
                default:
                    throw new Exception("unknown register: " + register);
            }
        }
    }
}
