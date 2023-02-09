using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
            List<KeyValuePair<Candy, int>> testList;

            // act
            testinv.AddInventory(test);
            testList = testinv.ListOfCurrentInventory();

            // assert
            Assert.AreEqual(100, testList[0].Value);
        }

        [TestMethod]
        public void AddInventoryDoesNotAddToDictionaryIfCandyIsNull()
        {
            // arrange
            Candy test = null;
            Inventory testinv = new Inventory();
            List<KeyValuePair<Candy, int>> testList;

            // act
            testinv.AddInventory(test);
            testList = testinv.ListOfCurrentInventory();

            // assert
            Assert.AreEqual(0, testList.Count);
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
            List<KeyValuePair<Candy, int>> testList;

            // act
            testinv.CreateCandyFromImport(candyType, id, name, dprice, wrapped);
            testList = testinv.ListOfCurrentInventory();


            // assert
            Assert.AreEqual(1, testList.Count);
        }

        [TestMethod]
        [DataRow("HF", "L1", "test", 1.00, "test")]
        public void CreateCandyFromImportDoesNotCreateCandy(string candyType, string id, string name, double price, string wrapped)
        {
            // arrange
            decimal dprice = (decimal)price;
            Inventory testinv = new Inventory();
            List<KeyValuePair<Candy, int>> testList;

            // act
            testinv.CreateCandyFromImport(candyType, id, name, dprice, wrapped);
            testList = testinv.ListOfCurrentInventory();

            // assert
            Assert.AreEqual(0, testList.Count);
        }
    }
}
