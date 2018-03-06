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
        public Operation(DragonToken tok, Symbols.DragonType p) : base(tok, p)
        {
        }

        public new Express Reduce()
        {
            Express e = Generate();
            Temp t = new Temp(type);
            EmitStatement(t.ToString() + " = " + e.ToString());
            return t;
        }
    }
}
