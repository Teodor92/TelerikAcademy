namespace StoreClasses
{
    using System;
    using System.Linq;
    using System.Text;

    public class Store : IShowable, IAddable, IRemoveable
    {
        private IUserInterface userInterface;

        private CashRegister myChashRegisterModule;
        private Storage myStorageModule;

        public Store(IUserInterface userInterface)
        {
            this.userInterface = userInterface;
            this.myChashRegisterModule = new CashRegister(1.95583m, 1.53m);
            this.myStorageModule = new Storage();
            this.myStorageModule.LoadDB();
        }

        // methods
        public string Show()
        {
            return this.myStorageModule.Show();
        }

        public void AddObject(Product myProduct)
        {
            this.myStorageModule.AddObject(myProduct);
            this.myChashRegisterModule.RemoveMoney(myProduct.Price, CurruncyType.Leva);
        }

        public void RemoveObject(Product myProduct)
        {
            this.myStorageModule.RemoveObject(myProduct);
            this.myChashRegisterModule.AddMoney(myProduct.Price, CurruncyType.Leva);
        }

        public void RemoveAll(Product myProduct)
        {
            // TODO: Bug fix
            this.myChashRegisterModule.AddMoney(myProduct.Price, CurruncyType.Leva);
            this.myStorageModule.RemoveAll(myProduct);
        }

        public void StartStore()
        {
            Console.ForegroundColor = ConsoleColor.White;
            UIDrawer homeDrawer = new UIDrawer(Console.WindowWidth - 4);
            homeDrawer.DrawHomeMenu();

            while (true)
            {
                this.userInterface.ProcessInput();
            }
        }

        public string ShowCashRegister()
        {
            return this.myChashRegisterModule.Show();
        }

        public void RemoveMoneyFromCashReg(decimal sum)
        {
            this.myChashRegisterModule.RemoveMoney(sum, CurruncyType.Leva);
        }

        public void AddMoneyToCashReg(decimal sum)
        {
            this.myChashRegisterModule.AddMoney(sum, CurruncyType.Leva);
        }

        public void SearchById(int id)
        {
            this.myStorageModule.SearchByID(id);
        }

        public void SearchByName(string name)
        {
            this.myStorageModule.SearchByName(name);
        }
    }
}
