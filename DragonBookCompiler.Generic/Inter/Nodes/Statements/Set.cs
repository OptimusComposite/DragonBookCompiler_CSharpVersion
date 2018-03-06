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
            if (Check(id.type, expr.type) == null)
                PrintError("type error");
        }

        public DragonType Check(DragonType p1, DragonType p2)
        {
            if (DragonType.Numeric(p1) && DragonType.Numeric(p2))
                return p2;
            else if (p1 == DragonType.Bool && p2 == DragonType.Bool)
                return p2;
            else
                return null;
        }

        public new void Generate(int b, int a)
        {
            EmitStatement(id.ToString() + " = " + expr.Generate().ToString());
        }
    }
}
