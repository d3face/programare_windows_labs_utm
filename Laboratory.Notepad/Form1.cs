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
        public Notepad42()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var res = this.openFileDialog1.ShowDialog();
            if (res != DialogResult.OK)
            {
                return;
            }
            _currentFileLocation = this.openFileDialog1.FileName;
            this.Text = $"[Opened] {_currentFileLocation}";
            this.richTextBox1.LoadFile(_currentFileLocation, contentType);
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentFileLocation))
            {
                var res = this.saveFileDialog1.ShowDialog();
                if (res != DialogResult.OK)
                {
                    return;
                }
                _currentFileLocation = this.saveFileDialog1.FileName;
            }
            this.richTextBox1.SaveFile(_currentFileLocation, contentType);
            this.Text = $"[Saved] {_currentFileLocation}";
        }
    }
}
