namespace CableCompany
{
    using System;

    public class HouseConection : IComparable<HouseConection>
    {
        public int StartHouse { get; set; }
        public int EndHouse { get; set; }
        public int ConectionLength { get; set; }

        public HouseConection(int startHouse, int endHouse, int conectionLength)
        {
            this.StartHouse = startHouse;
            this.EndHouse = endHouse;
            this.ConectionLength = conectionLength;
        }

        public int CompareTo(HouseConection other)
        {
            int weightCompared = this.ConectionLength.CompareTo(other.ConectionLength);

            if (weightCompared == 0)
            {
                return this.StartHouse.CompareTo(other.StartHouse);
            }
            return weightCompared;
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", this.StartHouse, this.EndHouse, this.ConectionLength);
        }
    }
}
