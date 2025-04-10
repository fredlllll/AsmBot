using Assets.Scripts.Emulation;
using Assets.Scripts.Emulation.Parsing;
using System.Text;
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

        //LoadProgram();

        string programText = @"
convertSectorToCHS: ; sectors in DX:AX, SectorsPerTrack[top of stack] and Heads on stack
    pop bx
    div bx ; divide by sectors per track. Temp in AX, sector in DX
    inc dl ; sector is 1 based, so add 1
    mov cl,dl ; put sector in CL
    xor dx,dx ; zero dx
    pop bx
    div bx ; divide temp by amount of heads
    mov ch,al; al contains track lower 8 bytes
    shr ax,2
    and ax,0C0h ; get bit 9 and 10 into right position to or it onto cl
    or cl,al
    mov dh,dl; dx contains head
    ret
            ";

        programText = @"add ax,ax
add bx,5
add cx,aah";

        var lines = Preprocessor.Process(programText);
        var tokens = Tokenizer.Tokenize(lines);
        var program = Parser.Parse(tokens);

        StringBuilder sb = new();
        foreach (var token in tokens)
        {
            sb.AppendLine(token.ToString());
        }

        Debug.Log(sb);
    }

    void Update()
    {
        //cpu.Step();
    }

    void LoadProgram()
    {
        // Example: MOV AX, 1234h; INT 10h
        byte[] program = { 0xB8, 0x34, 0x12, 0xCD, 0x10 };
        for (int i = 0; i < program.Length; i++)
        {
            memory.WriteByte(0x7C00 + (uint)i, program[i]);
        }
        //registers.CS = 0x0000;
        //registers.IP = 0x7C00; // Typical boot sector location
    }
}
