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

        private void lab1(object sender, EventArgs e) => StartLab();

        private void lab2(object sender, EventArgs e) => StartLab();

        private void lab3(object sender, EventArgs e) => StartLab();

        private void lab4(object sender, EventArgs e) => StartLab();

        private void lab5(object sender, EventArgs e) => StartLab();

        private void lab6(object sender, EventArgs e) => StartLab();
    }
}
