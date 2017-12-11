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

        public Logical(Token tok, Express x1, Express x2) : base(tok, null)
        {
            expr1 = x1;
            expr2 = x2;
            type = check(expr1.type, expr2.type);
            if (type == null)
                Error("type error");
        }

        public Symbols.Type check(Symbols.Type p1, Symbols.Type p2)
        {
            if (p1 == Symbols.Type.Bool && p2 == Symbols.Type.Bool)
                return Symbols.Type.Bool;
            else
                return null;
        }

        public new Express Gen()
        {
            int f = NewLabel();
            int a = NewLabel();
            Temp t = new Temp(type);
            this.Jump(0, f);
            Emit(t.ToString() + " = true");
            Emit("Goto L" + a);
            EmitLabel(f);
            Emit(t.ToString() + " = false");
            EmitLabel(a);
            return t;
        }

        public override string ToString()
        {
            return expr1.ToString() + " " + Op.ToString() + " " + expr2.ToString();
        }
    }
}
