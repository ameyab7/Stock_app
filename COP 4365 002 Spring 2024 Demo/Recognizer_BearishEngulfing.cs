using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Recognizes a Bearish Engulfing candlestick pattern based on the given candlestick data.
/// </summary>
namespace COP_4365_002_Spring_2024_Demo
{
    internal class Recognizer_BearishEngulfing : Recognizer
    {
        public Recognizer_BearishEngulfing() : base("Bearish Engulfing", 2) { }

        /// <summary>
        /// Recognizes the Bearish Engulfing pattern for the candlestick at the specified index in the provided list.
        /// </summary>
        /// <param name="scsList">The list of smartCandlesticks representing the candlestick data.</param>
        /// <param name="index">The index of the candlestick to analyze within the list.</param>
        /// <returns>True if the candlestick is recognized as a Bearish Engulfing pattern, false otherwise.</returns>

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
                //Return false if out of bounds or continue to calculation
                int offset = patternLength / 2;
                if (index < offset)
                {
                    scs.patterns.Add(patternName, false);
                    return false;
                }
                else
                {
                    smartCandlesticks prev = scsList[index - offset];
                    bool bearish = (prev.open < prev.close) & (scs.close < scs.open);
                    bool engulfing = (scs.topPrice > prev.topPrice) & (scs.bottomPrice < prev.bottomPrice);
                    bool bearish_engulfing = bearish & engulfing;
                    scs.patterns.Add(patternName, bearish_engulfing);
                    return bearish_engulfing;
                }
            }

        }


    }
}

