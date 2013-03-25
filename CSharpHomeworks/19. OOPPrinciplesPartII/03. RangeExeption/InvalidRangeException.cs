using System;

public class InvalidRangeException<T> : Exception
{
    // constructors
    public InvalidRangeException(string msg, Exception innerExcep = null)
        : this(msg, default(T), innerExcep)
    {
    }

    public InvalidRangeException(string msg, T outValue, Exception innerExcep = null)
        : this(msg, default(T), default(T), outValue, innerExcep)
    {
    }

    public InvalidRangeException(string msg, T start, T end, T outValue, Exception innerExcep)
        : base(msg, innerExcep)
    {
        this.OutValue = outValue;
        this.Start = start;
        this.End = end;
    }

    // props
    public T Start { get; private set; }

    public T End { get; private set; }

    public T OutValue { get; private set; }
}