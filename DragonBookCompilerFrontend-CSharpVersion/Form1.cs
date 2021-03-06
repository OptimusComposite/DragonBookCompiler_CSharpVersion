﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DragonBookCompiler.Generic.Lexer;
using DragonBookCompiler.Generic.Parser;
using DragonBookCompiler.Generic.IO;

namespace DragonBookCompilerFrontend_CSharpVersion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputAndOutput.InputText = richTextBox1.Text;
            InputAndOutput.OutputText.Clear();
            InputAndOutput.ErrorText.Clear();
            DragonLexer lex = new DragonLexer();
            DragonParser par = new DragonParser(lex);
            par.Program();
            richTextBox2.Text = InputAndOutput.OutputText.ToString();
            richTextBox3.Text = InputAndOutput.ErrorText.ToString();
        }

        //private void PrintResult()
        //{
        //    DragonLexer lex = new DragonLexer();
        //    DragonParser parser = new DragonParser(lex);
        //    parser.Program();
        //}
    }
}
