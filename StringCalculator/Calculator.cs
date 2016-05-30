using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class Calculator
    {
        // Step 1: if the string is empty return 0, if its lenght is hier the 2 throw an exeption
        // otherwise return the sum
        /*public int Add(String numbers)
        {
            if (numbers == String.Empty) return 0;
            else
            {
                var numbersStr = numbers.Split(',').ToList();
                if (numbersStr.Count() > 2) throw new Exception("The string conteins more then two elements.");
                else return Convert(numbersStr).Sum();
            }
        }*/

        // Step 2: remove lenght constraint
        /*public int Add(String numbers)
        {
            if (numbers == String.Empty) return 0;
            else return Convert(numbers.Split(',').ToList()).Sum();
        }*/

        // Step 3: use \n for splitting function
        /*public int Add(String numbers)
        {
            if (numbers == String.Empty) return 0;
            else return Convert(numbers.Split(',', '\n').ToList()).Sum();
        }*/

        // Step 4: The string composition should be:
        // a) initial character: //
        // b) subbstrings like [delimitatore]\n[numero], or [delimitatore][numero]
        // c) the delimiters are each character except \n, +, - and alphanumeric characters
        /*public int Add(String numbers)
        {      
            if (numbers == String.Empty) return 0;
            else if (!numbers.StartsWith("//")) throw new Exception("The string should strat with //.");
            else return Convert(SplitString(numbers)).Sum();
        }*/

        // Step 5
        /*public int Add(String numbers)
        {
            if (numbers == String.Empty) return 0;
            else if (!numbers.StartsWith("//")) throw new Exception("The string should strat with //.");
            else
            {     
                // Check for negative values
                var msg = String.Empty;
                var splitStr = SplitString(numbers);
                if (IsNegative(splitStr, out msg)) throw new Exception("Negatives not allowed: " + msg);
                else return Convert(splitStr).Sum();
            }
        }*/

        // Step 6
        public int Add(String numbers)
        {
            if (numbers == String.Empty) return 0;
            else if (!numbers.StartsWith("//")) throw new Exception("The string should strat with //.");
            else
            {
                // Check for negative values
                var msg = String.Empty;
                var splitStr = SplitString(numbers);
                if (IsNegative(splitStr, out msg)) throw new Exception("Negatives not allowed: " + msg);
                else return Convert(splitStr).Where(x => x <= 1000).Sum();
            }
        }

        // Convert list string into list int if it's possible, otherwise throw an exeption
        private List<int> Convert(List<String> numbers)
        {
            try
            {
                return numbers.ConvertAll(x => Int32.Parse(x)).ToList();
            }
            catch
            {
                throw new Exception("The string conteins non numeric values.");
            }
        }

        // Split String based on regex
        private List<String> SplitString(String str)
        {
            // remove initial //
            str = str.Substring(2, str.Count() - 2);

            // split the string
            var regex = new Regex(@"[^(\w\n\-\+)]");
            var regexStr = regex.Split(str).ToList();

            // Check for limit cases: //;
            if (!String.IsNullOrEmpty(regexStr[0]) || regexStr.Count() == 1 || regexStr.Any(x => x.Equals("\n"))) 
                throw new Exception("The string format is wrong.");
            regexStr.RemoveAt(0);

            // \n can be only at the first position 
            foreach (var r in regexStr)
            {
                var idx = r.LastIndexOf("\n");
                if (idx > 0) throw new Exception("The string format is wrong.");
            }

            // If the string list is in correct format replace \n
            return regexStr;
        }

        // Check for negative values
        private bool IsNegative(List<String> list, out string msg)
        {
            var array = list.Where(x => x.Contains("-")).ToArray();
            msg = String.Join(",", array);
            msg = msg.Replace("\n", String.Empty);
            return array.Count() > 0;
        }
    }
}
