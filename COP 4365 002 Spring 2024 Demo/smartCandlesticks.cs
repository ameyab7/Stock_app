
///This code defines a smartCandlesticks class that extends a Candlestick class, designed to encapsulate financial candlestick data along with 
///various technical analysis patterns. It calculates additional properties such as range, top and bottom prices, body range, and tail lengths. 
///The ComputePatternProperties method identifies common candlestick patterns (e.g., Bullish, Bearish, Neutral, Marubozu, Hammer, Doji, Dragonfly Doji, Gravestone Doji) 
///based on the candlestick's price data and stores 
///the results in a dictionary, allowing for easy pattern recognition and analysis.


using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace COP_4365_002_Spring_2024_Demo
{

    // Defines the smartCandlesticks class, which inherits from the Candlestick class, to include pattern detection.

    internal class smartCandlesticks : Candlestick
    {
        public Dictionary<string, bool> patterns = new Dictionary<string, bool>();


        // Dictionary to hold boolean values for each pattern type, indicating if a pattern is present.

        public Decimal range { get; set; }
        public Decimal topPrice { get; set; }
        public Decimal bottomPrice { get; set; }
        public Decimal bodyRange { get; set; }
        public Decimal upperTail { get; set; }
        public Decimal lowerTail { get; set; }

       


        // Calculates additional metrics based on candlestick data.
        public smartCandlesticks(string rowofdata) : base(rowofdata)
        {
            ComputeExtraProperties();
           
        }

        public void ComputeExtraProperties()
        {
            range = high - low; // Total price range of the candlestick.
            topPrice = Math.Max(open, close); // Determines the top price based on open/close values.
            bottomPrice = Math.Min(open, close);// Determines the bottom price based on open/close values.
            bodyRange = topPrice - bottomPrice; // The size of the candlestick's body
            upperTail = high - topPrice; // Length of the upper shadow or tail.
            lowerTail = bottomPrice - low; // Length of the lower shadow or tail.
        }


        
    }
}
