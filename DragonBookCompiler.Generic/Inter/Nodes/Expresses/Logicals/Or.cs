using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class Or : Logical
    {
        public Or(DragonToken tok, Express x1, Express x2) : base(tok, x1, x2)
        {

        }
        
        public new void Jump(int t, int f)
        {
            int label = t != 0 ? t : NewLabel();
            expr1.Jump(label, 0);
            expr2.Jump(t, f);
            if (t == 0)
                EmitLabel(label);
        }
    }
}
