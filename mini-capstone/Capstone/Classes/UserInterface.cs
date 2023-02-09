using System;
using System.Collections.Generic;
using System.Text;

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

        /// <summary>
        /// Provides all communication with human user.
        /// </summary>
        public void Greeting()
        {
            Console.WriteLine("Greetings!");
            // import inventory
        }
    }
}
