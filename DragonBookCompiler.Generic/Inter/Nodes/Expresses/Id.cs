using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class Id : Express
    {
        public int offset;

        public Id(DragonWord id, Symbols.DragonType p, int b) : base(id, p)
        {
            offset = b;
        }
    }
}
