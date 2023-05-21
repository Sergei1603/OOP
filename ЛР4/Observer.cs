using System.Xml.Linq;

public class observer
{
        public List<shape> parents { get; }
        public observer()
        {
            parents = new List<shape>();
        }

        public void AddPerent(shape shape)
        {
            parents.Add(shape);
        }
        public void RemovePerent(shape shape)
        {
            parents.Remove(shape);
        }
        public bool IsParent(shape shape)
        {
            return parents.Contains(shape);
        }
        public void Clear()
        {
            parents.Clear();
        }
        public void Changed(PaintEventArgs e)
        {
            foreach (shape shape in parents)
            {
                shape.observable.ShowLines(shape.get_center().X, shape.get_center().Y, e);
            }
        }
}