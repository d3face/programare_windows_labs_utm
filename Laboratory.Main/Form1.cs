using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratory.Main
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void StartLab([CallerMemberName] string callerName = "")
        {
            LaboratoryReferences.Run(callerName);
        }

        private void start_lab1_Click(object sender, EventArgs e) => StartLab();

        private void start_lab2_Click(object sender, EventArgs e) => StartLab();

        private void start_lab3_Click(object sender, EventArgs e) => StartLab();

        private void start_lab4_Click(object sender, EventArgs e) => StartLab();

        private void start_lab5_Click(object sender, EventArgs e) => StartLab();

        private void start_lab6_Click(object sender, EventArgs e) => StartLab();
    }
}
