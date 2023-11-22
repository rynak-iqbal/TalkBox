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
using static System.Net.Mime.MediaTypeNames;


namespace Winforms_Demo
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
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
            //speech.Volume = 70;
            //speech.SpeakAsync(s);


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




        }
        private void hoverLeave(object sender, EventArgs e)
        {
            //speech.SpeakAsyncCancelAll();
        }

        //private void phrases_Click(object sender, EventArgs e)
        //{

        //    phrases2.Visible = true;
        //    phrases2.Select();
        //    Control firstControlWithTabIndex = FindControlByTabIndex(phrases2, 4);
        //    if (firstControlWithTabIndex != null)
        //    {
        //        firstControlWithTabIndex.Focus();
        //    }
        //}

        private Control FindControlByTabIndex(Control container, int tabIndex)
        {
            foreach (Control control in container.Controls)
            {
                if (control.TabIndex == tabIndex)
                {
                    return control;
                }
            }
            return null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //phrases2.Visible = false;
            //music1.Visible = false;
            //sounds1.Visible = false;
            //audioBooks1.Visible = false;
        }

        //public static void OpenPhrasesSub(string category, Form form)
        //{
        //    Console.WriteLine(form);
        //    PhrasesSubMenu phrasesSub = new PhrasesSubMenu(category)
        //    {
        //        Location = new System.Drawing.Point(0, 0)
        //    };

        //    try
        //    {
        //        form.Controls.Add(phrasesSub);
        //        Console.WriteLine(category);
        //        phrasesSub.Visible = true;
        //        phrasesSub.BringToFront();
        //        phrasesSub.Select();
        //        foreach (Control control in phrasesSub.Controls)
        //        {
        //            if (control.TabIndex == 20)
        //            {
        //                control.Focus();
        //            }
        //        }
        //        Console.WriteLine("Phrases Sub reached");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }

        //}

        private void phrases1_Load_1(object sender, EventArgs e)
        {

        }


        //private void musicButton_click(object sender, EventArgs e)
        //{
        //    music1.Visible = true;
        //    music1.BringToFront();

        //    music1.Select();
        //    Control firstControlWithTabIndex = FindControlByTabIndex(music1, 1);
        //    if (firstControlWithTabIndex != null)
        //    {
        //        firstControlWithTabIndex.Focus();
        //    }

        //    phrases2.Visible = false;
        //    sounds1.Visible = false;
        //    audioBooks1.Visible = false;
        //}
        private void musicPage_Load_1(object sender, EventArgs e)
        {

        }

        //private void audioBooks_Click(object sender, EventArgs e)
        //{
        //    audioBooks1.Visible = true;
        //    audioBooks1.BringToFront();

        //    audioBooks1.Select();
        //    Control firstControlWithTabIndex = FindControlByTabIndex(audioBooks1, 1);
        //    if (firstControlWithTabIndex != null)
        //    {
        //        firstControlWithTabIndex.Focus();
        //    }

        //    phrases2.Visible = false;
        //    music1.Visible = false;
        //    sounds1.Visible = false;
        //}

        private void sounds1_Load(object sender, EventArgs e)
        {

        }

        //private void soundsButton_Click(object sender, EventArgs e)
        //{
        //    sounds1.Visible = true;
        //    sounds1.BringToFront();

        //    sounds1.Select();
        //    Control firstControlWithTabIndex = FindControlByTabIndex(sounds1, 1);
        //    if (firstControlWithTabIndex != null)
        //    {
        //        firstControlWithTabIndex.Focus();
        //    }

        //    phrases2.Visible = false;
        //    music1.Visible = false;
        //    audioBooks1.Visible = false;
        //}

        private void audioBooks1_Load(object sender, EventArgs e)
        {

        }
    }
}
