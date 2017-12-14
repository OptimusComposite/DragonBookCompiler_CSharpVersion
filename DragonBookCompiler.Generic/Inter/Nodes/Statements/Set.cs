using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class Set : Statement
    {
        public Id id;
        public Express expr;

        public Set(Id i, Express x)
        {
            id = i;
            expr = x;
            if (check(id.type, expr.type) == null)
                Error("type error");
        }

        public Symbols.Type check(Symbols.Type p1, Symbols.Type p2)
        {
            if (Symbols.Type.Numeric(p1) && Symbols.Type.Numeric(p2))
                return p2;
            else if (p1 == Symbols.Type.Bool && p2 == Symbols.Type.Bool)
                return p2;
            else
                return null;
        }

        public new void Gen(int b, int a)
        {
            Emit(id.ToString() + " = " + expr.Gen().ToString());
        }
    }
}
