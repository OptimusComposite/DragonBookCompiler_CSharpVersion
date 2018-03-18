using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Generic.Lexer
{
    public class DragonWord : DragonToken
    {
        public string LexElement = "";

        public DragonWord(string s, int tag) : base(tag)
        {
            LexElement = s;
        }

        public new string ToString()
        {
            return LexElement;
        }

        public readonly static DragonWord   and     = new DragonWord("&&",      DragonTag.AND),
                                            or      = new DragonWord("||",      DragonTag.OR),
                                            eq      = new DragonWord("==",      DragonTag.EQ),
                                            ne      = new DragonWord("!=",      DragonTag.NE),
                                            le      = new DragonWord("<=",      DragonTag.LE),
                                            ge      = new DragonWord(">=",      DragonTag.GE),
                                            minus   = new DragonWord("minus",   DragonTag.MINUS),
                                            True    = new DragonWord("true",    DragonTag.TRUE),
                                            False   = new DragonWord("false",   DragonTag.FALSE),
                                            temp    = new DragonWord("t",       DragonTag.TEMP);
    }
}
