using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StringCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            //var inputStr = "1,2,5";
            //var inputStr = "a,2";
            //var inputStr = String.Empty;
            //var inputStr = "3";
            //var inputStr = "5,4";
            //var inputStr = "\n";
            //var inputStr = "1\n2,3";
            //var inputStr = "1,\n";
            //var inputStr = "2\n1";
            //var inputStr = "//;\n1;2";
            //var inputStr = "//:\n2&\n3%25/+1001";
            //var inputStr = "!\n2";
            //var inputStr = "//\n";
            //var inputStr = "//\n2";
            //var inputStr = "//£\n";
            //var inputStr = "//;";
            //var inputStr = "//2";
            //var inputStr = "//@\n1;1.\n-55;\n3";
            //var inputStr = "//@\n1;-1.\n-55";
            //var inputStr = "//@\n1;1.\n1000";
            var inputStr = "//@\n1;1.\n1001";
            try
            {
                Console.WriteLine("The sum of the string is: " + calc.Add(inputStr));
            }
            catch(Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }

            Thread.Sleep(3600000);
        }
    }
}
