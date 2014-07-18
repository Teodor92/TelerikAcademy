namespace StoreClasses
{
    using System;
    using System.Linq;

    public interface IUserInterface
    {
        event EventHandler OnActionPressed;

        event EventHandler OnAPressed;

        event EventHandler OnRPressed;

        event EventHandler OnHPressed;

        event EventHandler OnCPressed;

        event EventHandler OnSPressed;

        event EventHandler OnPlusPressed;

        event EventHandler OnMinusPressed;

        void ProcessInput();
    }
}
