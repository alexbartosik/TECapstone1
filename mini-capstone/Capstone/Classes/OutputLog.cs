using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Capstone.Classes
{
    public class OutputLog
    {
        string filepath = @"C:\Store\Log.txt";

        public void MoneyReceived(decimal depositAmount, decimal balance)
        {
            string deposit = depositAmount.ToString("C");
            string totalBal = balance.ToString("C");
            string output = $"MONEY RECEIVED: {deposit} {totalBal}";
            WriteToLog(output);
        }

        public void ChangeGiven(decimal change)
        {
            string output = $"CHANGE GIVEN: {change.ToString("C")} $0.00";
            WriteToLog(output);
        }

        public void WriteToLog(string output)
        {
            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                string date = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                string line = $"{date} {output}";
                writer.WriteLine(line);
            }
        }
    }
}
