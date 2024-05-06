
/// This code defines a Candlestick class that represents financial trading data
/// for a specific period (like a day or week). The constructor takes a string
/// representing a row of this data, splits it into its components (date, open, high, low, close prices, and volume)
/// parses them into the appropriate data types (DateTime for date, decimal for prices, and ulong for volume), 
///and sets the properties of the Candlestick object accordingly. The class is used to store and access the 
///details of a single candlestick in financial charting.
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP_4365_002_Spring_2024_Demo
{
    internal class Candlestick  //We have named the class candlestick because we want to create candlesticks.
    {
        // Properties to hold the open, close, high, low price data and volume for the candlestick.
        public decimal open { get; set; }

        // Properties to hold the  close for the candlestick.

        public decimal close { get; set; }

        // Properties to hold the high,  for the candlestick.

        public decimal high { get; set; }

        // Properties to hold the low price data for the candlestick.

        public decimal low { get; set; }
        // Properties to hold the volume for the candlestick.

        public ulong volume { get; set; }

        // Property to hold the date of the candlestick data
        public DateTime date { get; set; }

        // Constructor that takes a string containing the candlestick data
        public Candlestick() { }
        public Candlestick(string rowOfData)

        {
            // Define characters that will be used to split the input string

            char[] separators = new char[] { ',', ' ', '"' };
            // Split the input string into an array of strings

            string[] subs = rowOfData.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            //Get the date string so that we can send it to DateTime.Parse
            string dateString = subs[0];
            //Parse the date
            date = DateTime.Parse(dateString);
            // Temporary variable to hold the parsed decimal value

            decimal temp;

            // Try parsing the open price and set the property if successful


            bool success = decimal.TryParse(subs[1], out temp);
            if (success) open = temp;

            // Try parsing the high price and set the property if successful

            success = decimal.TryParse(subs[2], out temp);
            if (success) high = temp;

            // Try parsing the low price and set the property if successful

            success = decimal.TryParse(subs[3], out temp);
            if (success) low = temp;

            // Try parsing the close price and set the property if successful

            success = decimal.TryParse(subs[4], out temp);
            if (success) close = temp;

            ulong tempvolume;

            // Try parsing the volume and set the property if successful

            success = ulong.TryParse(subs[6], out tempvolume);
            if (success) volume = tempvolume;



        }
    }

   
}

   
