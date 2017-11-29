using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DragonBookCompiler.Generic.Symbols;
using System.IO;

namespace DragonBookCompiler.Generic.Lexer
{
    public class Lexer
    {
        public static int Line = 1;
        char Peek = ' ';
        Hashtable Words = new Hashtable();
        void Reserve(Word w)
        {
            Words.Add(w.LexElement, w);
        }
        public Lexer()
        {
            Reserve(new Word("if",      Tag.IF      ));
            Reserve(new Word("else",    Tag.ELSE    ));
            Reserve(new Word("while",   Tag.WHILE   ));
            Reserve(new Word("do",      Tag.DO      ));
            Reserve(new Word("break",   Tag.BREAK   ));
            Reserve(Word.True);
            Reserve(Word.False);
            Reserve(Symbols.Type.Int);
            Reserve(Symbols.Type.Char);
            Reserve(Symbols.Type.Float);
            Reserve(Symbols.Type.Bool);
        }
        void ReadChar()
        {
            try
            {
                Peek = (char)Console.Read();
            }
            catch
            {
                throw new IOException();
            }
        }
        Boolean ReadChar(char c)
        {
            try
            {
                ReadChar();
                if (Peek != c)
                    return false;
                Peek = ' ';
                return true;
            }
            catch
            {
                throw new IOException();
            }
        }

    }
}
