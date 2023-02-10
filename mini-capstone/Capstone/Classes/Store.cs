using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// Most of the "work" (the data and the methods) of dealing with inventory and money 
    /// should be created or controlled from this class
    /// </summary>
    /// <remarks>
    /// As a reminder, no Console statements belong in this class or any other class besides UserInterface
    /// </remarks>
    public sealed class Store
    {
        // property
        public decimal CustomerBalance { get; private set; }

        public void AddMoney(int addedMoney)
        {
            decimal money = (decimal)addedMoney;
            if (CustomerBalance + money <= 1000)
            {
                CustomerBalance += money;
            }

            // Add Log
        }

        public bool CheckAvailableBalance(Candy candy, int userQty)
        {
            // calculate the total price of product * user requested qty
            decimal calcAmount = candy.Price * userQty;
            // compare user balance to total price and create a bool
            if (CustomerBalance > calcAmount)
            {
                // true = sufficient funds
                return true;
            }
            // false = insufficient funds
            return false;
        }

        public void RemoveMoney(decimal amountOfSale)
        {
            CustomerBalance -= amountOfSale;
        }

        public string MakeChange()
        {
            int balanceInPennies = (int)(CustomerBalance * 100);
            int remainingBalance;
            int twenties = balanceInPennies / 2000;
            remainingBalance = balanceInPennies % 2000;
            int tens = remainingBalance / 1000;
            remainingBalance %= 1000;
            int fives = remainingBalance / 500;
            remainingBalance %= 500;
            int ones = remainingBalance / 100;
            remainingBalance %= 100;
            int quarters = remainingBalance / 25;
            remainingBalance %= 25;
            int dimes = remainingBalance / 10;
            remainingBalance %= 10;
            int nickles = remainingBalance / 5;

            return $"Change: {CustomerBalance.ToString("C")} \n({twenties}) Twenties, ({tens}) Tens, ({fives}) Fives, ({ones}) Ones, ({quarters}) Quarters, ({dimes}) Dimes, ({nickles}) Nickles";
            
        }
    }
}
