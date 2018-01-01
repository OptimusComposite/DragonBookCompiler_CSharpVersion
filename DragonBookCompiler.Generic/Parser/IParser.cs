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
    interface IParser
    {
        void Move();
        void GetError();
        void Match();
        void Program();
        Statement GetBlock();
        void Declare();
        Symbols.Type GetType();
        Symbols.Type GetDimensions();
        Statement GetStatements();
        Statement GetSingleStatement();
        Statement Assign();
        Express GetBoolValue();
        Express Join();
        Express GetEquality();
        Express GetRelativity();
        Express GetExpress();
        Express GetTerm();
        Express GetUnary();
        Express GetFactor();
        Express GetOffset();
    }
}
