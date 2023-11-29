
namespace Winforms_Demo
{
    partial class AudioBook
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
            this.book = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // book
            // 
            this.book.Location = new System.Drawing.Point(81, 94);
            this.book.Name = "book";
            this.book.Size = new System.Drawing.Size(261, 45);
            this.book.TabIndex = 1;
            this.book.Text = "Goldilocks";
            this.book.UseVisualStyleBackColor = true;
            this.book.Click += new System.EventHandler(this.book_Click);
            this.book.Enter += new System.EventHandler(this.hoverSpeak);
            this.book.Leave += new System.EventHandler(this.hoverLeave);
            this.book.MouseLeave += new System.EventHandler(this.hoverLeave);
            this.book.MouseHover += new System.EventHandler(this.hoverSpeak);
            // 
            // AudioBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.book);
            this.Name = "AudioBook";
            this.Size = new System.Drawing.Size(414, 236);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button book;
    }
}

