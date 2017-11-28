using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Generic.Lexer
{
    public class Token
    {
        public readonly int tag;
        public Token(int t)
        {
            tag = t;
        }
        public override string ToString()
        {
            return "" + (char)tag;
        }
    }
}
