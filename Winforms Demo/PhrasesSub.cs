using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Button = System.Windows.Forms.Button;
using Point = System.Drawing.Point;

namespace Winforms_Demo
{
    public partial class PhrasesSub : UserControl
    {
        String category;
        private Phrases phrasesPage = MainPage.phrases1;
        private List<Button> phrasesButtons = new List<Button>();
        public PhrasesSub(String category)
        {
            this.category = category;
            InitializeComponent();
            loadSub(category);
            this.Load += PhrasesSubMenu_Load;
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

                    if (focusedControl.Name == "addPhrase" || focusedControl.Name == "deletePhrase")
                    {
                        return true;
                    }

                    (focusedControl as Button).PerformClick();
                    return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void PhrasesSubMenu_Load(object sender, EventArgs e)
        {
            SubscribeToEnterEvent(this);
        }
        public void SubscribeToEnterEvent(Control container)
        {
            foreach (Control control in container.Controls)
            {
                control.Enter += Control_Enter;

                // If the control is a container, recursively subscribe to its child controls
                if (control.HasChildren)
                {
                    SubscribeToEnterEvent(control);
                }
            }
        }

        private void Control_Enter(object sender, EventArgs e)
        {
            Console.WriteLine($"Tab index changed for: {((Control)sender).TabIndex}");

            Control btn = sender as Control;
            int index = btn.TabIndex;

            if (btn != null)
            {
                // Calculate the Y-coordinate to bring the control into view
                int newY = btn.Location.Y - AutoScrollPosition.Y;

                // Determine the maximum visible area
                int maxVisibleY = ClientSize.Height - btn.Height;

                // If the button is out of the max screen size, move all buttons up
                if (newY < 0 || newY > maxVisibleY)
                {
                    // Calculate adjustment value for button movement
                    int adjustment = newY < 0 ? -newY : maxVisibleY - newY;

                    // Move each button in the form by the adjustment value - simulate scroll
                    foreach (Control control in Controls)
                    {
                        control.Location = new Point(control.Location.X, control.Location.Y + adjustment);
                    }
                }
            }

        }
        private void clickSpeak(object sender, EventArgs e)
        {
            Console.WriteLine("clickSpeak");
            string s = (sender as Button).Text;

            // Create a temporary WAV file for the espeak output
            string tempWavFile = "/tmp/espeak_output.wav";

            // Set the default sink to the audio jack
            SetDefaultSink("alsa_output.platform-bcm2835_audio.analog-stereo");


            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "espeak"; // The command to run eSpeak
            startInfo.Arguments = $"-w {tempWavFile} \"{s}\""; // The text to be spoken
            startInfo.UseShellExecute = false; // Do not use the shell execute process
            startInfo.CreateNoWindow = true; // Do not create a window

            using (Process process = new Process())
            {
                process.StartInfo = startInfo;
                process.Start();
                process.WaitForExit(); // Wait for the process to finish
            }

            // Play the generated WAV file through PulseAudio
            ProcessStartInfo paplayStartInfo = new ProcessStartInfo();
            paplayStartInfo.FileName = "paplay";
            paplayStartInfo.Arguments = tempWavFile;
            paplayStartInfo.UseShellExecute = false;
            paplayStartInfo.CreateNoWindow = true;

            using (Process paplayProcess = new Process())
            {
                paplayProcess.StartInfo = paplayStartInfo;
                paplayProcess.Start();
                paplayProcess.WaitForExit();
            }

            // Delete the temporary WAV file
            File.Delete(tempWavFile);

            // Switch back to the Bluetooth sink
            SetDefaultSink("bluez_sink.88_C9_E8_49_FA_B1.headset_head_unit");
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

        private void back_Click(object sender, EventArgs e)
        {
            //backClicked = true;
            this.Visible = false;
            phrasesPage.refocusIndex();


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

        private void loadSub(String category)
        {
            Console.WriteLine("Loading " + category + "!");

            // Clear existing buttons
            foreach (Button btn in phrasesButtons)
            {
                this.Controls.Remove(btn);
            }

            phrasesButtons.Clear();


            int tabIndex = 20;
            int btnHeight = 0;
            int btnNum = 0;
            int numButtons = 0; // count buttons to see if category is empty

            string filePath = @"/home/pi/demo/Phrases.txt";
            //string filePath = @"C:\TalkBox\Phrases.txt";



            List<string> phrases = new List<string>();
            string[] lines = File.ReadAllLines(filePath);
            string[] phraseSplit = new string[2];


            try
            {
                Console.WriteLine("Reading txt file!");

                //for (int i = 0; i < categories.Count; i++)
                foreach (string line in lines)
                {
                    if (!line.StartsWith("$"))
                    {
                        phraseSplit = line.Split(':');

                        if (phraseSplit[1] == category) // check if correct category
                        {
                            Console.WriteLine(phraseSplit[1]);
                            phrases.Add(phraseSplit[0]);
                            Console.WriteLine("Phrase: " + phraseSplit[0]);
                        }
                    }
                }
                Console.WriteLine("Count: " + phrases.Count);
                for (int i = 0; i < phrases.Count; i++)
                {
                    String btnText = phrases[i];
                    Console.WriteLine(btnText);
                    if (!String.IsNullOrEmpty(btnText))
                    {
                        String name = "btn" + btnNum;
                        Button btn = new Button();
                        this.SuspendLayout();

                        btn.Location = new Point(0, btnHeight);
                        btn.Name = name;
                        btn.Size = new Size(414, 59);
                        btn.TabIndex = tabIndex;
                        btn.Text = btnText;
                        btn.UseVisualStyleBackColor = true;

                        btn.Click += new EventHandler(this.clickSpeak);
                        btn.Enter += new EventHandler(this.hoverSpeak);
                        btn.Leave += new EventHandler(this.hoverLeave);
                        btn.Enter += new EventHandler(this.Control_Enter); // Subscribe to Control_Enter

                        this.Controls.Add(btn);
                        btnHeight = btnHeight + 59;
                        tabIndex++;
                        btnNum++;

                        numButtons++;

                        phrasesButtons.Add(btn);

                    }

                }
                Button addPhrase = new Button();
                this.SuspendLayout();

                addPhrase.Location = new Point(0, btnHeight);
                addPhrase.Name = "addPhrase";
                addPhrase.Size = new Size(414, 59);
                addPhrase.TabStop = false;
                addPhrase.Text = "Add Phrase";
                addPhrase.UseVisualStyleBackColor = true;

                addPhrase.Click += new EventHandler(this.AddPhrase);
                addPhrase.Enter += new EventHandler(this.hoverSpeak);
                addPhrase.Leave += new EventHandler(this.hoverLeave);
                addPhrase.Enter += new EventHandler(this.Control_Enter); // Subscribe to Control_Enter


                this.Controls.Add(addPhrase);
                btnHeight = btnHeight + 59;
                tabIndex++;
                btnNum++;

                Button deletePhrase = new Button();
                this.SuspendLayout();

                deletePhrase.Location = new Point(0, btnHeight);
                deletePhrase.Name = "deletePhrase";
                deletePhrase.Size = new Size(414, 59);
                deletePhrase.TabStop = false;
                deletePhrase.Text = "Delete Phrase";
                deletePhrase.UseVisualStyleBackColor = true;

                deletePhrase.Click += new EventHandler(this.DeletePhrase);
                deletePhrase.Enter += new EventHandler(this.hoverSpeak);
                deletePhrase.Leave += new EventHandler(this.hoverLeave);
                deletePhrase.Enter += new EventHandler(this.Control_Enter); // Subscribe to Control_Enter


                this.Controls.Add(deletePhrase);
                btnHeight = btnHeight + 59;
                tabIndex++;
                btnNum++;

                phrasesButtons.Add(addPhrase);
                phrasesButtons.Add(deletePhrase);

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while reading the file: {e.Message}");
            }


        }

        private void DeletePhrase(object sender, EventArgs e)
        {
            Console.WriteLine("Delete Phrase!");

            using (var form = new Form())
            {
                form.Text = "Delete Phrase";
                form.Size = new Size(300, 150);
                form.StartPosition = FormStartPosition.CenterParent;

                ComboBox deletePhraseComboBox = new ComboBox
                {
                    Location = new Point(20, 20),
                    Size = new Size(200, 25),
                    TabIndex = 0,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };

                deletePhraseComboBox.Items.AddRange(phrasesButtons.Where(btn => btn.Name != "addPhrase" && btn.Name != "deletePhrase").Select(btn => btn.Text).ToArray());

                Button deleteButton = new Button
                {
                    Location = new Point(20, 60),
                    Size = new Size(100, 30),
                    TabIndex = 1,
                    Text = "Delete"
                };

                deleteButton.Click += (s, args) =>
                {
                    string selectedPhrase = deletePhraseComboBox.SelectedItem?.ToString();

                    if (!string.IsNullOrEmpty(selectedPhrase))
                    {
                        Console.WriteLine($"Deleting phrase: {selectedPhrase}");

                        try
                        {
                            string filePath = @"/home/pi/demo/Phrases.txt";
                            string[] lines = File.ReadAllLines(filePath);

                            int index = Array.FindIndex(lines, line => line == $"{selectedPhrase}:{category}");

                            if (index != -1)
                            {
                                List<string> updatedLines = lines.ToList();
                                updatedLines.RemoveAt(index);

                                File.WriteAllLines(filePath, updatedLines);

                                Console.WriteLine($"Phrase '{selectedPhrase}' deleted from the file.");
                            }
                            else
                            {
                                Console.WriteLine($"Phrase '{selectedPhrase}' not found in the file.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                    }
                    form.Close();
                    loadSub(category);
                };

                form.Controls.Add(deletePhraseComboBox);
                form.Controls.Add(deleteButton);

                form.ShowDialog(this.ParentForm);
            }
        }

        private void AddPhrase(object sender, EventArgs e)
        {
            Console.WriteLine("Add Phrase!");

            using (var form = new Form())
            {
                form.Text = "Add Phrase";
                form.Size = new Size(300, 150);
                form.StartPosition = FormStartPosition.CenterParent;

                TextBox textBox = new TextBox
                {
                    Location = new Point(20, 20),
                    Size = new Size(200, 25),
                    TabIndex = 0
                };

                Button addButton = new Button
                {
                    Location = new Point(20, 60),
                    Size = new Size(100, 30),
                    TabIndex = 1,
                    Text = "Add"
                };

                string filePath = @"/home/pi/demo/Phrases.txt";


                // when the user clicks add button
                addButton.Click += (s, args) =>
                {
                    string newPhrase = textBox.Text.Trim();
                    if (!string.IsNullOrEmpty(newPhrase))
                    {
                        Console.WriteLine($"New phrase added: {newPhrase}");

                        try
                        {
                            
                            string[] lines = File.ReadAllLines(filePath); // array of all lines
                                                                          
                            int insertIndex = Array.FindIndex(lines, line => line.StartsWith("$")); // Getgs index of the first category

                            if (insertIndex != -1)
                            {
                                List<string> updatedLines = new List<string>();
                                updatedLines.AddRange(lines);
                                updatedLines.Insert(insertIndex, $"{newPhrase}:{category}");

                                // Write the modified lines back to the file
                                File.WriteAllLines(filePath, updatedLines);

                                Console.WriteLine($"Phrase '{newPhrase}' added to the file.");
                            }
                            else
                            {
                                Console.WriteLine("No lines starting with '$' found in the file.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                    }
                    form.Close();
                    loadSub(category);
                };

                form.Controls.Add(textBox);
                form.Controls.Add(addButton);

                form.ShowDialog(this.ParentForm);
            }
            

        }

    }
}
