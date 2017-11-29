using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;

namespace DragonBookCompiler.Generic.Symbols
{
    public class Type : Word
    {
        public int Width = 0;

        public Type(string s, int tag, int w) : base(s, tag)
        {
            Width = w;
        }

        public static readonly Type Int     = new Type("int",   Tag.BASIC, 4),
                                    Float   = new Type("float", Tag.BASIC, 8),
                                    Char    = new Type("char",  Tag.BASIC, 1),
                                    Bool    = new Type("bool",  Tag.BASIC, 1);

        public static Boolean Numeric (Type p)
        {
            if (p == Char || p == Float || p == Int)
                return true;
            else
                return false;
        }

        public static Type Max(Type p1, Type p2)
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
