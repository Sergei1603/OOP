using System.Security.Cryptography.X509Certificates;
using System;
using static List;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ЛР4
{
    public partial class Form1 : Form
    {
        public MyList<shape> list;
        Stack<MyList<command>> history;
        string filename = "store.txt";
        Dictionary<Keys, command> map = new Dictionary<Keys, command>();
        storage storage;

        public Form1()
        {

            InitializeComponent();
            this.KeyPreview = true;
            list = new MyList<shape>();
            history = new Stack<MyList<command>>();
            map[Keys.Delete] = new DeleteCommand(list);
            map[Keys.A] = new MoveCommand(Keys.A, pict_box.Width, pict_box.Height);
            map[Keys.D] = new MoveCommand(Keys.D, pict_box.Width, pict_box.Height);
            map[Keys.W] = new MoveCommand(Keys.W, pict_box.Width, pict_box.Height);
            map[Keys.S] = new MoveCommand(Keys.S, pict_box.Width, pict_box.Height);
            storage = new storage(list);
        }


        private void pict_box_MouseClick(object sender, MouseEventArgs e)
        {
            bool inside = false;
            if (Control.ModifierKeys != Keys.Control)
            {
                for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
                {
                    i.getCurrentItem().uncheck();
                }
            }

            for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
            {
                if (i.getCurrentItem().Is_inside(e.X, e.Y))
                {
                    inside = true;
                    i.getCurrentItem().check();
                    if (!ch_box_intersec.Checked)
                        break;
                }
            }
            if (!inside && listBox_shape.Text != "")
            {
                Factory factory = new shapeFactory();
                shape shape = factory.create_shape(listBox_shape.Text, e.X, e.Y, (int)numericUpDown_size.Value, button_color.BackColor);
                shape.corect_position(pict_box.Width, pict_box.Height);
                MakeCommand command = new MakeCommand(list);
                command.execute(shape);
                MyList<command> list_command = new MyList<command>();
                list_command.PushBack(command);
                history.Push(list_command);
            }
            pict_box.Refresh();
        }

        private void pict_box_Paint(object sender, PaintEventArgs e)
        {
            for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
            {
                i.getCurrentItem().paint_shape(e);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W || e.KeyData == Keys.A || e.KeyData == Keys.S || e.KeyData == Keys.D || e.KeyData == Keys.Delete)
            {
                MyList<command> list_command = new MyList<command>();
                for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
                {
                    if (i.getCurrentItem()._check)
                    {
                        command command = map[e.KeyData].clone();
                        command.execute(i.getCurrentItem());
                        list_command.PushBack(command);
                    }
                }
                history.Push(list_command);
            }
            if (e.KeyData == Keys.Z && history.Count != 0)
            {
                if (history.Count != 0)
                {
                    for (Iterator<command> i = history.Pop().CreateIterator(); !i.isEOL(); i.next())
                    {
                        i.getCurrentItem().unexecute();
                    }
                }
            }
            pict_box.Refresh();
            if (e.KeyCode == Keys.ControlKey)
            {
                ch_box_ctrl.Checked = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                ch_box_ctrl.Checked = false;
            }
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MyList<command> list_command = new MyList<command>();
            for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
            {
                if (i.getCurrentItem()._check)
                {
                    command command = new ChangeSizeCommand((int)numericUpDown_size.Value);
                    i.getCurrentItem().corect_position(pict_box.Width, pict_box.Height);
                    command.execute(i.getCurrentItem());
                    list_command.PushBack(command);
                }
            }
            history.Push(list_command);
            pict_box.Refresh();
        }

        private void textBox_color_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = button_color.BackColor;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                button_color.BackColor = MyDialog.Color;
                MyList<command> list_command = new MyList<command>();
                for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
                {
                    if (i.getCurrentItem()._check)
                    {
                        command command = new ChangeColorCommand(MyDialog.Color);
                        command.execute(i.getCurrentItem());
                        list_command.PushBack(command);
                        //                     i.getCurrentItem().change_color(MyDialog.Color);
                    }
                }
                history.Push(list_command);
                pict_box.Refresh();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (pict_box.Width > pict_box.Height)
            {
                numericUpDown_size.Maximum = pict_box.Size.Height / 2;
            }
            else
            {
                numericUpDown_size.Maximum = pict_box.Size.Width / 2;
            }
            map[Keys.A] = new MoveCommand(Keys.A, pict_box.Width, pict_box.Height);
            map[Keys.D] = new MoveCommand(Keys.D, pict_box.Width, pict_box.Height);
            map[Keys.W] = new MoveCommand(Keys.W, pict_box.Width, pict_box.Height);
            map[Keys.S] = new MoveCommand(Keys.S, pict_box.Width, pict_box.Height);
            pict_box.Refresh();
        }


        private void make_group_Click(object sender, EventArgs e)
        {
            Group group = new Group();
            command command = new MakeGroupCommand(list);
            command.execute(group);
            MyList<command> list_command = new MyList<command>();
            list_command.PushBack(command);
            history.Push(list_command);

        }

        private void delete_group_Click(object sender, EventArgs e)
        {

            for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
            {
                if (i.getCurrentItem()._check && i.getCurrentItem() is Group)
                {
                    Group g = (Group)i.getCurrentItem();
                    for (Iterator<shape> j = g.delete_group().CreateIterator(); !j.isEOL(); j.next())
                        list.PushFront(j.getCurrentItem());
                    i.remove();
                }
            }
        }


        private void Save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog.FileName;
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine(Width + " " +  Height + " " + Location.X + " " + Location.Y);
//            writer.Close();
            storage.save(writer);
            writer.Close();
        }

        private void Load_file_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            StreamReader reader = new StreamReader(filename);
            string line = reader.ReadLine();
            string[] parametrs = line.Split();
            Width = int.Parse(parametrs[0]);
            Height = int.Parse(parametrs[1]);
            this.Location= new Point(int.Parse(parametrs[2]), int.Parse(parametrs[3]));
//            Location.Y = int.Parse(parametrs[3]);
            storage.load(reader, new shapeFactory());
            pict_box.Refresh();
        }
    }
}