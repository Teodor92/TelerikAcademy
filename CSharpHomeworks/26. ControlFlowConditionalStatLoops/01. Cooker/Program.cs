namespace Cooker
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            Bowl bowl = this.GetBowl();

            Potato potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);
            bowl.Add(potato);

            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);
            bowl.Add(carrot);
        }

        private Potato GetPotato()
        {
            // ...
            return new Potato();
        }

        private Carrot GetCarrot()
        {
            // ...
            return new Carrot();
        }

        private Bowl GetBowl()
        {
            // ... 
            return new Bowl();
        }

        private void Cut(Vegetable potato)
        {
            // ...
        }

        private void Peel(Vegetable carrot)
        {
            throw new NotImplementedException();
        }
    }
}
