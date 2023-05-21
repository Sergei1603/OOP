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
            components = new System.ComponentModel.Container();
            pict_box = new PictureBox();
            Menu = new ContextMenuStrip(components);
            make_group = new ToolStripMenuItem();
            delete_group = new ToolStripMenuItem();
            Save_file = new ToolStripMenuItem();
            Load_file = new ToolStripMenuItem();
            ch_box_ctrl = new CheckBox();
            ch_box_intersec = new CheckBox();
            numericUpDown_size = new NumericUpDown();
            listBox_shape = new ListBox();
            button_color = new Button();
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
            treeView_shapes = new TreeView();
            checkBox_line = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pict_box).BeginInit();
            Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_size).BeginInit();
            SuspendLayout();
            // 
            // pict_box
            // 
            pict_box.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pict_box.BorderStyle = BorderStyle.FixedSingle;
            pict_box.ContextMenuStrip = Menu;
            pict_box.Location = new Point(34, 97);
            pict_box.Name = "pict_box";
            pict_box.Size = new Size(854, 508);
            pict_box.TabIndex = 0;
            pict_box.TabStop = false;
            pict_box.Paint += pict_box_Paint;
            pict_box.MouseClick += pict_box_MouseClick;
            pict_box.MouseDown += pict_box_MouseDown;
            pict_box.MouseMove += pict_box_MouseMove;
            pict_box.MouseUp += pict_box_MouseUp;
            // 
            // Menu
            // 
            Menu.ImageScalingSize = new Size(20, 20);
            Menu.Items.AddRange(new ToolStripItem[] { make_group, delete_group, Save_file, Load_file });
            Menu.Name = "Group";
            Menu.Size = new Size(199, 100);
            // 
            // make_group
            // 
            make_group.Name = "make_group";
            make_group.Size = new Size(198, 24);
            make_group.Text = "Сгруппировать";
            make_group.Click += make_group_Click;
            // 
            // delete_group
            // 
            delete_group.Name = "delete_group";
            delete_group.Size = new Size(198, 24);
            delete_group.Text = "Разгруппировать";
            delete_group.Click += delete_group_Click;
            // 
            // Save_file
            // 
            Save_file.Name = "Save_file";
            Save_file.Size = new Size(198, 24);
            Save_file.Text = "Сохранить";
            Save_file.Click += Save_Click;
            // 
            // Load_file
            // 
            Load_file.Name = "Load_file";
            Load_file.Size = new Size(198, 24);
            Load_file.Text = "Загрузить";
            Load_file.Click += Load_file_Click;
            // 
            // ch_box_ctrl
            // 
            ch_box_ctrl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ch_box_ctrl.AutoSize = true;
            ch_box_ctrl.Location = new Point(931, 417);
            ch_box_ctrl.Name = "ch_box_ctrl";
            ch_box_ctrl.Size = new Size(64, 24);
            ch_box_ctrl.TabIndex = 1;
            ch_box_ctrl.Text = "CTRL";
            ch_box_ctrl.UseVisualStyleBackColor = true;
            // 
            // ch_box_intersec
            // 
            ch_box_intersec.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ch_box_intersec.AutoSize = true;
            ch_box_intersec.Location = new Point(931, 367);
            ch_box_intersec.Name = "ch_box_intersec";
            ch_box_intersec.Size = new Size(204, 24);
            ch_box_intersec.TabIndex = 2;
            ch_box_intersec.Text = "Выделение пересечения";
            ch_box_intersec.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_size
            // 
            numericUpDown_size.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDown_size.Location = new Point(499, 33);
            numericUpDown_size.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDown_size.Name = "numericUpDown_size";
            numericUpDown_size.Size = new Size(150, 27);
            numericUpDown_size.TabIndex = 4;
            numericUpDown_size.Value = new decimal(new int[] { 26, 0, 0, 0 });
            numericUpDown_size.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // listBox_shape
            // 
            listBox_shape.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            listBox_shape.FormattingEnabled = true;
            listBox_shape.ItemHeight = 20;
            listBox_shape.Items.AddRange(new object[] { "Круг", "Квадрат", "Треугольник", "Шестиугольник" });
            listBox_shape.Location = new Point(280, 33);
            listBox_shape.Name = "listBox_shape";
            listBox_shape.Size = new Size(150, 44);
            listBox_shape.TabIndex = 5;
            // 
            // button_color
            // 
            button_color.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_color.BackColor = Color.Green;
            button_color.Location = new Point(139, 33);
            button_color.Name = "button_color";
            button_color.Size = new Size(94, 29);
            button_color.TabIndex = 6;
            button_color.UseVisualStyleBackColor = false;
            button_color.Click += textBox_color_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // treeView_shapes
            // 
            treeView_shapes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            treeView_shapes.ContextMenuStrip = Menu;
            treeView_shapes.HideSelection = false;
            treeView_shapes.Location = new Point(917, 97);
            treeView_shapes.Name = "treeView_shapes";
            treeView_shapes.Size = new Size(218, 244);
            treeView_shapes.TabIndex = 7;
            treeView_shapes.AfterSelect += treeView1_AfterSelect;
            // 
            // checkBox_line
            // 
            checkBox_line.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox_line.AutoSize = true;
            checkBox_line.Location = new Point(931, 461);
            checkBox_line.Name = "checkBox_line";
            checkBox_line.Size = new Size(164, 24);
            checkBox_line.TabIndex = 8;
            checkBox_line.Text = "Рисование стрелок";
            checkBox_line.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 653);
            Controls.Add(checkBox_line);
            Controls.Add(treeView_shapes);
            Controls.Add(button_color);
            Controls.Add(listBox_shape);
            Controls.Add(numericUpDown_size);
            Controls.Add(ch_box_intersec);
            Controls.Add(ch_box_ctrl);
            Controls.Add(pict_box);
            MinimumSize = new Size(1200, 700);
            Name = "Form1";
            Text = "Form1";
            KeyDown += Form1_KeyDown;
            KeyUp += Form1_KeyUp;
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)pict_box).EndInit();
            Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown_size).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pict_box;
        private CheckBox ch_box_ctrl;
        private CheckBox ch_box_intersec;
        private NumericUpDown numericUpDown_size;
        private ListBox listBox_shape;
        private Button button_color;
        private ContextMenuStrip Menu;
        private ToolStripMenuItem make_group;
        private ToolStripMenuItem delete_group;
        private ToolStripMenuItem Save_file;
        private ToolStripMenuItem Load_file;
        private SaveFileDialog saveFileDialog;
        private OpenFileDialog openFileDialog;
        private TreeView treeView_shapes;
        private CheckBox checkBox_line;
    }
}