using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace COP4265_002
{
    internal class Recognizer_Neutral : Recognizer
    {
        /// <summary>
        /// A constructor for Recognizer_Neutral 
        /// </summary>
        public Recognizer_Neutral(): base("Neutral", 1)
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
            bool r = SCS.open == SCS.close;
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
