using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Symbols;
using DragonBookCompiler.Generic.Lexer;

namespace DragonBookCompiler.Generic.Inter
{
    public class Logical : Express
    {
        public Express expr1, expr2;

        public Logical(DragonToken tok, Express x1, Express x2) : base(tok, null)
        {
            expr1 = x1;
            expr2 = x2;
            type = Check(expr1.type, expr2.type);
            if (type == null)
                PrintError("type error");
        }

        public DragonType Check(DragonType p1, DragonType p2)
        {
            if (p1 == Symbols.DragonType.Bool && p2 == Symbols.DragonType.Bool)
                return Symbols.DragonType.Bool;
            else
                return null;
        }

        public new Express Generate()
        {
            int f = NewLabel();
            int a = NewLabel();
            Temp t = new Temp(type);
            this.Jump(0, f);
            EmitStatement(t.ToString() + " = true");
            EmitStatement("Goto L" + a);
            EmitLabel(f);
            EmitStatement(t.ToString() + " = false");
            EmitLabel(a);
            return t;
        }

        public override string ToString()
        {
            return expr1.ToString() + " " + Op.ToString() + " " + expr2.ToString();
        }
    }
}
