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
    public class DragonLexer
    {
        public static int Line = 1;
        char Peek = ' ';
        Hashtable Words = new Hashtable();

        void Reserve(DragonWord w)
        {
            Words.Add(w.LexElement, w);
        }

        public DragonLexer()
        {
            Reserve(new DragonWord("if",      DragonTag.IF      ));
            Reserve(new DragonWord("else",    DragonTag.ELSE    ));
            Reserve(new DragonWord("while",   DragonTag.WHILE   ));
            Reserve(new DragonWord("do",      DragonTag.DO      ));
            Reserve(new DragonWord("break",   DragonTag.BREAK   ));
            Reserve(DragonWord.True);
            Reserve(DragonWord.False);
            Reserve(Symbols.DragonType.Int);
            Reserve(Symbols.DragonType.Char);
            Reserve(Symbols.DragonType.Float);
            Reserve(Symbols.DragonType.Bool);
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

        public DragonToken Scan()
        {
            try
            {
                for (; ; ReadChar())
                {
                    if (Peek == ' ' || Peek == '\t')
                        continue;
                    else if (Peek == '\n')
                        Line = Line + 1;
                    else
                        break;
                }
                switch (Peek)
                {
                    case '&':
                        if (ReadChar('&'))
                            return DragonWord.and;
                        else
                            return new DragonToken('&');
                    case '|':
                        if (ReadChar('|'))
                            return DragonWord.or;
                        else
                            return new DragonToken('|');
                    case '=':
                        if (ReadChar('='))
                            return DragonWord.eq;
                        else
                            return new DragonToken('=');
                    case '!':
                        if (ReadChar('='))
                            return DragonWord.ne;
                        else
                            return new DragonToken('!');
                    case '<':
                        if (ReadChar('='))
                            return DragonWord.le;
                        else
                            return new DragonToken('<');
                    case '>':
                        if (ReadChar('='))
                            return DragonWord.ge;
                        else
                            return new DragonToken('>');
                }
                if (Char.IsDigit(Peek))
                {
                    int v = 0;
                    do
                    {
                        v *= 10;
                        v += Convert.ToInt16(Peek);
                        ReadChar();
                    }
                    while (Char.IsDigit(Peek));
                    if (Peek != '.')
                        return new DragonNumber(v);
                    float x = v;
                    float d = 10;
                    for (; ; )
                    {
                        ReadChar();
                        if (!Char.IsDigit(Peek)) break;
                        x += Convert.ToInt16(Peek);
                        x /= d;
                        d *= 10;
                    }
                    return new DragonReal(x);
                }
                if (Char.IsLetter(Peek))
                {
                    StringBuilder Sb = new StringBuilder();
                    do
                    {
                        Sb.Append(Peek);
                        ReadChar();
                    }
                    while (Char.IsLetterOrDigit(Peek));
                    string s = Sb.ToString();
                    DragonWord w = (DragonWord)Words[s];
                    if (w != null)
                        return w;
                    w = new DragonWord(s, DragonTag.ID);
                    Words.Add(s, w);
                    return w;
                }
                DragonToken tok = new DragonToken(Peek);
                Peek = ' ';
                return tok;
            }
            catch
            {
                throw new IOException();
            }
        }
    }
}
