namespace Task5_PrototypePattern.Abstractions
{
    internal interface IMyCloneable<T> where T: class
    {
        T MyClone();
    }
}
