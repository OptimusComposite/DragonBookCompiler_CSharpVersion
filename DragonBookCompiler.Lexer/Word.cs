using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Lexer
{
    public class Word : Token
    {
        public string LexElement = "";
        public Word(string s, int tag) : base(tag)
        {
            LexElement = s;
        }
        public override string ToString()
        {
            return LexElement;
        }

        public readonly static Word and     = new Word("&&",    Tag.AND),
                                    or      = new Word("||",    Tag.OR),
                                    eq      = new Word("==",    Tag.EQ),
                                    ne      = new Word("!=",    Tag.NE),
                                    le      = new Word("<=",    Tag.LE),
                                    ge      = new Word(">=",    Tag.GE),
                                    minus   = new Word("minus", Tag.MINUS),
                                    True    = new Word("true",  Tag.TRUE),
                                    False   = new Word("false", Tag.FALSE),
                                    temp    = new Word("t",     Tag.TEMP);
    }
}
