using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4265_002
{
    internal class Recognizer_Bullish : Recognizer
    {
        /// <summary>
        /// Constructor for Recognizer_Bullish class
        /// </summary>
        public Recognizer_Bullish() : base("Bullish", 1)
        {

        }

        /// <summary>
        /// Recognize method that recognizes patterns for smartcandlesticks
        /// </summary>
        /// <param name="LSCS"></param>
        /// <param name="index"></param>
        /// <returns>Bool</returns>
        public override bool Recognize(BindingList<SmartCandlestick> LSCS, int index)
        {
            // Retrieving SmartCandlestick object at the specified index
            SmartCandlestick SCS = LSCS[index];
            bool r = SCS.close > SCS.open;
            // Check if the pattern already exists in the dictionary
            if (!SCS.candlestickpattern.ContainsKey(patternName))
            {
                // Add patternName and boolean value to dictionary
                SCS.candlestickpattern.Add(patternName, r);
            }
            return r;
        }
        
    }
}
