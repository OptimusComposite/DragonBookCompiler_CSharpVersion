using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DragonBookCompiler.Generic.Lexer;

namespace DragonBookCompiler.Generic.Symbols
{
    public class Environment
    {
        private Hashtable Table;
        protected Environment Prev;

        public Environment(Environment n)
        {
            Table = new Hashtable();
            Prev = n;
        }

        //public void AddToTable(Token t, Id i)
        //{

        //}
    }
}
