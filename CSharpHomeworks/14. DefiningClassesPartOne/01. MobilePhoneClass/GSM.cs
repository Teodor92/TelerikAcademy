/* Define a class that holds information about 
 * a mobile phone device: model, manufacturer, 
 * price, owner, battery characteristics 
 * (model, hours idle and hours talk) and display 
 * characteristics (size and number of colors). 
 * Define 3 separate classes 
 * (class GSM holding instances of the classes Battery and Display).
 */

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
