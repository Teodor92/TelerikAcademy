namespace StackImplement
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomStack<T> : IEnumerable
    {
        // fields
        private const int DefSize = 4;
        private T[] innerArray;
        private int maxSize = 4;
        private int stackSize = 0;

        // constructors
        public CustomStack()
        {
            this.innerArray = new T[DefSize];
        }

        public CustomStack(int size)
        {
            this.innerArray = new T[size];
        }

        // properties
        public int Count
        {
            get
            {
                return this.stackSize;
            }
        }

        // methods
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // Not fully working. TODO: Do not show element buffer
        public IEnumerator GetEnumerator()
        {
            foreach (T item in this.innerArray)
            {
                if (item == null)
                {
                    break;
                }

                yield return item;
            }
        }

        public void Push(T element)
        {
            if (this.stackSize == this.maxSize)
            {
                this.innerArray = this.ResizeStack(this.innerArray);
            }

            this.innerArray[this.stackSize] = element;
            this.stackSize++;
        }

        public T Pop()
        {
            if (this.stackSize == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            T popedElement = this.innerArray[this.stackSize - 1];
            this.innerArray[this.stackSize] = default(T);
            this.stackSize--;

            return popedElement;
        }

        public T Peek()
        {
            if (this.stackSize == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }

            T topElement = this.innerArray[this.stackSize - 1];
            return topElement;
        }

        public bool Contains(T element)
        {
            bool isContained = false;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.innerArray[i].Equals(element))
                {
                    isContained = true;
                    break;
                }
            }

            return isContained;
        }

        public T[] ToArray()
        { 
            T[] copiedArray = new T[this.Count];
            Array.Copy(this.innerArray, copiedArray, this.Count);
            return copiedArray;
        }

        private T[] ResizeStack(T[] innerArray)
        {
            T[] newInnerArray = new T[this.maxSize * 2];
            this.maxSize = this.maxSize * 2;

            for (int i = 0; i < innerArray.Length; i++)
            {
                newInnerArray[i] = this.innerArray[i];
            }

            return newInnerArray;
        }
    }
}
