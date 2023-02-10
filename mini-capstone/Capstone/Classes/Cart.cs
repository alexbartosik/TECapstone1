using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes.CandyClasses;

namespace Capstone.Classes
{
    public class Cart
    {
        OutputLog log = new OutputLog();

        //field
        private List<KeyValuePair<Candy, int>> customerCart = new List<KeyValuePair<Candy, int>>();

        public Cart()
        {

        }

        public void AddToCart(Candy selectedCandy, int quantity, Store store, Inventory inventory)
        {
            //Combine candy and customer quanity then add to cart
            KeyValuePair<Candy, int> candyToBeAdded = new KeyValuePair<Candy, int>(selectedCandy, quantity);
            customerCart.Add(candyToBeAdded);

            // Remove from inventory
            inventory.RemoveFromInventory(selectedCandy, quantity);

            // Decrement Balance
            decimal purchasePrice = selectedCandy.Price * quantity;
            store.RemoveMoney(purchasePrice);

            string output = $"{quantity} {selectedCandy.Name} {selectedCandy.Id} {purchasePrice.ToString("C")} {store.CustomerBalance.ToString("C")}";
            log.WriteToLog(output);
        }

        public List<KeyValuePair<Candy, int>> GetCartList()
        {
            return customerCart;
        }

        public string[] DisplayCart()
        {
            string[] receipt = new string[customerCart.Count+2];
            int counter = 0;
            decimal totalCartPrice = 0m;
            foreach (KeyValuePair<Candy, int> item in customerCart)
            {
                int qty = item.Value;
                string name = item.Key.Name;
                string type = item.Key.FullClassName;
                decimal price = item.Key.Price;
                decimal totPrice = qty * price;
                totalCartPrice += totPrice;

                string output = $"{qty.ToString().PadRight(5)} {name.PadRight(20)} {type.PadRight(30)} {price.ToString("C").PadRight(8)} {totPrice.ToString("C")}";
                receipt[counter] = output;
                counter++;
            }
            receipt[counter] = "";
            counter++;
            receipt[counter] = "Total: " + totalCartPrice.ToString("C");
            return receipt;
        }
    }
}
