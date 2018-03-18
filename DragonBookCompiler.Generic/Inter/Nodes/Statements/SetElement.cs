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
            if (Check(x.type, expr.type) == null)
                PrintError("type error");
        }

        public DragonType Check(DragonType p1, DragonType p2)
        {
            if (p1 is DragonArray || p2 is DragonArray )
                return null;
            else if (p1 == p2)
                return p2;
            else if (DragonType.IsNumeric(p1) && DragonType.IsNumeric(p2))
                return p2;
            else
                return null;
        }

        public override void Generate(int b, int a)
        {
            string s1 = index.Reduce().ToString();
            string s2 = expr.Reduce().ToString();
            EmitStatement(array.ToString() + " [ " + s1 + " ] = " + s2);
        }
    }
}
