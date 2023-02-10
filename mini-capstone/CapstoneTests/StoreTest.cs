using Capstone.Classes;
using Capstone.Classes.CandyClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Xml.Linq;

namespace CapstoneTests
{
    [TestClass]
    public class StoreTest
    {
        [TestMethod]
        [DataRow(100, 100)]
        [DataRow(1001, 0)]
        [DataRow(0, 0)]
        public void AddMoneyAddsMoneyToBalance(int amount, int balance)
        {
            //Arrange
            Store test = new Store();

            //Act
            test.AddMoney(amount);

            //Assert
            Assert.AreEqual(balance, test.CustomerBalance);
        }

        [TestMethod]
        [DataRow(90, true)]
        [DataRow(0, true)]
        [DataRow(101, false)]
        public void CheckAvailableBalanceReturnsCorrectBool(int userQty, bool expected)
        {
            // arrange
            Store test = new Store();
            Candy testCandy = new ChocolateConfectionery("TEST", "TEST", 1, "TEST");
            test.AddMoney(100); // add $100 to balance

            // act
            bool sufficientFunds = test.CheckAvailableBalance(testCandy, userQty);

            // assert
            Assert.AreEqual(expected, sufficientFunds);
        }

        [TestMethod]
        [DataRow(10, 90)]
        [DataRow(0, 100)]
        [DataRow(100, 0)]
        public void CheckRemoveMoneyProperlyDecementsBalance(double amountOfSale, double expectedBalance)
        {
            // arrange
            Store test = new Store();
            test.AddMoney(100);
            decimal expectSale = (decimal)amountOfSale;
            decimal decBalance = (decimal)expectedBalance;


            // act
            test.RemoveMoney(expectSale);
            

            // assert
            Assert.AreEqual(decBalance, test.CustomerBalance);
        }
    }
}
