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
using System.Text.RegularExpressions;

namespace _20250102_exception
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string FilePath = @"C:\\Users\\dudwn\\Desktop\\스마트팩토리SW과정\\4주차\\input.txt";

            FileOpen(FilePath); // 파일열고, 예외처리

            string[] FileContentArray; // Out Array사용 전, 선언

            string[] inputLines = ReadTxtFile(FilePath, out FileContentArray); // Out Array로 파일 읽고 저장

            string[] extractedNumbers = new string[inputLines.Length];

            textBox.Text += "\r\n\r\n";


            // int인 숫자만 추출
            extractedNumbers = ExtractingNumbers(inputLines);

            for (int i = 0; i < extractedNumbers.Length; i++)
            {
                textBox.Text += extractedNumbers[i] + "\r\n";
            }




        }
        public string FileOpen(string filepath)
        {
            string content = "";
            try
            {
                content = File.ReadAllText(filepath);
                textBox.Text = content;
            }
            catch (FileNotFoundException)
            {
                textBox.Text = "찾는 파일이 없습니다.";
            }
            catch (Exception e)
            {
                textBox.Text = "Exception에러";
            }
            return content;
        }

        public string[] ReadTxtFile(string FilePath, out string[] InputTxTArray)
        {
            string content = File.ReadAllText(FilePath);
            int lineCount = 0;

            string[] TxtLines = File.ReadAllLines(FilePath);


            try
            {
                //string[] TxtLines = File.ReadAllLines(FilePath);
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

            return TxtLines;

        }
        public string[] ExtractingNumbers(string[] txtLines)
        {
            string[] extractedNumbers = new string[txtLines.Length];

            for (int i = 0; i < txtLines.Length; i++) // Txt파일의 라인수만큼 N번 반복
            {
                extractedNumbers[i] = Regex.Replace(txtLines[i], @"\D", "");
            }
            return extractedNumbers;
        }
    }
}
