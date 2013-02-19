using System;
using System.Linq;

public class Battery
{
    private string batteryModel;
    private int hoursIdle;
    private int hoursTalked;

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
