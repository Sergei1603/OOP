using System.Security.Cryptography.X509Certificates;
using System;
using static List;
using System.Drawing;
using System.Windows.Forms;

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
                    //					i.cur_item.val.check = false;
                    //		j.val.check = false;
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
                if (comboBox1.Text == "Круг")
                {
                    shape c = new Ccircle(e.X, e.Y);
                    list.PushBack(c);
                }
                else if (comboBox1.Text == "Квадрат")
                {
                    shape c = new Square(e.X, e.Y);
                    list.PushBack(c);
                }
                else if (comboBox1.Text == "Треугольник")
                {
                    shape c = new Triangle(e.X, e.Y);
                    list.PushBack(c);
                }
                else if (comboBox1.Text == "Шестиугольник")
                {
                    shape c = new hexagon(e.X, e.Y);
                    list.PushBack(c);
                }
                //              list.PushBack(c);
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
    }
}