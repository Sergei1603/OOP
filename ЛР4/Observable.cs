using System.Drawing.Drawing2D;
using System.Xml.Linq;

public class observable
{
        public List<shape> observers { get; }
    public List<bool> visited { get; }
 //   List<shape> lines;

    public observable()
    {
        observers = new List<shape>();
  //      lines = new List<shape>();
        visited = new List<bool>();
    }

    public void NotifyObservers(Mover mover)
    {
        for (int i = 0; i < observers.Count; i++)
        {
            if (visited[i] == false)
            {
                visited[i] = true;
                observers[i].apply(mover);
                //if (observers[i].outside(width, height).Item1 != "inside")
                //{
                //    observers[i].apply(mover[1]);
                //}
                // visited[i] = true;
            }
        }
    }

    public void NotifyObservers(int dx, int dy, int width, int height)
    {
        for (int i = 0; i < observers.Count; i++)
        {
           if (visited[i] == false)
            {
               visited[i] = true;
                observers[i].change_position(dx, dy, width, height);
    //            observers[i].corect_position(width, height);
      //          observers[i].observable.NotifyObservers(dx, dy, width, height);
                //if (observers[i].outside(width, height).Item1 != "inside")
                //{
                //    observers[i].apply(mover[1]);
                //}
     //            visited[i] = true;
            }
        }
    }
    public void AddObserver(shape e)
    {
        observers.Add(e);
        visited.Add(false);
    }
    public void RemoveObserver(shape e)
    {
        observers.Remove(e);
    }
    public void Clear()
    {
        observers.Clear();
        visited.Clear();
    }
    public bool IsObserver(shape e)
    {
        return observers.Contains(e);
    }

    public void ShowLines(float start_x, float start_y, PaintEventArgs pict)
    {
        foreach (shape e in observers)
        {
            Pen pen = new Pen(Color.Black, 1.0f);
            pen.CustomEndCap = new AdjustableArrowCap(6, 6, true);
            pict.Graphics.DrawLine(pen, start_x, start_y, e.get_center().X, e.get_center().Y);
        }
    }
    internal void ToDefault()
    {
        for (int i = 0; i < visited.Count; i++)
        {
            visited[i] = false;
        }
    }
}