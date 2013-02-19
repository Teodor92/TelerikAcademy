using System;

public class GSM
{
    public Battery Battery = new Battery(null, 0, 0);
    public Display Display = new Display(0, 0);

    private string model;
    private string manufacturer;
    private int? price;
    private string owner;

    public GSM(string model, string manufacturer) : this(model, manufacturer, null , null, null, null)
    {

    }

    public GSM(string model, string manufacturer, int price) : this(model, manufacturer, price, null, null, null)
    {
        
    }

    public GSM(string model, string manufacturer, int? price, string owner, Battery battery, Display display)
    {
        this.model = model;
        this.manufacturer = manufacturer;
        this.price = price;
        this.owner = owner;
        this.Battery.BatteryModel = battery.BatteryModel;
        this.Battery.HoursIdle = battery.HoursIdle;
        this.Battery.HoursTalked = battery.HoursTalked;
        this.Display.Size = display.Size;
        this.Display.NumberOfColors = display.NumberOfColors;
    }

    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public string Manufacturer
    {
        get { return this.manufacturer; }
        set { this.manufacturer = value; }
    }

    public int? Price
    {
        get { return this.price; }
        set { this.price = value; }
    }

    public string Owner
    {
        get { return this.owner; }
        set { this.owner = value; }
    }
}
