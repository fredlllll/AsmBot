using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    public class Add : Instruction
    {
        public static readonly string description = "ADD r/m8, r8";

        public Add() : base(0x00, description) { }

        public override void Execute(CPU cpu)
        {
            ModRM modRM = new(cpu.FetchNextCodeByte());

            // r8 (source)
            byte addValue = cpu.registers.GetRegisterByte(modRM.Register);
            if (modRM.IsMemoryOperand)
            {//m8
                uint address = modRM.CalculateEffectiveAddress(cpu);
                byte baseValue = cpu.bus.ReadByte(address);
                cpu.bus.Write(address, (byte)(baseValue + addValue));
            }
            else
            {//r8
                byte baseValue = cpu.registers.GetRegisterByte(modRM.RM);
                cpu.registers.SetRegisterByte(modRM.RM, (byte)(baseValue + addValue));
            }
        }
    }
}
