using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_identification
{
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            //  "int, const, class, float, string, bool, char, ref, out";
            //  Enum type = "int, float, string, char, bool";
            //  Enum object = "class, const, /method, /vars";
            //  Enum mode = "ref, out /val"; 

            
            Regex reg = new Regex(@"((?<type>(int)|(char)|(float)|(bool)|(string))|(?<object>(const)|(class)))+\s*(?<name>\S*)+\s*(?<value>^[ =]*)+");
            string str = "classfrgrgregrdintsfschareffefewfclassefecons";
            Console.WriteLine(reg.Matches(str)[0].Groups["type"]);
            Console.WriteLine(reg.Matches(str)[0].Groups["type"]);

            Console.ReadLine();

            if (reg.Matches(str)[0].Groups["type"].ToString() != "")
            {
                if (reg.Matches(str)[1].Groups["object"].ToString() != "")
                {
                    
                }
                else
                {
                    
                }
            }
            else
            {
                if (reg.Matches(str)[1].Groups["object"].ToString() != "")
                {

                }
                else
                {

                }
            }

        }


        static void SentenceParser(string sentence)
        {
            //foreach (var VARIABLE in COLLECTION)
            //{

            //}
            //Regex regex = new Regex(@"(?<>)");


        }
        
    }
}
