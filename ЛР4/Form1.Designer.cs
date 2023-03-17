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
            this.ch_box_ctrl = new System.Windows.Forms.CheckBox();
            this.ch_box_hight = new System.Windows.Forms.CheckBox();
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
            // ch_box_ctrl
            // 
            this.ch_box_ctrl.AutoSize = true;
            this.ch_box_ctrl.Location = new System.Drawing.Point(570, 90);
            this.ch_box_ctrl.Name = "ch_box_ctrl";
            this.ch_box_ctrl.Size = new System.Drawing.Size(64, 24);
            this.ch_box_ctrl.TabIndex = 1;
            this.ch_box_ctrl.Text = "CTRL";
            this.ch_box_ctrl.UseVisualStyleBackColor = true;
            // 
            // ch_box_hight
            // 
            this.ch_box_hight.AutoSize = true;
            this.ch_box_hight.Location = new System.Drawing.Point(570, 135);
            this.ch_box_hight.Name = "ch_box_hight";
            this.ch_box_hight.Size = new System.Drawing.Size(204, 24);
            this.ch_box_hight.TabIndex = 2;
            this.ch_box_hight.Text = "Выделение пересечения";
            this.ch_box_hight.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ch_box_hight);
            this.Controls.Add(this.ch_box_ctrl);
            this.Controls.Add(this.pict_box);
            this.Name = "Form1";
            this.Text = "Form1";
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Form1_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pict_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pict_box;
        private CheckBox ch_box_ctrl;
        private CheckBox ch_box_hight;
    }
}