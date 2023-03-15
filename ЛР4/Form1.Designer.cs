namespace ЛР4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pict_box = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pict_box)).BeginInit();
            this.SuspendLayout();
            // 
            // pict_box
            // 
            this.pict_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pict_box.Location = new System.Drawing.Point(34, 30);
            this.pict_box.Name = "pict_box";
            this.pict_box.Size = new System.Drawing.Size(472, 372);
            this.pict_box.TabIndex = 0;
            this.pict_box.TabStop = false;
            this.pict_box.Paint += new System.Windows.Forms.PaintEventHandler(this.pict_box_Paint);
            this.pict_box.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pict_box_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pict_box);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pict_box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pict_box;
    }
}