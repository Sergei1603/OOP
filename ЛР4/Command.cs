using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using static List;
public abstract class command
{
    public abstract void execute(shape selection);
    public abstract void unexecute();
    public abstract command clone();
}

public class MoveCommand: command
{
    shape selection;
    //int width;
    //int hight;
    Mover[] movers;

    public void update_edgs(int width, int hight)
    {
        //this.width = width;
        //this.hight = hight;
        movers[0].update_size(width, hight);
        movers[1].update_size(width, hight);
    }
    public MoveCommand(Mover[] movers)
    {
        selection = null;
        //this.width = width;
        //this.hight = hight;
        this.movers = movers;
        //movers[0].update_size(width, hight);
        //movers[1].update_size(width, hight);
    }
    public override void execute(shape selection)
    {
        this.selection = selection;
        if (selection != null)
        {
            selection.apply(movers[0]);
            //if(selection.outside(width, hight).Item1 != "inside")
            //{
            //    unexecute();
            //}
    //        selection.observable.NotifyObservers(movers[0], width, hight);
        }
    }
    public override void unexecute()
    {
        if (selection != null)
        {
            selection.apply(movers[1]);
  //          selection.observable.NotifyObservers(movers[1], width, hight);
        }
    }
    public override command clone()
    {
        return new MoveCommand(movers);
    }
}

public class ChangeColorCommand : command
{
    shape selection;
    Changer_color changer;
    Color pre_color;
    public ChangeColorCommand(Changer_color changer)
    {
        this.changer = changer;
        selection = null;
    }
    public override void execute(shape selection)
    {
        pre_color = selection.get_color();
        this.selection = selection;
        if (selection != null)
        {
            selection.apply(changer);
        }
    }
    public override void unexecute()
    {
        if (selection != null)
        { 
            Changer_color pre_change = new Changer_color(pre_color);
            selection.apply(pre_change);
        }
    }
    public override command clone()
    {
        return new ChangeColorCommand(changer);
    }
}

public class ChangeSizeCommand : command
{
    shape selection;
    int pre_size;
    Resizer resizer;

    public ChangeSizeCommand(Resizer resizer)
    {
        this.resizer = resizer;
        selection = null;
    }
    public override void execute(shape selection)
    {
        pre_size = selection.get_size();
        this.selection = selection;
        if (selection != null)
        {
            selection.apply(resizer);
        }
    }
    public override void unexecute()
    {
        if (selection != null)
        {
            Resizer pre_resizer = new Resizer(pre_size);
            selection.apply(resizer);
        }
    }
    public override command clone()
    {
        return new ChangeSizeCommand(resizer);
    }
}

public class MakeGroupCommand : command
{
    MyList <shape> shapes;
    Group selection;
    public MakeGroupCommand(MyList <shape> shapes)
    {
        this.shapes = shapes;
    }
    public override void execute(shape selection)
    {
        this.selection = (Group)selection;
        if (selection != null)
        {
            for (Iterator<shape> i = shapes.CreateIterator(); !i.isEOL(); i.next())
            {
                if (i.getCurrentItem()._check)
                {
                    this.selection.add(i.getCurrentItem());
                    i.remove();
                }
            }
            shapes.PushBack(selection);
        }
    }
    public override void unexecute()
    {
        if (selection != null)
        {
            for (Iterator<shape> i = shapes.CreateIterator(); !i.isEOL(); i.next())
            {
                if (i.getCurrentItem()._check && i.getCurrentItem() is Group)
                {
                    Group g = (Group)i.getCurrentItem();
                    for (Iterator<shape> j = g.delete_group().CreateIterator(); !j.isEOL(); j.next())
                        shapes.PushFront(j.getCurrentItem());
                    i.remove();
                }
            }
        }
    }
    public override command clone()
    {
        return new MakeGroupCommand(shapes);
    }
}

public class DeleteGroupCommand : command
{
    public MyList<shape> shapes;
    Group selection;
    public DeleteGroupCommand(MyList<shape> shapes)
    {
        this.shapes = shapes;
    }
    public override void execute(shape selection)
    {
        this.selection =(Group)selection;
        if (selection != null)
        {
            for (Iterator<shape> i = shapes.CreateIterator(); !i.isEOL(); i.next())
            {
                if (i.getCurrentItem()._check && i.getCurrentItem() is Group)
                {
                    Group g = (Group)i.getCurrentItem();
                    for (Iterator<shape> j = g.delete_group().CreateIterator(); !j.isEOL(); j.next())
                        shapes.PushFront(j.getCurrentItem());
                    i.remove();
                }
            }
        }
    }
    public override void unexecute()
    {
        if (selection != null)
        {
            for (Iterator<shape> i = selection.groups.CreateIterator(); !i.isEOL(); i.next())
            {
                shapes.remove(i.getCurrentItem());
            }
             selection.check();
            shapes.PushBack(selection);
            
        }
    }
    public override command clone()
    {
        return new DeleteGroupCommand(shapes);
    }
}

public class DeleteCommand : command
{
    shape deleted;
    MyList<shape> list;
    public DeleteCommand(MyList<shape> list)
    {
        this.list = list;
    }
    public override void execute(shape selection)
    {
        deleted = selection;
        for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
        {
            if(i.getCurrentItem() == selection)
            {
                i.previos();
                if (i.cur_item != null)
                {
                    i.getCurrentItem().check();
                }
                break;
            }
        }
        list.remove(selection);
    }
    public override void unexecute()
    {
        list.PushBack(deleted);
    }
    public override command clone()
    {
        return new DeleteCommand(list);
    }
}

public class MakeCommand : command
{
    MyList<shape> list;
    shape shape;
    public MakeCommand(MyList<shape> list)
    {
        this.list= list;
    }
    public override void execute(shape selection)
    {
        shape = selection;
        list.PushBack(selection);
    }
    public override void unexecute()
    {
        for (Iterator<shape> i = list.CreateIterator(); !i.isEOL(); i.next())
        {
            if (i.getCurrentItem() == shape)
            {
                i.previos();
                if(i.cur_item != null)
                    i.getCurrentItem().check();
                break;
            }
        }
        list.remove(shape);
    }
    public override command clone()
    {
        return new MakeCommand(list);
    }
}

public class ChangePositionCommand : command
{
    int sum_dx = 0;
    int sum_dy = 0;
    int dx;
    int dy;
    shape selection;
    int width;
    int height;
    public ChangePositionCommand(int dx, int dy, int width, int height)
    {
        this.dx= dx;
        this.dy= dy;
        this.width= width;
        this.height= height;
    }
    public override void execute(shape selection)
    {
        this.selection = selection;
        if (selection != null)
        {
            selection.change_position(dx, dy, width, height);
            //           selection.corect_position(width, height);
            //           selection.observable.NotifyObservers(dx, dy, width, height);
                     sum_dx += dx;
            sum_dy += dy;
        }
    }
    public override void unexecute()
    {
        if (selection != null)
        {
            selection.change_position(-sum_dx, -sum_dy, width, height);
      //      selection.observable.NotifyObservers(-sum_dx, -sum_dy, width, height);
        }
    }
    public override command clone()
    {
        return new ChangePositionCommand(dx, dy, width, height);
    }
}