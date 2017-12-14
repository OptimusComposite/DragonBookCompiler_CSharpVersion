using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class SetElement : Statement
    {
        public Id array;
        public Express index;
        public Express expr;

        public SetElement(Access x, Express y)
        {
            array = x.array;
            index = x.index;
            expr = y;
            if (check(x.type, expr.type) == null)
                Error("type error");
        }

        public Symbols.Type check(Symbols.Type p1, Symbols.Type p2)
        {
            if (p1 is Symbols.Array || p2 is Symbols.Array )
                return null;
            else if (p1 == p2)
                return p2;
            else if (Symbols.Type.Numeric(p1) && Symbols.Type.Numeric(p2))
                return p2;
            else
                return null;
        }

        public new void Gen(int b, int a)
        {
            String s1 = index.Reduce().ToString();
            String s2 = expr.Reduce().ToString();
            Emit(array.ToString() + " [ " + s1 + " ] = " + s2);
        }
    }
}
