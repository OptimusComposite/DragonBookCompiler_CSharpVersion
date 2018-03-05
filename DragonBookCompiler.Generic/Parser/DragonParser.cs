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

        public DragonParser(DragonLexer l)
        {
            lex = l;
            Move();
        }

        private Statement Assign()
        {
            Statement statement;
            DragonToken t = look;
            Match(DragonTag.ID);
            Id id = top.GetId(t);
            if(id == null)
            {
                PrintError(t.ToString() + " undeclared.");
            }
            if(look.tag == '=')
            {
                Move();
                statement = new Set(id, GetBoolExpress());
            }
            else
            {
                Access x = GetOffset(id);
                Match('=');
                statement = new SetElement(x, GetBoolExpress());
            }
            Match(';');
            return statement;
        }

        private void Declare()
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
        }

        private Statement GetBlock()
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

        private Express GetBoolExpress()
        {
            Express x = Join();
            while(look.tag == DragonTag.OR)
            {
                DragonToken tok = look;
                Move();
                x = new Or(tok, x, Join());
            }
            return x;
        }

        private DragonType GetDimensions(DragonType p)
        {
            Match('[');
            DragonToken tok = look;
            Match(DragonTag.NUM);
            Match(']');
            if(look.tag == '[')
            {
                p = GetDimensions(p);
            }
            return new DragonArray(((DragonNumber)tok).Value, p);
        }

        private Express GetEquality()
        {
            Express x = GetRelativity();
            while(look.tag == DragonTag.EQ || look.tag == DragonTag.NE)
            {
                DragonToken tok = look;
                Move();
                x = new Relation(tok, x, GetRelativity());
            }
            return x;
        }

        private void PrintError(string s)
        {
            throw new Exception("Near line: " + DragonLexer.Line + ": " + s);
        }

        private Express GetExpress()
        {
            Express x = GetTerm();
            while (look.tag == '+' || look.tag == '-')
            {
                DragonToken tok = look;
                Move();
                x = new Arith(tok, x, GetExpress());
            }
            return x;
        }

        private Express GetFactor()
        {
            Express x = null;
            switch (look.tag)
            {
                case '(':
                    Move();
                    x = GetBoolExpress();
                    Match(')');
                    return x;

                case DragonTag.NUM:
                    x = new Constant(look, DragonType.Int);
                    Move();
                    return x;

                case DragonTag.REAL:
                    x = new Constant(look, DragonType.Float);
                    Move();
                    return x;

                case DragonTag.TRUE:
                    x = Constant.True;
                    Move();
                    return x;

                case DragonTag.FALSE:
                    x = Constant.False;
                    Move();
                    return x;

                case DragonTag.ID:
                    string s = look.ToString();
                    Id id = top.GetId(look);
                    if(id == null)
                    {
                        PrintError(look.ToString() + " undeclared.");
                    }
                    Move();
                    if(look.tag != '[')
                    {
                        return id;
                    }
                    else
                    {
                        return GetOffset(id);
                    }

                default:
                    PrintError("Syntax error.");
                    return x;
            }
        }

        private Express GetRelativity()
        {
            Express x = GetExpress();
            switch (look.tag)
            {
                case '<':
                case '>':
                case DragonTag.LE:
                case DragonTag.GE:
                    DragonToken tok = look;
                    Move();
                    return new Relation(tok, x, GetExpress());
                default:
                    return x;
            }
        }

        private Statement GetSingleStatement()
        {
            Express x;
            //Statement s;
            Statement s1, s2;
            Statement savedStatement;

            switch (look.tag)
            {
                case ';':
                    Move();
                    return Statement.Nul;

                case DragonTag.IF:
                    Match(DragonTag.IF);
                    Match('(');
                    x = GetBoolExpress();
                    Match(')');
                    s1 = GetSingleStatement();
                    if (look.tag != DragonTag.ELSE)
                    {
                        return new If(x, s1);
                    }
                    Match(DragonTag.ELSE);
                    s2 = GetSingleStatement();
                    return new Else(x, s1, s2);

                case DragonTag.WHILE:
                    While whilenode = new While();
                    savedStatement = Statement.Enclosing;
                    Statement.Enclosing = whilenode;
                    Match(DragonTag.WHILE);
                    Match('(');
                    x = GetBoolExpress();
                    Match(')');
                    s1 = GetSingleStatement();
                    whilenode.Init(x, s1);
                    Statement.Enclosing = savedStatement;
                    return whilenode;

                case DragonTag.DO:
                    Do donode = new Do();
                    savedStatement = Statement.Enclosing;
                    Statement.Enclosing = donode;
                    Match(DragonTag.DO);
                    s1 = GetSingleStatement();
                    Match(DragonTag.WHILE);
                    Match('(');
                    x = GetBoolExpress();
                    Match(')');
                    Match(';');
                    donode.Init(s1, x);
                    Statement.Enclosing = savedStatement;
                    return donode;

                case DragonTag.BREAK:
                    Match(DragonTag.BREAK);
                    Match(';');
                    return new Break();

                case '{':
                    return GetBlock();

                default:
                    return Assign();
            }
        }

        private Statement GetStatements()
        {
            if(look.tag == '}')
            {
                return Statement.Nul;
            }
            else
            {
                return new Sequence(GetSingleStatement(), GetStatements());
            }
        }

        private Express GetTerm()
        {
            Express x = GetUnary();
            while(look.tag == '*' || look.tag == '/')
            {
                DragonToken tok = look;
                Move();
                x = new Arith(tok, x, GetUnary());
            }
            return x;
        }

        private Express GetUnary()
        {
            if(look.tag == '-')
            {
                Move();
                return new Unary(DragonWord.minus, GetUnary());
            }
            else if(look.tag == '!')
            {
                DragonToken tok = look;
                Move();
                return new Not(tok, GetUnary());
            }
            else
            {
                return GetFactor();
            }
        }

        private Express Join()
        {
            Express x = GetEquality();
            while(look.tag == DragonTag.AND)
            {
                DragonToken tok = look;
                Move();
                x = new And(tok, x, GetEquality());
            }
            return x;
        }

        private void Match(int t)
        {
            if (look.tag == t)
            {
                Move();
            }
            else
            {
                PrintError("Syntax error.");
            }
        }

        private void Move()
        {
            look = lex.Scan();
        }

        public void Program()
        {
            Statement s = GetBlock();
            int begin = s.NewLabel();
            int after = s.NewLabel();
            s.EmitLabel(begin);
            s.Generate(begin, after);
            s.EmitLabel(after);
        }

        private DragonType GetDragonType()
        {
            DragonType p = (DragonType)look;
            Match(DragonTag.BASIC);
            if(look.tag != '[')
            {
                return p;
            }
            else
            {
                return GetDimensions(p);
            }
        }

        private Access GetOffset(Id a)
        {
            Express i;
            Express w;
            Express t1, t2;
            Express loc;
            DragonType type = a.type;
            Match('[');
            i = GetBoolExpress();
            Match(']');
            type = ((DragonArray)type).of;
            w = new Constant(type.Width);
            t1 = new Arith(new DragonToken('*'), i, w);
            loc = t1;
            while(look.tag == '[')
            {
                Match('[');
                i = GetBoolExpress();
                Match(']');
                type = ((DragonArray)type).of;
                w = new Constant(type.Width);
                t1 = new Arith(new DragonToken('*'), i, w);
                t2 = new Arith(new DragonToken('+'), loc, t1);
                loc = t2;
            }
            return new Access(a, loc, type);
        }
    }
}
