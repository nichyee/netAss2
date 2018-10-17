using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateFontSizes();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveFile("Save");
        }
        
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            saveFile("Save As");
        }

        private void boldToolStripButton_Click(object sender, EventArgs e)
        {
            Font BoldFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.SizeInPoints, FontStyle.Bold);
            Font RegularFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.SizeInPoints, FontStyle.Regular);

            if (richTextBox1.SelectionFont.Bold)
            {
                richTextBox1.SelectionFont = RegularFont;
            }
            else
            {
                richTextBox1.SelectionFont = BoldFont;
            }
        }

        private void italicsToolStripButton_Click(object sender, EventArgs e)
        {
            Font ItalicFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.SizeInPoints, FontStyle.Italic);
            Font RegularFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.SizeInPoints, FontStyle.Regular);

            if (richTextBox1.SelectionFont.Italic)
            {
                richTextBox1.SelectionFont = RegularFont;
            }
            else
            {
                richTextBox1.SelectionFont = ItalicFont;
            }
        }

        private void underlineToolStripButon_Click(object sender, EventArgs e)
        {
            Font UnderlineFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.SizeInPoints, FontStyle.Underline);
            Font RegularFont = new Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.SizeInPoints, FontStyle.Regular);

            if (richTextBox1.SelectionFont.Underline)
            {
                richTextBox1.SelectionFont = RegularFont;
            }
            else
            {
                richTextBox1.SelectionFont = UnderlineFont;
            }
        }

        private void PopulateFontSizes()
        {
            for (int i = 8; i <= 20; i++)
            {
                textSizeToolStipTextBox.Items.Add(i);
            }

            textSizeToolStipTextBox.SelectedIndex = 11;
        }

        private void textSizeToolStipTextBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            float NewSize;

            float.TryParse(textSizeToolStipTextBox.SelectedItem.ToString(), out NewSize);

            Font NewFont = new Font(richTextBox1.SelectionFont.Name, NewSize, richTextBox1.SelectionFont.Style);

            richTextBox1.SelectionFont = NewFont;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void newFile()
        {
            richTextBox1.Text = "";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFile();
        }

        private void saveFile(String title)
        {
            saveFileDialog1.Filter = "Rich Text Format|*.rtf";
            saveFileDialog1.Title = title;

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) //Check if it's all ok  
            {
                if (saveFileDialog1.FileName.Length > 0) //Check for a valid name
                {
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void openFile()
        {
            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Open";

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile("Save");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile("Save As");
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
    }
}
