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
        public Constant(Token tok, Symbols.Type p) : base(tok, p)
        {
        }

        public Constant(int i) : base(new Num(i), Symbols.Type.Int)
        {
        }

        public static readonly Constant True    = new Constant(Word.True,   Symbols.Type.Bool);
        public static readonly Constant False   = new Constant(Word.False,  Symbols.Type.Bool);

        public void Jump(int t, int f)
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
