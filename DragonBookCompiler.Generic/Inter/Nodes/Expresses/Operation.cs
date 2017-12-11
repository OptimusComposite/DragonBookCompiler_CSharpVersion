using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class Operation : Express
    {
        public Operation(Token tok, Symbols.Type p) : base(tok, p)
        {
        }

        public new Express Reduce()
        {
            Express e = Gen();
            Temp t = new Temp(type);
            Emit(t.ToString() + " = " + e.ToString());
            return t;
        }
    }
}
