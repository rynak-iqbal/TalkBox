using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms_Demo
{
    public partial class AudioBook : UserControl
    {
        private static Process process;
        private bool playing = false;
        public AudioBook()
        {
            InitializeComponent();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    this.back_Click(this, EventArgs.Empty);
                    return true;
                case Keys.Right:
                    Console.WriteLine("Select");
                    Control focusedControl = this.ActiveControl;
                    (focusedControl as Button).PerformClick();
                    return true;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void hoverSpeak(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "espeak"; // The command to run eSpeak
            startInfo.Arguments = $"\"{s}\""; // The text to be spoken
            startInfo.UseShellExecute = false; // Do not use the shell execute process
            startInfo.CreateNoWindow = true; // Do not create a window

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit(); // Wait for the process to finish
            }


            ((Button)sender).BackColor = Color.Red;
        }
        private void hoverLeave(object sender, EventArgs e)
        {
            ((Button)sender).BackColor = Color.White;
        }

        private void back_Click(object sender, EventArgs e)
        {
            // Switch back to the Bluetooth sink
            SetDefaultSink("bluez_sink.88_C9_E8_49_FA_B1.headset_head_unit");
            SetVolume(50);
            if (playing)
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "pkill";
                    process.StartInfo.Arguments = "paplay";
                    process.Start();
                    process.WaitForExit();
                }
                
            }

            this.Visible = false;
        }
        private void SetVolume(int volumePercent)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "amixer",
                Arguments = $"set Master {volumePercent}%",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit();
            }
        }
        private void book_Click(object sender, EventArgs e)
        {
            playing = true;

            string filePath = "/home/pi/demo/goldilocks.wav";

            SetDefaultSink("alsa_output.platform-bcm2835_audio.analog-stereo"); // set audio to speakers

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "paplay",
                Arguments = filePath,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            process = new Process { StartInfo = startInfo };
            process.Start();

        }
        private void SetDefaultSink(string sinkName)
        {
            ProcessStartInfo setSinkStartInfo = new ProcessStartInfo();
            setSinkStartInfo.FileName = "pactl";
            setSinkStartInfo.Arguments = $"set-default-sink {sinkName}";
            setSinkStartInfo.UseShellExecute = false;
            setSinkStartInfo.CreateNoWindow = true;

            using (Process setSinkProcess = new Process())
            {
                setSinkProcess.StartInfo = setSinkStartInfo;
                setSinkProcess.Start();
                setSinkProcess.WaitForExit();
            }
        }
    }
}
