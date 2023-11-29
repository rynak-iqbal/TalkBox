using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
//using Microsoft.Office.Interop.Excel;
using Button = System.Windows.Forms.Button;
using System.IO;
using System.Reflection;
using Point = System.Drawing.Point;
using System.Diagnostics;

namespace Winforms_Demo
{
    public partial class Phrases_fr : UserControl
    {

        private List<Button> categoryButtons = new List<Button>();
        private Form form;

        public Phrases_fr()
        {
            InitializeComponent();

            loadCategories();
            
            this.Load += Phrases_Load;

        }

        private void Phrases_Load(object sender, EventArgs e)
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
                    if (focusedControl.Name == "addCategory" || focusedControl.Name == "deleteCategory")
                    {
                        return true;
                    }
                    (focusedControl as Button).PerformClick();
                    return true;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void loadCategories()
        {
            string filePath = @"/home/pi/demo/Phrases_fr.txt";
            //string filePath = @"C:\TalkBox\Phrases.txt";


            // Clear existing buttons
            foreach (Button btn in categoryButtons)
            {
                this.Controls.Remove(btn);
            }

            categoryButtons.Clear();

            int tabIndex = 5;
            int btnHeight = 0;
            int btnNum = 0;




            List<string> categories = new List<string>();
            string[] lines = File.ReadAllLines(filePath, Encoding.GetEncoding("iso-8859-1"));

            try
            {
                Console.WriteLine("Reading txt file!");

                //for (int i = 0; i < categories.Count; i++)
                foreach (string line in lines)
                {
                    if (line.StartsWith("$"))
                    {
                        string category = line.Substring(1).Trim(); // get all categories, words that start with "$"
                        categories.Add(category);
                    }
                }
                for (int i = 0; i < categories.Count; i++)
                {
                    String btnText = categories[i];
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

                        btn.Click += new EventHandler(this.CatergoryClick);
                        btn.Enter += new EventHandler(this.hoverSpeak);
                        btn.Leave += new EventHandler(this.hoverLeave);
                        btn.Enter += new EventHandler(this.Control_Enter); // Subscribe to Control_Enter

                        this.Controls.Add(btn);
                        btnHeight = btnHeight + 59;
                        tabIndex++;
                        btnNum++;


                        categoryButtons.Add(btn);
                    }
                }

                Button addCategory = new Button();
                this.SuspendLayout();

                addCategory.Location = new Point(0, btnHeight);
                addCategory.Name = "addCategory";
                addCategory.Size = new Size(414, 59);
                addCategory.TabStop = false;
                addCategory.Text = "Add Category";
                addCategory.UseVisualStyleBackColor = true;

                addCategory.Click += new EventHandler(this.AddCategory);
                addCategory.Enter += new EventHandler(this.hoverSpeak);
                addCategory.Leave += new EventHandler(this.hoverLeave);
                addCategory.Enter += new EventHandler(this.Control_Enter); // Subscribe to Control_Enter


                this.Controls.Add(addCategory);
                btnHeight = btnHeight + 59;
                tabIndex++;
                btnNum++;



                Button deleteCategory = new Button();
                this.SuspendLayout();

                deleteCategory.Location = new Point(0, btnHeight);
                deleteCategory.Name = "deleteCategory";
                deleteCategory.Size = new Size(414, 59);
                deleteCategory.TabStop = false;
                deleteCategory.Text = "Delete Category";
                deleteCategory.UseVisualStyleBackColor = true;

                deleteCategory.Click += new EventHandler(this.DeleteCategory);
                deleteCategory.Enter += new EventHandler(this.hoverSpeak);
                deleteCategory.Leave += new EventHandler(this.hoverLeave);
                deleteCategory.Enter += new EventHandler(this.Control_Enter); // Subscribe to Control_Enter


                this.Controls.Add(deleteCategory);
                btnHeight = btnHeight + 59;
                tabIndex++;
                btnNum++;

                categoryButtons.Add(addCategory);
                categoryButtons.Add(deleteCategory);
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }


        }

        private void DeleteCategory(object sender, EventArgs e)
        {
            Console.WriteLine("Delete Category!");

            string filePath = @"/home/pi/demo/Phrases.txt";

            using (var form = new Form())
            {
                form.Text = "Delete Category";
                form.Size = new Size(300, 150);
                form.StartPosition = FormStartPosition.CenterParent;

                ComboBox deleteCategoryComboBox = new ComboBox
                {
                    Location = new Point(20, 20),
                    Size = new Size(200, 25),
                    TabIndex = 0,
                    DropDownStyle = ComboBoxStyle.DropDownList // Ensure the user can only select from the existing categories
                };

                deleteCategoryComboBox.Items.AddRange(categoryButtons
                    .Where(btn => btn.Name != "addCategory" && btn.Name != "deleteCategory")
                    .Select(btn => btn.Text.TrimStart('$'))
                    .ToArray());

                Button deleteButton = new Button
                {
                    Location = new Point(20, 60),
                    Size = new Size(100, 30),
                    TabIndex = 1,
                    Text = "Delete"
                };

                deleteButton.Click += (s, args) =>
                {
                    string selectedCategory = deleteCategoryComboBox.SelectedItem?.ToString();

                    if (!string.IsNullOrEmpty(selectedCategory))
                    {
                        Console.WriteLine($"Deleting category: {selectedCategory}");

                        try
                        {
                            List<string> lines = File.ReadAllLines(filePath).ToList();

                            int index = lines.FindIndex(line => line.TrimStart().Equals($"${selectedCategory}"));

                            if (index != -1)
                            {
                                lines.RemoveAt(index);

                                File.WriteAllLines(filePath, lines);

                                Console.WriteLine($"Category '{selectedCategory}' deleted from the file.");
                            }
                            else
                            {
                                Console.WriteLine($"Category '{selectedCategory}' not found in the file.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                    }
                    form.Close();
                };

                form.Controls.Add(deleteCategoryComboBox);
                form.Controls.Add(deleteButton);

                form.ShowDialog(this.ParentForm);
            }

            loadCategories();
        }

        private void AddCategory(object sender, EventArgs e)
        {
            Console.WriteLine("Add Category!");

            string filePath = @"/home/pi/demo/Phrases_fr.txt";
            //string filePath = @"C:\TalkBox\Phrases.txt";

            using (var form = new Form())
            {

                this.form = form; 

                form.Text = "Add Category";
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


                // when the user clicks add button
                addButton.Click += (s, args) =>
                {
                    string newCategory = textBox.Text.Trim();
                    if (!string.IsNullOrEmpty(newCategory))
                    {
                        Console.WriteLine($"New category added: {newCategory}");

                        try
                        {
                            // Open the file for appending
                            using (StreamWriter sw = File.AppendText(filePath))
                            {
                                // Append the new category with a "$" at the beginning
                                sw.WriteLine($"\n${newCategory}");
                                Console.WriteLine($"Category '{newCategory}' added to the file.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                    }
                    form.Close();
                };

                form.Controls.Add(textBox);
                form.Controls.Add(addButton);

                form.ShowDialog(this.ParentForm);
            }

            loadCategories();

        }

        

        // refocus index after returning from sub menu
        public void refocusIndex()
        {
            if (categoryButtons.Count > 0)
            {
                Button btn = categoryButtons[0];
                Console.WriteLine(btn.Text);
                this.BringToFront();
                btn.Select();
                btn.Focus();
            }


        }

        private void back_Click(object sender, EventArgs e)
        {
            //backClicked = true;
            this.Visible = false;
        }

        private void hoverSpeak(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "espeak"; // The command to run eSpeak
            startInfo.Arguments = $"-v fr \"{s}\""; // The text to be spoken
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

        private void CatergoryClick(object sender, EventArgs e)
        {

            if (sender is Button clickedButton)
            {

                string category = clickedButton.Text;
                Console.WriteLine(category);
                MainPage.OpenPhrasesSub_fr(category, this.ParentForm);
            }
        }

        private void Phrases_Load_2(object sender, EventArgs e)
        {

        }

    }
}
