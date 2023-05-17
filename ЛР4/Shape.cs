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

    public abstract (string, int) outside(int width, int height);
    public abstract bool Is_inside(int x, int y);
    public abstract void corect_position(int width, int height, int dx = 0, string direct = "");
    public abstract void save(StreamWriter sr);
    public abstract void load(StreamReader file, Factory factory, int c);
    public abstract void apply(Handler handler);
    public abstract void change_position(int x, int y);
}

public abstract class figure: shape
{
    public int x;
    public int y;
    public int size;
    public Color _color = Color.Green;

    public abstract string get_name();
    public override void change_position(int x, int y)
    {
        this.x += x;
        this.y += y;
    }
    public override void apply(Handler handler)
    {
        handler.HandleFigure(this);
    }
    public override void load(StreamReader file, Factory factory, int count = 1)
    {
        string line = file.ReadLine();

        string[] parametrs = line.Split();
        x = int.Parse(parametrs[0]);
        y = int.Parse(parametrs[1]);
        size = int.Parse(parametrs[2]);
        _color = Color.FromArgb(int.Parse(parametrs[3]));
        _check = bool.Parse(parametrs[4]);
    }
    public override void save(StreamWriter sr)
    {
        string name = get_name();
        sr.WriteLine(name + " " + 1);
        sr.WriteLine(x + " " + y + " " + size + " " + _color.ToArgb() + " " + _check);
    }
    public override Color get_color()
    {
        return _color;
    }
    public override int get_size()
    {
        return size;
    }

    public override (string, int) outside(int width, int height)
    {
        if(x < size / 2)
        {
            return ("left", -(x - size/2));
        }
        else if(y < size / 2)
        {
            return ("top", -(y - size / 2));
        }
        else if (x > width - 3 - size / 2)
        {
            return ("right", width - x - 3  - size / 2);
        }
        else if (y > height - 3  - size / 2)
        {
            return ("bottom", height - 3 - y  - size / 2);
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
    }
}

public abstract class poligon_shape: figure
{
    public abstract Point[] calculate_vertex();
    public override void apply(Handler handler)
    {
        Drawer? dr = handler as Drawer;
        if (dr != null)
        {
            dr.HandlePoligon(this);
        }
        else
        {
            handler.HandleFigure(this);
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