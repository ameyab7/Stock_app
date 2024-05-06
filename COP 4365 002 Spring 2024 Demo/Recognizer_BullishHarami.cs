using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP_4365_002_Spring_2024_Demo
{
    // Class Recognizer_BullishHarami inherits from Recognizer, designed to identify Bullish Harami patterns in candlestick data.
    internal class Recognizer_BullishHarami : Recognizer
    {
        // Constructor sets the pattern name to "Bullish Harami" and specifies that the pattern spans two candlesticks.
        public Recognizer_BullishHarami() : base("Bullish Harami", 2)
        { }

        // Overrides the abstract Recognize method to implement the logic specific to identifying a Bullish Harami pattern.
        public override bool Recognize(List<smartCandlesticks> scsList, int index)
        {
            // Retrieve the smartCandlesticks object at the specified index from the list.
            smartCandlesticks scs = scsList[index];

            // Attempt to retrieve the previously computed value for the pattern from the dictionary.
            if (scs.patterns.TryGetValue(patternName, out bool value))
            {
                // If the value is found in the dictionary, return it without recalculating.
                return value;
            }
            else
            {
                // Check if there are enough preceding candlesticks to compare with the current one.
                int offset = patternLength / 2; // Since patternLength is 2, offset is 1.
                if (index < offset) // Check if the current index allows for accessing the previous candlestick.
                {
                    // If not enough candlesticks before the current one, return false and add it to the dictionary.
                    scs.patterns.Add(patternName, false);
                    return false;
                }
                else
                {
                    // Retrieve the previous candlestick to compare with the current candlestick.
                    smartCandlesticks prev = scsList[index - offset]; // Index - 1 to get the previous candlestick.

                    // Check if the previous candlestick is bearish and the current candlestick is bullish.
                    bool bullish = (prev.open > prev.close) & (scs.close > scs.open);

                    // Check if the current candlestick's body is within the previous candlestick's body range.
                    bool harami = (scs.topPrice < prev.topPrice) & (scs.bottomPrice > prev.bottomPrice);

                    // The pattern is recognized as Bullish Harami if both bullish and harami conditions are true.
                    bool bullish_harami = bullish & harami;

                    // Add the result of the Bullish Harami recognition to the dictionary.
                    scs.patterns.Add(patternName, bullish_harami);

                    // Return the result of the recognition.
                    return bullish_harami;
                }
            }
        }
    }
}
