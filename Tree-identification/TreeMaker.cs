
namespace Tree_identification
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class TreeMaker
    {
        public static List<(Types.Value, Types.Parameter)> ArgumentsParser(string methodInput)
        {
            var regMethod = new Regex(@"\s*(?<param>(ref)|(out))*\s*(?<value>(int)|(char)|(float)|(bool)|(string))+");
            var arguments = new List<(Types.Value, Types.Parameter)>();
            foreach (Match match in regMethod.Matches(methodInput))
            {
                arguments.Add(
                    (Types.ToValue(match.Groups["value"].ToString()),
                        Types.ToParameter(match.Groups["param"].ToString())));
            }

            return arguments;
        }

        public static Identificator SentenceParse(string sentence)
        {
            var regSentence = new Regex(
                @"\s*(?<object>(const)|(class))*\s*(?<type>(int)|(char)|(float)|(bool)|(string))*\s*(?<name>[^ =;()]*)[ =]*(?<value>[^;]*)");

            var matches = regSentence.Matches(sentence)[0];
            if (matches.Groups["object"].ToString() != string.Empty)
            {
                if (matches.Groups["type"].ToString() != string.Empty)
                {
                    return new Const(
                        matches.Groups["name"].ToString(),
                        matches.Groups["value"].ToString(),
                        Types.ToValue(matches.Groups["type"].ToString()));
                }
                else
                {
                    return new Class(matches.Groups["name"].ToString());
                }
            }
            else
            {
                if (matches.Groups["value"].ToString() != string.Empty)
                {
                    return new Method(
                        matches.Groups["name"].ToString(),
                        new List(ArgumentsParser(matches.Groups["value"].ToString())),
                        Types.ToValue(matches.Groups["type"].ToString()));
                }
                else
                {
                    return new Variable(
                        matches.Groups["name"].ToString(),
                        Types.ToValue(matches.Groups["type"].ToString()));
                }
            }
        }

        public static List<string> FileParse(string fileName)
        {
            var studentsFile = new FileStream(fileName + ".txt", FileMode.OpenOrCreate);
            var reader = new StreamReader(studentsFile);
            var text = new List<string>();
            while (!reader.EndOfStream)
            {
                text.Add(reader.ReadLine());
            }

            studentsFile.Close();
            return text;
        }

        public static void Main()
        {
            var tree = new BinaryTree();
            foreach (string sentence in FileParse("тест"))
            {
                tree.Add(SentenceParse(sentence));
            }

            Console.WriteLine("\n\tДля завершения работы нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}