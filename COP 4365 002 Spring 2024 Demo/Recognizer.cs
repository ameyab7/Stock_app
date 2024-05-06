using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP_4365_002_Spring_2024_Demo
{
    /// <summary>
    /// Abstract class representing a candlestick pattern recognizer.
    /// </summary>
    internal abstract class Recognizer
    {
        /// <summary>
        /// Gets the name of the pattern recognized by this recognizer.
        /// </summary>
        public string patternName { get; private set; }

        /// <summary>
        /// Gets the length of the pattern recognized by this recognizer.
        /// </summary>
        public int patternLength { get; private set; }

        /// <summary>
        /// Constructor for the Recognizer class.
        /// </summary>
        /// <param name="pName">The name of the pattern.</param>
        /// <param name="pLength">The length of the pattern.</param>
        protected Recognizer(string pName, int pLength)
        {
            // Set the pattern name and length
            this.patternName = pName;
            this.patternLength = pLength;
        }

        /// <summary>
        /// Abstract method that all concrete classes must implement.
        /// Analyzes a list of candlesticks and determines if the pattern is recognized.
        /// </summary>
        /// <param name="lscs">The list of candlesticks to analyze.</param>
        /// <param name="currentIndex">The index of the candlestick to analyze.</param>
        /// <returns>True if the pattern is recognized, otherwise false.</returns>
        public abstract bool Recognize(List<smartCandlesticks> lscs, int currentIndex);
        public void Recognize_ALL(List<smartCandlesticks> scsList)
        {
            for (int i = 0; i < scsList.Count; i++)
            {
                Recognize(scsList, i);
            }
        }
    }
}
