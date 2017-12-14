using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class While : Statement
    {
        Express expr;
        Statement stmt;

        public While()
        {
            expr = null;
            stmt = null;
        }

        public void init(Express x, Statement s)
        {
            expr = x;
            stmt = s;
            if (expr.type != Symbols.Type.Bool)
                expr.Error("boolean required in while");
        }
        public new void Gen(int b, int a)
        {
            After = a;                // save label a
            expr.Jump(0, a);
            int label = NewLabel();   // label for stmt
            EmitLabel(label);
            stmt.Gen(label, b);
            Emit("goto L" + b);
        }
    }
}
