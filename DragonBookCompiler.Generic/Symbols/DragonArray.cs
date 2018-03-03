using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;

namespace DragonBookCompiler.Generic.Symbols
{
    public class DragonArray : DragonType
    {
        public DragonType of;
        public int size = 1;

        public DragonArray(int sz, DragonType p) : base("[]", DragonTag.INDEX, sz * p.Width)
        {
            size = sz;
            of = p;
        }
        public override string ToString()
        {
            return "[" + size + "]" + of.ToString();
        }
    }
}
