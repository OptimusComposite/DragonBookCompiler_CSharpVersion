using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DragonBookCompiler.Generic.Lexer
{
    public class Lexer
    {
        public static int Line = 1;
        char peek = ' ';
        Hashtable Words = new Hashtable();
        void Reserve(Word w)
        {
            Words.Add(w.LexElement, w);
        }
        public Lexer()
        {
            Reserve(new Word("if", Tag.IF));
            Reserve(new Word("else", Tag.ELSE));
            Reserve(new Word("while", Tag.WHILE));
            Reserve(new Word("do", Tag.DO));
            Reserve(new Word("break", Tag.BREAK));
        }
    }
}
