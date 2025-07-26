using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Instructions.Operands
{
    public interface IMemoryOperand
    {
        uint GetEffectiveAddress(CPU cpu);
    }
}
