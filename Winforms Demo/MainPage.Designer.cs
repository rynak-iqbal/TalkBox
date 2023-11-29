using System;

namespace Winforms_Demo
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.phrases_button = new System.Windows.Forms.Button();
            this.sounds_button = new System.Windows.Forms.Button();
            this.music_button = new System.Windows.Forms.Button();
            this.audiobooks_button = new System.Windows.Forms.Button();
            this.Phrases_fr_button = new System.Windows.Forms.Button();
            phrases1 = new Winforms_Demo.Phrases();
            this.sounds2 = new Winforms_Demo.Sounds();
            this.audioBook1 = new Winforms_Demo.AudioBook();
            this.music1 = new Winforms_Demo.Music();
            phrases1_fr = new Winforms_Demo.Phrases_fr();
            this.SuspendLayout();
            // 
            // phrases_button
            // 
            this.phrases_button.Location = new System.Drawing.Point(0, 0);
            this.phrases_button.Name = "phrases_button";
            this.phrases_button.Size = new System.Drawing.Size(414, 47);
            this.phrases_button.TabIndex = 0;
            this.phrases_button.Text = "Phrases English";
            this.phrases_button.UseVisualStyleBackColor = true;
            this.phrases_button.Click += new System.EventHandler(this.phrases_Click);
            this.phrases_button.Enter += new System.EventHandler(this.hoverSpeak);
            this.phrases_button.Leave += new System.EventHandler(this.hoverLeave);
            // 
            // sounds_button
            // 
            this.sounds_button.Location = new System.Drawing.Point(0, 94);
            this.sounds_button.Name = "sounds_button";
            this.sounds_button.Size = new System.Drawing.Size(414, 47);
            this.sounds_button.TabIndex = 2;
            this.sounds_button.Text = "Sounds";
            this.sounds_button.UseVisualStyleBackColor = true;
            this.sounds_button.Click += new System.EventHandler(this.soundsButton_Click);
            this.sounds_button.Enter += new System.EventHandler(this.hoverSpeak);
            this.sounds_button.Leave += new System.EventHandler(this.hoverLeave);
            // 
            // music_button
            // 
            this.music_button.Location = new System.Drawing.Point(0, 141);
            this.music_button.Name = "music_button";
            this.music_button.Size = new System.Drawing.Size(414, 47);
            this.music_button.TabIndex = 3;
            this.music_button.Text = "Music";
            this.music_button.UseVisualStyleBackColor = true;
            this.music_button.Click += new System.EventHandler(this.musicButton_click);
            this.music_button.Enter += new System.EventHandler(this.hoverSpeak);
            this.music_button.Leave += new System.EventHandler(this.hoverLeave);
            // 
            // audiobooks_button
            // 
            this.audiobooks_button.Location = new System.Drawing.Point(0, 188);
            this.audiobooks_button.Name = "audiobooks_button";
            this.audiobooks_button.Size = new System.Drawing.Size(414, 47);
            this.audiobooks_button.TabIndex = 4;
            this.audiobooks_button.Text = "Audiobooks";
            this.audiobooks_button.UseVisualStyleBackColor = true;
            this.audiobooks_button.Click += new System.EventHandler(this.audioBooks_Click);
            this.audiobooks_button.Enter += new System.EventHandler(this.hoverSpeak);
            this.audiobooks_button.Leave += new System.EventHandler(this.hoverLeave);
            // 
            // Phrases_fr_button
            // 
            this.Phrases_fr_button.Location = new System.Drawing.Point(0, 47);
            this.Phrases_fr_button.Name = "Phrases_fr_button";
            this.Phrases_fr_button.Size = new System.Drawing.Size(414, 47);
            this.Phrases_fr_button.TabIndex = 1;
            this.Phrases_fr_button.Text = "Phrases French";
            this.Phrases_fr_button.UseVisualStyleBackColor = true;
            this.Phrases_fr_button.Click += new System.EventHandler(this.Phrases_fr_button_Click);
            this.Phrases_fr_button.Enter += new System.EventHandler(this.hoverSpeak);
            this.Phrases_fr_button.Leave += new System.EventHandler(this.hoverLeave);
            // 
            // phrases1
            // 
            phrases1.Location = new System.Drawing.Point(0, 0);
            phrases1.Name = "phrases1";
            phrases1.Size = new System.Drawing.Size(414, 236);
            phrases1.TabIndex = 7;
            // 
            // sounds2
            // 
            this.sounds2.Location = new System.Drawing.Point(0, 0);
            this.sounds2.Name = "sounds2";
            this.sounds2.Size = new System.Drawing.Size(414, 236);
            this.sounds2.TabIndex = 6;
            // 
            // audioBook1
            // 
            this.audioBook1.Location = new System.Drawing.Point(0, 0);
            this.audioBook1.Name = "audioBook1";
            this.audioBook1.Size = new System.Drawing.Size(414, 236);
            this.audioBook1.TabIndex = 5;
            // 
            // music1
            // 
            this.music1.AutoScroll = true;
            this.music1.Location = new System.Drawing.Point(0, 0);
            this.music1.Name = "music1";
            this.music1.Size = new System.Drawing.Size(414, 236);
            this.music1.TabIndex = 4;
            // 
            // phrases_fr1
            // 
            phrases1_fr.Location = new System.Drawing.Point(0, 0);
            phrases1_fr.Name = "phrases_fr1";
            phrases1_fr.Size = new System.Drawing.Size(414, 236);
            phrases1_fr.TabIndex = 8;
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(414, 236);
            this.Controls.Add(phrases1_fr);
            this.Controls.Add(phrases1);
            this.Controls.Add(this.sounds2);
            this.Controls.Add(this.audioBook1);
            this.Controls.Add(this.music1);
            this.Controls.Add(this.Phrases_fr_button);
            this.Controls.Add(this.audiobooks_button);
            this.Controls.Add(this.music_button);
            this.Controls.Add(this.sounds_button);
            this.Controls.Add(this.phrases_button);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "MainPage";
            this.Text = "Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button phrases_button;
        private System.Windows.Forms.Button sounds_button;
        private System.Windows.Forms.Button music_button;
        private System.Windows.Forms.Button audiobooks_button;
        private System.Windows.Forms.Button Phrases_fr_button;

        private Music music1;
        public static Phrases_fr phrases1_fr;
        private AudioBook audioBook1;
        private Sounds sounds2;
        public static Phrases phrases1;
    }
}

