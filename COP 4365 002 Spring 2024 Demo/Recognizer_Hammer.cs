using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/// The Recognizer_isHammer class inherits from the abstract Recognizer class and overrides its Recognize method
/// to implement the specific Hammer pattern recognition logic.
/// The recognizer calculates the total range, body range, and lower tail of the candlestick under examination.
/// It checks whether the candlestick meets the Hammer criteria based on the calculated values.
///If the candlestick satisfies the criteria, the recognizer updates the patterns dictionary associated with the candlestick 
///instance, marking it as a Hammer pattern.

namespace COP_4365_002_Spring_2024_Demo
{
    internal class Recognizer_Hammer:Recognizer
    {
        public Recognizer_Hammer() : base("Hammer", 1) { }

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
                bool hammer = ((scs.range * 0.20m) < scs.bodyRange) & (scs.bodyRange < (scs.range * 0.33m)) & (scs.lowerTail > scs.range * 0.66m);
                scs.patterns.Add(patternName, hammer);
                return hammer;
            }
        }
    }
}
