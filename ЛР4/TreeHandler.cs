using static List;
using System.Xml.Linq;
using System.Collections.Generic;

public class TreeHandler : IObserver, IObservable
{
    internal TreeView treeView;
    List<IObserver> observers;
 //   List<MyShapeList> observers;
    public TreeHandler(TreeView tree)
    {
        observers = new List<IObserver>();
        treeView = tree;
    }

    public void AddObserver(IObserver obj)
    {
        observers.Add(obj);
    }
    public void Notify()
    {
        foreach (IObserver obs in observers)
        {
            obs.OnObjectChanged(this);
        }
    }

    public void OnObjectChanged(IObservable o)
    {
        treeView.Nodes.Clear();
        MyShapeList tmp = (MyShapeList)o;
//        CIterator<Element> i = tmp.CreateIterator();
        for (Iterator<shape> i = tmp.CreateIterator(); !i.isEOL(); i.next())
        {
            TreeNode new_node = new TreeNode(i.getCurrentItem().get_name());
            if (i.getCurrentItem()._check)
            {
                new_node.BackColor = Color.Gray;
                new_node.Expand();
            }
            else
            {
                new_node.Collapse();
            }
            if (i.getCurrentItem() is Group)
            {
                ProcessNode(new_node, i.getCurrentItem());
            }
            treeView.Nodes.Add(new_node);
        }
        // treeView.Refresh();
    }
    public void ProcessNode(TreeNode tr, shape elem)
    {
        if (elem is Group)
        {
            Group g = (Group)elem;
            MyShapeList tmp = (MyShapeList)g.groups;
   //         CIterator<Element> i = tmp.CreateIterator();
            for (Iterator<shape> i = tmp.CreateIterator(); !i.isEOL(); i.next())
            {
                TreeNode new_node = new TreeNode(i.getCurrentItem().get_name());
                if (i.getCurrentItem()._check)
                {
                    new_node.BackColor = Color.Gray;
                    new_node.Expand();
                }
                else
                {
                    new_node.Collapse();
                }
                ProcessNode(new_node, i.getCurrentItem());
                tr.Nodes.Add(new_node);
            }
        }
    }
}
