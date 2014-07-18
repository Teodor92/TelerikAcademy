namespace _11.PriceCalc
{
    using System;

    public class Call
    {
        // properties
        public Call(DateTime dateAndTime, string dialedNumber, int duration)
        {
            this.DateAndTime = dateAndTime;
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }

        public DateTime DateAndTime { get; set; }

        public string DialedNumber { get; set; }

        public int Duration { get; set; }
    }
}
