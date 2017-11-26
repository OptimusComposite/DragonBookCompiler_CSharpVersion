using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Lexer
{
    class Token
    {
        public readonly int Tag;
        public Token(int t)
        {
            Tag = t;
        }
        public string toString()
        {
            return "" + (char)Tag;
        }
    }
}
