using System;
using System.Collections.Generic;

namespace COP_4365_002_Spring_2024_Demo
{
    // Recognizer_GravestoneDoji inherits from Recognizer to specifically recognize Gravestone Doji patterns.
    internal class Recognizer_GravestoneDoji : Recognizer
    {
        // Constructor sets the name of the pattern to "Gravestone Doji" and a pattern length of 1, 
        // indicating it only needs one candlestick to determine this pattern.
        public Recognizer_GravestoneDoji() : base("Gravestone Doji", 1) { }

        // Overrides the Recognize method to implement the specific logic for detecting a Gravestone Doji pattern.
        public override bool Recognize(List<smartCandlesticks> scsList, int index)
        {
            // Retrieves the smartCandlesticks object at the specified index.
            smartCandlesticks scs = scsList[index];

            // Attempts to get the pre-calculated pattern value from the dictionary to avoid re-calculation.
            if (scs.patterns.TryGetValue(patternName, out bool value))
            {
                return value;  // If found, returns the stored value.
            }
            else
            {
                // Calculate whether the upper tail is greater than 66% of the total range,
                // which is characteristic of a Gravestone Doji where the upper shadow is much longer than the body.
                bool gravestone = scs.upperTail > (scs.range * 0.66m);

                // Calculate whether the body of the candlestick is less than 3% of the total range,
                // indicating a very small body, typical of a Doji.
                bool doji = scs.bodyRange < (scs.range * 0.03m);

                // The candlestick is recognized as a Gravestone Doji if both conditions are true.
                bool gravestone_doji = gravestone & doji;

                // Stores the result in the patterns dictionary for future reference.
                scs.patterns.Add(patternName, gravestone_doji);

                // Returns the result of the recognition.
                return gravestone_doji;
            }
        }
    }
}
