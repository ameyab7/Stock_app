using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP_4365_002_Spring_2024_Demo
{
    // Class Recognizer_Marubozu inherits from Recognizer, designed to identify Marubozu patterns in candlestick data.
    internal class Recognizer_Marubozu : Recognizer
    {
        // Constructor for Recognizer_Marubozu with "Marubozu" as the pattern name and 1 as the pattern length.
        public Recognizer_Marubozu() : base("Marubozu", 1)
        {
        }

        // Overrides the abstract method Recognize from the base class Recognizer to implement logic specific to identifying Marubozu patterns.
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
                // Calculate whether the body of the candlestick occupies at least 96% of the total range, typical of a Marubozu.
                bool marubozu = scs.bodyRange > (scs.range * 0.96m);

                // Add the result of the Marubozu recognition to the dictionary.
                scs.patterns.Add(patternName, marubozu);

                // Return the result of the recognition.
                return marubozu;
            }
        }
    }
}
