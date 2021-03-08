using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using Notepad_Kuvaev.Logic;
using Notepad_Kuvaev.Model;

namespace Notepad_Kuvaev
{
    public partial class Notepad : Form
    {
        MyLogic logic = new MyLogic();
        public Notepad()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.OpenFile();
        private void newToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Clear();
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Application.Exit();
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.SaveFile(richTextBox1);
        private void printToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.PrintFile();
        private void undoToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.Undo(richTextBox1);
        private void redoToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.Redo(richTextBox1);
        private void cutToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.Cut(richTextBox1);
        private void copyToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.Copy(richTextBox1);
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.Paste(richTextBox1);
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.SelectedText = "";
        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.Clear();
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.SelectAll();
        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.DateTimePrint(richTextBox1);
        private void fontToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.Font(richTextBox1);
        private void onToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.WordWrap = true;
        private void offToolStripMenuItem_Click(object sender, EventArgs e) => richTextBox1.WordWrap = false;
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) => MessageBox.Show("This version of the Notepad was created specifically for homework by Nikita Kuvaev, a student of the VBU911 group. Request to Ruslan Viktorovich to give a higher grade.", "About Notepad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        private void dayToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.DayTheme(richTextBox1);
        private void nightToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.NightTheme(richTextBox1);
        private void pageParamsToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.PageParams();
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) => MyModel.SaveAs(richTextBox1);

        private void Notepad_Load(object sender, EventArgs e)
        {

        }
    }
}
