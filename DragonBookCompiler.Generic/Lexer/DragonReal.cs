using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Generic.Lexer
{
    public class DragonReal : DragonToken
    {
        public readonly float Value;

        public DragonReal(float v) : base(DragonTag.REAL)
        {
            Value = v;
        }

        public new string ToString()
        {
            return ("" + Value);
        }
    }
}
