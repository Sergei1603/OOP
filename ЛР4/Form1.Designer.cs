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
            numericUpDown_size = new NumericUpDown();
            listBox_shape = new ListBox();
            button_color = new Button();
            ((System.ComponentModel.ISupportInitialize)pict_box).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_size).BeginInit();
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
            // numericUpDown_size
            // 
            numericUpDown_size.Location = new Point(587, 340);
            numericUpDown_size.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown_size.Name = "numericUpDown_size";
            numericUpDown_size.Size = new Size(150, 27);
            numericUpDown_size.TabIndex = 4;
            numericUpDown_size.Value = new decimal(new int[] { 25, 0, 0, 0 });
            numericUpDown_size.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // listBox_shape
            // 
            listBox_shape.FormattingEnabled = true;
            listBox_shape.ItemHeight = 20;
            listBox_shape.Items.AddRange(new object[] { "Круг", "Квадрат", "Треугольник", "Шестиугольник" });
            listBox_shape.Location = new Point(570, 223);
            listBox_shape.Name = "listBox_shape";
            listBox_shape.Size = new Size(150, 44);
            listBox_shape.TabIndex = 5;
            // 
            // button_color
            // 
            button_color.BackColor = Color.Green;
            button_color.Location = new Point(604, 45);
            button_color.Name = "button_color";
            button_color.Size = new Size(94, 29);
            button_color.TabIndex = 6;
            button_color.UseVisualStyleBackColor = false;
            button_color.Click += textBox_color_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_color);
            Controls.Add(listBox_shape);
            Controls.Add(numericUpDown_size);
            Controls.Add(ch_box_hight);
            Controls.Add(ch_box_ctrl);
            Controls.Add(pict_box);
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pict_box).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_size).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pict_box;
        private CheckBox ch_box_ctrl;
        private CheckBox ch_box_hight;
        private NumericUpDown numericUpDown_size;
        private ListBox listBox_shape;
        private Button button_color;
    }
}