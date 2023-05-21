public abstract class poligon_shape : figure
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