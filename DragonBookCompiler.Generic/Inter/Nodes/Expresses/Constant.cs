using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;


namespace DragonBookCompiler.Generic.Inter
{
    public class Constant : Express
    {
        public Constant(DragonToken tok, Symbols.DragonType p) : base(tok, p)
        {
        }

        public Constant(int i) : base(new DragonNumber(i), Symbols.DragonType.Int)
        {
        }

        public static readonly Constant True    = new Constant(DragonWord.True,   Symbols.DragonType.Bool);
        public static readonly Constant False   = new Constant(DragonWord.False,  Symbols.DragonType.Bool);

        public new void Jump(int t, int f)
        {
            if (this == True && t != 0)
            {
                Emit("Goto L" + t);
            }
            else if (this == False && f != 0)
            {
                Emit("Goto L" + f);
            }
        }
    }
}
