using System;

public class GSM
{
    public Battery Battery = new Battery();
    public Display Display = new Display(); 

    private string model;
    private string manufacturer;
    private int price;
    private string owner;

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

    public int Price
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
