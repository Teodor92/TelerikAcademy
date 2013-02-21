using System;
using System.Text;
using System.Collections.Generic;

public class GSM
{
    public Battery Battery = new Battery(BatteryType.Type1, null, null);
    public Display Display = new Display(0, null);

    private string model;
    private string manufacturer;
    private int? price;
    private string owner;

    // The static filed
    static private bool isIphone;

    // constructors

    public GSM(string model, string manufacturer) : this(model, manufacturer, null , null, null, null)
    {

    }

    public GSM(string model, string manufacturer, int price) : this(model, manufacturer, price, null, null, null)
    {
        
    }

    public GSM(string model, string manufacturer, int? price, string owner, Battery battery, Display display)
    {
        this.Model = model;
        this.Manufacturer = manufacturer;
        this.Price = price;
        this.Owner = owner;
        this.Battery= battery;
        this.Display = display;
    }

    // properties

    private List<Call> callHistory = new List<Call>();


    public List<Call> CallHistory
    {
        get
        {
            return this.callHistory;
        }
    }

    public string Model
    {
        get 
        { 
            return this.model; 
        }
        set 
        {
            if (value.Length >= 0)
            {
                this.model = value;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    public string Manufacturer
    {
        get 
        { 
            return this.manufacturer; 
        }
        set 
        {
            if (value.Length >= 0)
            {
                this.manufacturer = value;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    public int? Price
    {
        get 
        { 
            return this.price; 
        }
        set 
        {
            if (value == null || value >= 0 )
            {
                this.price = value;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    public string Owner
    {
        get 
        { 
            return this.owner; 
        }
        set 
        {
            if (value == null || value.Length >= 0)
            {
                this.owner = value; 
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    public static bool IPhone4S
    {
        get
        {
            return isIphone;
        }

        set
        {
            if (value == true || value == false)
            {
                isIphone = value;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }


    // methods
    public void AddCall(DateTime now, int number, int duration)
    {
        Call myCall = new Call(now, number, duration);
        callHistory.Add(myCall);
    }

    public void RemoveCall(int number)
    {
        for (int i = 0; i < callHistory.Count; i++)
        {
            if (callHistory[i].DialedNumber == number)
            {
                callHistory.RemoveAt(i);
                i--;
            }
        }
    }

    public void ClearHistory()
    {
        callHistory.Clear();
    }

    public double CalcPrice(double pricePerMin)
    {
        double wholeTime = 0;
        for (int i = 0; i < callHistory.Count; i++)
        {
            wholeTime = wholeTime + callHistory[i].Duration;
        }

        double price = pricePerMin * (wholeTime / 60);
        return price;
    }

    public override string ToString()
    {
        StringBuilder endText = new StringBuilder();
        endText.AppendLine("----------GSM ------------");
        endText.AppendLine(this.model);
        endText.AppendLine(this.manufacturer);
        endText.AppendLine(this.price.ToString());
        endText.AppendLine(this.owner);
        endText.AppendLine(this.Battery.ToString());
        endText.AppendLine(this.Display.ToString());
        string result = endText.ToString();
        return result;
    }
}
