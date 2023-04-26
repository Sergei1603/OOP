public class Factory
{
    List<shape> shapes;
    public virtual shape create_shape(string code, int x, int y, int size, Color color)
    {
        return null;
    }
}
public class shapeFactory: Factory
{
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
