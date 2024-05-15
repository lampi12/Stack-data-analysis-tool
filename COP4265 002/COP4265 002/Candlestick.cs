using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COP4265_002
{
    internal class Candlestick
    {
        // Declaring a public property named date of type DateTime
        public DateTime date { get; set; }
        // Declaring a public property named open of type decimal
        public decimal open { get; set; }
        // Declaring a public property named high of type decimal
        public decimal high { get; set; }
        // Declaring a public property named low of type decimal
        public decimal low { get; set; }
        // Declaring a public property named close of type decimal
        public decimal close { get; set; }
        // Declaring a public property named adjustedclose of type decimal
        public decimal adjustedclose { get; set; }
        // Declaring a public property named volume of type ulong
        public ulong volume { get; set; }
        
        public Candlestick() { }

        /// <summary>
        /// This method will convert the data input from a csv file into candlesticks
        /// </summary>
        /// <param name="rowofData"></param>
        public Candlestick(string rowofData)
        {
            // Defining an array of separator characters
            char[] seperators = new char[] { ',', ' ', '"' };
            // Splitting the rowofData string using the separators
            string[] subs = rowofData.Split(seperators, StringSplitOptions.RemoveEmptyEntries);

            // Extracting the date string from the substrings
            string datestring = subs[0];
            // Parsing the datestring into a DateTime object
            date = DateTime.Parse(datestring);

            // Declaring a decimal variable named temp
            decimal temp;
            // Attempting to parse the substring as a decimal
            bool success = decimal.TryParse(subs[1], out temp);
            // Assigning the parsed value to the open property if parsing is successful
            if (success) open = temp;

            // Attempting to parse the substring as a decimal
            success = decimal.TryParse(subs[2], out temp);
            if (success) high = temp; // Assigning the parsed value to the high property if parsing is successful

            // Attempting to parse the substring as a decimal
            success = decimal.TryParse(subs[3], out temp);
            if (success) low = temp; // Assigning the parsed value to the low property if parsing is successful

            // Attempting to parse the substring as a decimal
            success = decimal.TryParse(subs[4], out temp);
            if (success) close = temp; // Assigning the parsed value to the close property if parsing is successful

            // Declaring a ulong variable named tempvolume
            ulong tempvolume;
            // Attempting to parse the substring as a ulong
            success = ulong.TryParse(subs[6], out tempvolume);
            if (success) volume = tempvolume; // Assigning the parsed value to the volume property if parsing is successful
        }

    }
}
