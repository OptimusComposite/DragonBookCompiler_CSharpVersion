using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Generic.Lexer
{
    public class DragonNumber : DragonToken
    {
        public readonly int Value;

        public DragonNumber(int v) : base(DragonTag.NUM)
        {
            Value = v;
        }

        public override string ToString()
        {
            return "" + Value;
        }
    }
}
