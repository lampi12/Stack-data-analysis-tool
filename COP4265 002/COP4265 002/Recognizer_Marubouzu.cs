using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4265_002
{
    internal class Recognizer_Marubouzu : Recognizer
    {
        /// <summary>
        /// A constructor for Recognizer_Marubouzu
        /// </summary>
        public Recognizer_Marubouzu() : base("Marubouzu", 1) 
        {

        }

        /// <summary>
        /// A method that recognizes smartcandlestick patterns 
        /// </summary>
        /// <param name="LSCS"></param>
        /// <param name="index"></param>
        /// <returns>bool</returns>
        public override bool Recognize(BindingList<SmartCandlestick> LSCS, int index)
        {
            // Retrieving SmartCandlestick object at the specified index
            SmartCandlestick SCS = LSCS[index];
            bool r = SCS.bodyrange >= (0.92m * SCS.range);
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
