using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Generic.Inter
{
    interface IOperation
    {
        Express Gen();
        string ToString();
    }
}
