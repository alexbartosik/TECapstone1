using Capstone.Classes;
using Capstone.Classes.CandyClasses;
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
        

        public void CreateCandyFromImportCreatesCorrectCandy(string candyType, string id, string name, double price, string wrapped)
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

        [TestMethod]
        [DataRow("CH","C1", "C1")]
        public void CheckInventoryIdReturnsProperCandyId(string classId,string id, string expectResult)
        {
            // Arrange
            Inventory testInventory = new Inventory();
            testInventory.CreateCandyFromImport(classId, id, "Test", 1, "T");

            // Act
            Candy resultCandy = testInventory.CheckInventoryId(id);

            // Assert
            Assert.AreEqual(expectResult, resultCandy.Id);
        }

        [TestMethod]
        [DataRow("QQ", "C1", "C1")]
        public void CheckInventoryIdReturnsNullIfCalledIdDoesNotExistInInventory(string classId, string id, string expectResult)
        {
            // Arrange
            Inventory testInventory = new Inventory();
            testInventory.CreateCandyFromImport(classId, id, "Test", 1, "T");

            // Act
            Candy resultCandy = testInventory.CheckInventoryId(id);

            // Assert
            Assert.IsNull(resultCandy);
        }

        [TestMethod]
        [DataRow(10,90)]
        public void CheckRemoveInventoryProperlyDecrementsInventoryQty(int quantityToRemove, int expectedInventoryQty)
        {
            // Arrange
            Inventory testInventory = new Inventory(); //Create inventory
            testInventory.CreateCandyFromImport("CH", "C1", "Test", 1, "T"); // Add candy to inventory w/ quantity 100
            Candy testCandy = testInventory.CheckInventoryId("C1"); // Create candy
            int actualInventory = 0;

            // Act
            testInventory.RemoveFromInventory(testCandy, quantityToRemove); // call test method
            List<KeyValuePair<Candy, int>> testList = testInventory.ListOfCurrentInventory(); // create list of current inventory values
            foreach(KeyValuePair<Candy,int> candy in testList) // find the quantity in the list
            {
                if(candy.Key == testCandy)
                {
                    actualInventory = candy.Value;
                }
            }

            // Assert
            Assert.AreEqual(expectedInventoryQty, actualInventory); 
        }


        /*
        [TestMethod] // Finish after decrement inventory method
        [DataRow(100,2)]
        [DataRow(101,)]
        [DataRow(-1,)]

        public void CheckInventoryQtyReturnsProperCondition(int testQty, int expectResult)
        {
            // Arrange
            Inventory testInventory = new Inventory();
            testInventory.CreateCandyFromImport("CH", "C1", "Test", 1, "T");
            Candy testCandy = testInventory.CheckInventoryId("C1");

            // Act
            int result = testInventory.CheckInventoryQty(testCandy, testQty);

            // Assert


        }
        */
    }
}
