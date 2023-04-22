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
    public class Ccircle : shape
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

public class Square : shape
{
    public int r = 25;
    public Square(int x, int y)
    {
        this.x = x;
        this.y = y;
        _check = true;
    }
    public override void paint_shape(PaintEventArgs e)
    {
        e.Graphics.FillRectangle(Brushes.Red, x - r, y - r, r * 2, r * 2);
        if (_check)
        {
            e.Graphics.DrawRectangle(new Pen(System.Drawing.Color.Green, 5), x - r, y - r, r * 2, r * 2);
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

public class Triangle : shape
{
    public int r = 50;
    public Triangle(int x, int y)
    {
        this.x = x;
        this.y = y;
        _check = true;
    }
    public override void paint_shape(PaintEventArgs e)
    {
        Point point1 = new Point(x, (int)(y - r * Math.Sqrt(3) / 2));
        Point point2 = new Point(x - r /2, (int)(y + (r * Math.Sqrt(3) / 6)));
        Point point3 = new Point(x + r / 2, (int)(y + (r * Math.Sqrt(3) / 6)));
        Point[] arr_point = {point1, point2, point3};
        e.Graphics.FillPolygon(Brushes.Red, arr_point);
        if (_check)
        {
            e.Graphics.DrawPolygon(new Pen(System.Drawing.Color.Green, 5), arr_point);
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

public class hexagon : shape
{
    public int r = 25;
    public hexagon(int x, int y)
    {
        this.x = x;
        this.y = y;
        _check = true;
    }
    public override void paint_shape(PaintEventArgs e)
    {
        Point point1 = new Point(x, y - r);
        Point point2 = new Point(x + (int)(Math.Sqrt(3) * r)/2, y - r/2);
        Point point3 = new Point(x + (int)(Math.Sqrt(3) * r)/2, y + r/2);
        Point point4 = new Point(x, y + r);
        Point point5 = new Point(x - (int)(Math.Sqrt(3) * r) / 2, y + r / 2);
        Point point6 = new Point(x - (int)(Math.Sqrt(3) * r) / 2, y - r / 2);
        Point[] arr_point = { point1, point2, point3, point4, point5, point6 };
        e.Graphics.FillPolygon(Brushes.Red, arr_point);
        if (_check)
        {
            e.Graphics.DrawPolygon(new Pen(System.Drawing.Color.Green, 5), arr_point);
        }
    }
    public override bool Equals(object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        hexagon p = (hexagon)obj;
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
