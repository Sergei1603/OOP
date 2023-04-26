public abstract class shape
{
	public int x;
	public int y;
	public int a;
	public bool _check;
	public Color _color = Color.Green;
	public abstract void paint_shape(PaintEventArgs e);
	public abstract bool Is_inside(int x, int y);
	public abstract void uncheck();
	public abstract void check();
	public void change_color(Color color)
	{
		_color = color;
	}
	public abstract void resize(int dx);
	public virtual void move(Keys k)
	{
		switch (k)
		{
			case Keys.A:
				x -= 5;
				break;
			case Keys.D:
				x += 5;
				break;
			case Keys.W:
				y -= 5; break;
			case Keys.S:
				y += 5;
				break;
		}
	}
	public virtual void corect_position(int width, int height)
	{
		if (x < a / 2)
		{
			x = 0;
		}
		if (y < a / 2)
		{
			y = 0;
		}
		if (x > width - a/2)
		{
			x = width;
		}
		if (y > height - a / 2)
		{
			y = height;
		}
	}
}
	public class Ccircle : shape
	{
		public int d = 50;
		public Ccircle(int x, int y, int size, Color color)
		{
			this.x = x;
			this.y = y;
			_check = true;
			d = size;
			_color = color;
		}
		public override void paint_shape(PaintEventArgs e)
		{
		e.Graphics.FillEllipse(new SolidBrush(_color), x - d / 2, y - d / 2, d, d);
		if (_check)
		{
			e.Graphics.DrawEllipse(new Pen(System.Drawing.Color.Red, 3), x - d / 2, y - d / 2, d, d);
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
			if ((x - this.x) * (x - this.x) + (y - this.y) * (y - this.y) <= d * d / 4)
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
	public override void resize(int dx)
	{
		d = dx;
	}
}

public class Square : shape
{
	public int a = 50;
	public Square(int x, int y, int size, Color color)
	{
		this.x = x;
		this.y = y;
		_check = true;
		a = size;
		_color = color;
	}
	public override void paint_shape(PaintEventArgs e)
	{
		e.Graphics.FillRectangle(new SolidBrush(_color), x - a / 2, y - a / 2, a, a);
		if (_check)
		{
			e.Graphics.DrawRectangle(new Pen(System.Drawing.Color.Red, 3), x - a / 2, y - a / 2, a, a);
		}
	}
	public override bool Equals(object obj)
	{
		if ((obj == null) || !this.GetType().Equals(obj.GetType()))
		{
			return false;
		}
		Square p = (Square)obj;
		return (x == p.x) && (y == p.y);
	}
	public override bool Is_inside(int x, int y)
	{
		if ((x - this.x) * (x - this.x) + (y - this.y) * (y - this.y) <= a * a)
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
	public override void resize(int dx)
	{
		a = dx;
	}
}

public class Triangle : shape
{
	public int a = 50;
	public Triangle(int x, int y, int size, Color color)
	{
		this.x = x;
		this.y = y;
		_check = true;
		a = size;
		_color = color;
	}
	public override void paint_shape(PaintEventArgs e)
	{
		Point point1 = new Point(x, (int)(y - a * Math.Sqrt(3) / 3));
		Point point2 = new Point(x - a / 2, (int)(y + (a * Math.Sqrt(3) / 6)));
		Point point3 = new Point(x + a / 2, (int)(y + (a * Math.Sqrt(3) / 6)));
		Point[] arr_point = { point1, point2, point3 };
		e.Graphics.FillPolygon(new SolidBrush(_color), arr_point);
		if (_check)
		{
			e.Graphics.DrawPolygon(new Pen(System.Drawing.Color.Red, 3), arr_point);
		}
	}
	public override bool Equals(object obj)
	{
		if ((obj == null) || !this.GetType().Equals(obj.GetType()))
		{
			return false;
		}
		Triangle p = (Triangle)obj;
		return (x == p.x) && (y == p.y);
	}
	public override bool Is_inside(int x, int y)
	{
		if ((x - this.x) * (x - this.x) + (y - this.y) * (y - this.y) <= a * a)
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
	public override void resize(int dx)
	{
		a = dx;
	}
}

public class Hexagon : shape
{
	public int a = 50;
	public Hexagon(int x, int y, int size, Color color)
    {
        this.x = x;
        this.y = y;
        _check = true;
        a = size;
        _color = color;
    }
	public override void paint_shape(PaintEventArgs e)
	{
		Point point1 = new Point(x, y - a);
		Point point2 = new Point(x + (int)(Math.Sqrt(3) * a) / 2, y - a / 2);
		Point point3 = new Point(x + (int)(Math.Sqrt(3) * a) / 2, y + a / 2);
		Point point4 = new Point(x, y + a);
		Point point5 = new Point(x - (int)(Math.Sqrt(3) * a) / 2, y + a / 2);
		Point point6 = new Point(x - (int)(Math.Sqrt(3) * a) / 2, y - a / 2);
		Point[] arr_point = { point1, point2, point3, point4, point5, point6 };
		e.Graphics.FillPolygon(new SolidBrush(_color), arr_point);
		if (_check)
		{
			e.Graphics.DrawPolygon(new Pen(System.Drawing.Color.Red, 3), arr_point);
		}
	}
	public override bool Equals(object obj)
	{
		if ((obj == null) || !this.GetType().Equals(obj.GetType()))
		{
			return false;
		}
		Hexagon p = (Hexagon)obj;
		return (x == p.x) && (y == p.y);
	}
	public override bool Is_inside(int x, int y)
	{
		if ((x - this.x) * (x - this.x) + (y - this.y) * (y - this.y) <= a * a)
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
	public override void resize(int dx)
	{
		a = dx;
	}
}
