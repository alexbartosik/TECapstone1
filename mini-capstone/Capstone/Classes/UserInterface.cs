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
                        Console.Clear();
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
            Cart cart = new Cart(); // create the customer's cart to add products and complete sale
            Store store = new Store();

            Console.Clear();
            while (keepGoing)
            {
                Console.WriteLine("Please select a menu option (1-3)");
                Console.WriteLine("(1) Take Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Complete Sale");
                //Customer Balance
                Console.WriteLine("Current Customer Balance: " + store.CustomerBalance.ToString("C"));
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        this.TakeMoney(store);
                        break;
                    case "2":
                        this.SelectProducts(cart, store);
                        break;
                    case "3":
                        this.CompleteSale(cart, store);
                        keepGoing = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input. Please input a numeral 1-3.");
                        Console.WriteLine();
                        break;

                }
            }
        }

        public void TakeMoney(Store store)
        {
            Console.Clear();
            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("Current Customer Balance: " + store.CustomerBalance.ToString("C"));
                Console.WriteLine();
                Console.WriteLine("Input the amount of money to add");
                Console.WriteLine("* Money can be added only in whole dollar amounts (1-100)");
                Console.WriteLine("* Maximum of $100 can be added at a time");
                Console.WriteLine("* Total balance cannot exceed $1000");
                Console.WriteLine("* Enter 0 to return to Make Sale Menu.");

                // Take validate user input and convert to int
                string strAmount = Console.ReadLine();
                try
                {
                    int amount = int.Parse(strAmount);

                    if (amount <= 100 && amount > 0)
                    {
                        if (store.CustomerBalance + amount <= 1000)
                        {
                            // Add money to the balance
                            store.AddMoney(amount);
                            Console.Clear();
                        }
                        else
                        {
                            // Prompt balance above $1000 error
                            Console.Clear();
                            Console.WriteLine("Number entered is invalid.  Please try again.");
                            Console.WriteLine("* Total balance cannot exceed $1000");
                            Console.WriteLine();
                        }
                    }
                    // Check for negitive numbers
                    else if (amount == 0)
                    {
                        // Exit to Make Sale
                        keepGoing = false;
                        Console.Clear();
                    }
                    else
                    {
                        // Prompt maximum addition of $100 error
                        Console.Clear();
                        Console.WriteLine("Number entered is invalid.  Please try again.");
                        Console.WriteLine("* Maximum of $100 can be added at a time");
                        Console.WriteLine();
                    }
                }
                catch (FormatException)
                {
                    // Prompt whole number error
                    Console.Clear();
                    Console.WriteLine("Number entered is invalid.  Please try again.");
                    Console.WriteLine("* Money can be added only in whole dollar amounts (1-100)");
                    Console.WriteLine();
                }
            }
        }

        public void SelectProducts(Cart cart, Store store)
        {
            this.ShowInventory();
            Console.WriteLine();
            Console.WriteLine("Please enter a product Id to add to the cart");

            string userInputId = Console.ReadLine().ToUpper();

            // check inventory for valid user input Id
            Candy selectedCandy = inventory.CheckInventoryId(userInputId);
            if (selectedCandy != null)
            {
                Console.WriteLine("Please enter the quantity of product to add to the cart");
                try
                {
                    string strUserInputQty = Console.ReadLine().ToUpper();
                    // parse user input into usable integer
                    int userInputQty = int.Parse(strUserInputQty);

                    // check inventory for valid user input qty
                    int inventoryQtyExistsCondition = inventory.CheckInventoryQty(selectedCandy, userInputQty);

                    switch (inventoryQtyExistsCondition)
                    {
                        case 0: // Invalid input
                            Console.Clear();
                            Console.WriteLine("Quantity is outside of accepted range. Please try another whole quantity (1-100)");
                            Console.WriteLine();
                            break;

                        case 2: // Process sale
                            // check if user has sufficient funds
                            bool sufficientFunds = store.CheckAvailableBalance(selectedCandy, userInputQty);
                            if (sufficientFunds)
                            { // user isn't poor
                                // add the candy to cart
                                cart.AddToCart(selectedCandy, userInputQty, store, inventory);
                                Console.Clear();
                            }
                            else // user is poor
                            {
                                Console.Clear();
                                Console.WriteLine("Insufficient funds. Stop being poor.");
                                Console.WriteLine();
                            }
                            break;

                        case 1: // Product SOLD OUT
                            Console.Clear();
                            Console.WriteLine("This product is SOLD OUT. Please choose another product.");
                            Console.WriteLine();
                            break;

                        case 3: // Insufficient qty
                            Console.Clear();
                            Console.WriteLine("Insufficient quantity. Check available stock and try again.");
                            Console.WriteLine();
                            break;
                    }
                }
                catch (FormatException) // Ensures user inputs a whole integer 1-100
                {
                    Console.Clear();
                    Console.WriteLine("Quantity entered is the wrong format. Please enter a whole integer (1-100).");
                    Console.WriteLine();
                }
            }
            else // Item doesn't exist in inventory
            {
                Console.Clear();
                Console.WriteLine("Invalid product Id. Product is not in inventory.");
                Console.WriteLine();
            }
        }

        public void CompleteSale(Cart cart, Store store)
        {
            Console.Clear();

            // print receipt
            Console.WriteLine("Purchase Summary:");
            Console.WriteLine();
            string[] receipt = cart.DisplayCart();
            foreach (string item in receipt)
            {
                Console.WriteLine(item);
            }

            // make change
            Console.WriteLine();
            string change = store.MakeChange();
            Console.WriteLine(change);
        }
    }
}
