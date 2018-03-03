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
    public class DragonEnvironment
    {
        private Hashtable Table;
        protected DragonEnvironment Prev;

        public DragonEnvironment(DragonEnvironment n)
        {
            Table = new Hashtable();
            Prev = n;
        }

        public void Put(DragonToken t, Id i)
        {
            Table.Add(t, i);
        }

        public Id GetId(DragonToken t)
        {
            for (DragonEnvironment e = this; e != null; e = e.Prev)
            {
                Id found = (Id)(e.Table[t]);
                if (found != null)
                    return found;
            }
            return null;
        }
    }
}
