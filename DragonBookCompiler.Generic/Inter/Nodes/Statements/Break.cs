using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Generic.Inter
{
    public class Break : Statement
    {
        Statement stmt;

        public Break()
        {
            if (Enclosing == Nul)
            {
                PrintError("unenclosed break");
            }
            stmt = Enclosing;
        }

        public override void Generate(int b, int a)
        {
            EmitStatement("Goto L" + stmt.After);
        }
    }
}
