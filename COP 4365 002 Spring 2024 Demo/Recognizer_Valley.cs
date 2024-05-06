using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP_4365_002_Spring_2024_Demo
{
    // Class Recognizer_Valley inherits from Recognizer and is designed to identify Valley patterns in candlestick data.
    internal class Recognizer_Valley : Recognizer
    {
        // Constructor for Recognizer_Valley with "Valley" as the pattern name and 3 as the pattern length.
        public Recognizer_Valley() : base("Valley", 3)
        {
        }

        // Overrides the abstract method Recognize from the base class Recognizer to implement logic specific to identifying Valley patterns.
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
                // Check if the index is out of bounds for calculating the pattern, considering the necessary offset.
                int offset = patternLength / 2; // The offset needed to check candlesticks before and after the current index.
                if ((index < offset) | (index == scsList.Count() - offset)) // Using bitwise OR should be logical OR here.
                {
                    // If out of bounds, add a false entry for this pattern to the dictionary and return false.
                    scs.patterns.Add(patternName, false);
                    return false;
                }
                else
                {
                    // Retrieve candlesticks adjacent to the current index for comparison.
                    smartCandlesticks prev = scsList[index - offset];
                    smartCandlesticks next = scsList[index + offset];

                    // Determine if the current candlestick's low is less than the low of both adjacent candlesticks.
                    bool valley = (scs.low < prev.low) && (scs.low < next.low);

                    // Add the result of the valley recognition to the dictionary.
                    scs.patterns.Add(patternName, valley);

                    // Return the result of the recognition.
                    return valley;
                }
            }
        }
    }
}
