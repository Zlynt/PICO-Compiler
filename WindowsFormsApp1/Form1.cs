using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.calitha.commons;
using com.calitha.goldparser;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        String parseTree;
        MyParser parser;

        public Form1()
        {
            InitializeComponent();
            parser = new MyParser("Gramatica.cgt", error_listBox, c_code);

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void compileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            error_listBox.Items.Clear();
            c_code.Clear();
            parser.Parse(pico_code.Text);
        }

        private void compileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (isParsedWithSucess())
            {
                //Prepare for code compilation
                if (File.Exists(@".\output\compiled_app.c"))
                {
                    File.Delete(@".\output\compiled_app.c");
                }
                if (File.Exists(@".\output\compiled_app.exe"))
                {
                    File.Delete(@".\output\compiled_app.exe");
                }
                //Export the C Code
                c_code.SaveFile(".\\output\\compiled_app.c", RichTextBoxStreamType.PlainText);
                //Compile the C Code
                runCMD(".\\compile.bat");
                System.Windows.Forms.MessageBox.Show("Compiled!\r\nFile: output\\compiled_app.exe");
            }else
                System.Windows.Forms.MessageBox.Show("Please fix all the error(s) first and\r\nparse the code first!");
        }

        //Check if code is parsed with sucess
        private bool isParsedWithSucess()
        {
            if (error_listBox.Items.Count <= 0)
                return false;
            else
            if (String.Equals(error_listBox.Items[0].ToString(), "No errors found!"))
                return true;
            else
                return false;
        }


        //Run CMD Commands
        private void runCMD(string Command)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C "+Command;
            process.StartInfo = startInfo;
            process.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
