using System.Xml.Linq;
using System;
using static List;
using System.Collections.Generic;

public class MyShapeList : MyList<shape>, IObservable, IObserver
{
    //public System.EventHandler observers;
    //public override void PushBack(shape v)
    //{
    //    base.PushBack(v);
    //    observers.Invoke(this, null);
    //}
    //public override bool remove(shape data)
    //{
    //    bool ans = base.remove(data);
    //    observers.Invoke(this, null);
    //    return ans;
    //}


    List<IObserver> observers;
    public MyShapeList() : base()
    {
        observers = new List<IObserver>();
    }
    public void OnObjectChanged(IObservable obj)
        {

            DeselectAll();
           TreeHandler tmp = (TreeHandler)obj;
   //         CIterator<Element> i = this.CreateIterator();
            int j = 0;
        for (Iterator<shape> i = this.CreateIterator(); !i.isEOL(); i.next(), j++)
        {
                if (tmp.treeView.Nodes[j].BackColor == Color.Gray)
                {
                    i.getCurrentItem().check();
                    // SelectElement(i.GetCurrent());
                }
            }
            Notify();
        }
        public void DeselectAll()
        {
  //          CIterator<Element> i = this.CreateIterator();
        for (Iterator<shape> i = this.CreateIterator(); !i.isEOL(); i.next())
        {
                if (i.getCurrentItem()._check)
                {
                    i.getCurrentItem().uncheck();
                }
            }
        }
        public void AddObserver(IObserver obj)
        {
            observers.Add(obj);
        }
        public void Notify()
        {
            foreach (IObserver obj in observers)
            {
                obj.OnObjectChanged(this);
            }
        }
        public void SelectElement(shape current)
        {
            current.check();
            Notify();
        }
        public void DeselectElement(shape current)
        {
            current.uncheck();
            Notify();
        }
        public override bool remove(shape value)
        {
            bool IsRemoved = base.remove(value);
            value.observable.Clear();
            value.observer.Clear();
        //    CIterator<Element> i = CreateIterator();
        for (Iterator<shape> i = CreateIterator(); !i.isEOL(); i.next())
        {
                if (i.getCurrentItem().observable.IsObserver(value))
                {
                    i.getCurrentItem().observable.RemoveObserver(value);
                }
            }
//            value.observer.Clear();
            if (IsRemoved)
                Notify();
            return IsRemoved;
        }

        public override void PushBack(shape value)
        {
            base.PushBack(value);
            Notify();
        }
        //public new void InsertAfter(Element value, Node<Element>? node)
        //{
        //    base.PushBack(value);
        //    Notify();
        //}
        //public void LoadFigures(StreamReader reader, FigureFactory factory)
        //{
        //    Element? curr = null;
        //    string? current_figure;
        //    int counter = 0;

        //    counter = Convert.ToInt32(reader.ReadLine());

        //    for (int i = 0; i < counter; i++)
        //    {
        //        current_figure = reader.ReadLine();
        //        curr = factory.CreateFigure(current_figure);
        //        if (curr != null)
        //        {
        //            curr.Load(reader, factory);
        //            PushBack(curr);
        //        }
        //    }
        //    Notify();
        //}

    }
