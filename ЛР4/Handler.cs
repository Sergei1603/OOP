using System.Drawing;
using static List;

public abstract class Handler
{ 
    public virtual void HandlePoligon(poligon_shape poligon) { }
    public virtual void HandleCircle(Ccircle circle) { }
    public virtual void HandleFigure(figure figure) { }
    public virtual void HandleGroup(Group group)
    {
        for (Iterator<shape> i = group.groups.CreateIterator(); !i.isEOL(); i.next())
        {
            i.getCurrentItem().apply(this);
        }
    }
}

public class Drawer: Handler
{
    public PaintEventArgs e;

    public Drawer(PaintEventArgs e)
    {
        this.e = e;
    }
    public override void HandleCircle(Ccircle circle)
    {
        e.Graphics.FillEllipse(new SolidBrush(circle._color), circle.x - circle.size / 2, circle.y - circle.size / 2, circle.size, circle.size);
        if (circle._check)
        {
            e.Graphics.DrawEllipse(new Pen(System.Drawing.Color.Red, 3), circle.x - circle.size / 2, circle.y - circle.size / 2, circle.size, circle.size);
        }
    }
    public override void HandlePoligon(poligon_shape poligon)
    {
        e.Graphics.FillPolygon(new SolidBrush(poligon._color), poligon.calculate_vertex());
        if (poligon._check)
        {
            e.Graphics.DrawPolygon(new Pen(System.Drawing.Color.Red, 3), poligon.calculate_vertex());
        }
    }
}
public class Mover : Handler
{
    Keys key;
    public Mover(Keys key)
    {
        this.key = key;
    }
    public override void HandleFigure(figure figure)
    {
        switch (key)
        {
            case Keys.A:
                figure.x -= 5;
                break;
            case Keys.D:
                figure.x += 5;
                break;
            case Keys.W:
                figure.y -= 5;
                break;
            case Keys.S:
                figure.y += 5;
                break;
        }
    }
}

public class Changer_color: Handler
{
    public Color color;
    public Changer_color(Color color)
    {
        this.color = color;
    }
    public override void HandleFigure(figure figure)
    {
        figure._color = color;
    }
}

public class Resizer : Handler
{
    public int size;
    public Resizer(int size)
    {
        this.size = size;
    }
    public override void HandleFigure(figure figure)
    {
        figure.size = size;
    }
}
