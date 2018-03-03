using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Symbols;
using DragonBookCompiler.Generic.Lexer;

namespace DragonBookCompiler.Generic.Inter
{
    public class Temp : Express
    {
        static int count = 0;
        int number = 0;

        public Temp(DragonType p) : base(DragonWord.temp, p)
        {
            number = ++count;
        }

        public override string ToString()
        {
            return "t" + number;
        }
    }
}
