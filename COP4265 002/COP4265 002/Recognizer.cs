using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace COP4265_002
{
    abstract internal class Recognizer
    {
        //Declear variable patternName to store the name of the pattern 
        public string patternName;
        //Declear variable patternLength to store the number of candlesticks are used to calculate the pattern
        public int patternLength;

        /// <summary>
        /// A constructor for the Recognizer class 
        /// </summary>
        /// <param name="patternName"></param>
        /// <param name="patternLength"></param>
        public Recognizer(string patternName, int patternLength)
        {
            this.patternName = patternName;
            this.patternLength = patternLength;
        }

        /// <summary>
        /// Default function that will be inheritted by the recognizers to calculate the patterns and return a bool
        /// </summary>
        /// <param name="LSCS"></param>
        /// <param name="index"></param>
        /// <returns> Bool that shows if a pattern is regognized for a candlestick or not</returns>
        public virtual bool Recognize(BindingList<SmartCandlestick> LSCS, int index)
        {
            //Default implementation, can be overwritter 
            return false;
        }

        /// <summary>
        /// Recognize all candlestick patterns in the list.
        /// </summary>
        /// <param name="LSCS">The list of smart candlesticks.</param>
        public void recognizeAll(BindingList<SmartCandlestick> LSCS)
        {
            // Iterate through each candlestick in the list
            for (int i = 0; i < LSCS.Count; i++)
            {
                // Recognize the pattern for the current candlestick
                Recognize(LSCS, i);
            }
        }
    }
}
