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
        Changer_color changer_color;
        Resizer resizer;
        bool mouse_move;
        bool f = false;
        int x;
        int y;
        MyList<command> change_position_list;

        public Form1()
        {

            InitializeComponent();
            this.KeyPreview = true;
            list = new MyList<shape>();
            history = new Stack<MyList<command>>();
            Mover[] A = { new Mover(Keys.A), new Mover(Keys.D) };
            Mover[] D = { new Mover(Keys.D), new Mover(Keys.A) };
            Mover[] W = { new Mover(Keys.W), new Mover(Keys.S) };
            Mover[] S = { new Mover(Keys.S), new Mover(Keys.W) };
            map[Keys.Delete] = new DeleteCommand(list);
            map[Keys.A] = new MoveCommand(A, pict_box.Width, pict_box.Height);
            map[Keys.D] = new MoveCommand(D, pict_box.Width, pict_box.Height);
            map[Keys.W] = new MoveCommand(W, pict_box.Width, pict_box.Height);
            map[Keys.S] = new MoveCommand(S, pict_box.Width, pict_box.Height);
            storage = new storage(list);
            changer_color = new Changer_color(Color.Green);
            resizer = new Resizer(20);

        }


        private void pict_box_MouseClick(object sender, MouseEventArgs e)
        {
       //     if (!checkBox_move.Checked)
            {
                //if (e.Button == MouseButtons.Left)
                //{
                //    mouse_move = false;
                //    history.Push(change_position_list);
                //}
                bool inside = false;
                if (Control.ModifierKeys != Keys.Control && f)
                {
                    for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
                    {
                        i.getCurrentItem().uncheck();
                    }
                }
                //             mouse_move = true;
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
                if (!inside && listBox_shape.Text != "" && f)
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
            //if (e.Button == MouseButtons.Left)
            //{
            //    mouse_move = false;
            //    history.Push(change_position_list);
            //}
        }

        private void pict_box_Paint(object sender, PaintEventArgs e)
        {
            Drawer drawer = new Drawer(e);
            for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
            {
                i.getCurrentItem().apply(drawer);
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
            resizer.size = (int)numericUpDown_size.Value;
            MyList<command> list_command = new MyList<command>();
            for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
            {
                if (i.getCurrentItem()._check)
                {
                    command command = new ChangeSizeCommand(resizer);
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
                changer_color.color = MyDialog.Color;
                MyList<command> list_command = new MyList<command>();
                for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
                {
                    if (i.getCurrentItem()._check)
                    {
                        command command = new ChangeColorCommand(changer_color);
                        command.execute(i.getCurrentItem());
                        list_command.PushBack(command);
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
            foreach (var i in map)
            {
                MoveCommand? command = i.Value as MoveCommand;

                if (command != null)
                {
                    command.update_edgs(pict_box.Width, pict_box.Height);
                }
            }
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
            MyList<command> list_command = new MyList<command>();
            for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
            {
                if (i.getCurrentItem()._check)
                {
                    command command = new DeleteGroupCommand(list);
                    command.execute(i.getCurrentItem());
                    list_command.PushBack(command);
                }
            }
            history.Push(list_command);
        }


        private void Save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog.FileName;
            StreamWriter writer = new StreamWriter(filename);
            writer.WriteLine(Width + " " + Height + " " + Location.X + " " + Location.Y);
            storage.save(writer);
            writer.Close();
        }

        private void Load_file_Click(object sender, EventArgs e)
        {
            list.clear();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog.FileName;
            StreamReader reader = new StreamReader(filename);
            string line = reader.ReadLine();
            string[] parametrs = line.Split();
            Width = int.Parse(parametrs[0]);
            Height = int.Parse(parametrs[1]);
            this.Location = new Point(int.Parse(parametrs[2]), int.Parse(parametrs[3]));
            //            Location.Y = int.Parse(parametrs[3]);
            storage.load(reader, new shapeFactory());
            pict_box.Refresh();
        }

        private void pict_box_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouse_move = true;
                f = true;
                x = e.X;
                y = e.Y;
                change_position_list = new MyList<command>();
            }
        }

        private void pict_box_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_move)
            {
                bool inside = false;
                for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
                {
                    if (i.getCurrentItem().Is_inside(e.X, e.Y))
                    {
                        inside = true;
                    }
                }
                if (inside)
                {
                    for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
                    {
                        if (i.getCurrentItem()._check)
                        {

                            command command = new ChangePositionCommand(e.X - x, e.Y - y, pict_box.Width, pict_box.Height);
                            //                           move.update_d(e.X - x, e.Y - y);
                            f = false;
                            command.execute(i.getCurrentItem());
                            change_position_list.PushBack(command);
                            //                         i.getCurrentItem().chenge_position(e.X - x, e.Y - y);
                        }
                    }
                    //                  history.Push(list_command);
                }
                x = e.X;
                y = e.Y;
            }
            //x = e.X;
            //y = e.Y;
            pict_box.Refresh();
        }

        private void pict_box_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouse_move = false;
                history.Push(change_position_list);
                f = false;
            }
        }
    }
}