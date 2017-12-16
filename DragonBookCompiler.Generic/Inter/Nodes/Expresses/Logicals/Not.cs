using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class Not : Logical
    {
        public Not(Token tok, Express x2) : base(tok, x2, x2)
        {

        }

        public new void Jump(int t, int f)
        {
            expr2.Jump(f, t);
        }

        public override string ToString ()
        {
            return Op.ToString() + " " + expr2.ToString();
        }
    }
}
