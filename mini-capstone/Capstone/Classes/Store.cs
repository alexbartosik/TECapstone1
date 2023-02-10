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
    }
}
