using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{
    public class Access : Operation, IOperation
    {
        public Id array;
        public Express index;

        public Access(Id a, Express i, Symbols.Type p) : base(new Word("[]", Tag.INDEX), p)
        {
            array = a;
            index = i;
        }

        public new Express Gen()
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
