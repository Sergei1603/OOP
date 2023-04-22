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


		public abstract class shape
		{
			public int x;
			public int y;
            public bool _check;
			public abstract void paint_shape(PaintEventArgs e);
			public abstract bool Is_inside(int x, int y);
			public abstract void uncheck();
			public abstract void check();

		}
		public class Ccircle :  shape
		{
			public int r = 25;
			public Ccircle(int x, int y)
			{
				this.x = x;
				this.y = y;
				_check = true;
			}
			public override void paint_shape(PaintEventArgs e)
			{
				e.Graphics.FillEllipse(Brushes.Red, x - r, y - r, r * 2, r * 2);
				if (_check)
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
			public override bool Is_inside(int x, int y)
			{
				if ((x - this.x) * (x - this.x) + (y - this.y) * (y - this.y) <= r * r)
				{
					return true;
				}
				return false;
			}
			public override void uncheck()
			{
				_check = false;
			}
            public override void check()
            {
                _check = true;
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
				Ccircle c = new Ccircle(e.X, e.Y);
				list.PushBack(c);
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
						//       Iterator<shape> j = ;
						//j.previos();
						//i.previos();
						//i.cur_item.prev
						Iterator<shape> j = i.clone();
						j.previos();
                        if (j.cur_item != null)
							j.getCurrentItem().check();
						//	list.remove(i.getCurrentItem());
					//	i.next();
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