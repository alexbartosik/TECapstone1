using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.CandyClasses
{
    public class FlavoredCandies : Candy
    {
        //constructor
        public FlavoredCandies(string id, string name, decimal price, string wrapped) : base(id, name, price, wrapped)
        {
            FullClassName = "Sour Flavored Candies";
        }
    }
}
