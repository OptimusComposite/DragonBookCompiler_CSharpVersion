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
            if (Statement.Enclosing == Statement.Nul)
            {
                Error("unenclosed break");
            }
            stmt = Statement.Enclosing;
        }
        public void Gen(int b, int a)
        {
            Emit("Goto L" + stmt.After);
        }
        
    }
}
