using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;

namespace Notepad_Kuvaev.Model
{

    public class MyModel
    {
        private static string file = "";
        private static Lazy<PrintDocument> printDocument;
       
        public static void OpenFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult dr = openFileDialog1.ShowDialog();
            openFileDialog1.Filter = ".txt |*.txt";
            if (dr == DialogResult.OK)
            {
                StreamReader read = new StreamReader(openFileDialog1.FileName);
                read.Close();
                file = openFileDialog1.FileName;
            }
        }
        public static void SaveFile(RichTextBox richTextBox1)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(saveFileDialog1.FileName);
                write.Write(richTextBox1.Text);
                write.Close();
            }
            else
            {
                try
                {
                    StreamWriter write = new StreamWriter(saveFileDialog1.FileName);
                    write.Write(richTextBox1.Text);
                    write.Close();
                }
                catch { }
            }
        }
        public static void PrintFile()
        {
            PrintDialog printDialog1 = new PrintDialog();
            DialogResult dr = printDialog1.ShowDialog();
            if (dr == DialogResult.OK) { }
        }
        public static void Undo(RichTextBox richTextBox1)
        {
            if (richTextBox1.CanUndo == true)
            {
                richTextBox1.Undo();
            }
        }
        public static void Redo(RichTextBox richTextBox1)
        {
            if (richTextBox1.CanRedo == true)
            {
                richTextBox1.Redo();
            }
        }
        public static void Cut(RichTextBox richTextBox1)
        {
            if (richTextBox1.SelectedText != "")
            {
                richTextBox1.Cut();
            }
        }
        public static void Copy(RichTextBox richTextBox1)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }
        public static void Paste(RichTextBox richTextBox1)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                richTextBox1.Paste();
            }
        }
        public static void DateTimePrint(RichTextBox richTextBox1)
        {
            DateTime dt = DateTime.Now;
            richTextBox1.Text = dt.ToString();
        }
        public static void Font(RichTextBox richTextBox1)
        {
            FontDialog fontDialog1 = new FontDialog();
            DialogResult dr = fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }
        public static void DayTheme(RichTextBox richTextBox1)
        {
            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;

        }
        public static void NightTheme(RichTextBox richTextBox1)
        {
            richTextBox1.BackColor = Color.Black;
            richTextBox1.ForeColor = Color.White;
        }
        public static void PageParams()
        {
            PageSetupDialog pageSetupDialog = new PageSetupDialog
            {
                PageSettings = new PageSettings()
            };

            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
            {
                if (printDocument == null)
                {
                    printDocument = new Lazy<PrintDocument>();
                }

                printDocument.Value.DefaultPageSettings = pageSetupDialog.PageSettings;
                printDocument.Value.PrinterSettings = pageSetupDialog.PrinterSettings;
            }
        }
        public static void SaveAs(RichTextBox richTextBox1)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = ".txt|*.txt"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                file = saveFileDialog.FileName;
                File.WriteAllText(file, richTextBox1.Text, Encoding.Default);
            }
        }
    }
}
