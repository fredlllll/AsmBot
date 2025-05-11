using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Emulation.Registers;

namespace Assets.Scripts.Emulation
{
    public class Registers
    {
        public enum Register
        {
            R8_AL,
            R8_BL,
            R8_CL,
            R8_DL,

            R8_AH,
            R8_BH,
            R8_CH,
            R8_DH,

            R16_AX,
            R16_BX,
            R16_CX,
            R16_DX,

            R16_BP,
            R16_SP,

            R16_SI,
            R16_DI,

            R16_DS,
            R16_SS,
        }

        public enum RegisterSize
        {
            _8Bit = 1,
            _16Bit = 2,
        }

        public static Register RegisterNameToRegister(string name)
        {
            return name.ToUpper() switch
            {
                "AX" => Register.R16_AX,
                "AL" => Register.R8_AL,
                "AH" => Register.R8_AH,

                "BX" => Register.R16_BX,
                "BL" => Register.R8_BL,
                "BH" => Register.R8_BH,

                "CX" => Register.R16_CX,
                "CL" => Register.R8_CL,
                "CH" => Register.R8_CH,

                "DX" => Register.R16_DX,
                "DL" => Register.R8_DL,
                "DH" => Register.R8_DH,

                "BP" => Register.R16_BP,
                "SP" => Register.R16_SP,

                "SI" => Register.R16_SI,
                "DI" => Register.R16_DI,

                "DS" => Register.R16_DS,
                "SS" => Register.R16_SS,

                _ => throw new Exception("unknown register " + name)
            };
        }
        public static RegisterSize GetRegisterSize(Register register)
        {
            switch (register)
            {
                case Register.R16_AX:
                case Register.R16_BX:
                case Register.R16_CX:
                case Register.R16_DX:
                case Register.R16_BP:
                case Register.R16_SP:
                case Register.R16_SI:
                case Register.R16_DI:
                case Register.R16_DS:
                case Register.R16_SS:
                    return RegisterSize._16Bit;
                case Register.R8_AL:
                case Register.R8_AH:
                case Register.R8_BL:
                case Register.R8_BH:
                case Register.R8_CL:
                case Register.R8_CH:
                case Register.R8_DL:
                case Register.R8_DH:
                    return RegisterSize._8Bit;
                default:
                    throw new Exception("unknown register " + register);
            }
        }

        public ushort AX; //(primary accumulator)
        public ushort BX; //(base, accumulator)
        public ushort CX; //(counter, accumulator)
        public ushort DX; //(accumulator, extended acc)

        public ushort SI; //Source Index
        public ushort DI; //Destination Index
        public ushort BP; //Base Pointer
        public ushort SP; //Stack Pointer

        //public ushort IP; //Instruction Pointer/Program Counter

        //public ushort CS; //Code Segment
        public ushort DS; //Data Segment
        //public ushort ES; //Extra Segment
        public ushort SS; //Stack Segment

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
                _ => throw new Exception("unknown register: " + register)
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
                Register.R16_SP => SP,
                Register.R16_BP => BP,
                Register.R16_SI => SI,
                Register.R16_DI => DI,
                _ => throw new Exception("unknown register: " + register)
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
                case Register.R16_SP:
                    SP = value;
                    break;
                case Register.R16_BP:
                    BP = value;
                    break;
                case Register.R16_SI:
                    SI = value;
                    break;
                case Register.R16_DI:
                    DI = value;
                    break;
                default:
                    throw new Exception("unknown register: " + register);
            }
        }
    }

    public struct FlagsRegister
    {
        //commented out flags are not really necessary for what i do, i hope

        /// <summary>
        /// Carry Flag //Carry indicates the result isn't mathematically correct when interpreted as unsigned
        /// </summary>
        public bool CF;
        /// <summary>
        /// Parity Flag // if result parity is even/odd
        /// </summary>
        //public bool PF;
        /// <summary>
        /// Auxiliary Carry Flag //when least 4 bits caused carry
        /// </summary>
        //public bool AF;
        /// <summary>
        /// Zero Flag //result is zero
        /// </summary>
        public bool ZF;
        /// <summary>
        /// Sign Flag //result has sign bit set
        /// </summary>
        public bool SF;
        /// <summary>
        /// Trap Flag
        /// </summary>
        //public bool TF;
        /// <summary>
        /// Interrupt Enable Flag
        /// </summary>
        //public bool IF;
        /// <summary>
        /// Direction Flag
        /// </summary>
        //public bool DF;
        /// <summary>
        /// Overflow Flag // overflow indicates the result isn't mathematically correct when interpreted as signed
        /// </summary>
        public bool OF;
    }
}
