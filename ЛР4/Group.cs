using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static List;
public class Group: shape
{
    MyList<shape> groups = new MyList<shape>();

    public Group()
    {
        _check = true;
    }
    public override string outside(int width, int height)
    {
        for (Iterator<shape> i = groups.CreateIterator(); !i.isEOL(); i.next())
        {
            if (i.getCurrentItem().outside(width, height) != "inside")
            {
                return i.getCurrentItem().outside(width, height);
            }
        }
        return "inside";
    }
    public override void corect_position(int dx, string s, int width, int height)
    {
        for (Iterator<shape> i = groups.CreateIterator(); !i.isEOL(); i.next())
        {
            i.getCurrentItem().corect_position(dx, s, width, height);
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
    public override void resize(int dx, int width, int hight)
    {
        for (Iterator<shape> i = groups.CreateIterator(); !i.isEOL(); i.next())
        {
            i.getCurrentItem().resize(dx, width, hight);
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
