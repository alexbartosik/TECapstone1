using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class InventoryTests
    {
        [TestMethod]
        public void AddInventoryAddsCandyWithQuantity100()
        {
            // arrange
            Candy test = new ChocolateConfectionery("TEST", "TEST", 1.00m, "TEST");
            Inventory testinv = new Inventory();

            // act
            testinv.AddInventory(test);

            // assert
            Assert.AreEqual(100, testinv.inventory[test]);
        }

        [TestMethod]
        public void AddInventoryDoesNotAddToDictionaryIfCandyIsNull()
        {
            // arrange
            Candy test = null;
            Inventory testinv = new Inventory();

            // act
            testinv.AddInventory(test);

            // assert
            Assert.AreEqual(0, testinv.inventory.Count);
        }

        [TestMethod]
        [DataRow("CH", "C1", "test", 1.00, "test")]
        [DataRow("SR", "S1", "test", 1.00, "test")]
        [DataRow("HC", "H1", "test", 1.00, "test")]
        [DataRow("LI", "L1", "test", 1.00, "test")]
        
        public void CreateCandyFromImportCreatesCandy(string candyType, string id, string name, double price, string wrapped)
        {
            // arrange
            decimal dprice = (decimal)price;
            Inventory testinv = new Inventory();

            // act
            testinv.CreateCandyFromImport(candyType, id, name, dprice, wrapped);

            // assert
            Assert.AreEqual(1, testinv.inventory.Count);
        }

        [TestMethod]
        [DataRow("HF", "L1", "test", 1.00, "test")]
        public void CreateCandyFromImportDoesNotCreateCandy(string candyType, string id, string name, double price, string wrapped)
        {
            // arrange
            decimal dprice = (decimal)price;
            Inventory testinv = new Inventory();

            // act
            testinv.CreateCandyFromImport(candyType, id, name, dprice, wrapped);

            // assert
            Assert.AreEqual(0, testinv.inventory.Count);
        }
    }
}
