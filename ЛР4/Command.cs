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
    public MoveCommand(Keys key)
    {
        this.key = key;
        selection = null;
    }
    public override void execute(shape selection)
    {
        this.selection = selection;
        if (selection != null)
        {
            selection.move(key);
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
        return new MoveCommand(key);
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
    int width;
    int hight;
    public ChangeSizeCommand(int size, int width, int hight)
    {
        this.size = size;
        selection = null;
        this.width = width;
        this.hight = hight;
    }
    public override void execute(shape selection)
    {
        pre_size = selection.get_size();
        this.selection = selection;
        if (selection != null)
        {
            selection.resize(size, width, hight);
        }
    }
    public override void unexecute()
    {
        if (selection != null)
        {
            selection.resize(pre_size, width, hight);
        }
    }
    public override command clone()
    {
        return new ChangeSizeCommand(size, width, hight);
    }
}