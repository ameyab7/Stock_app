using COP_4365_002_Spring_2024_Demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp_COP_4365
{
    // Class Recognizer_Dragonfly_Doji inherits from Recognizer, intended to identify Dragonfly Doji candlestick patterns
    internal class Recognizer_Dragonfly_Doji : Recognizer
    {
        // Constructor initializes the Recognizer base class with the name "Dragonfly Doji" and a pattern length of 1
        public Recognizer_Dragonfly_Doji() : base("Dragonfly Doji", 1)
        {
        }

        // Override the abstract method Recognize from the base class to implement specific logic for recognizing a Dragonfly Doji pattern
        public override bool Recognize(List<smartCandlesticks> scsList, int index)
        {
            // Retrieve the smartCandlesticks object at the specified index from the list
            smartCandlesticks scs = scsList[index];

            // Try to retrieve the previously calculated value for the pattern recognition from the dictionary
            if (scs.patterns.TryGetValue(patternName, out bool value))
            {
                // If found, return the existing value without recalculating
                return value;
            }
            else
            {
                // Calculate if the lower tail is greater than 66% of the total candlestick range
                bool df = scs.lowerTail > (scs.range * 0.66m);

                // Calculate if the body range is less than 3% of the total candlestick range, indicating a Doji
                bool doji = scs.bodyRange < (scs.range * 0.03m);

                // A Dragonfly Doji occurs if both the lower tail is long and the body is small
                bool dragonfly_doji = df & doji;

                // Add the result of the Dragonfly Doji recognition to the dictionary for future reference
                scs.patterns.Add(patternName, dragonfly_doji);

                // Return the result of the recognition
                return dragonfly_doji;
            }
        }
    }
}
