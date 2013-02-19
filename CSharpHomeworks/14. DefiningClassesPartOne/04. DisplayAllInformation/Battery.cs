using System;
using System.Linq;

public enum BatteryType
{
    Type1, Type2, Type3
}

public class Battery
{
    private BatteryType batteryModel;
    private int? hoursIdle;
    private int? hoursTalked;

    public Battery(BatteryType baterryModel) : this(baterryModel, null, null)
    { 
    
    }

    public Battery(BatteryType baterryModel, int? hoursIdle) : this(baterryModel, hoursIdle, null)
    { 
    
    }

    public Battery(BatteryType baterryModel, int? hoursIdle, int? hoursTalked)
    {
        this.batteryModel = baterryModel;
        this.hoursIdle = hoursIdle;
        this.hoursTalked = hoursTalked;
    }


    public BatteryType BatteryModel
    {
        get { return this.batteryModel; }
        set { this.batteryModel = value; }
    }

    public int? HoursIdle
    {
        get { return this.hoursIdle; }
        set { this.hoursIdle = value; }
    }

    public int? HoursTalked
    {
        get { return this.hoursTalked; }
        set { this.hoursTalked = value; }
    }
}
