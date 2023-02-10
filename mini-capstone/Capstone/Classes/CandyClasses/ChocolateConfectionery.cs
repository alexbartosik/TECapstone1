using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.CandyClasses
{
    public class ChocolateConfectionery : Candy
    {
        //constructor
        public ChocolateConfectionery(string id, string name, decimal price, string wrapped) : base(id, name, price, wrapped)
        {
            FullClassName = "Chocolate Confectionery";
        }
    }
}
