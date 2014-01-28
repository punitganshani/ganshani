using System;
using LockImpact.Interfaces;

namespace LockImpact.Worker
{
    public class ArrayWorkerQueue<T> : IArrayWorker<T>
    {
        public T[] Data { get; set; }

        private int _tail;

        public ArrayWorkerQueue(int capacity)
        {
            Data = new T[capacity];
            _tail = 0;
        }

        public void Push(T data)
        {
            if (_tail >= Data.Length)
                throw new InvalidOperationException("Capacity already reached");

            Data[_tail] = data;
            _tail++;
        }

        public T Pop()
        {
            if (_tail > Data.Length || _tail < 0)
                throw new InvalidOperationException("Capacity already reached");

            return Data[--_tail];
        }
    }
}
