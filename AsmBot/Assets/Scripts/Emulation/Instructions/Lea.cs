using Assets.Scripts.Emulation.Instructions.Operands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Video;

namespace Assets.Scripts.Emulation.Instructions
{
    [InstructionInfo(MnemonicOpCode.LEA)]
    public class Lea : Instruction
    {
        public Lea(Operand[] operands) : base(operands) { }

        public override void Execute(CPU cpu)
        {
            var reg = Operands[0];
            var mem = Operands[1] as IMemoryOperand;

            var (seg, off) = AddressUtil.ToSegmentAndOffset(mem.GetEffectiveAddress(cpu));
            //apparently we just throw away the segment
            reg.SetWord(cpu, off);
        }
    }
}
