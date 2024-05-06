using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP_4365_002_Spring_2024_Demo
{
    internal class Recognizer_BearishHarami:Recognizer
    {
        public Recognizer_BearishHarami() : base("Bearish Harami", 2) // PatternLength is set to 2 because we need to check two candlesticks
        { }

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
                    bool harami = (scs.topPrice < prev.topPrice) & (scs.bottomPrice > prev.bottomPrice);
                    bool bearish_harami = bearish & harami;
                    scs.patterns.Add(patternName, bearish_harami);
                    return bearish_harami;
                }
            }
        }
    }
}
