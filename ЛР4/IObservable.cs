using System;

public interface IObservable
{
    void Notify();
    void AddObserver(IObserver obj);

}
