using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Generic.Inter
{
    public class Sequence : Statement
    {
        Statement st1, st2;

        public Sequence(Statement s1, Statement s2)
        {
            st1 = s1;
            st2 = s2;
        }

        public new void Gen(int b, int a)
        {
            if (st1 == Statement.Nul)
                st2.Gen(b, a);
            else if (st2 == Nul)
                st1.Gen(b, a);
            else
            {
                int label = NewLabel();
                st1.Gen(b, label);
                EmitLabel(label);
                st2.Gen(label, a);
            }
        }
    }
}
