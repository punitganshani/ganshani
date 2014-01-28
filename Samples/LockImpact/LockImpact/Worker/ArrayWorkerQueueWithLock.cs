using System;
using LockImpact.Interfaces;

namespace LockImpact.Worker
{
    public class ArrayWorkerQueueWithLock<T> : IArrayWorker<T>
    {
        public T[] Data { get; set; }

        private int _tail;

        private readonly object _sync;

        public ArrayWorkerQueueWithLock(int capacity)
        {
            Data = new T[capacity];
            _tail = 0;
            _sync = new object();
        }

        public void Push(T data)
        {
            lock (_sync)
            {
                if (_tail >= Data.Length)
                    throw new InvalidOperationException("Capacity already reached");

                lock (_sync)
                {
                    Data[_tail] = data;
                    _tail++;
                }
            }
        }

        public T Pop()
        {
            lock (_sync)
            {
                if (_tail > Data.Length || _tail < 0)
                    throw new InvalidOperationException("Capacity already reached");

                lock (_sync)
                {
                    return Data[--_tail];
                }
            }
        }
    }
}
