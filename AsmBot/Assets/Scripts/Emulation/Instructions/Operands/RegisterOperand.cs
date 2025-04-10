using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    public class RegisterOperand : Operand
    {
        Registers.Register register;

        public RegisterOperand(string name)
        {
            register = name.ToUpper() switch
            {
                "AX" => Registers.Register.R16_AX,
                "AL" => Registers.Register.R8_AL,
                "AH" => Registers.Register.R8_AH,

                "BX" => Registers.Register.R16_BX,
                "BL" => Registers.Register.R8_BL,
                "BH" => Registers.Register.R8_BH,

                "CX" => Registers.Register.R16_CX,
                "CL" => Registers.Register.R8_CL,
                "CH" => Registers.Register.R8_CH,

                "DX" => Registers.Register.R16_DX,
                "DL" => Registers.Register.R8_DL,
                "DH" => Registers.Register.R8_DH,

                "BP" => Registers.Register.R16_BP,
                "SP" => Registers.Register.R16_SP,

                "SI" => Registers.Register.R16_SI,
                "DI" => Registers.Register.R16_DI,

                "DS" => Registers.Register.R16_DS,
                "SS" => Registers.Register.R16_SS,

                _ => throw new Exception("unknown register " + name)
            };
        }

        public RegisterOperand(Registers.Register register)
        {
            this.register = register;
        }
    }
}
