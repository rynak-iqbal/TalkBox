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
            //speech.SpeakAsyncCancelAll();
            ((Button)sender).BackColor = Color.White;
        }

        private void phrases_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Phrases Clicked");

            music1.Visible = false;
            sounds2.Visible = false;
            audioBook1.Visible = false;
            phrases1_fr.Visible = false;

            phrases1.Visible = true;
            phrases1.Select();
            Control firstControlWithTabIndex = FindControlByTabIndex(phrases1, 4);
            if (firstControlWithTabIndex != null)
            {
                firstControlWithTabIndex.Focus();
            }
        }
        private void Phrases_fr_button_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Phrases_fr Clicked");

            music1.Visible = false;
            sounds2.Visible = false;
            audioBook1.Visible = false;
            phrases1.Visible = false;

            phrases1_fr.Visible = true;
            phrases1_fr.Select();
            Control firstControlWithTabIndex = FindControlByTabIndex(phrases1_fr, 4);
            if (firstControlWithTabIndex != null)
            {
                firstControlWithTabIndex.Focus();
            }
        }

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
            phrases1.Visible = false;
            phrases1_fr.Visible = false;
            music1.Visible = false;
            sounds2.Visible = false;
            audioBook1.Visible = false;
        }

        private void phrases1_Load_1(object sender, EventArgs e)
        {

        }


        private void musicButton_click(object sender, EventArgs e)
        {
            music1.Visible = true;
            music1.BringToFront();

            music1.Select();
            Control firstControlWithTabIndex = FindControlByTabIndex(music1, 1);
            Console.WriteLine(firstControlWithTabIndex);
            if (firstControlWithTabIndex != null)
            {
                firstControlWithTabIndex.Focus();
            }

            phrases1.Visible = false;
            phrases1_fr.Visible = false;
            sounds2.Visible = false;
            audioBook1.Visible = false;
        }
        private void musicPage_Load_1(object sender, EventArgs e)
        {

        }

        private void audioBooks_Click(object sender, EventArgs e)
        {
            audioBook1.Visible = true;
            audioBook1.BringToFront();

            audioBook1.Select();
            Control firstControlWithTabIndex = FindControlByTabIndex(audioBook1, 1);
            if (firstControlWithTabIndex != null)
            {
                firstControlWithTabIndex.Focus();
            }

            phrases1.Visible = false;
            phrases1_fr.Visible = false;
            music1.Visible = false;
            sounds2.Visible = false;
        }

        private void sounds2_Load(object sender, EventArgs e)
        {

        }

        private void soundsButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Sounds button clicked");

            phrases1.Visible = false;
            phrases1_fr.Visible = false;
            music1.Visible = false;
            audioBook1.Visible = false;

            sounds2.Visible = true;
            sounds2.BringToFront();

            sounds2.Select();
            Control firstControlWithTabIndex = FindControlByTabIndex(sounds2, 1);
            if (firstControlWithTabIndex != null)
            {
                firstControlWithTabIndex.Focus();
            }


        }

        private void audioBooks1_Load(object sender, EventArgs e)
        {

        }

        public static void OpenPhrasesSub(string category, Form form)
        {
            Console.WriteLine(form);
            PhrasesSub phrasesSub = new PhrasesSub(category)
            {
                Location = new System.Drawing.Point(0, 0)
            };

            try
            {
                form.Controls.Add(phrasesSub);
                Console.WriteLine(category);
                phrasesSub.Visible = true;
                phrasesSub.BringToFront();
                phrasesSub.Select();
                foreach (Control control in phrasesSub.Controls)
                {
                    if (control.TabIndex == 20)
                    {
                        control.Focus();
                    }
                }
                Console.WriteLine("Phrases Sub reached");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        internal static void OpenPhrasesSub_fr(string category, Form form)
        {
            Console.WriteLine(form);
            PhrasesSub_fr phrasesSub_fr = new PhrasesSub_fr(category)
            {
                Location = new System.Drawing.Point(0, 0)
            };

            try
            {
                form.Controls.Add(phrasesSub_fr);
                Console.WriteLine(category);
                phrasesSub_fr.Visible = true;
                phrasesSub_fr.BringToFront();
                phrasesSub_fr.Select();
                foreach (Control control in phrasesSub_fr.Controls)
                {
                    if (control.TabIndex == 20)
                    {
                        control.Focus();
                    }
                }
                Console.WriteLine("Phrases Sub fr reached");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
