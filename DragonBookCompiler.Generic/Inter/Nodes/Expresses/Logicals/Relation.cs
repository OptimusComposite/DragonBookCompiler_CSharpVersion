using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class Relation : Logical
    {
        public Relation(Token tok, Express x1, Express x2) : base(tok, x1, x2)
        {

        }

        public Symbols.Type check(Symbols.Type p1, Symbols.Type p2)
        {
            if (p1 is Symbols.Array || p2 is Symbols.Array )
                return null;
            else if (p1 == p2)
                return Symbols.Type.Bool;
            else
                return null;
        }

        public new void Jump(int t, int f)
        {
            Express a = expr1.Reduce();
            Express b = expr2.Reduce();
            String test = a.ToString() + " " + Op.ToString() + " " + b.ToString();
            EmitJumps(test, t, f);
        }
    }
}
