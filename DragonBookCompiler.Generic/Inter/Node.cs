using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;

namespace DragonBookCompiler.Generic.Inter
{
    public class Node
    {
        int LexLine = 0;

        public Node()
        {
            LexLine = Lexer.Lexer.Line;
        }

        internal void Error(string s)
        {
            throw new Exception("Near line " + LexLine + ": " + s);
        }

        static int labels = 0;
        public int NewLabel()
        {
            return ++labels;
        }
        public string EmitLabel (int i)
        {
            return "L" + i + ": ";
        }
        public string Emit(string s)
        {
            return "\t" + s;
        }
    }
}
