namespace _11.PriceCalc
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Gsm
    {
        private static Gsm iphone = new Gsm("IPhone", "Apple", 999);

        private string model;
        private string manufacturer;
        private int? price;
        private string owner;
        private List<Call> callHistory = new List<Call>();

        // constructors 
        public Gsm(string model, string manufacturer)
            : this(model, manufacturer, null, null, null, null)
        {
        }

        public Gsm(string model, string manufacturer, int price)
            : this(model, manufacturer, price, null, null, null)
        {
        }

        public Gsm(string model, string manufacturer, int? price, string owner)
            : this(model, manufacturer, price, owner, null, null)
        {
        }

        public Gsm(string model, string manufacturer, int? price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        // properties
        public static Gsm Iphone
        {
            get
            {
                return iphone;
            }
        }

        public Battery Battery { get; set; }

        public Display Display { get; set; }

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
                if (value == null || value >= 0)
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

        // methods
        public void AddCall(DateTime now, string number, int duration)
        {
            var myCall = new Call(now, number, duration);
            this.callHistory.Add(myCall);
        }

        public void RemoveCallByDuration(int duration)
        {
            for (int i = 0; i < this.callHistory.Count; i++)
            {
                if (this.callHistory[i].Duration == duration)
                {
                    this.callHistory.RemoveAt(i);
                    i--;
                }
            }
        }

        public void ClearHistory()
        {
            this.callHistory.Clear();
        }

        public void DisplayCallHistory()
        {
            var callHist = new StringBuilder();
            callHist.AppendLine("CALL HISTORY:");
            Console.WriteLine("---------------------------------");
            foreach (var call in this.callHistory)
            {
                callHist.AppendFormat("Number: {0},  Date: {1},  Duration: {2} \n", call.DialedNumber, call.DateAndTime, call.Duration);
            }

            Console.WriteLine("---------------------------------");

            Console.WriteLine(callHist.ToString());
        }

        public double CalcPrice(double pricePerMin)
        {
            double wholeTime = 0;
            for (int i = 0; i < this.callHistory.Count; i++)
            {
                wholeTime = wholeTime + this.callHistory[i].Duration;
            }

            double calcPrice = pricePerMin * Math.Ceiling(wholeTime / 60);
            return calcPrice;
        }

        public override string ToString()
        {
            var endText = new StringBuilder();
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
}
