using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4265_002
{
    internal class Recognizer_BullishEngulfing : Recognizer
    {
        /// <summary>
        /// A constructor for Recognizer_BullishEngulfing 
        /// </summary>
        public Recognizer_BullishEngulfing() : base("BullishEngulfing", 2) 
        {
            
        }

        /// <summary>
        /// Recognize method that recognizes smartcandlestick patterns 
        /// </summary>
        /// <param name="LSCS"></param>
        /// <param name="index"></param>
        /// <returns>bool</returns>
        public override bool Recognize(BindingList<SmartCandlestick> LSCS, int index)
        {
            if (index > 0 && index < LSCS.Count - 1)
            {
                // Retrieving SmartCandlestick object at the specified index
                SmartCandlestick SCS = LSCS[index];
                // Retrieving SmartCandlestick object at the next index
                SmartCandlestick SCSNext = LSCS[index + 1];
                bool r = SCS.high < SCSNext.high && SCS.low > SCSNext.low && SCS.open > SCS.close && SCSNext.close > SCSNext.open;
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
