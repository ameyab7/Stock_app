using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP_4365_002_Spring_2024_Demo
{
    // Class Recognizer_isBearish inherits from Recognizer, designed to identify Bearish patterns in candlestick data.
    internal class Recognizer_isBearish : Recognizer
    {
        // Constructor for Recognizer_isBearish with "Bearish" as the pattern name and 1 as the pattern length.
        public Recognizer_isBearish() : base("Bearish", 1)
        {
        }

        // Overrides the abstract method Recognize from the base class Recognizer to implement logic specific to identifying Bearish patterns.
        public override bool Recognize(List<smartCandlesticks> scsList, int index)
        {
            // Retrieve the smartCandlesticks object at the specified index from the list.
            smartCandlesticks scs = scsList[index];

            // Attempt to retrieve the previously computed value for the pattern from the patterns dictionary.
            if (scs.patterns.TryGetValue(patternName, out bool value))
            {
                // If the value is found in the dictionary, return it without recalculating.
                return value;
            }
            else
            {
                // Calculate whether the candlestick is bearish by checking if the open price is greater than the close price.
                bool bearish = scs.open > scs.close;

                // Add the result of the Bearish pattern recognition to the dictionary.
                scs.patterns.Add(patternName, bearish);

                // Return the result of the recognition.
                return bearish;
            }
        }
    }
}
