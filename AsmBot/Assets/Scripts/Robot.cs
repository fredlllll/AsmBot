using Antlr4.Runtime.Tree;
using Antlr4.Runtime;
using Assets.Scripts.Emulation;
using Assets.Scripts.Emulation.Parsing;
using System;
using System.Text;
using UnityEngine;
using Assets.Scripts.Emulation.Compiling;

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

        /*programText = @"add ax,[ax]
add bx,5
add cx,aah
loop:
jmp loop";*/

        ICharStream stream = CharStreams.fromString(programText);
        ITokenSource lexer = new asmbotGrammarLexer(stream);
        ITokenStream tokens = new CommonTokenStream(lexer);
        asmbotGrammarParser parser = new asmbotGrammarParser(tokens);
        //IParseTree tree = parser.StartRule()
        IParseTree tree = parser.prog();
        AsmbotGrammarListener listener = new AsmbotGrammarListener();
        ParseTreeWalker.Default.Walk(listener, tree);



        //var lines = Preprocessor.Process(programText);
        //var tokens = Tokenizer.Tokenize(lines);
        //var program = Parser.Parse(tokens);

        StringBuilder sb = new();
        foreach (var line in listener.programLines)
        {
            sb.AppendLine(line.ToString());
        }
        /*for (int i = 0; ; i++)
        {
            try
            {
                sb.AppendLine(tokens.Get(i).Text);
            }
            catch
            {
                break;
            }
        }*/
        Debug.Log(listener.tokenNames);
        Debug.Log(sb);
    }

    void Update()
    {
        //cpu.Step();
    }
}
