using System.Security.Cryptography.X509Certificates;

public abstract class shape
{
    public bool _check;
    public virtual void uncheck()
    {
        _check = false;
    }
    public virtual void check()
    {
        _check = true;
    }
    public abstract Color get_color();
    public abstract int get_size();
    public abstract void change_color(Color color);

    public abstract void resize(int dx);

    public abstract void move(Keys k);

    public abstract (string, int) outside(int width, int height);
 //   public abstract void corect_position();

    public abstract void paint_shape(PaintEventArgs e);
    public abstract bool Is_inside(int x, int y);
    public abstract void corect_position(int width, int height, int dx = 0, string direct = "");
}

public abstract class figure: shape
{
    public int x;
    public int y;
    public int size;
    public Color _color = Color.Green;

    public override Color get_color()
    {
        return _color;
    }
    public override int get_size()
    {
        return size;
    }
    public override void change_color(Color color)
    {
        _color = color;
    }
    public override void resize(int new_size)
    {
 //       int dx = new_size / size;
        size = new_size;
 //       corect_position(width, hight);
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

    public override (string, int) outside(int width, int height)
    {
        //if((x < size / 2) || (y < size / 2) || (x > width - 3 - size / 2) || (y > height - 3 - size / 2))
        //    return true;
        //return false;
        if(x < size / 2)
        {
            return ("left", -(x - size/2));
 //           corect_position_left();
        }
        else if(y < size / 2)
        {
            return ("top", -(y - size / 2));
        //    corect_position_top();
        }
        else if (x > width - 3 - size / 2)
        {
            return ("right", width - x - 3  - size / 2);
        //    corect_position_right(width);
        }
        else if (y > height - 3  - size / 2)
        {
            return ("bottom", height - 3 - y  - size / 2);
        //    corect_position_bottom(height);
        }
        else
        {
            return ("inside", 0);
        }
    }

    public override void corect_position(int width, int height, int dx = 0, string direct = "")
    {
        if (direct == "")
        {
            (direct, dx) = outside(width, height);
        }
        if (direct == "left" || direct == "right")
        {
            x += dx;
            corect_position(width, height);
        }
        if (direct == "top" || direct == "bottom")
        {
            y += dx;
            corect_position(width, height);
        }
        //if (direct == "right")
        //{
        //    x -= dx;
        //}
        //if (direct == "bottom")
        //{
        //    y -= dx;
        //}
 //       corect_position(width, height);
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