using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Emulation.Parsing
{
    public class SyntaxException : Exception
    {
        public SyntaxException(string str) : base(str) { }
    }
}
