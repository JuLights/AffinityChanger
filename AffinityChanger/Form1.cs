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
        private IntPtr totalPCCore = (IntPtr)0;

        private IntPtr totalCSGOAffinity = (IntPtr)0; // allCore for real
        private IntPtr totalFaceitAffinity = (IntPtr)0; // allCore for real

        public Form1()
        {
            Process[] ProcCSGO = Process.GetProcessesByName("csgo");
            totalPCCore = ProcCSGO[0].ProcessorAffinity;

            InitializeComponent();
        }

        private void csgoCheck_CheckedChanged(object sender, EventArgs e)
        {
            var powershell = PowerShell.Create();
            Process[] ProcCSGO = Process.GetProcessesByName("csgo");

            if (ProcCSGO.Length != 0)
            {
                totalCSGOAffinity = ProcCSGO[0].ProcessorAffinity;
                IntPtr preferedCores = GetAllExceptFirstCore(totalCSGOAffinity);

                if (csgoCheck.Checked)
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
                    var setAffinity = $"$Process = Get-Process csgo; $Process.ProcessorAffinity={totalPCCore}";
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

            if(ProcFACEIT.Length != 0)
            {
                totalFaceitAffinity = ProcFACEIT[0].ProcessorAffinity;

                if (faceitCheck.Checked)
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
                    var setAffinity = $"$Process = Get-Process faceitclient; $Process.ProcessorAffinity={totalPCCore}";
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

        public IntPtr GetAllExceptFirstCore(IntPtr totalCore)
        {
            int totalAsDecimal = (int)totalCore;
            var hexVal = totalAsDecimal.ToString("X");
            var totalExceptFirstCore = hexVal.Remove(hexVal.Length - 1, 1) + "e";
            IntPtr allexceptFirst = new IntPtr(Convert.ToInt32(totalExceptFirstCore, 16));
            return allexceptFirst;
            
        }

    }
}
