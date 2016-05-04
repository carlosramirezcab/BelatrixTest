using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelatrixTest.Common
{
    public static class CommonHelper
    {
        /// <summary>
        /// Verify if the response is between "Y" and "N"
        /// </summary>
        /// <param name="message">the response of evaluate</param>
        /// <returns></returns>
        public static bool VerifyResponseYesNo(string message)
        {
            return message == "Y" || message == "N";

        }

        /// <summary>
        /// Get a bool value of "Y" and "N"
        /// </summary>
        /// <param name="message">the response to evaluate</param>
        /// <returns></returns>
        public static bool GetYesNoValue(string message)
        {
            return message == "Y";

        }
    }
}
