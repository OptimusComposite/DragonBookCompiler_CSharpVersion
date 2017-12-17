using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Inter;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Parser
{
    public class Parser
    {
        private Lexer.Lexer lex;
        private Token look;
        Symbols.Environment top = null;
        int used = 0;

        public Parser(Lexer.Lexer l)
        {
            lex = l;
        }

        void Move()
        {
            look = lex.Scan();
        }

        void Error(string s)
        {
            throw new Exception("Near line " + Lexer.Lexer.Line + ": " + s);
        }

        void Match(int t)
        {

        }

        public void Program()
        {

        }

        Statement GetBlock()
        {

        }

        void GetDecls()
        {

        }

        Symbols.Type GetType()
        {

        }

        Symbols.Type Dims()
        {

        }

        Statement GetStatements()
        {

        }

        Statement GetStatement()
        {

        }

        Statement Assign()
        {

        }

        Express GetBool()
        {

        }

        Express Join()
        {

        }

        Express Equals()
        {

        }

        Express GetRelation()
        {

        }

        Express GetExpress()
        {

        }

        Express GetTerm()
        {
            
        }

        Express GetUnary()
        {

        }

        Express GetFactor()
        {

        }

        Access Offset()
        {

        }
    }
}
