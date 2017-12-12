using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Generic.Inter
{
    public class Statement : Node
    {
        public Statement()
        {

        }

        public static Statement Nul = new Statement();
        public void Gen(int a, int b)
        {

        }
        internal int After = 0;
        public static Statement Enclosing = Statement.Nul;
    }
}
