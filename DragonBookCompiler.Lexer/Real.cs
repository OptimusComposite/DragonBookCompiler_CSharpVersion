using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Lexer
{
    public class Real : Token
    {
        public readonly float Value;
        public Real(float v) : base(Tag.REAL)
        {
            Value = v;
        }
        public override string ToString()
        {
            return "" + Value;
        }
    }
}
