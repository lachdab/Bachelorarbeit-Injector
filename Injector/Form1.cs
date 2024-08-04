using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Injector
{
    public partial class Loader : Form
    {
        public string[] processGameData;
        public Loader()
        {
            InitializeComponent();
            
            status.Text = "Status: not found";
            processId.Text = "Process ID: not found";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Process gameProcess = Process.Start("F:\\Bachelorarbeit\\BuildGame2.0\\Bachelorarbeit2.0.exe");
                status.Text = "Status: game is starting";
                await Task.Delay(10000); // 10sek

                processGameData = Find_Game();
                if (processGameData[0] == "found")
                {
                    status.Text = "Status: " + processGameData[0];
                    processId.Text = "Process ID: " + processGameData[1];

                    string injectionStatus = Injecting.InjectingDLLToGame(processGameData[1], "F:\\Bachelorarbeit\\Injector\\Injector\\bin\\x64\\Release\\Cheat.dll");
                    label1.Text = injectionStatus;
                    Application.Exit();
                }
                else
                {
                    label1.Text = "Failed to find the game process";
                }
            }
            catch(Exception ex) {
                label1.Text = "Error: " + ex.Message;
            }
        }

        // Function that's checks if the game is started and returns the status if found + process ID
        private string[] Find_Game()
        {
            Process[] _process = Process.GetProcessesByName("Bachelorarbeit2.0");
            string[] process_status_data = new string[2];
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
