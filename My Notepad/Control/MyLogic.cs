using System.Windows.Forms;

namespace Notepad_Kuvaev.Logic
{
    public class MyLogic
    {
        public void NewWindow()
        {
            Notepad notepad = new Notepad();
            notepad.Show();
        }
        public void TextChanged(Notepad notepad, RichTextBox richTextBox1, 
                                ToolStripMenuItem undo, ToolStripMenuItem cut,
                                ToolStripMenuItem copy, ToolStripMenuItem paste,
                                ToolStripMenuItem delete, ToolStripMenuItem find,
                                ToolStripMenuItem font)
        {
            if (notepad.Text != "Блокнот" && notepad.Text[0] != '*')
            {
                string name = "*" + notepad.Text;
                notepad.Text = name;
            }

            if (notepad.Text != "")
            {
                undo.Enabled = true;
                cut.Enabled = true;
                copy.Enabled = true;
                paste.Enabled = true;
                delete.Enabled = true;
                find.Enabled = true;
                font.Enabled = true;
            }
            else
            {
                undo.Enabled = false;
                cut.Enabled = false;
                copy.Enabled = false;
                paste.Enabled = false;
                delete.Enabled = false;
                find.Enabled = false;
                font.Enabled = false;
            }
        }

        public void WordWrap(RichTextBox richTextBox1, ToolStripMenuItem goTo, ToolStripMenuItem wordWrap)
        {
            if (wordWrap.Checked == true)
            {
                wordWrap.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                goTo.Enabled = true;
                richTextBox1.WordWrap = false;
                wordWrap.Checked = false;
            }
            else if (wordWrap.Checked == false)
            {
                wordWrap.DisplayStyle = ToolStripItemDisplayStyle.Text;
                goTo.Enabled = false;
                richTextBox1.WordWrap = true;
                wordWrap.Checked = true;
            }
        }
    }
}
