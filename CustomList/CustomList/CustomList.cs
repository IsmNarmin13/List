using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class CustomList<T>:IEnumerable<T>
    {
        private T[] items;
        private int count;
        private int capacity;

        public CustomList()
        {
            items = new T[0];
            count = 0;
            capacity = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public int Capacity
        {
            get { return capacity; }
        }

        public void Add(T item)
        {
            if (count == capacity)
            {
                if (capacity == 0)
                    capacity = 4;
                else
                    capacity *= 2;

                T[] newArray = new T[capacity];
                Array.Copy(items, newArray, count);
                items = newArray;
            }

            items[count] = item;
            count++;
        }

        public T Find(Predicate<T> match)
        {
            for (int i = 0; i < count; i++)
            {
                if (match(items[i]))
                    return items[i];
            }

            return default(T);
        }

        public CustomList<T> FindAll(Predicate<T> match)
        {
            CustomList<T> resultList = new CustomList<T>();

            for (int i = 0; i < count; i++)
            {
                if (match(items[i]))
                    resultList.Add(items[i]);
            }

            return resultList;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                    return true;
            }

            return false;
        }

        public bool Exists(Predicate<T> match)
        {
            for (int i = 0; i < count; i++)
            {
                if (match(items[i]))
                    return true;
            }

            return false;
        }

        public void Remove(T item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                for (int i = index; i < count - 1; i++)
                {
                    items[i] = items[i + 1];
                }

                count--;
            }
        }

        private int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
            {
                if (EqualityComparer<T>.Default.Equals(items[i], item))
                    return i;
            }

            return -1;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
