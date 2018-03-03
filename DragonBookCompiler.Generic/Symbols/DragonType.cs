using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;

namespace DragonBookCompiler.Generic.Symbols
{
    public class DragonType : DragonWord
    {
        public int Width = 0;

        public DragonType(string s, int tag, int w) : base(s, tag)
        {
            Width = w;
        }

        public static readonly DragonType Int     = new DragonType("int",   DragonTag.BASIC, 4),
                                    Float   = new DragonType("float", DragonTag.BASIC, 8),
                                    Char    = new DragonType("char",  DragonTag.BASIC, 1),
                                    Bool    = new DragonType("bool",  DragonTag.BASIC, 1);

        public static Boolean Numeric (DragonType p)
        {
            if (p == Char || p == Float || p == Int)
                return true;
            else
                return false;
        }

        public static DragonType Max(DragonType p1, DragonType p2)
        {
            if (!(Numeric(p1)) || !(Numeric(p2)))
                return null;
            else if (p1 == Float || p2 == Float)
                return Float;
            else if (p1 == Int || p2 == Int)
                return Int;
            else
                return Char;
        }
    }
}
