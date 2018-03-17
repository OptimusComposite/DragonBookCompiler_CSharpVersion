using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonBookCompiler.Generic.IO
{
    public static class InputAndOutput
    {
        public static string InputText { get; set; }
        public static StringBuilder OutputText { get; internal set; }
        public static StringBuilder ErrorText { get; internal set; }

        static InputAndOutput()
        {
            InputText = String.Empty;
            OutputText = new StringBuilder(String.Empty);
            ErrorText = new StringBuilder(String.Empty);
        }
    }
}
