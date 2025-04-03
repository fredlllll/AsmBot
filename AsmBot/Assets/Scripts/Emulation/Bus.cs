using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation
{
    public class Bus
    {
        private Memory ram;
        private List<IDevice> devices = new List<IDevice>();
        //TODO: seperate list for memory mapped devices

        public Bus(Memory ram)
        {
            this.ram = ram;
        }

        public void AttachDevice(IDevice device)
        {
            devices.Add(device);
            if (device.MappedMemory != null)
            {

            }
        }

        public byte ReadByte(uint globalAddress)
        {
            if (ram.ContainsGlobalAddress(globalAddress))
            {
                return ram.ReadByte(globalAddress);
            }
            //TODO: check for memory mapped devices
            throw new AccessViolationException("unmapped address " + globalAddress);
        }

        public byte ReadPortByte(ushort port)
        {
            foreach (IDevice device in devices)
            {
                if (device.Ports.Contains(port))
                {
                    return device.ReadPortByte(port);
                }
            }
            throw new AccessViolationException("no such port " + port);
        }

        public ushort ReadWord(uint globalAddress)
        {
            if (ram.ContainsGlobalAddress(globalAddress))
            {
                return ram.ReadWord(globalAddress);
            }
            //TODO: check for memory mapped devices
            throw new AccessViolationException("unmapped address " + globalAddress);
        }

        public ushort ReadPortWord(ushort port)
        {
            foreach (IDevice device in devices)
            {
                if (device.Ports.Contains(port))
                {
                    return device.ReadPortWord(port);
                }
            }
            throw new AccessViolationException("no such port " + port);
        }

        public void Write(uint globalAddress, byte value)
        {
            if (ram.ContainsGlobalAddress(globalAddress))
            {
                ram.WriteByte(globalAddress, value);
            }
            else
            {
                //TODO: check for memory mapped devices
                throw new AccessViolationException("unmapped address " + globalAddress);
            }
        }

        public void WritePort(ushort port, byte value)
        {
            foreach (IDevice device in devices)
            {
                if (device.Ports.Contains(port))
                {
                    device.WritePortByte(port, value);
                    return;
                }
            }
            throw new AccessViolationException("no such port " + port);
        }

        public void Write(uint globalAddress, ushort word)
        {
            if (ram.ContainsGlobalAddress(globalAddress))
            {
                ram.WriteWord(globalAddress, word);
            }
            else
            {
                //TODO: check for memory mapped devices
                throw new AccessViolationException("unmapped address " + globalAddress);
            }
        }
        public void WritePort(ushort port, ushort word)
        {
            foreach (IDevice device in devices)
            {
                if (device.Ports.Contains(port))
                {
                    device.WritePortWord(port, word);
                    return;
                }
            }
            throw new AccessViolationException("no such port " + port);
        }
    }
}
