using Assets.Scripts.Emulation;
using Assets.Scripts.Emulation.Instructions;
using System;
using System.Collections.Generic;
using System.IO;
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
        public bool IsHalted { get; set; } = false;

        public CPU(Memory memory, Registers registers, Bus bus)
        {
            this.memory = memory;
            this.registers = registers;
            this.bus = bus;
        }

        private Instruction FetchNextInstruction()
        {
            var codeAddress = AddressUtil.ToGlobalAddress(registers.CS, registers.IP);
            using var ms = new MemoryStream(memory.Data, (int)codeAddress, (int)(memory.Data.Length - codeAddress), false);
            using var br = new BinaryReader(ms, Encoding.ASCII, true);
            return InstructionsUtil.FromStream(br);
        }

        public void Step()
        {
            if (!IsHalted)
            {
                var instr = FetchNextInstruction();
                instr.Execute(this);
            }
        }

        private void HandleInterrupt(byte interruptNum)
        {
            // Placeholder for BIOS/DOS interrupts (e.g., INT 10h for video, INT 21h for DOS functions)
            UnityEngine.Debug.Log($"Interrupt {interruptNum:X2} called");
        }
    }
}
