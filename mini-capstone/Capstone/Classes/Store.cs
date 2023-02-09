using System;
using System.Collections.Generic;
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


        public bool AddMoney(int addedMoney)
        {
            decimal money = (decimal)addedMoney;
            if (CustomerBalance + money <= 1000)
            {
                CustomerBalance += money;
                return true;
            }
            {
                return false;
            }
        }
    }
}
