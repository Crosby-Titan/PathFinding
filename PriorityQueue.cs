using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class PriorityQueue<T>: IEnumerable<T>
    {
        private List<T> elements;
        private IComparer<T> comparer;

        public int Count => elements.Count;

        public PriorityQueue(IComparer<T> comparer)
        {
            this.elements = new List<T>();
            this.comparer = comparer;
        }

        public void Enqueue(T item, int priority)
        {
            elements.Add(item);
            elements.Sort(comparer);
        }

        public void Enqueue(T item,double priority)
        {
            Enqueue(item, ((int)priority));
        }

        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException("Очередь пуста");

            T item = elements[0];
            elements.RemoveAt(0);
            return item;
        }

        public void Clear()
        {
            elements.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)elements).GetEnumerator();
        }
    }
}
