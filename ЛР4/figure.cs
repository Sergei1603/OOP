
public abstract class figure : shape
{
    public int x;
    public int y;
    public int size;
    public Color _color = Color.Green;

    public override Point get_center()
    {
        return new Point(x, y);
    }

    public override void change_position(int x, int y, int width, int height)
    {
        this.x += x;
        this.y += y;
        corect_position(width, height);
        observable.NotifyObservers(x, y, width, height);
        observable.ToDefault();
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
        if (x < size / 2)
        {
            return ("left", -(x - size / 2));
        }
        else if (y < size / 2)
        {
            return ("top", -(y - size / 2));
        }
        else if (x > width - 3 - size / 2)
        {
            return ("right", width - x - 3 - size / 2);
        }
        else if (y > height - 3 - size / 2)
        {
            return ("bottom", height - 3 - y - size / 2);
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