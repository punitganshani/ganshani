namespace LockImpact.Interfaces
{
    public interface IArrayWorker<T>
    {
        T[] Data { get; set; }
        void Push(T data);
        T Pop();
    }
}
