using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace _20250102_excpation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string FilePath = @"C:\\Users\\dudwn\\Desktop\\스마트팩토리SW과정\\4주차\\input.txt";

            string[] FileContentArray;


            ReadTxtFile(FilePath, out FileContentArray);



        }

        public void ReadTxtFile(string FilePath, out string[] InputTxTArray)
        {
            string content = File.ReadAllText(FilePath);
            int lineCount = 0;

            try
            {
                string[] TxtLines = File.ReadAllLines(FilePath);
                lineCount = TxtLines.Length;
            }

            catch (IOException ex)
            {
                textBox.Text = "오류발생!";
            }
            finally
            {
                InputTxTArray = new string[lineCount];
            }
        }
    }
}
