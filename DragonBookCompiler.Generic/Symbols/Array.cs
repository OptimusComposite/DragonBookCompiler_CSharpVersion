using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;

namespace DragonBookCompiler.Generic.Symbols
{
    public class Array : Type
    {
        public Array(int sz, Type p) : base("[]", Tag.INDEX, sz * p.Width)
        {

        }
    }
}
