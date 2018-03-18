using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Generic.Lexer
{
    public class DragonToken
    {
        public readonly int tag;

        public DragonToken(int t)
        {
            tag = t;
        }

        public new string ToString()
        {
            return ("" + (char)tag);
        }
    }
}
