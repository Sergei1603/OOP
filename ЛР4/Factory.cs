using System.Drawing;
using static List;

public class storage
{
    public MyList<shape> list;
    public storage(MyList<shape> list)
    {
        this.list = list;
    }
    public void load(string filename, Factory factory)
    {
        StreamReader sr = new StreamReader(filename);
        string? line;
        line = sr.ReadLine();
        while (line != "" && line != null)
        {
            string[] parameters = line.Split();
            shape shape = factory.create_shape(parameters[0]);
            shape.load(line);
            list.PushBack(shape);
            //      list.PushBack(factory.create_shape(parameters[0], Int32.Parse(parameters[1]), Int32.Parse(parameters[2]), Int32.Parse(parameters[3]), Color.FromName(parameters[4])));
            line = sr.ReadLine();
        }
        sr.Close();

        // StreamReader sr = new StreamReader(filename);
        // string? line;
        //line = sr.ReadToEnd();
        //string[] parameters = line .Split(";\n");
    }
}

public abstract class Factory
{
    public abstract shape create_shape(string code, int x, int y, int size, Color color);
    public abstract shape create_shape(string code);

}
public class shapeFactory: Factory
{
    public override shape create_shape(string code)
    {
        shape s = null;
        switch (code)
        {
            case "Круг":
                s = new Ccircle(0, 0, 10, Color.Green);
                break;
            case "Квадрат":
                s = new Square(0, 0, 10, Color.Green);
                break;
            case "Треугольник":
                s = new Triangle(0, 0, 10, Color.Green);
                break;
            case "Шестиугольник":
                s = new Hexagon(0, 0, 10, Color.Green);
                break;
            case "Группа":
                s = new Group();
                break;
            default: return null;
        }
        return s;
    }
    public override shape create_shape(string code, int x, int y, int size, Color color)
    {
        shape s = null;
        switch (code)
        {
            case "Круг":
                s = new Ccircle(x, y, size, color);
                break;
            case "Квадрат":
                s = new Square(x, y, size, color);
                break;
            case "Треугольник":
                s = new Triangle(x, y, size, color);
                break;
            case "Шестиугольник":
                s = new Hexagon(x, y, size, color);
                break;  
            default: return null;
        }
        return s;
    } 
}
