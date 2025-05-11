using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo("DBG", 1)]
    public class Dbg : Instruction
    {
        public Dbg(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            var source = Operands[0];
            switch (source.GetSize())
            {
                case OperandSize._8Bits:
                    Debug.Log("Dbg/8: "+source.GetByte(cpu));
                    break;
                case OperandSize._16Bits:
                    Debug.Log("Dbg/16: " + source.GetWord(cpu));
                    break;
                case OperandSize.Any:
                    Debug.Log("Dbg/8|16: " + source.GetByte(cpu)+" | "+ source.GetWord(cpu));
                    break;
            }
        }
    }
}
