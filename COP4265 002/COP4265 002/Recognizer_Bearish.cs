using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4265_002
{
    internal class Recognizer_Bearish: Recognizer
    {
        /// <summary>
        /// Constructor for Recognizer_Bearish class, calling base constructor with parameters "Bearish" and 1
        /// </summary>
        public Recognizer_Bearish() : base("Bearish", 1) 
        {
            
        }

        /// <summary>
        /// This method regcognizes Bearish patterns and reuturns a bool
        /// </summary>
        /// <param name="LSCS"></param>
        /// <param name="index"></param>
        /// <returns>A bool</returns>
        public override bool Recognize(BindingList<SmartCandlestick> LSCS, int index)
        {
            // Retrieving SmartCandlestick object at the specified index
            SmartCandlestick SCS = LSCS[index];
            bool r = SCS.close < SCS.open;
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
