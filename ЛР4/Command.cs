using System.Collections.Generic;
using System.Drawing;
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
    Keys key;
    int width;
    int hight;
    public MoveCommand(Keys key, int width, int hight)
    {
        this.key = key;
        selection = null;
        this.width = width;
        this.hight = hight;
    }
    public override void execute(shape selection)
    {
        this.selection = selection;
        if (selection != null)
        {
            selection.move(key);
            if(selection.outside(width, hight).Item1 != "inside")
            {
                unexecute();
            }
        }
    }
    public override void unexecute()
    {
        if (selection != null)
        {
            switch (key)
            {
                case Keys.A:
                    selection.move(Keys.D);
                    break;
                case Keys.D:
                    selection.move(Keys.A);
                    break;
                case Keys.W:
                    selection.move(Keys.S); break;
                case Keys.S:
                    selection.move(Keys.W);
                    break;
            }
        }
    }
    public override command clone()
    {
        return new MoveCommand(key, width, hight);
    }
}

public class ChangeColorCommand : command
{
    shape selection;
    Color color;
    Color pre_color;
    public ChangeColorCommand(Color color)
    {
        this.color = color;
        selection = null;
    }
    public override void execute(shape selection)
    {
        pre_color = selection.get_color();
        this.selection = selection;
        if (selection != null)
        {
            selection.change_color(color);
        }
    }
    public override void unexecute()
    {
        if (selection != null)
        {
            selection.change_color(pre_color);
        }
    }
    public override command clone()
    {
        return new ChangeColorCommand(color);
    }
}

public class ChangeSizeCommand : command
{
    shape selection;
    int size;
    int pre_size;

    public ChangeSizeCommand(int size)
    {
        this.size = size;
        selection = null;
    }
    public override void execute(shape selection)
    {
        pre_size = selection.get_size();
        this.selection = selection;
        if (selection != null)
        {
            selection.resize(size);
        }
    }
    public override void unexecute()
    {
        if (selection != null)
        {
            selection.resize(pre_size);
        }
    }
    public override command clone()
    {
        return new ChangeSizeCommand(size);
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
    public override command clone()
    {
        return new MakeGroupCommand(shapes);
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