using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class StoreTest
    {
        [TestMethod]
        public void StoreTestObjectCreation() // This test is for reference and doesn't test anything meaningful. Feel free to delete it.
        {
            //Arrange
            Store testObject = new Store();

            //Act (done in arrange above)

            //Assert
            Assert.IsNotNull(testObject);
        }
    }
}
