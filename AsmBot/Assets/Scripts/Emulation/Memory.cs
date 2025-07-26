using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation
{
    public class Memory
    {
        private readonly byte[] memory;
        public byte[] Data { get { return memory; } }

        public uint StartAddress { get; }
        public uint EndAddress { get; }

        public Memory(uint startAddress = 0, uint size = 0xFFFF)
        {
            StartAddress = startAddress;
            EndAddress = startAddress + size-1;
            memory = new byte[size];
        }

        public byte ReadByte(uint globalAddress) => memory[globalAddress - StartAddress];
        public void WriteByte(uint globalAddress, byte value) => memory[globalAddress - StartAddress] = value;

        public ushort ReadWord(uint globalAddress)
        {
            uint localAddress = globalAddress - StartAddress;
            return (ushort)(memory[localAddress] | (memory[localAddress + 1] << 8));
        }

        public void WriteWord(uint globalAddress, ushort value)
        {
            uint localAddress = globalAddress - StartAddress;
            memory[localAddress] = (byte)(value & 0xFF);
            memory[localAddress + 1] = (byte)((value >> 8) & 0xFF);
        }

        public bool ContainsGlobalAddress(uint globalAddress)
        {
            if(globalAddress < StartAddress) return false;
            if(globalAddress > EndAddress) return false;
            return true;
        }
    }
}
