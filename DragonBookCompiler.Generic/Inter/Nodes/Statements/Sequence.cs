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

        public override void Generate(int b, int a)
        {
            if (st1 == Nul)
                st2.Generate(b, a);
            else if (st2 == Nul)
                st1.Generate(b, a);
            else
            {
                int label = NewLabel();
                st1.Generate(b, label);
                EmitLabel(label);
                st2.Generate(label, a);
            }
        }
    }
}
