namespace StoreClasses
{
    using System;
    using System.Linq;

    public class KeyboardInterface : IUserInterface
    {
        // For adding items
        public event EventHandler OnAPressed;

        // For removeing items
        public event EventHandler OnRPressed;

        // For showing the storage
        public event EventHandler OnActionPressed;

        // For home menu
        public event EventHandler OnHPressed;

        // For cash register cotnent
        public event EventHandler OnCPressed;

        // For search perss
        public event EventHandler OnSPressed;

        // Add cash to registry
        public event EventHandler OnPlusPressed;

        // Remove cash from registry
        public event EventHandler OnMinusPressed;

        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey(true);

                if (keyInfo.Key.Equals(ConsoleKey.Add))
                {
                    if (this.OnPlusPressed != null)
                    {
                        this.OnPlusPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.Subtract))
                {
                    if (this.OnMinusPressed != null)
                    {
                        this.OnMinusPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.C))
                {
                    if (this.OnCPressed != null)
                    {
                        this.OnCPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.S))
                {
                    if (this.OnSPressed != null)
                    {
                        this.OnSPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.A))
                {
                    if (this.OnAPressed != null)
                    {
                        this.OnAPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.H))
                {
                    if (this.OnHPressed != null)
                    {
                        this.OnHPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.R))
                {
                    if (this.OnRPressed != null)
                    {
                        this.OnRPressed(this, new EventArgs());
                    }
                }

                if (keyInfo.Key.Equals(ConsoleKey.Spacebar))
                {
                    if (this.OnActionPressed != null)
                    {
                        this.OnActionPressed(this, new EventArgs());
                    }
                }

                while (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                }
            }
        }
    }
}
