using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Lexer
{
    public class Num : Token
    {
        public readonly int Value;
        public Num(int v) : base(Tag.NUM)
        {
            Value = v;
        }
        public override string ToString()
        {
            return "" + Value;
        }
    }
}
