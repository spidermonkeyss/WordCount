//Word Count - Count number of words from text file
using System;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            string fileContent = "";
            int numOfWords = 0;

            OpenFileDialog fileDialog = new OpenFileDialog
            {
                //InitialDirectory = "c:\\";
                Title = "File To Count",
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = fileDialog.FileName;
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        fileContent = sr.ReadToEnd();
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }

            bool inWord = false;
            for (int i = 0; i < fileContent.Length; i++)
            {
                if (!Char.IsWhiteSpace(fileContent[i]) && !inWord)
                {
                    inWord = true;
                    numOfWords++;
                }
                if (Char.IsWhiteSpace(fileContent[i]))
                    inWord = false;
            }
            Console.WriteLine("Number of words:" + numOfWords);
        }
    }
}
