using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4265_002
{
    internal class Recognizer_BearishHarami : Recognizer
    {
        /// <summary>
        /// Constructor for Recognizer_BearishHarami class
        /// </summary>
        public Recognizer_BearishHarami() : base("BearishHarami", 2)
        {

        }

        /// <summary>
        /// Recognizer method that recognizes patterns for smartcandlesticks 
        /// </summary>
        /// <param name="LSCS"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public override bool Recognize(BindingList<SmartCandlestick> LSCS, int index)
        {
            if (index > 0 && index < LSCS.Count - 1)
            {
                // Retrieving SmartCandlestick object at the specified index
                SmartCandlestick SCS = LSCS[index];
                // Retrieving SmartCandlestick object at the next index
                SmartCandlestick SCSNext = LSCS[index + 1];
                bool r = (SCSNext.close > SCS.open) && (SCSNext.open < SCS.close) && (SCSNext.range <= (0.85m * SCS.range)) && (SCSNext.open > SCSNext.close) && (SCS.open < SCS.close);
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
                //If index is out of range, return false
                return false;
            }
        }

    }
}
