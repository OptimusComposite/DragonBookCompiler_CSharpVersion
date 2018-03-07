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

        internal Node()
        {
            LexLine = DragonLexer.Line;
        }

        internal void PrintError(string s)
        {
            //throw new Exception("Near line " + LexLine + ": " + s);
            Console.WriteLine("Near line " + LexLine + ": " + s);
        }

        static int labels = 0;

        public int NewLabel()
        {
            return ++labels;
        }

        public void EmitLabel (int i)
        {
            Console.WriteLine( "L" + i + ": ");
        }

        public void EmitStatement(string s)
        {
            Console.WriteLine("\t" + s);
        }
    }
}
