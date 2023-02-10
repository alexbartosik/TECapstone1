using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Capstone.Classes
{
    public class Inventory
    {
        // fields
        private Dictionary<Candy, int> inventory = new Dictionary<Candy, int>();

        //constructor
        public Inventory()
        {

        }

        //methods
        public void ImportInventory()
        {
            string filepath = @"C:\Store\inventory.csv";


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
        public void AddInventory(Candy candy)
        {
            if (candy != null)
            {
                const int DefaultStartingQty = 100;
                // add candy to dictionary with default quatity of 100
                inventory[candy] = DefaultStartingQty;
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

        public List<KeyValuePair<Candy, int>> ListOfCurrentInventory()
        {

            // Need to create a list to be able to sort a dictionary.

            List<KeyValuePair<Candy, int>> inventoryList = new List<KeyValuePair<Candy, int>>();

            // Adding each dictionary item to the list.

            foreach (KeyValuePair<Candy, int> candy in inventory)
            {
                inventoryList.Add(candy);
            }

            // sorting list aphabetically by Candy id
            inventoryList = inventoryList.OrderBy(Candy => Candy.Key.Id).ToList();  // used Linq based on StackOverflow Thread https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object

            return inventoryList;
        }

        public Candy CheckInventoryId(string inputId)
            // checks if item exists in inventory
        {
            foreach (KeyValuePair<Candy, int> product in inventory)
            {
                if (product.Key.Id == inputId)
                {
                    return product.Key;
                }
            }
            return null;
        }

        /// <summary>
        /// Checks if the store inventory has enough of what the user requests
        /// </summary>
        /// <param name="candy"></param>
        /// <param name="inputQty"></param>
        /// <returns>Returns a int that corresponds to a specific condition, 0 = Invalid input, 1 = Product SOLD OUT, 2 = Process sale, 3 = Insufficient qty</returns>
        public int CheckInventoryQty(Candy candy, int inputQty)
        {
            // return inventory value
            if (inputQty < 0 || inputQty > 100)
            {
                return 0;
            }
            // Add quantity 0 condition
            else if (inventory[candy] == 0)
            {
                return 1;
            }
            else if (inventory[candy] >= inputQty)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        public void RemoveFromInventory(Candy candy, int quantity)
        {
            inventory[candy] -= quantity;
        }

    }
}
