using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_StringCalculator
{
    public class StringCalculator
    {
        public StringCalculator()
        {
        }
        public int Calculate(string arg)
        {
            if (arg == null || arg == "")
                return 0;
            int result = 0;
            List<char> delimitingChars = [',', '\n'];
            string[] checkDelimitingChars = arg.Split('\n', StringSplitOptions.TrimEntries);
            if (checkDelimitingChars.Length > 0) 
            {
                if (checkDelimitingChars[0].StartsWith("//"))
                {
                    if (checkDelimitingChars[0].Length != 3)
                        throw new Exception("Only single delimiting characters should be specified this way");

                    Console.WriteLine(checkDelimitingChars[0]);
                    delimitingChars.Add(checkDelimitingChars[0][2]);
                }
            }
            string[] args = arg.Split(delimitingChars.ToArray(), StringSplitOptions.TrimEntries);
            foreach (string a in args)
            {
                if (a == null || a == "")
                    continue;
                if (int.TryParse(a, out int a_int))
                {
                    if (a_int < 0)
                        throw new Exception("The argument cannot be negative");
                    if (a_int > 1000)
                        a_int = 0;

                    result += a_int;
                }
                else
                    throw new Exception("Something is just simply wrong");
            }
            return result;
        }
    }
}
