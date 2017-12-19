using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class Unary : Operation, IOperation
    {
        public Express expr;

        public Unary(Token tok, Express x) : base(tok, null)
        {
            expr = x;
            type = Symbols.Type.Max(Symbols.Type.Int, expr.type);
            if (type == null)
                Error("type error");
        }

        public new Express Gen()
        {
            return new Unary(Op, expr.Reduce());
        }

        public override String ToString()
        {
            return Op.ToString() + " " + expr.ToString();
        }
    }
}
