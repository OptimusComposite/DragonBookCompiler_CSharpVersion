using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class Unary : Operation
    {
        public Express expr;

        public Unary(DragonToken tok, Express x) : base(tok, null)
        {
            expr = x;
            type = Symbols.DragonType.Max(Symbols.DragonType.Int, expr.type);
            if (type == null)
                PrintError("type error");
        }

        public new Express Generate()
        {
            return new Unary(Op, expr.Reduce());
        }

        public override String ToString()
        {
            return Op.ToString() + " " + expr.ToString();
        }
    }
}
