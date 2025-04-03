using Assets.Scripts.Emulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation
{
    public class CPU
    {
        public readonly Memory memory;
        public readonly Registers registers;
        public readonly Bus bus;

        public CPU(Memory memory, Registers registers, Bus bus)
        {
            this.memory = memory;
            this.registers = registers;
            this.bus = bus;
        }

        public void Step()
        {
            byte opcode = FetchNextCodeByte();
            Execute(opcode);
        }

        public byte FetchNextCodeByte()
        {
            uint globalAddress = EmuUtil.ConvertAddress(registers.CS, registers.IP);
            byte opcode = memory.ReadByte(globalAddress);
            registers.IP++;
            return opcode;
        }

        private void Execute(byte opcode)
        {
            switch (opcode)
            {
                case 0xB8: // MOV AX, imm16
                    registers.AX = memory.ReadWord(EmuUtil.ConvertAddress(registers.CS,registers.IP));
                    registers.IP += 2;
                    break;

                case 0xE9: // JMP rel16
                    short offset = (short)memory.ReadWord(((uint)registers.CS << 4) + registers.IP);
                    registers.IP = (ushort)(registers.IP + offset);
                    break;

                case 0xCD: // INT n
                    byte interruptNum = FetchNextCodeByte();
                    HandleInterrupt(interruptNum);
                    break;

                default:
                    UnityEngine.Debug.Log($"Unimplemented opcode: {opcode:X2}");
                    break;
            }
        }

        private void HandleInterrupt(byte interruptNum)
        {
            // Placeholder for BIOS/DOS interrupts (e.g., INT 10h for video, INT 21h for DOS functions)
            UnityEngine.Debug.Log($"Interrupt {interruptNum:X2} called");
        }
    }
}
