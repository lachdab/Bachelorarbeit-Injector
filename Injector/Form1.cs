using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Injector
{
    public partial class Loader : Form
    {
        public String[] processGameData;
        public Loader()
        {
            InitializeComponent();
            
            processGameData = Find_Game();
            status.Text = "Status: " + processGameData[0];
            processId.Text = "Process ID: " + processGameData[1];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String injectionStatus = Injecting.InjectingDLLToGame(processGameData[1], "F:\\Bachelorarbeit\\Injector\\Injector\\bin\\x64\\Release\\Cheat.dll");
            label1.Text = injectionStatus;
            Application.Exit();
        }

        // Function that's checks if the game is started and returns the status if found + process ID
        private String[] Find_Game()
        {
            Process[] _process = null;
            _process = Process.GetProcessesByName("Bachelorarbeit");
            String[] process_status_data = new String[2];
            foreach (Process proc in _process)
            {
                if (proc != null)
                {
                    process_status_data[0] = "found";
                    process_status_data[1] = proc.Id.ToString();
                    return process_status_data;
                }   
            }
            return process_status_data;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
