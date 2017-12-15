using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class Arith : Operation
    {
        public Express expr1, expr2;

        public Arith(Token tok, Express x1, Express x2) : base(tok, null)
        {
            expr1 = x1;
            expr2 = x2;
            type = Symbols.Type.Max(expr1.type, expr2.type);
            if (type == null)
                Error("type error");
        }

        public new Express Gen()
        {
            return new Arith(Op, expr1.Reduce(), expr2.Reduce());
        }

        public override String ToString()
        {
            return expr1.ToString() + " " + Op.ToString() + " " + expr2.ToString();
        }
    }
}
