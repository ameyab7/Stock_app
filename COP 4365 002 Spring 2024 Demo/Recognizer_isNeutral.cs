﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP_4365_002_Spring_2024_Demo
{
    // Class Recognizer_isNeutral inherits from Recognizer and is designed to identify Neutral patterns in candlestick data.
    internal class Recognizer_isNeutral : Recognizer
    {
        // Constructor for Recognizer_isNeutral with "Neutral" as the pattern name and 1 as the pattern length.
        public Recognizer_isNeutral() : base("Neutral", 1)
        {
        }

        // Overrides the abstract method Recognize from the base class Recognizer to implement logic specific to identifying Neutral patterns.
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
                // Calculate whether the body of the candlestick is less than 3% of the total range,
                // which would suggest a neutral market condition with no strong price movement in either direction.
                bool neutral = scs.bodyRange < (scs.range * 0.03m);

                // Add the result of the Neutral pattern recognition to the dictionary.
                scs.patterns.Add(patternName, neutral);

                // Return the result of the recognition.
                return neutral;
            }
        }
    }
}
