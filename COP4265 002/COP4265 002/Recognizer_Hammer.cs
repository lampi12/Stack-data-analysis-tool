using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace COP4265_002
{
    internal class Recognizer_Hammer : Recognizer
    {
        /// <summary>
        /// // Constructor for Recognizer_Hammer class, calling base constructor with parameters "Hammer" and 1
        /// </summary>
        public Recognizer_Hammer() :base("Hammer", 1)
        {

        }

        /// <summary>
        /// This overides the Recognize function in the base class and recognizes if a pattern is a Hammer
        /// </summary>
        /// <param name="LSCS"></param>
        /// <param name="index"></param>
        /// <returns>A bool</returns>
        public override bool Recognize(BindingList<SmartCandlestick> LSCS, int index)
        {
            // Retrieving SmartCandlestick object at the specified index
            SmartCandlestick SCS = LSCS[index];
            bool r = (SCS.close >= ((98 / 100m) * SCS.high) && (SCS.close - SCS.low) >= ((50 / 100m) * SCS.bodyrange)) && SCS.uppertail >= (2 * SCS.bodyrange);
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
