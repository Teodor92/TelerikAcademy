using System;
using System.Linq;

public class Battery
{
    private string batteryModel;
    private int hoursIdle;
    private int hoursTalked;

    public Battery(string baterryModel) : this(baterryModel, 0, 0)
    { 
    
    }

    public Battery(string baterryModel, int hoursIdle) : this(baterryModel, hoursIdle, 0)
    { 
    
    }

    public Battery(string baterryModel, int hoursIdle, int hoursTalked)
    {
        this.batteryModel = baterryModel;
        this.hoursIdle = hoursIdle;
        this.hoursTalked = hoursTalked;
    }


    public string BatteryModel
    {
        get { return this.batteryModel; }
        set { this.batteryModel = value; }
    }

    public int HoursIdle
    {
        get { return this.hoursIdle; }
        set { this.hoursIdle = value; }
    }

    public int HoursTalked
    {
        get { return this.hoursTalked; }
        set { this.hoursTalked = value; }
    }
}
