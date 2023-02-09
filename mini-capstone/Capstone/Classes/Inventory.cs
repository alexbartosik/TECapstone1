using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Inventory
    {
        // fields
        public Dictionary<Candy, int> inventory = new Dictionary<Candy, int>();

        //constructor
        public Inventory()
        {

        }

        //methods
        public void ImportInventory()
        {
            string filepath = @"C:\Store\inventory.csv";

            try
            {
                // checks if file path exists, throws exception if not
                if (!File.Exists(filepath))
                {
                    throw new FileNotFoundException();
                }

                // read the inventory file line by line
                using (StreamReader reader = new StreamReader(filepath))
                {
                    while (!reader.EndOfStream)
                    {
                        // readline and create array
                        string line = reader.ReadLine();
                        string[] lineArray = line.Split("|");

                        // setting properties from inventory array
                        string candyType = lineArray[0];
                        string id = lineArray[1];
                        string name = lineArray[2];
                        string wrapped = lineArray[4];

                        // save price as string then convert to a decimal
                        string stringPrice = lineArray[3];
                        decimal price = decimal.Parse(stringPrice);

                        this.CreateCandyFromImport(candyType, id, name, price, wrapped);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Inventory file not found");
            }
        }
        public void AddInventory(Candy candy)
        {
            if (candy != null)
            {
                // add candy to dictionary with default quatity of 100
                inventory[candy] = 100;
            }
        }

        public void CreateCandyFromImport(string candyType, string id, string name, decimal price, string wrapped)
        {
            Candy candy;

            //check each candy to see which constructor to use
            switch (candyType)
            {
                // assign specific constructor to candy and add it to the inventory
                case "CH":
                    candy = new ChocolateConfectionery(id, name, price, wrapped);
                    AddInventory(candy);
                    break;
                case "SR":
                    candy = new FlavoredCandies(id, name, price, wrapped);
                    AddInventory(candy);
                    break;
                case "HC":
                    candy = new HardTackConfectionery(id, name, price, wrapped);
                    AddInventory(candy);
                    break;
                case "LI":
                    candy = new LicorceAndJellies(id, name, price, wrapped);
                    AddInventory(candy);
                    break;
            }
        }
        
        // Get dictionary when private
        /*
        public Dictionary<Candy, int> GetInventoryDictionary()
        {
            return inventory;
        }*/
    }
}
