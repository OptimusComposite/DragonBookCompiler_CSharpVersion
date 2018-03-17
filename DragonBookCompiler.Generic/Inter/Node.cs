using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.IO;

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
            //Console.WriteLine("Near line " + LexLine + ": " + s);
            InputAndOutput.ErrorText.Append("Near line " + LexLine + ": " + s);
            InputAndOutput.ErrorText.AppendLine();
        }

        static int labels = 0;

        public int NewLabel()
        {
            return ++labels;
        }

        public void EmitLabel (int i)
        {
            //Console.WriteLine( "L" + i + ": ");
            InputAndOutput.OutputText.Append("L" + i + ": ");
            InputAndOutput.OutputText.AppendLine();
        }

        public void EmitStatement(string s)
        {
            //Console.WriteLine("\t" + s);
            InputAndOutput.OutputText.Append("\t" + s);
            InputAndOutput.OutputText.AppendLine();
        }
    }
}
