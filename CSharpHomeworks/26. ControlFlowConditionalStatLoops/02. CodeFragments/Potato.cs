namespace CodeFragments
{
    using System;

    public class Potato
    {
        private bool hasBeenPeeled;

        public bool HasBeenPeeled
        {
            get
            {
                return this.hasBeenPeeled;
            }

            set
            {
                this.hasBeenPeeled = value;
            }
        }

        public bool IsNotRotten { get; set; }
    }
}
