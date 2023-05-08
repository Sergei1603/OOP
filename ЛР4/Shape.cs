using System.Security.Cryptography.X509Certificates;

public abstract class shape
{
    public bool _check;
    public void uncheck()
    {
        _check = false;
    }
    public void check()
    {
        _check = true;
    }
    public abstract void change_color(Color color);

    public abstract void resize(int dx);

    public abstract void move(Keys k);

    public abstract bool Is_Outside(int width, int height);
    public abstract void corect_position();

    public abstract void paint_shape(PaintEventArgs e);
}

public abstract class figure: shape
{
    public int x;
    public int y;
    public int size;
    public Color _color = Color.Green;
    public override void change_color(Color color)
    {
        _color = color;
    }
    public override void resize(int dx)
    {
        size = dx;
    }
    public override void move(Keys k)
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

    public override bool Is_Outside(int width, int height)
    {
        if((x < size / 2) || (y < size / 2) || (x > width - 3 - size / 2) || (y > height - 3 - size / 2))
            return true;
        return false;
    }
    public override void corect_position()
    {

            x = size / 2;
            y = size / 2;
    }
}

public abstract class poligon_shape: figure
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
    public bool Is_inside(int x, int y)
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