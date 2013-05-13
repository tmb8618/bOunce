using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace game_v0._1
{/*
    class List<T> : IList<T>
    {
        T[] array;
        int size;
        public int Count
        {
            get
            {
                return size;
            }
        }

        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }

        public List()
        {
            array = new T[10];
            size = 0;
        }

        public List(int capacity)
        {
            array = new T[capacity];
            size = 0;
        }

        /// <summary>
        /// Adds an object to the array
        /// </summary>
        /// <param name="addition">the item to be added to the list</param>
        public void Add(T addition)
        {
            if (array.Length <= size)
            {
                T[] newArray = new T[2 * size];
                for (int i = 0; i < array.Length; i++)
                {
                    newArray[i] = array[i];
                }
                array = newArray;
            }
            array[size] = addition;
            size++;
        }

        public void Add(List<T> addition)
        {
            foreach (T item in addition)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Removes and returns the value at the given index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T RemoveAt(int index)
        {
            if (index >= size || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            T value = array[index];
            for (int i = index; i + 1 < size; i++)
            {
                array[i] = array[i + 1];
            }
            size--;
            return value;
        }

        public T Remove(T target)
        {
            return RemoveAt(IndexOf(target));
        }

        public int IndexOf(T target)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(target))
                {
                    return i;
                }
            }
            return -1;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListEnumerator<T>(array);
        }
    }*/
}
