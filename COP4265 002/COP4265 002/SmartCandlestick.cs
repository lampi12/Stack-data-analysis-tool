using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace COP4265_002
{
    internal class SmartCandlestick : Candlestick
    {
        // Declaring a public property called range of type decimal
        public decimal range { get; set; }
        // Declaring a public property called bodyrange of type decimal
        public decimal bodyrange { get; set; }
        // Declaring a public property called topprice of type decimal
        public decimal topprice { get; set; }
        // Declaring a public property called bottomprice of type decimal
        public decimal bottomprice { get; set; }
        // Declaring a public property called uppertail of type decimal
        public decimal uppertail { get; set; }
        // Declaring a public property called lowertail of type decimal
        public decimal lowertail { get; set; }

        // Dictionary to store candlestick pattern names and corresponding boolean values indicating their presence
        public Dictionary<string, bool> candlestickpattern = new Dictionary<string, bool>();

        /// <summary>
        /// Method to compute additional properties of the candlestick
        /// </summary>
        public void Computeaddedproperties()
        {
            // Calculating the length of upper and lower tails of the candlestick
            lowertail = Math.Min(open, close) - low; // Calculating the value of lowertail
            uppertail = high - Math.Max(open, close); // Calculating the value of uppertail
            // Calculating the price range of the body of the candlestick
            bottomprice = Math.Min(open, close); // Calculating the value of bottomprice
            topprice = Math.Max(open, close); // Calculating the value of topprice
            bodyrange = topprice - bottomprice; // Calculating the value of bodyrange
            // Calculating the total range of the candlestick
            range = high - low; // Calculating the value of range
        }

        /// <summary>
        /// Method to compute properties related to candlestick patterns
        /// </summary>
        //public void Computepatternproperties()
        //{
        //    // Clearing the dictionary before updating it with new pattern values
        //    candlestickpattern.Clear();

        //    // Determining if the candlestick is bullish (open < close) and adding the result to the dictionary
        //    bool isbullish = open < close;
        //    // Adding the result to the candlestickpattern dictionary with key "bullish"
        //    candlestickpattern.Add("bullish", isbullish);

        //    // Determining if the candlestick is bearish (open > close) and adding the result to the dictionary
        //    bool isbearish = open > close; ;
        //    // Adding the result to the candlestickpattern dictionary with key "bearish"
        //    candlestickpattern.Add("bearish", isbearish);

        //    // Determining if the candlestick is a doji and adding the result to the dictionary
        //    bool isdoji = Math.Abs(open - close) <= ((5 / 100m) * range);
        //    // Adding the result to the candlestickpattern dictionary with key "doji"
        //    candlestickpattern.Add("doji", isdoji);

        //    // Determining if the candlestick is a marubouzu and adding the result to the dictionary
        //    bool ismarubouzu = bodyrange >= ((92 / 100m) * range);
        //    // Adding the result to the candlestickpattern dictionary with key "marubouzu"
        //    candlestickpattern.Add("marubouzu", ismarubouzu);

        //    // Determining if the candlestick is a dragonfly doji and adding the result to the dictionary
        //    bool isdragonflydoji = isdoji && uppertail <= ((8 / 100m) * range);
        //    // Adding the result to the candlestickpattern dictionary with key "dragonflydoji"
        //    candlestickpattern.Add("dragonflydoji", isdragonflydoji);

        //    // Determining if the candlestick is a gravestone doji and adding the result to the dictionary
        //    bool isgravestonedoji = isdoji && lowertail <= ((8 / 100m) * range);
        //    // Adding the result to the candlestickpattern dictionary with key "gravestonedoji"
        //    candlestickpattern.Add("gravestonedoji", isgravestonedoji);

        //    // Determining if the candlestick is a hammer pattern and adding the result to the dictionary
        //    bool ishammer = (close >= ((98 / 100m) * high) && (close - low) >= ((50 / 100m) * bodyrange)) && uppertail >= (2 * bodyrange);
        //    // Adding the result to the candlestickpattern dictionary with key "hammer"
        //    candlestickpattern.Add("hammer", ishammer);

        //    // Determining if the candlestick is neutral (open equals close) and adding the result to the dictionary
        //    bool isneutral = open == close;
        //    // Adding the result to the candlestickpattern dictionary with key "neutral"
        //    candlestickpattern.Add("neutral", isneutral);
            
        //}

        /// <summary>
        /// Constructor for the SmartCandlestick class, which initializes the properties and computes their values
        /// </summary>
        /// <param name="Candlestickdata"></param>
        public SmartCandlestick(string Candlestickdata):base(Candlestickdata) 
        {
            // Calling the Computeaddedproperties method
            Computeaddedproperties();
        }

        

    }
}
