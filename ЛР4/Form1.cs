using System.Security.Cryptography.X509Certificates;
using System;
using static List;
using System.Drawing;

namespace ЛР4
{
    public partial class Form1 : Form
    {
        MyList<Ccircle> list = new MyList<Ccircle>();
        public class Ccircle
        {
            public int r = 50;
            public int x;
            public int y;
            public bool check;
            public Ccircle(int x, int y)
            {
                this.x = x;
                this.y = y;
                check= true;
            }
            public void paint_Ccircle(PaintEventArgs e)
            {
                e.Graphics.FillEllipse(Brushes.Red, x - r/2, y - r/2, r, r);
                if (check)
                {
                    e.Graphics.DrawEllipse(new Pen(System.Drawing.Color.Green), x - r / 2, y - r / 2, r, r);
                }
            }
            public override bool Equals(object obj)
            {
                if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                {
                    return false;
                }
                Ccircle p = (Ccircle)obj;
                return (x == p.x) && (y == p.y);
            }
        }
   
//        Ccircle c = new Ccircle(10, 50);
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_paint_Click(object sender, EventArgs e)
        {
            pict_box.Refresh();
        }

        private void pict_box_MouseClick(object sender, MouseEventArgs e)
        {
            if (list.last != null)
            {
                list.last.val.check = false;
            }
            Ccircle c = new Ccircle(e.X, e.Y);
            list.PushBack(c);
            pict_box.Refresh();
        }

        private void pict_box_Paint(object sender, PaintEventArgs e)
        {
            for (Node<Ccircle> i = list.first; i!= null; i = i.pos)
            {
                i.val.paint_Ccircle(e);
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete)
            {
                for (Node<Ccircle> i = list.first; i != null; i = i.pos)
                {
                    if (i.val.check)
                    {
                        list.remove(i.val);
                    }
                }
            }
            pict_box.Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                for (Node<Ccircle> i = list.first; i != null; i = i.pos)
                {
                    if (i.val.check)
                    {
                        list.remove(i.val);
                    }
                }
            }
            pict_box.Refresh();
        }
    }
}