using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Progress.Demo
{
    public partial class Form1 : Form
    {
        private readonly Progress<int> progress;

        public Form1()
        {
            InitializeComponent();

            progress = new Progress<int>();
            progress.ProgressChanged += i => progressBar1.Value = i;

            // For .Net Framework 4.5 above
            //progress.ProgressChanged += delegate(object sender, int i) { progressBar1.Value = i;};
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            DoSomeThing(progress);
        }

        private void DoSomeThing(IProgress<int> progress)
        {
            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    progress.Report(i);
                    Thread.Sleep(100);
                }

                progress.Report(0);
            });
        }
    }
}
