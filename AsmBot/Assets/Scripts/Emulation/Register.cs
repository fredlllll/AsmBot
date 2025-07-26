using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation
{
    public enum Register : byte
    {
        R8_AL = 0,
        R8_BL = 1,
        R8_CL = 2,
        R8_DL = 3,

        R8_AH = 4,
        R8_BH = 5,
        R8_CH = 6,
        R8_DH = 7,

        R16_AX = 8,
        R16_BX = 9,
        R16_CX = 10,
        R16_DX = 11,

        R16_SI = 12,
        R16_DI = 13,

        R16_BP = 14,
        R16_SP = 15,

        R16_CS = 16,
        R16_DS = 17,
        R16_SS = 18,
    }

    public enum RegisterSize
    {
        _8Bit = 1,
        _16Bit = 2,
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
