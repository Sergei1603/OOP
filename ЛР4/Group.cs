using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static List;
public class Group: shape
{
    public MyList<shape> groups = new MyList<shape>();

    public Group()
    {
        _check = true;
    }
    public MyList<shape> delete_group()
    {
        return groups;
    }
    public override (string, int) outside(int width, int height)
    {
        for (Iterator<shape> i = groups.CreateIterator(); !i.isEOL(); i.next())
        {
            if (i.getCurrentItem().outside(width, height).Item1 != "inside")
            {
                return i.getCurrentItem().outside(width, height);
            }
        }
        return ("inside", 0);
    }
    public override void corect_position(int width, int height, int dx = 0, string direct = "")
    {
        if (direct == "")
        {
            (direct, dx) = outside(width, height);
        }
        for (Iterator<shape> i = groups.CreateIterator(); !i.isEOL(); i.next())
        {
            i.getCurrentItem().corect_position(width, height, dx, direct);
        }
    }
    public override void uncheck()
    {
        _check = false;
        for (Iterator<shape> i = groups.CreateIterator(); !i.isEOL(); i.next())
        {
            i.getCurrentItem().uncheck();
        }
    }
    public override void check()
    {
        _check = true;
        for (Iterator<shape> i = groups.CreateIterator(); !i.isEOL(); i.next())
        {
            i.getCurrentItem().check();
        }
    }
    public override Color get_color()
    {
        return groups.first.val.get_color();
    }

    public override int get_size()
    {
        return groups.first.val.get_size();
    }
    public void add(shape shape)
    {
        groups.PushBack(shape);
    }
    public override void move(Keys key)
    {
        for (Iterator<shape> i = groups.CreateIterator(); !i.isEOL(); i.next())
        {
            i.getCurrentItem().move(key);
        }
    }
    public override void paint_shape(PaintEventArgs e)
    {
        for (Iterator<shape> i = groups.CreateIterator(); !i.isEOL(); i.next())
        {
            i.getCurrentItem().paint_shape(e);
        }
    }
    public override void change_color(Color color)
    {
        for (Iterator<shape> i = groups.CreateIterator(); !i.isEOL(); i.next())
        {
            i.getCurrentItem().change_color(color);
        }
    }
    public override void resize(int dx)
    {
        for (Iterator<shape> i = groups.CreateIterator(); !i.isEOL(); i.next())
        {
            i.getCurrentItem().resize(dx);
        }
    }
   
    public override bool Is_inside(int x, int y)
    {
        for (Iterator<shape> i = groups.CreateIterator(); !i.isEOL(); i.next())
        {
            if (i.getCurrentItem().Is_inside(x, y))
                return true;
        }
        return false;
    }
}
