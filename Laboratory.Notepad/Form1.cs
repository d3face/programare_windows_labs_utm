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

namespace Laboratory.Notepad
{
    public partial class Notepad42 : Form
    {
        private const RichTextBoxStreamType contentType = RichTextBoxStreamType.PlainText;
        private string _currentFileLocation = string.Empty;
        private bool _changed = false;
        public Notepad42()
        {
            InitializeComponent();
            this.richTextBox1.TextChanged += RichTextBox1_TextChanged;
            newToolStripMenuItem_Click(null, null);
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            Text = $"[Changed] {_currentFileLocation}";
            _changed = true;
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_changed)
            {
                var resr = MessageBox.Show("File was changed! changes will be lost?", "File", MessageBoxButtons.YesNo);
                if (resr == DialogResult.No)
                {
                    return;
                }
            }
            var res = this.openFileDialog1.ShowDialog();
            if (res != DialogResult.OK)
            {
                return;
            }
            _currentFileLocation = this.openFileDialog1.FileName;
            this.Text = $"[Opened] {_currentFileLocation}";
            _changed = false;
            this.richTextBox1.LoadFile(_currentFileLocation, contentType);
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!_changed)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(_currentFileLocation))
            {
                var res = this.saveFileDialog1.ShowDialog();
                if (res != DialogResult.OK)
                {
                    return;
                }
                _currentFileLocation = this.saveFileDialog1.FileName;
            }
            _changed = false;
            this.richTextBox1.SaveFile(_currentFileLocation, contentType);
            this.Text = $"[Saved] {_currentFileLocation}";
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_changed)
            {
                var res = MessageBox.Show("File was changed! changes will be lost?", "File", MessageBoxButtons.YesNo);
                if (res == DialogResult.No)
                {
                    return;
                }
            }
            _changed = false;
            _currentFileLocation = string.Empty;
            this.richTextBox1.ResetText();
            this.Text = $"[New] {_currentFileLocation}";
        }

        private void increaseSizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.ZoomFactor += 0.1f;
        }

        private void decreaseSizeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.richTextBox1.ZoomFactor -= 0.1f;
        }
    }
}
