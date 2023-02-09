using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace Capstone.Classes
{
    /// <summary>
    /// This class is responsible for displaying data to the user and getting input from the user
    /// </summary>
    /// <remarks>
    /// All Console statements belong in this class.
    /// NO Console statements should be in any other class.
    /// </remarks>
    public sealed class UserInterface
    {
        private Store store = new Store();
        private Inventory inventory = new Inventory();

        /// <summary>
        /// Provides all communication with human user.
        /// </summary>
        public void Greeting()
        {
            try // Move catch 
            {
                inventory.ImportInventory();
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Inventory file not found " + ex.Message);
            }

            Console.WriteLine("Greetings!");
            // import inventory
        }

        public void MainMenu()
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine();
                Console.WriteLine("Please select a menu option (1-3)");
                Console.WriteLine("(1) Show Inventory");
                Console.WriteLine("(2) Make Sale");
                Console.WriteLine("(3) Quit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        this.ShowInventory();
                        break;
                    case "2":
                        this.MakeSale();
                        break;
                    case "3":
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please input a numeral 1-3.");
                        break;

                }
            }
        }

        public void ShowInventory()
        {
            Console.Clear();

            // Creating list to hold sorted inventory
            List<KeyValuePair<Candy, int>> currentInventory = inventory.ListOfCurrentInventory();

            // Creating inventory header
            string idHeader = "Id";
            string nameHeader = "Name";
            string wrappedHeader = "Wrapped";
            string quantityHeader = "Qty";
            string priceHeader = "Price";

            Console.WriteLine();
            Console.WriteLine($"{idHeader.PadRight(5)}  {nameHeader.PadRight(20)} {wrappedHeader.PadRight(8)} {quantityHeader.PadRight(10)} {priceHeader}");

            // Write line for each item in inventory
            foreach (KeyValuePair<Candy, int> candy in currentInventory)
            {
                string id = candy.Key.Id;
                string name = candy.Key.Name;
                string wrapped = candy.Key.Wrapped;
                string price = candy.Key.Price.ToString("C");

                // Convert inventory qty from int to string and add soldout if value is 0.
                int numQuantity = candy.Value;
                string quantity;
                if (numQuantity == 0)
                {
                    quantity = "Sold Out";
                }
                else
                {
                    quantity = numQuantity.ToString();
                }
                Console.WriteLine($"{id.PadRight(5)}  {name.PadRight(20)} {wrapped.PadRight(8)} {quantity.PadRight(10)} {price}");
            }
        }

        public void MakeSale()
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.WriteLine();
                Console.WriteLine("Please select a menu option (1-3)");
                Console.WriteLine("(1) Take Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Complete Sale");
                //Customer Balance
                Console.WriteLine("Current Customer Balance: ");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        this.ShowInventory();
                        break;
                    case "2":
                        this.MakeSale();
                        break;
                    case "3":
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please input a numeral 1-3.");
                        break;

                }
            }
        }
    }
}
