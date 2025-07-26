using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.Emulation.Registers;

namespace Assets.Scripts.Emulation
{
    public static class RegistersUtil
    {
        public static readonly Dictionary<string, Register> nameToRegister = new()
        {
            { "AX", Register.R16_AX },
            { "AL" , Register.R8_AL },
            { "AH" , Register.R8_AH },

            { "BX" , Register.R16_BX },
            { "BL" , Register.R8_BL },
            { "BH" , Register.R8_BH },

            { "CX" , Register.R16_CX },
            { "CL" , Register.R8_CL },
            { "CH" , Register.R8_CH },

            { "DX" , Register.R16_DX },
            { "DL" , Register.R8_DL },
            { "DH" , Register.R8_DH },

            { "BP" , Register.R16_BP },
            { "SP" , Register.R16_SP },

            { "SI" , Register.R16_SI },
            { "DI" , Register.R16_DI },

            { "CS" , Register.R16_CS },
            { "DS" , Register.R16_DS },
            { "SS" , Register.R16_SS },
        };

        public static readonly Dictionary<Register, string> registerToName = new();

        static RegistersUtil()
        {
            foreach (var kv in nameToRegister)
            {
                registerToName[kv.Value] = kv.Key;
            }
        }

        public static Register RegisterNameToRegister(string name)
        {
            if (nameToRegister.TryGetValue(name.ToUpper(), out var register))
            {
                return register;
            }
            throw new Exception("unknown register " + name);
        }

        public static string RegisterToRegisterName(Register register)
        {
            if (registerToName.TryGetValue(register, out var name))
            {
                return name;
            }
            throw new Exception("unknown register " + register);
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
                case Register.R16_CS:
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
    }
}
