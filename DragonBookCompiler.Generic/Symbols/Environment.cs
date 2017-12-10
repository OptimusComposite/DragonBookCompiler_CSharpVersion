using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Inter;

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

        public void Put(Token t, Id i)
        {
            Table.Add(t, i);
        }

        public Id GetId(Token t)
        {
            for (Environment e = this; e != null; e = e.Prev)
            {
                Id found = (Id)(e.Table[t]);
                if (found != null)
                    return found;
            }
            return null;
        }
    }
}
