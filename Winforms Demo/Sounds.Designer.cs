
namespace Winforms_Demo
{
    partial class Sounds
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.birds = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // birds
            // 
            this.birds.Location = new System.Drawing.Point(81, 94);
            this.birds.Name = "birds";
            this.birds.Size = new System.Drawing.Size(261, 45);
            this.birds.TabIndex = 1;
            this.birds.Text = "Birds";
            this.birds.UseVisualStyleBackColor = true;
            this.birds.Click += new System.EventHandler(this.playBirds);
            this.birds.Enter += new System.EventHandler(this.hoverSpeak);
            this.birds.Leave += new System.EventHandler(this.hoverLeave);
            this.birds.MouseEnter += new System.EventHandler(this.hoverSpeak);
            this.birds.MouseLeave += new System.EventHandler(this.hoverLeave);
            // 
            // Sounds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.birds);
            this.Name = "Sounds";
            this.Size = new System.Drawing.Size(414, 236);
            this.Load += new System.EventHandler(this.Sounds_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button birds;
    }
}
