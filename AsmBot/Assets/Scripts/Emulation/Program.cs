using Assets.Scripts.Emulation.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation
{
    public class Program
    {
        public List<Instruction> Instructions { get; } = new();
        public Dictionary<string, int> Labels { get; } = new();

        public void Step(CPU cpu)
        {
        }
    }
}
