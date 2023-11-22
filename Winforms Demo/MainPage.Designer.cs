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
            this.SuspendLayout();
            // 
            // phrases_button
            // 
            this.phrases_button.Location = new System.Drawing.Point(0, 0);
            this.phrases_button.Name = "phrases_button";
            this.phrases_button.Size = new System.Drawing.Size(464, 70);
            this.phrases_button.TabIndex = 0;
            this.phrases_button.Text = "Phrases";
            this.phrases_button.UseVisualStyleBackColor = true;
            this.phrases_button.Enter += new System.EventHandler(this.hoverSpeak);
            // 
            // sounds_button
            // 
            this.sounds_button.Location = new System.Drawing.Point(0, 70);
            this.sounds_button.Name = "sounds_button";
            this.sounds_button.Size = new System.Drawing.Size(464, 70);
            this.sounds_button.TabIndex = 1;
            this.sounds_button.Text = "Sounds";
            this.sounds_button.UseVisualStyleBackColor = true;
            this.sounds_button.Enter += new System.EventHandler(this.hoverSpeak);
            // 
            // music_button
            // 
            this.music_button.Location = new System.Drawing.Point(0, 140);
            this.music_button.Name = "music_button";
            this.music_button.Size = new System.Drawing.Size(464, 70);
            this.music_button.TabIndex = 2;
            this.music_button.Text = "Music";
            this.music_button.UseVisualStyleBackColor = true;
            this.music_button.Enter += new System.EventHandler(this.hoverSpeak);
            // 
            // audiobooks_button
            // 
            this.audiobooks_button.Location = new System.Drawing.Point(0, 210);
            this.audiobooks_button.Name = "audiobooks_button";
            this.audiobooks_button.Size = new System.Drawing.Size(464, 70);
            this.audiobooks_button.TabIndex = 3;
            this.audiobooks_button.Text = "Audiobooks";
            this.audiobooks_button.UseVisualStyleBackColor = true;
            this.audiobooks_button.Enter += new System.EventHandler(this.hoverSpeak);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.audiobooks_button);
            this.Controls.Add(this.music_button);
            this.Controls.Add(this.sounds_button);
            this.Controls.Add(this.phrases_button);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "MainPage";
            this.Text = "Demo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button phrases_button;
        private System.Windows.Forms.Button sounds_button;
        private System.Windows.Forms.Button music_button;
        private System.Windows.Forms.Button audiobooks_button;
    }
}

