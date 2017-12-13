﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DragonBookCompiler.Generic.Symbols;

namespace DragonBookCompiler.Generic.Inter
{ 
    public class Else : Statement
    {
        Express ex;
        Statement st1, st2;

        public Else(Express e, Statement s1, Statement s2)
        {
            ex = e;
            st1 = s1;
            st2 = s2;
            if (ex.type != Symbols.Type.Bool)
                ex.Error("Boolean required in if");
        }

        public new void Gen(int b, int a)
        {
            int label1 = NewLabel();
            int label2 = NewLabel();
            ex.Jump(0, label2);
            EmitLabel(label1);
            st1.Gen(label1, a);
            Emit("Goto L" + a);
            EmitLabel(label2);
            st2.Gen(label2, a);
        }
    }
}
