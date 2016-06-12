namespace GenericList
{
    using System;
    using System.Text;

    public class Generic<T>
        where T : IComparable
    {
        private uint counter;
        private T[] genericList;

        public uint Capacity { get; private set; }

        public Generic()
        {
            this.Capacity = 4;
            this.genericList = new T[Capacity];
            this.counter = 0;
        }

        public Generic(uint capacity)
        {
            this.Capacity = capacity;
            this.genericList = new T[capacity];
            this.counter = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index >= counter || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                T atIndex = genericList[index];
                return atIndex;
            }
        }

        public void Add(T item)
        {
            if (this.counter >= this.Capacity)
            {
                Capacity *= 2;
                T[] temp = new T[Capacity];
                genericList.CopyTo(temp, 0);
                genericList = temp;
            }

            this.genericList[counter] = item;
            this.counter++;
        }

        public void RemoveElementAtIndex(int index)
        {
            if (index >= counter || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            T[] temp = new T[Capacity];
            genericList.CopyTo(temp, 0);
            genericList = new T[Capacity];

            for (int i = 0, j = 0; i < temp.Length; i++, j++)
            {
                if (i == index)
                {
                    j--;
                    continue;
                }

                genericList[j] = temp[i];
            }

            this.counter--;
        }

        public void Insert(T element, int index)
        {
            if (index > this.counter || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (counter == Capacity)
            {
                Capacity *= 2;
            }

            T[] temp = new T[this.Capacity];
            this.genericList.CopyTo(temp, 0);
            this.genericList = new T[this.Capacity + 1];

            bool inserted = false;

            for (int i = 0, j = 0; i < temp.Length - 1; i++, j++)
            {
                if (i == index && !inserted)
                {
                    this.genericList[j] = element;

                    i--;
                    inserted = true;
                    continue;
                }

                this.genericList[j] = temp[i];
            }

            this.counter++;
        }

        public int FindElementByValue(T value)
        {
            int index = -1;

            for (int i = 0; i < this.counter; i++)
            {
                if (genericList[i].CompareTo(value) == 0)
                {
                    index = i;
                    return index;
                }
            }

            return index;
        }

        public T Max()
        {
            T result = default(T);

            for (int i = 0; i < this.counter; i++)
            {
                if (genericList[i].CompareTo(result) > 0)
                {
                    result = genericList[i];
                }
            }

            return result;
        }

        public T Min()
        {
            T result = default(T);

            for (int i = 0; i < this.counter - 1; i++)
            {
                if (i == 0)
                {
                    result = genericList[i];
                }

                if (genericList[i].CompareTo(result) < 0 && genericList[i].CompareTo(default(T)) != 0)
                {
                    result = genericList[i];
                }
            }

            return result;
        }

        public void Clear()
        {
            T[] temp = new T[Capacity];
            genericList = temp;

            counter = 0;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            for (int i = 0; i < this.counter; i++)
            {
                builder.Append(genericList[i] + ", ");
            }

            return builder.ToString().Trim(',', ' ');
        }
    }
}
