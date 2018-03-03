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
    public class DragonParser
    {
        private DragonLexer lex;
        private DragonToken look;
        DragonEnvironment top = null;
        int used = 0;

        public DragonParser(Lexer.DragonLexer l)
        {
            lex = l;
            Move();
        }

        public Statement Assign()
        {
            throw new NotImplementedException();
        }

        public void Declare()
        {
            while(look.tag == DragonTag.BASIC)
            {
                DragonType p = GetDragonType();
                DragonToken tok = look;
                Match(DragonTag.ID);
                Match(';');
                Id id = new Id((DragonWord)tok, p , used);
                top.Put(tok, id);
                used += p.Width;
            }
            throw new NotImplementedException();
        }

        public Statement GetBlock()
        {
            Match('{');
            DragonEnvironment savedEnv = top;
            top = new DragonEnvironment(top);
            Declare();
            Statement s = GetStatements();
            Match('}');
            top = savedEnv;
            return s;
        }

        public Express GetBoolValue()
        {
            throw new NotImplementedException();
        }

        public Symbols.DragonType GetDimensions()
        {
            throw new NotImplementedException();
        }

        public Express GetEquality()
        {
            throw new NotImplementedException();
        }

        public void PrintError(string s)
        {
            throw new Exception("Near line: " + lex.Line + ": " + s);
            throw new NotImplementedException();
        }

        public Express GetExpress()
        {
            throw new NotImplementedException();
        }

        public Express GetFactor()
        {
            throw new NotImplementedException();
        }

        public Express GetOffset()
        {
            throw new NotImplementedException();
        }

        public Express GetRelativity()
        {
            throw new NotImplementedException();
        }

        public Statement GetSingleStatement()
        {
            throw new NotImplementedException();
        }

        public Statement GetStatements()
        {
            throw new NotImplementedException();
        }

        public Express GetTerm()
        {
            throw new NotImplementedException();
        }

        public Express GetUnary()
        {
            throw new NotImplementedException();
        }

        public Express Join()
        {
            throw new NotImplementedException();
        }

        public void Match(int t)
        {
            if (look.tag == t)
            {
                Move();
            }
            else
            {
                PrintError("Syntax error.");
            }
            throw new NotImplementedException();
        }

        public void Move()
        {
            look = lex.Scan();
            throw new NotImplementedException();
        }

        public void Program()
        {
            throw new NotImplementedException();
        }

        DragonType GetDragonType()
        {
            throw new NotImplementedException();
        }

        public Express GetOffset(Id id)
        {
            throw new NotImplementedException();
        }
    }
}
