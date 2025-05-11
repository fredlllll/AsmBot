using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation
{
    /*

    public struct ModRM
    {
        public enum RegisterMemory : byte
        {
            R8_AL = 0,
            R8_CL = 1,
            R8_DL = 2,
            R8_BL = 3,
            R8_AH = 4,
            R8_CH = 5,
            R8_DH = 6,
            R8_BH = 7,
            R16_AX = 0,
            R16_CX = 1,
            R16_DX = 2,
            R16_BX = 3,
            R16_SP = 4,
            R16_BP = 5,
            R16_SI = 6,
            R16_DI = 7,
        }

        public byte Mod { get; }
        public RegisterMemory Register { get; }
        public RegisterMemory RM { get; }
        public bool IsMemoryOperand => Mod != 3; // Mod 3 means direct register

        public ModRM(byte value)
        {
            Mod = (byte)((value >> 6) & 0b11);
            Register = (RegisterMemory)((value >> 3) & 0b111);
            RM = (RegisterMemory)(value & 0b111);
        }

        public uint CalculateEffectiveAddress(CPU cpu)
        {
            switch (Mod)
            {
                case 0:
                    return (byte)RM switch
                    {
                        0 => (uint)(cpu.registers.DS << 16 + cpu.registers.BX + cpu.registers.SI),
                        1 => (uint)(cpu.registers.DS << 16 + cpu.registers.BX + cpu.registers.DI),
                        2 => (uint)(cpu.registers.DS << 16 + cpu.registers.BP + cpu.registers.SI),
                        3 => (uint)(cpu.registers.DS << 16 + cpu.registers.BP + cpu.registers.DI),
                        4 => (uint)(cpu.registers.DS << 16 + cpu.registers.SI),
                        5 => (uint)(cpu.registers.DS << 16 + cpu.registers.DI),
                        //6 => (uint)(cpu.registers.DS << 16 + cpu.FetchNextCodeByte() << 8 + cpu.FetchNextCodeByte()),
                        7 => (uint)(cpu.registers.DS << 16 + cpu.registers.BX),
                        _ => throw new NotImplementedException()
                    };
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
            throw new NotImplementedException();
        }
    }*/
}