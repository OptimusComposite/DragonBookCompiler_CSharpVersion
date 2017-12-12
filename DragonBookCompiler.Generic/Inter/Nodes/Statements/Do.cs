using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class Do : Statement
    {
        Express ex;
        Statement st;

        public Do()
        {
            ex = null;
            st = null;
        }

        public void Init(Statement s, Express e)
        {
            ex = e;
            st = s;
            if (ex.type != Symbols.Type.Bool)
                ex.Error("boolean required in Do");
        }

        public void Gen(int b, int a)
        {
            After = a;
            int label = NewLabel();
            st.Gen(b, label);
            EmitLabel(label);
            ex.Jump(b, 0);
        }
    }
}
