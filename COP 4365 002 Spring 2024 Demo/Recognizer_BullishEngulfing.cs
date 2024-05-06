using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP_4365_002_Spring_2024_Demo
{
    // Class Recognizer_BullishEngulfing inherits from Recognizer and is designed to identify Bullish Engulfing patterns in candlestick data.
    internal class Recognizer_BullishEngulfing : Recognizer
    {
        // Constructor sets the pattern name to "Bullish Engulfing" and specifies that the pattern spans two candlesticks.
        public Recognizer_BullishEngulfing() : base("Bullish Engulfing", 2)
        { }

        // Overrides the abstract method Recognize to implement the logic specific to identifying a Bullish Engulfing pattern.
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

                    // Define the criteria for a Bullish Engulfing pattern.
                    bool bullish = (prev.open > prev.close) && (scs.close > scs.open); // Previous candle is bearish and current is bullish.
                    bool engulfing = (scs.open < prev.close) && (scs.close > prev.open); // Current candlestick completely engulfs the previous candlestick.

                    // The pattern is recognized as Bullish Engulfing if both bullish and engulfing conditions are true.
                    bool bullish_engulfing = bullish && engulfing;

                    // Add the result of the Bullish Engulfing recognition to the dictionary.
                    scs.patterns.Add(patternName, bullish_engulfing);

                    // Return the result of the recognition.
                    return bullish_engulfing;
                }
            }
        }
    }
}
