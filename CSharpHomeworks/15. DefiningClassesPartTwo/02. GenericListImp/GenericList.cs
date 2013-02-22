using System;
using System.Text;

public class GenericList<T> //where T:
{
    private T[] list;
    private int position;

    public GenericList(int cap)
    {
        list = new T[cap];
    }

    public T this[int index]
    {
        get
        {
            return list[index];
        }

        set
        {
            list[index] = value;
        }
    }

    // methods

    public void AddElement(T element)
    {
        if (position >= list.Length)
        {
            Console.WriteLine("Out of bounds");
        }
        else
        {
            list[position] = element;
            position++;
        }
    }
    public void RemoveElemAtIndex(int index)
    { 
        if (index < list.Length)
        {
            T[] newList = new T[list.Length - 1];
            bool beforeRem = true;

            for (int i = 0; i < list.Length - 1; i++)
            {
                if (i == index)
                {
                    beforeRem = false;
                }

                if (beforeRem)
                {
                    newList[i] = list[i];
                }
                else
                {
                    newList[i] = list[i + 1];
                }
            }

            list = newList;
        }
        else
        {
            Console.WriteLine("Outside the array");
        }
    }

    public void InsertElemAtIndex(int index, T element)
    {
        if (index < list.Length)
        {
            T[] newList = new T[list.Length + 1];
            bool beforeRem = true;

            for (int i = 0; i < list.Length + 1; i++)
            {
                if (i == index)
                {
                    beforeRem = false;
                    newList[i] = element;
                    continue;
                }

                if (beforeRem)
                {
                    newList[i] = list[i];
                }
                else
                {
                    newList[i] = list[i - 1];
                }
            }

            list = newList;
        }
        else
        {
            Console.WriteLine("Outside the array");
        }
    }

    public void ClearList()
    {
        list = new T[list.Length];
    }

    public int FindElemByValue(T value)
    {
        int indexFound = -1;

        for (int i = 0; i < list.Length; i++)
        {

            if (list[i].Equals(value))
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
        foreach (var item in list)
        {
            endText.AppendFormat("{0} ", item);
        }
        return endText.ToString().Trim();
    }
}
