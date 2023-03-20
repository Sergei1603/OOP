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
				e.Graphics.FillEllipse(Brushes.Red, x - r, y - r, r * 2, r * 2);
				if (check)
				{
					e.Graphics.DrawEllipse(new Pen(System.Drawing.Color.Green, 5), x - r, y - r, r * 2, r * 2);
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
				for (Node<Ccircle> j = list.last; j != null; j = j.prev)
				{
					j.val.check = false;
				}
			}

			for (Node<Ccircle> i = list.last; i != null; i = i.prev)
			{
				if (i.val.Is_inside(e.X, e.Y))
				{
					inside = true;
					i.val.check = true;
					if (!ch_box_hight.Checked)
						break;
				}
			}
			if (!inside)
			{
				Ccircle c = new Ccircle(e.X, e.Y);
				list.PushBack(c);
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

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Delete)
			{
				for (Node<Ccircle> i = list.first; i != null; i = i.pos)
				{
					if (i.val.check)
					{
						if (i.prev != null)
							i.prev.val.check = true;
						list.remove(i.val);
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