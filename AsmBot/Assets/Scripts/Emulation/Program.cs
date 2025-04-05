using Assets.Scripts.Emulation.Instructions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation
{
    internal class Program
    {
        public List<string> Lines { get; }
        private Dictionary<string,int> labels = new Dictionary<string,int>();

        public Program(string program)
        {
            
        }

        public void Step(CPU cpu)
        {
        }
    }
}
