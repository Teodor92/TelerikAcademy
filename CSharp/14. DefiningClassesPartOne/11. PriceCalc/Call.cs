using System;
using System.Linq;

public class Call
{
    private DateTime dateAndTime;
    private string dialedNumber;
    private int duration;

    // constructors



    // properties

    public Call(DateTime dateAndTime, string dialedNumber, int duration)
    {
        this.dateAndTime = dateAndTime;
        this.dialedNumber = dialedNumber;
        this.duration = duration;
    }

    public DateTime DateAndTime
    {
        get
        {
            return this.dateAndTime;
        }

        set 
        {
            this.dateAndTime = value;
        }
    }

    public string DialedNumber
    {
        get 
        {
            return this.dialedNumber;
        }

        set
        {
            this.dialedNumber = value;
        }
    }

    public int Duration
    {
        get
        {
            return this.duration;
        }
        set
        {
            this.duration = value;
        }
    }
}
