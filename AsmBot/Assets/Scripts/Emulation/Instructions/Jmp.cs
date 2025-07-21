using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo("JMP", 1)]
    public class Jmp : Instruction
    {
        public Jmp(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            var source = Operands[0];
            switch (source.GetSize())
            {
                case OperandSize._8Bits:
                    UnityEngine.Debug.Log("Dbg/8: " + source.GetByte(cpu));
                    break;
                case OperandSize._16Bits:
                    UnityEngine.Debug.Log("Dbg/16: " + source.GetWord(cpu));
                    break;
                case OperandSize.Any:
                    UnityEngine.Debug.Log("Dbg/8|16: " + source.GetByte(cpu) + " | " + source.GetWord(cpu));
                    break;
            }
        }
    }
}
