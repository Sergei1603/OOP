using System.Security.Cryptography.X509Certificates;

public abstract class shape
{
    public observer observer;
    public observable observable;
    public bool _check;
    public shape()
    {
        observer = new observer();
        observable = new observable();
    }
    public virtual void uncheck()
    {
        _check = false;
    }
    public virtual void check()
    {
        _check = true;
    }
    public abstract Color get_color();
    public abstract int get_size();

    public abstract (string, int) outside(int width, int height);
    public abstract bool Is_inside(int x, int y);
    public abstract void corect_position(int width, int height, int dx = 0, string direct = "");
    public abstract void save(StreamWriter sr);
    public abstract void load(StreamReader file, Factory factory, int c);
    public abstract void apply(Handler handler);
    public abstract void change_position(int x, int y, int width, int height);
    public abstract string get_name();
    public abstract Point get_center();
}