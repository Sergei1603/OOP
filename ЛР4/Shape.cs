using System.Security.Cryptography.X509Certificates;

public abstract class shape
{
    public int x;
    public int y;
    public int size;
    public bool _check;
    public Color _color = Color.Green;
    public abstract bool Is_inside(int x, int y);
    public void uncheck()
    {
        _check = false;
    }
    public void check()
    {
        _check = true;
    }
    public void change_color(Color color)
    {
        _color = color;
    }
    public void resize(int dx)
    {
        size = dx;
    }
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
        if (x < size / 2)
        {
            x = size / 2;
        }
        if (y < size / 2)
        {
            y = size / 2;
        }
        if (x > width - size / 2)
        {
            x = width - size / 2;
        }
        if (y > height - size / 2)
        {
            y = height - size / 2;
        }
    }
    public abstract void paint_shape(PaintEventArgs e);

}

public abstract class poligon_shape: shape
{
    public abstract Point[] calculate_vertex();
    public override void paint_shape(PaintEventArgs e)
    {
        e.Graphics.FillPolygon(new SolidBrush(_color), calculate_vertex());
        if (_check)
        {
            e.Graphics.DrawPolygon(new Pen(System.Drawing.Color.Red, 3), calculate_vertex());
        }
    }
    public override bool Is_inside(int x, int y)
    {
        bool result = false;
		Point[] p = calculate_vertex();
        int j = p.Length - 1;
        for (int i = 0; i < p.Length; i++)
        {
            if ((((p[i].Y <= y) && (y < p[j].Y)) || ((p[j].Y <= y) && (y < p[i].Y))) &&
        (((p[j].Y - p[i].Y) != 0) && (x > ((p[j].X - p[i].X) * (y - p[i].Y) / (p[j].Y - p[i].Y) + p[i].X))))
                result = !result;
            j = i;
        }
		return result;
    }
}