using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP_4365_002_Spring_2024_Demo
{
    // Class Recognizer_Peak inherits from Recognizer, designed to identify Peak patterns in candlestick data.
    internal class Recognizer_Peak : Recognizer
    {
        // Constructor for Recognizer_Peak with "Peak" as the pattern name and 3 as the pattern length.
        public Recognizer_Peak() : base("Peak", 3)
        {
        }

        // Overrides the abstract method Recognize from the base class Recognizer to implement logic specific to identifying Peak patterns.
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
                if ((index < offset) | (index >= scsList.Count() - offset)) // Using bitwise OR should be logical OR here.
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

                    // Determine if the current candlestick's high is greater than the high of both adjacent candlesticks.
                    bool peak = (scs.high > prev.high) && (scs.high > next.high);

                    // Add the result of the Peak recognition to the dictionary.
                    scs.patterns.Add(patternName, peak);

                    // Return the result of the recognition.
                    return peak;
                }
            }
        }
    }
}
