using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Recognizes a Doji candlestick pattern based on the given candlestick data.
/// </summary>
/// <param name="scsList">List of smartCandlesticks representing the candlestick data.</param>
/// <param name="index">Index of the candlestick to analyze within the list.</param>
/// <returns>True if the candlestick is recognized as a Doji, false otherwise.</returns>


namespace COP_4365_002_Spring_2024_Demo
{
    internal class Recognizer_Doji:Recognizer
    {// Constructor to initialize the recognizer with the pattern name and length
        public Recognizer_Doji() : base("Doji", 1) { }

        // Override the Recognize method to implement the specific Doji pattern recognition logic
        public override bool Recognize(List<smartCandlesticks> scsList, int index)
        {
            //Return existing value or calculate
            smartCandlesticks scs = scsList[index];
            if (scs.patterns.TryGetValue(patternName, out bool value))
            {
                return value;
            }
            else
            {
                bool doji = scs.bodyRange < (scs.range * 0.03m);
                scs.patterns.Add(patternName, doji);
                return doji;
            }
        }
    }
}
