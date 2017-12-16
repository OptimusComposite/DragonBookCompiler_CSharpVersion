using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class And : Logical
    {
        public And(Token tok, Express x1, Express x2) : base(tok, x1, x2)
        {

        }

        public new void Jump(int t, int f)
        {
            int label = f != 0 ? f : NewLabel();
            expr1.Jump(0, label);
            expr2.Jump(t, f);
            if (f == 0)
                EmitLabel(label);
        }
    }
}
