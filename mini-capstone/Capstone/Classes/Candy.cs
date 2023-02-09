using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public abstract class Candy
    {
        // properties
        public string Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string Wrapped { get; private set; }
        public string FullClassName { get; protected set; }

        // constructor
        public Candy(string id, string name, decimal price, string wrapped)
        {
            Id = id;
            Name = name;
            Price = price;
            Wrapped = wrapped;
        }
    }
}
