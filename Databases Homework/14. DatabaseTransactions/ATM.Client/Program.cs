using ATM.Data;
using ATM.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Model;

namespace ATM.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMContext, Configuration>());
            Random randGen = new Random();

            using (ATMContext dbContext = new ATMContext())
            {
                //for (int i = 0; i < 50; i++)
                //{
                //    dbContext.CardAccounts.Add(new CardAccount() { CardPIN = 9999, CardCash = 100 * i, CardNumber = randGen.Next(10000, 20000) });
                //}

                //for (int i = 0; i < 50; i++)
                //{
                //    dbContext.TransactionsHistory.Add(new TransactionHistory() { Ammount = 50 * i, CardNumber = randGen.Next(10000, 20000), TransactionDate = DateTime.Now });
                //}

                //dbContext.SaveChanges();

                // Uncomment the seed method in Configuration to populate.
                ATMUtils.ShowCards();

                int pin = 9999;
                int cardNumber = 14665;
                decimal moneyToWithdraw = 300m;

                using (ATMContext db = new ATMContext())
                {
                    if (ATMUtils.WithdrawMoney(pin, cardNumber, moneyToWithdraw, db))
                    {
                        Console.WriteLine("Money withdrawn");
                    }
                    else
                    {
                        Console.WriteLine("Transactions canceled");
                    }
                }


                Console.WriteLine("New cards: ");
                ATMUtils.ShowCards();
            }
        }
    }
}
