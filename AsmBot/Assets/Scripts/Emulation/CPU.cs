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

        }

        private void HandleInterrupt(byte interruptNum)
        {
            // Placeholder for BIOS/DOS interrupts (e.g., INT 10h for video, INT 21h for DOS functions)
            UnityEngine.Debug.Log($"Interrupt {interruptNum:X2} called");
        }
    }
}
