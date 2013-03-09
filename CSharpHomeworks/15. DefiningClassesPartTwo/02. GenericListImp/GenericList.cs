using System;
using System.Text;

public class GenericList<T> where T : IComparable
{
    private const int DefCap = 10;
    private T[] list;
    private int position;

    public GenericList()
        : this(DefCap)
    {
    }

    public GenericList(int cap)
    {
        this.list = new T[cap];
    }

    public T this[int index]
    {
        get
        {
            return this.list[index];
        }

        set
        {
            this.list[index] = value;
        }
    }

    // methods
    public T Max()
    {
        dynamic maxElem = int.MinValue;
        for (int i = 0; i < this.list.Length; i++)
        {
            if (this.list[i] > maxElem)
            {
                maxElem = this.list[i];
            }
        }

        return maxElem;
    }

    public T Min()
    {
        dynamic minElem = int.MaxValue;
        for (int i = 0; i < this.list.Length; i++)
        {
            if (this.list[i] < minElem)
            {
                minElem = this.list[i];
            }
        }

        return minElem;
    }

    public void AddElement(T element)
    {
        if (this.position >= this.list.Length)
        {
            // autogrow
            T[] newList = new T[this.list.Length * 2];
            for (int i = 0; i < this.list.Length; i++)
            {
                newList[i] = this.list[i];
            }

            this.position++;
            newList[this.list.Length] = element;
            this.list = newList;
        }
        else
        {
            this.list[this.position] = element;
            this.position++;
        }
    }

    public void RemoveElemAtIndex(int index)
    {
        if (index < this.list.Length)
        {
            T[] newList = new T[this.list.Length - 1];
            bool beforeRem = true;

            for (int i = 0; i < this.list.Length - 1; i++)
            {
                if (i == index)
                {
                    beforeRem = false;
                }

                if (beforeRem)
                {
                    newList[i] = this.list[i];
                }
                else
                {
                    newList[i] = this.list[i + 1];
                }
            }

            this.list = newList;
        }
        else
        {
            Console.WriteLine("Outside the array");
        }
    }

    public void InsertElemAtIndex(int index, T element)
    {
        if (index < this.list.Length)
        {
            T[] newList = new T[this.list.Length + 1];
            bool beforeRem = true;

            for (int i = 0; i < this.list.Length + 1; i++)
            {
                if (i == index)
                {
                    beforeRem = false;
                    newList[i] = element;
                    continue;
                }

                if (beforeRem)
                {
                    newList[i] = this.list[i];
                }
                else
                {
                    newList[i] = this.list[i - 1];
                }
            }

            this.list = newList;
        }
        else
        {
            Console.WriteLine("Outside the array");
        }
    }

    public int Length()
    {
        return this.list.Length;
    }

    public void ClearList()
    {
        this.list = new T[1];
    }

    public int FindElemByValue(T value)
    {
        int indexFound = -1;

        for (int i = 0; i < this.list.Length; i++)
        {
            if (this.list[i].Equals(value))
            {
                indexFound = i;
                break;
            }
        }

        return indexFound;
    }

    public override string ToString()
    {
        StringBuilder endText = new StringBuilder();
        foreach (var item in this.list)
        {
            endText.AppendFormat("{0} ", item);
        }

        return endText.ToString().Trim();
    }
}
