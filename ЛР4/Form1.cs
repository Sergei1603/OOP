using System.Security.Cryptography.X509Certificates;
using System;
using static List;
using System.Drawing;
using System.Windows.Forms;

namespace ЛР4
{
	public partial class Form1 : Form
	{
		MyList<Ccircle> list = new MyList<Ccircle>();
		public class Ccircle
		{
			public int d = 50;
			public int r = 25;
			public int x;
			public int y;
			public bool check;
			public Ccircle(int x, int y)
			{
				this.x = x;
				this.y = y;
				check = true;
			}
			public void paint_Ccircle(PaintEventArgs e)
			{
				e.Graphics.FillEllipse(Brushes.Red, x - r, y - r, d, d);
				if (check)
				{
					e.Graphics.DrawEllipse(new Pen(System.Drawing.Color.Green, 5), x - r, y - r, d, d);
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
			public bool Is_inside(int x, int y)
			{
				if ((x - this.x) * (x - this.x) + (y - this.y) * (y - this.y) <= r * r)
				{
					return true;
				}
				return false;
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
			if (Control.ModifierKeys == Keys.Control || ch_box_ctrl.Checked)
			{
				for (Node<Ccircle> i = list.first; i != null; i = i.pos)
				{
					i.val.check = true;
				}
            }
			else
			{
				bool f = true;
				for (Node<Ccircle> i = list.last; i != null; i = i.prev)
				{
					if (i.val.Is_inside(e.X, e.Y))
					{
						i.val.check = !(i.val.check);
						f = false;
						if (!ch_box_hight.Checked)
						{
							break;
						}
					}
				}
				if (f)
				{
					if (list.last != null)
					{
						list.last.val.check = false;
					}
					Ccircle c = new Ccircle(e.X, e.Y);
					list.PushBack(c);
				}
			}
			pict_box.Refresh();
		}

		private void pict_box_Paint(object sender, PaintEventArgs e)
		{
			for (Node<Ccircle> i = list.first; i != null; i = i.pos)
			{
				i.val.paint_Ccircle(e);
			}
		}

		private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
            if (Control.ModifierKeys == Keys.Control)
            {
                ch_box_ctrl.Checked = !ch_box_ctrl.Checked;
            }
            if (keyData == Keys.Delete)
			{
				for (Node<Ccircle> i = list.first; i != null; i = i.pos)
				{
					if (i.val.check)
					{
						if (i.prev != null)
						{
							i.prev.val.check = true;
						}
						list.remove(i.val);
					}
				}
			}
			pict_box.Refresh();
			return base.ProcessCmdKey(ref msg, keyData);
		}
	}
}