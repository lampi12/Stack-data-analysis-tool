using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4265_002
{
    internal class Recognizer_BearishEngulfing : Recognizer
    {
        /// <summary>
        /// Constructor for Recognizer_BearishEngulfing class
        /// </summary>
        public Recognizer_BearishEngulfing() : base("BearishEngulfing", 2)
        {

        }

        /// <summary>
        /// Recognize method that recognizes BearishEngulfing candlestick patterns 
        /// </summary>
        /// <param name="LSCS"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool Recognize(BindingList<SmartCandlestick> LSCS, int index)
        {
            // Checking if the index is within the range of the list LSCS
            if (index < LSCS.Count - 1)
            {
                // Retrieving SmartCandlestick object at the specified index
                SmartCandlestick SCS = LSCS[index];
                // Retrieving SmartCandlestick object at the next index
                SmartCandlestick SCSNext = LSCS[index + 1];
                bool r = SCS.high < SCSNext.high && SCS.low > SCSNext.low && SCS.close > SCS.open && SCSNext.open > SCSNext.close;
                // Check if the pattern already exists in the dictionary
                if (!SCS.candlestickpattern.ContainsKey(patternName))
                {
                    // Add patternName and boolean value to dictionary
                    SCS.candlestickpattern.Add(patternName, r);
                }
                return r;
            }
            else
            {
                return false;
            }
        }

    }
}
