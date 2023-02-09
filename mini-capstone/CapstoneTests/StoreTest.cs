using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
