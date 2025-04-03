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
        public ushort BX; //(base, accumulator)
        public ushort CX; //(counter, accumulator)
        public ushort DX; //(accumulator, extended acc)

        public ushort SI; //Source Index
        public ushort DI; //Destination Index
        public ushort BP; //Base Pointer
        public ushort SP; //Stack Pointer

        public ushort IP; //Instruction Pointer/Program Counter

        public ushort CS; //Code Segment
        public ushort DS; //Data Segment
        public ushort ES; //Extra Segment
        public ushort SS; //Stack Segment

        public FlagsRegister Flags;

        public byte GetRegisterByte(ModRM.RegisterMemory register)
        {
            return register switch
            {
                ModRM.RegisterMemory.R8_AL => (byte)AX,
                ModRM.RegisterMemory.R8_BL => (byte)BX,
                ModRM.RegisterMemory.R8_CL => (byte)CX,
                ModRM.RegisterMemory.R8_DL => (byte)DX,
                ModRM.RegisterMemory.R8_AH => (byte)(AX >> 8),
                ModRM.RegisterMemory.R8_BH => (byte)(BX >> 8),
                ModRM.RegisterMemory.R8_CH => (byte)(CX >> 8),
                ModRM.RegisterMemory.R8_DH => (byte)(DX >> 8),
                _ => throw new Exception("unknown register: " + register)
            };
        }

        public void SetRegisterByte(ModRM.RegisterMemory register, byte value)
        {
            switch (register)
            {
                case ModRM.RegisterMemory.R8_AL:
                    AX = (ushort)((AX & 0xF0) | value);
                    break;
                case ModRM.RegisterMemory.R8_BL:
                    BX = (ushort)((BX & 0xF0) | value);
                    break;
                case ModRM.RegisterMemory.R8_CL:
                    CX = (ushort)((CX & 0xF0) | value);
                    break;
                case ModRM.RegisterMemory.R8_DL:
                    DX = (ushort)((DX & 0xF0) | value);
                    break;
                case ModRM.RegisterMemory.R8_AH:
                    AX = (ushort)((AX & 0x0F) | (value << 8));
                    break;
                case ModRM.RegisterMemory.R8_BH:
                    BX = (ushort)((BX & 0x0F) | (value << 8));
                    break;
                case ModRM.RegisterMemory.R8_CH:
                    CX = (ushort)((CX & 0x0F) | (value << 8));
                    break;
                case ModRM.RegisterMemory.R8_DH:
                    DX = (ushort)((DX & 0x0F) | (value << 8));
                    break;
                default:
                    throw new Exception("unknown register: " + register);
            }
        }

        public ushort GetRegisterWord(ModRM.RegisterMemory register)
        {
            return register switch
            {
                ModRM.RegisterMemory.R16_AX => AX,
                ModRM.RegisterMemory.R16_BX => BX,
                ModRM.RegisterMemory.R16_CX => CX,
                ModRM.RegisterMemory.R16_DX => DX,
                ModRM.RegisterMemory.R16_SP => SP,
                ModRM.RegisterMemory.R16_BP => BP,
                ModRM.RegisterMemory.R16_SI => SI,
                ModRM.RegisterMemory.R16_DI => DI,
                _ => throw new Exception("unknown register: " + register)
            };
        }

        public void SetRegisterWord(ModRM.RegisterMemory register, ushort value)
        {
            switch (register)
            {
                case ModRM.RegisterMemory.R16_AX:
                    AX = value;
                    break;
                case ModRM.RegisterMemory.R16_BX:
                    BX = value;
                    break;
                case ModRM.RegisterMemory.R16_CX:
                    CX = value;
                    break;
                case ModRM.RegisterMemory.R16_DX:
                    DX = value;
                    break;
                case ModRM.RegisterMemory.R16_SP:
                    SP = value;
                    break;
                case ModRM.RegisterMemory.R16_BP:
                    BP = value;
                    break;
                case ModRM.RegisterMemory.R16_SI:
                    SI = value;
                    break;
                case ModRM.RegisterMemory.R16_DI:
                    DI = value;
                    break;
                default:
                    throw new Exception("unknown register: " + register);
            }
        }
    }

    public struct FlagsRegister
    {
        public bool CF;
        public bool PF;
        public bool AF;
        public bool ZF;
        public bool SF;
        public bool TF;
        public bool IF;
        public bool DF;
        public bool OF;
    }
}
