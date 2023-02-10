using Capstone.Classes;
using Capstone.Classes.CandyClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        [DataRow(50, 50, 50)]
        public void AddToCartMethodWorks(int qty, double expectedBal, int expectedInventoryQty)
        {
            // arrange
            decimal decExpectedBal = (decimal)expectedBal;
            Store store = new Store();
            store.AddMoney(100);
            Inventory inventory = new Inventory();
            List<KeyValuePair<Candy, int>> testList;
            List<KeyValuePair<Candy, int>> cartList;
            inventory.CreateCandyFromImport("CH", "C1", "test", 1, "t");
            Candy candy = inventory.CheckInventoryId("C1");
            Cart cart = new Cart();

            // act
            cart.AddToCart(candy, qty, store, inventory);
            testList = inventory.ListOfCurrentInventory();
            cartList = cart.GetCartList();

            // assert
            Assert.AreEqual(decExpectedBal, store.CustomerBalance);
            Assert.AreEqual(expectedInventoryQty, testList[0].Value);
            Assert.AreEqual(qty, cartList[0].Value);
        }
    }
}
