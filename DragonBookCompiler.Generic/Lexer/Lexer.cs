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

        public Token Scan()
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
                            return Word.and;
                        else
                            return new Token('&');
                    case '|':
                        if (ReadChar('|'))
                            return Word.or;
                        else
                            return new Token('|');
                    case '=':
                        if (ReadChar('='))
                            return Word.eq;
                        else
                            return new Token('=');
                    case '!':
                        if (ReadChar('='))
                            return Word.ne;
                        else
                            return new Token('!');
                    case '<':
                        if (ReadChar('='))
                            return Word.le;
                        else
                            return new Token('<');
                    case '>':
                        if (ReadChar('='))
                            return Word.ge;
                        else
                            return new Token('>');
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
                        return new Num(v);
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
                    return new Real(x);
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
                    Word w = (Word)Words[s];
                    if (w != null)
                        return w;
                    w = new Word(s, Tag.ID);
                    Words.Add(s, w);
                    return w;
                }
                Token tok = new Token(Peek);
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
