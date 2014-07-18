namespace StoreClasses
{
    using System;
    using System.Linq;

    public interface IRemoveable
    {
        void RemoveObject(Product myProduct);

        void RemoveAll(Product myProduct);
    }
}
