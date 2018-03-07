using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class Access : Operation
    {
        public Id array;
        public Express index;

        public Access(Id a, Express i, DragonType p) : base(new DragonWord("[]", DragonTag.INDEX), p)
        {
            array = a;
            index = i;
        }

        public override Express Generate()
        {
            return new Access(array, index.Reduce(), type);
        }

        public new void Jump(int t, int f)
        {
            EmitJumps(Reduce().ToString(), t, f);
        }

        public override String ToString()
        {
            return array.ToString() + " [ " + index.ToString() + " ]";
        }
    }
}
