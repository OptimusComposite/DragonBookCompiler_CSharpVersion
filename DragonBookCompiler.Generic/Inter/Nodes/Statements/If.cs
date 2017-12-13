using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Generic.Inter
{ 
    public class If : Statement
    {
        Express ex;
        Statement st;

        public If(Express e, Statement s)
        {
            ex = e;
            st = s;
            if (ex.type != Symbols.Type.Bool)
                ex.Error("Boolean required in if");
        }

        public new void Gen(int b, int a)
        {
            int label = NewLabel();
            ex.Jump(0, a);
            EmitLabel(label);
            st.Gen(label, a);
        }
    }
}
