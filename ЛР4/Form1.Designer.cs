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
            pict_box = new PictureBox();
            ch_box_ctrl = new CheckBox();
            ch_box_hight = new CheckBox();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pict_box).BeginInit();
            SuspendLayout();
            // 
            // pict_box
            // 
            pict_box.BorderStyle = BorderStyle.FixedSingle;
            pict_box.Location = new Point(34, 30);
            pict_box.Name = "pict_box";
            pict_box.Size = new Size(472, 372);
            pict_box.TabIndex = 0;
            pict_box.TabStop = false;
            pict_box.Paint += pict_box_Paint;
            pict_box.MouseClick += pict_box_MouseClick;
            // 
            // ch_box_ctrl
            // 
            ch_box_ctrl.AutoSize = true;
            ch_box_ctrl.Location = new Point(570, 90);
            ch_box_ctrl.Name = "ch_box_ctrl";
            ch_box_ctrl.Size = new Size(64, 24);
            ch_box_ctrl.TabIndex = 1;
            ch_box_ctrl.Text = "CTRL";
            ch_box_ctrl.UseVisualStyleBackColor = true;
            // 
            // ch_box_hight
            // 
            ch_box_hight.AutoSize = true;
            ch_box_hight.Location = new Point(570, 135);
            ch_box_hight.Name = "ch_box_hight";
            ch_box_hight.Size = new Size(204, 24);
            ch_box_hight.TabIndex = 2;
            ch_box_hight.Text = "Выделение пересечения";
            ch_box_hight.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Круг", "Квадрат", "Треугольник", "Шестиугольник" });
            comboBox1.Location = new Point(581, 248);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(ch_box_hight);
            Controls.Add(ch_box_ctrl);
            Controls.Add(pict_box);
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pict_box).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pict_box;
        private CheckBox ch_box_ctrl;
        private CheckBox ch_box_hight;
        private ComboBox comboBox1;
    }
}