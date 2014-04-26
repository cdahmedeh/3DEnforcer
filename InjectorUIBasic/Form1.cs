using System;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using EasyHook;
using System.IO;
using InjectorLibrary;

namespace TestScreenshot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInject_Click(object sender, EventArgs e)
        {
            AttachProcess();
        }

        int processId = 0;
        Process _process;
        InjectorProcess _captureProcess;
        private void AttachProcess()
        {
            string exeName = Path.GetFileNameWithoutExtension(textBox1.Text);
            
            Process[] processes = Process.GetProcessesByName(exeName);
            foreach (Process process in processes)
            {
                processId = process.Id;
                _process = process;

                var captureInterface = new InjectorInterface();
                _captureProcess = new InjectorProcess(process, captureInterface);

                break;
            }
        }
    }
}
