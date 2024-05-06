using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP_4365_002_Spring_2024_Demo
{
    internal class Recognizer_isBullish : Recognizer
    { //Inherit Constructor
        public Recognizer_isBullish() : base("Bullish", 1)
        {
        }

        //Abstract Method
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
                bool bullish = scs.close > scs.open;
                scs.patterns.Add(patternName, bullish);
                return bullish;
            }
        }
    }
}