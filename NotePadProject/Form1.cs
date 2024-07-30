namespace NotePadProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string path = string.Empty;

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Documents(*.txt)|*.txt|All Files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                File.WriteAllText(path, textBox1.Text);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(path))
            {
                File.WriteAllText(path, textBox1.Text);
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFileDialog1.FileName);
                path = openFileDialog1.FileName;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                DialogResult dr = MessageBox.Show("do you want to save current file?", "NotePad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    saveToolStripMenuItem_Click(sender, e);
                    textBox1.Text = string.Empty;
                    path = string.Empty;
                }
                if (dr == DialogResult.No)
                {
                    textBox1.Text = string.Empty;
                    path = string.Empty;
                }
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectedText = string.Empty;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked)
            {
                textBox1.WordWrap = true;
                textBox1.ScrollBars = ScrollBars.Horizontal;
                wordWrapToolStripMenuItem.Checked = false;
            }
            else
            {
                textBox1.WordWrap = false;
                textBox1.ScrollBars = ScrollBars.Vertical;
                wordWrapToolStripMenuItem.Checked = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = new Font(fontDialog1.Font, fontDialog1.Font.Style);
                textBox1.ForeColor = fontDialog1.Color;
            }
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.White;
            textBox1.BackColor = Color.Black;
        }

        private void greyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.White;
            textBox1.BackColor = Color.Gray;
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.Black;
            textBox1.BackColor = Color.White;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Our Notepad App", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString(textBox1.Text, textBox1.Font, Brushes.Black, 12, 10);
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }
    }
}
