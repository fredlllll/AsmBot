using Assets.Scripts.Computer;
using Assets.Scripts.Emulation;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private CPU cpu;
    private Memory memory;
    private Registers registers;
    private Bus bus;

    void Start()
    {
        memory = new Memory();
        registers = new Registers();
        bus = new Bus(memory);
        cpu = new CPU(memory, registers, bus);

        LoadProgram();
    }

    void Update()
    {
        cpu.Step();
    }

    void LoadProgram()
    {
        // Example: MOV AX, 1234h; INT 10h
        byte[] program = { 0xB8, 0x34, 0x12, 0xCD, 0x10 };
        for (int i = 0; i < program.Length; i++)
        {
            memory.WriteByte(0x7C00 + (uint)i, program[i]);
        }
        registers.CS = 0x0000;
        registers.IP = 0x7C00; // Typical boot sector location
    }
}
