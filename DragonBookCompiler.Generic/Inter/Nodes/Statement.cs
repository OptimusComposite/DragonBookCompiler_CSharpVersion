using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Generic.Inter
{
    public class Statement : Node
    {
        //TODO: ...

        public Statement()
        {

        }

        public static Statement Nul = new Statement();

        public virtual void Generate(int a, int b)
        {

        }

        internal int After = 0;

        public static Statement Enclosing = Nul;
    }
}
