namespace LinkedListImplement
{
    using System;

    public class CustomLinkedList<T>
    {
        private ListItem<T> firstElement;
        private int elementCount = 0;

        public int Count
        {
            get
            {
                return this.elementCount;
            }
        }

        public void AddFirst(T value)
        {
            if (this.firstElement == null)
            {
                this.firstElement = new ListItem<T>(value);
                this.elementCount++;
            }
            else
            {
                ListItem<T> newElement = new ListItem<T>(value);
                newElement.NextItem = this.firstElement;
                this.firstElement = newElement;
                this.elementCount++;
            }
        }

        public void AddLast(T value)
        {
            if (this.firstElement == null)
            {
                this.firstElement = new ListItem<T>(value);
                this.elementCount++;
            }
            else
            {
                ListItem<T> last = this.firstElement;

                while (last.NextItem != null)
                {
                    last = last.NextItem;
                }

                last.NextItem = new ListItem<T>(value);
                this.elementCount++;
            }
        }

        public void RemoveFirst()
        {
            if (this.firstElement == null)
            {
                throw new InvalidOperationException("Linked list is empty!");
            }

            this.firstElement = this.firstElement.NextItem;
            this.elementCount--;
        }

        // Maybe is better to implement the "last" operations by defining a new filed "lastElement".
        public void RemoveLast()
        {
            ListItem<T> last = this.firstElement;

            while (last.NextItem != null)
            {
                last = last.NextItem;
            }

            ListItem<T> valueToRemove = this.firstElement;
            while (valueToRemove.NextItem != last)
            {
                valueToRemove = valueToRemove.NextItem;
            }

            valueToRemove.NextItem = null;
            this.elementCount--;
        }

        public void Clear()
        {
            while (this.firstElement != null)
            {
                this.firstElement = this.firstElement.NextItem;
                this.elementCount--;
            }
        }
    }
}
