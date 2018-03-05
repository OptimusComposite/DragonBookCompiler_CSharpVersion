using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Parser;

namespace DragonBookCompilerFrontend_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DragonLexer lex = new DragonLexer();
            DragonParser par = new DragonParser(lex);
            par.Program();
        }
    }
}
