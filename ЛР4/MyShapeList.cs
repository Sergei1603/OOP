using System.Xml.Linq;
using System;
using static List;
using System.Collections.Generic;

public class MyShapeList : MyList<shape>, IObservable, IObserver
{

    List<IObserver> observers;
    public MyShapeList() : base()
    {
        observers = new List<IObserver>();
    }
    public void OnObjectChanged(IObservable obj)
        {

            DeselectAll();
           TreeHandler tmp = (TreeHandler)obj;
            int j = 0;
        for (Iterator<shape> i = this.CreateIterator(); !i.isEOL(); i.next(), j++)
        {
                if (tmp.treeView.Nodes[j].BackColor == Color.Gray)
                {
                    i.getCurrentItem().check();
                }
            }
            Notify();
        }
        public void DeselectAll()
        {
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
        for (Iterator<shape> i = CreateIterator(); !i.isEOL(); i.next())
        {
                if (i.getCurrentItem().observable.IsObserver(value))
                {
                    i.getCurrentItem().observable.RemoveObserver(value);
                }
            }
            if (IsRemoved)
                Notify();
            return IsRemoved;
        }

        public override void PushBack(shape value)
        {
            base.PushBack(value);
            Notify();
        }
    }
