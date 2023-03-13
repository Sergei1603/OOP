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
            this.ch_box_ctr = new System.Windows.Forms.CheckBox();
            this.ch_box_all = new System.Windows.Forms.CheckBox();
            this.btn_paint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pict_box)).BeginInit();
            this.SuspendLayout();
            // 
            // pict_box
            // 
            this.pict_box.Location = new System.Drawing.Point(34, 30);
            this.pict_box.Name = "pict_box";
            this.pict_box.Size = new System.Drawing.Size(472, 372);
            this.pict_box.TabIndex = 0;
            this.pict_box.TabStop = false;
            this.pict_box.Paint += new System.Windows.Forms.PaintEventHandler(this.pict_box_Paint);
            this.pict_box.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pict_box_MouseClick);
            // 
            // ch_box_ctr
            // 
            this.ch_box_ctr.AutoSize = true;
            this.ch_box_ctr.Location = new System.Drawing.Point(596, 103);
            this.ch_box_ctr.Name = "ch_box_ctr";
            this.ch_box_ctr.Size = new System.Drawing.Size(118, 24);
            this.ch_box_ctr.TabIndex = 1;
            this.ch_box_ctr.Text = "Ctrl включен";
            this.ch_box_ctr.UseVisualStyleBackColor = true;
            // 
            // ch_box_all
            // 
            this.ch_box_all.AutoSize = true;
            this.ch_box_all.Location = new System.Drawing.Point(596, 150);
            this.ch_box_all.Name = "ch_box_all";
            this.ch_box_all.Size = new System.Drawing.Size(143, 24);
            this.ch_box_all.TabIndex = 2;
            this.ch_box_all.Text = "Выделяются все";
            this.ch_box_all.UseVisualStyleBackColor = true;
            // 
            // btn_paint
            // 
            this.btn_paint.Location = new System.Drawing.Point(603, 350);
            this.btn_paint.Name = "btn_paint";
            this.btn_paint.Size = new System.Drawing.Size(94, 29);
            this.btn_paint.TabIndex = 3;
            this.btn_paint.Text = "Рисовать";
            this.btn_paint.UseVisualStyleBackColor = true;
            this.btn_paint.Click += new System.EventHandler(this.btn_paint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_paint);
            this.Controls.Add(this.ch_box_all);
            this.Controls.Add(this.ch_box_ctr);
            this.Controls.Add(this.pict_box);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pict_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pict_box;
        private CheckBox ch_box_ctr;
        private CheckBox ch_box_all;
        private Button btn_paint;
    }
}