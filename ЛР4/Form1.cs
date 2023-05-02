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
        MyList<shape> list = new MyList<shape>();

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
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
                    if (!ch_box_hight.Checked)
                        break;
                }
            }
            if (!inside)
            {
                Factory factory = new shapeFactory();
                list.PushBack(factory.create_shape(listBox_shape.Text, e.X, e.Y, (int)numericUpDown_size.Value, button_color.BackColor));
            }
            pict_box.Refresh();
        }

        private void pict_box_Paint(object sender, PaintEventArgs e)
        {
            for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
            {
                i.getCurrentItem().corect_position(pict_box.Width, pict_box.Height);
                i.getCurrentItem().paint_shape(e);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
                {
                    if (i.getCurrentItem()._check)
                    {
                        Iterator<shape> j = i.clone();
                        j.previos();
                        if (j.cur_item != null)
                            j.getCurrentItem().check();
                        i.remove();
                    }
                }
            }
            if (e.KeyData == Keys.W || e.KeyData == Keys.A || e.KeyData == Keys.S || e.KeyData == Keys.D)
            {
                for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
                {
                    if (i.getCurrentItem()._check)
                    {
                        i.getCurrentItem().move(e.KeyData);
                        i.getCurrentItem().corect_position(pict_box.Size.Width, pict_box.Size.Height);
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
            for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
            {
                if (i.getCurrentItem()._check)
                {
                    i.getCurrentItem().resize((int)numericUpDown_size.Value);
                    i.getCurrentItem().corect_position(pict_box.Size.Width, pict_box.Height);
                }
            }
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
                for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
                {
                    if (i.getCurrentItem()._check)
                    {
                        i.getCurrentItem().change_color(MyDialog.Color);
                    }
                }
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
            pict_box.Refresh();
        }
    }
}