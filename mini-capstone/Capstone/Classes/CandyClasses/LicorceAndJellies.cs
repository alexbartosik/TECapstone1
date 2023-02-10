using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.CandyClasses
{
    public class LicorceAndJellies : Candy
    {
        //constructor
        public LicorceAndJellies(string id, string name, decimal price, string wrapped) : base(id, name, price, wrapped)
        {
            FullClassName = "Licorce and Jellies";
        }
    }
}
