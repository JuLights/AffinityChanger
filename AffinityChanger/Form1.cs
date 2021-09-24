using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Management.Automation;

namespace AffinityChanger
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void csgoCheck_CheckedChanged(object sender, EventArgs e)
        {
            var powershell = PowerShell.Create();
            Process[] ProcCSGO = Process.GetProcessesByName("csgo");


            IntPtr preferedCores = GetSystemCoreCount(false);  //for csgo every core except 0;
            IntPtr allCore = GetSystemCoreCount(true);  //for comparison

            if (ProcCSGO.Length != 0)
            {
                var getCSGOAffinity = $"Get-Process csgo | Select-Object ProcessorAffinity";
                
                powershell.Commands.AddScript(getCSGOAffinity);
                var csgo = powershell.Invoke();
                var csgoAffinityValue = (IntPtr)csgo[0].Members["ProcessorAffinity"].Value;

                if (csgoAffinityValue == allCore)
                {
                    var setAffinity = $"$Process = Get-Process csgo; $Process.ProcessorAffinity={preferedCores}";
                    powershell.Commands.AddScript(setAffinity);
                    powershell.Invoke();
                    var error = powershell.Streams.Error;
                    label1.ForeColor = Color.Green;
                    label1.Text = "GL";
                }
                else //revert
                {
                    var setAffinity = $"$Process = Get-Process csgo; $Process.ProcessorAffinity={allCore}";
                    powershell.Commands.AddScript(setAffinity);
                    powershell.Invoke();
                    var error = powershell.Streams.Error;
                    label1.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Make sure you started csgo", "Warning", MessageBoxButtons.OK);
                csgoCheck.Checked = false;
            }
        }

        private void faceitCheck_CheckedChanged(object sender, EventArgs e)
        {
            var powershell = PowerShell.Create();
            Process[] ProcFACEIT = Process.GetProcessesByName("faceitclient");
            
            IntPtr preferedCores = (IntPtr)0x1;  //for faceit only 0 core;
            IntPtr allCore = GetSystemCoreCount(true);

            if(ProcFACEIT.Length != 0)
            {
                var getFACEITAffinity = $"Get-Process faceitclient | Select-Object ProcessorAffinity";
                powershell.Commands.AddScript(getFACEITAffinity);

                var faceit = powershell.Invoke();
                var faceitAffinityValue = (IntPtr)faceit[0].Members["ProcessorAffinity"].Value;

                if (faceitAffinityValue == allCore)
                {
                    var setAffinity = $"$Process = Get-Process faceitclient; $Process.ProcessorAffinity={preferedCores}";
                    powershell.Commands.AddScript(setAffinity);
                    powershell.Invoke();
                    var error = powershell.Streams.Error;
                    label2.ForeColor = Color.Green;
                    label2.Text = "HF";
                }
                else //revert
                {
                    var setAffinity = $"$Process = Get-Process faceitclient; $Process.ProcessorAffinity={allCore}";
                    powershell.Commands.AddScript(setAffinity);
                    powershell.Invoke();

                    var error = powershell.Streams.Error;
                    label2.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Make sure you started faceit", "Warning", MessageBoxButtons.OK);
                faceitCheck.Checked = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //testing
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    using (Process chromeProcess = Process.GetProcessesByName("chrome")[0])
        //    {
        //        var aff = chromeProcess.ProcessorAffinity;
        //        chromeProcess.ProcessorAffinity = (IntPtr)7;
        //        var affNew = chromeProcess.ProcessorAffinity;
        //        var asd = affNew;

        //    }
        //}

        public IntPtr GetSystemCoreCount(bool AllCore)
        {
            var cpuCount = Environment.ProcessorCount;
            string totalLogicalProcessor = "0x";
            string totalExceptFirstCore = "0x";
            var fLimit = cpuCount / 4;

            for (int i = 0; i < fLimit; i++)
            {
                totalLogicalProcessor = totalLogicalProcessor + "f";
                if (fLimit - 1 == i)
                {
                    totalExceptFirstCore = totalLogicalProcessor.Remove(totalLogicalProcessor.Length - 1, 1) + "e";
                }
            }

            IntPtr allAffinity = new IntPtr(Convert.ToInt32(totalLogicalProcessor, 16));
            IntPtr allExceptFirst = new IntPtr(Convert.ToInt32(totalExceptFirstCore, 16));

            if (AllCore)
            {
                return allAffinity;
            }
            else
            {
                return allExceptFirst;
            }

        }

    }
}
