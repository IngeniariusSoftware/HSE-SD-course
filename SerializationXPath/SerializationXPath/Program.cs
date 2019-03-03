
namespace SerializationXPath
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml;
    using System.Xml.Serialization;

    using Ionic.Zip;

    using Tree_identification;

    public class Program
    {
        public static void Main()
        {
            var tree = new BinaryTree();
            foreach (string sentence in TreeMaker.FileParse("тест"))
            {
                tree.Add(TreeMaker.SentenceParse(sentence));
            }

            var binaryTree = (BinaryTree)TestTreeBinarySerialize(tree);
            var xmlTree = (BinaryTree)TestTreeXmlSerialize(tree);

            MakeXmlTask();

            Console.WriteLine("\n\tДля завершения работы нажмите любую клавишу...");
            Console.ReadKey();
        }

        private static object TestTreeBinarySerialize(object element)
        {
            var binFormatter = new BinaryFormatter();
            using (var fileStream = new FileStream("tree.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(fileStream, element);
                Console.WriteLine("\n\tБинарная сериализация выполнена");
            }

            object deserializedElement;
            using (var fileStream = new FileStream("tree.bin", FileMode.OpenOrCreate))
            {
                deserializedElement = binFormatter.Deserialize(fileStream);

                Console.WriteLine("\n\tБинарная десериализация выполнена");
            }

            return deserializedElement;
        }

        private static object TestTreeXmlSerialize(object element)
        {
            var xmlFormatter = new XmlSerializer(element.GetType());

            using (var fileStream = new FileStream("tree.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(fileStream, element);
                Console.WriteLine("\n\tXml сериализация выполнена");
            }

            object deserializedElement;
            using (var fileStream = new FileStream("tree.xml", FileMode.OpenOrCreate))
            {
                deserializedElement = xmlFormatter.Deserialize(fileStream);
                Console.WriteLine("\n\tXml десериализация выполнена");
            }

            return deserializedElement;
        }

        private static void MakeXmlTask()
        {
            var customers = new List<Customer>();

            ExtractZipFile(out string path);

            foreach (var file in Directory.GetFiles(path, "*xml"))
            {
                foreach (Customer customer in ParseXmlFile(file))
                {
                    Customer existCustomer = customers.Find(x => x.INN == customer.INN);
                    if (existCustomer == null)
                    {
                        existCustomer = new Customer(customer.FullName, customer.INN, customer.KPP);
                        customers.Add(existCustomer);
                    }

                    existCustomer.PositionCount += customer.PositionCount;
                    existCustomer.Positions.AddRange(customer.Positions);

                    //foreach (var position in customer.Positions)
                    //{
                    //    var existPosition = existCustomer.Positions.Find(x => x.Code == position.Code);
                    //    if (existPosition != null)
                    //    {
                    //        existPosition.Cost += position.Cost;
                    //    }
                    //    else
                    //    {
                    //        existCustomer.Positions.Add(position);
                    //    }
                    //}
                }
            }

            PrintCustomers(customers);
        }

        private static void ExtractZipFile(out string outputPath)
        {
            do
            {
                outputPath = Guid.NewGuid().ToString();
            }
            while (Directory.Exists(outputPath));

            Directory.CreateDirectory(outputPath);

            foreach (string zipFile in Directory.GetFiles(Directory.GetCurrentDirectory(), "*zip"))
            {
                using (var zip = ZipFile.Read(zipFile))
                {
                    zip.ExtractAll(outputPath);
                }
            }

            Console.WriteLine($"\n\tФайлы распакованы в папку {outputPath}");
        }

        private static List<Customer> ParseXmlFile(string path)
        {
            var customers = new List<Customer>();
            var xDoc = new XmlDocument();
            xDoc.Load(path);

            var xRoot = xDoc.DocumentElement;
            foreach (XmlNode tenderPlan in xRoot.SelectNodes("*"))
            {
                try
                {
                    var customer = new Customer
                                       {
                                           FullName = FindXmlNode(tenderPlan, "commonInfo/customerInfo/fullName")
                                               ?.FirstChild?.Value,
                                           INN = FindXmlNode(tenderPlan, "commonInfo/customerInfo/INN")?.FirstChild
                                               ?.Value,
                                           KPP = FindXmlNode(tenderPlan, "commonInfo/customerInfo/KPP")?.FirstChild
                                               ?.Value
                                       };

                    XmlNode positions = FindXmlNode(tenderPlan, "positions");
                    if (positions != null)
                    {
                        foreach (XmlElement position in positions)
                        {
                            string code = FindXmlNode(position, "purchaseObjectInfo/OKPD2Info/OKPD2/code")?.FirstChild
                                ?.Value;
                            double cost;
                            if (double.TryParse(
                                FindXmlNode(position, "commonInfo/financeInfo/planPayments/total")?.FirstChild
                                    ?.Value,
                                out cost))
                            {
                                customer.Positions.Add(new Position(code, cost));
                            }
                        }

                        customer.PositionCount = positions.ChildNodes.Count;
                    }

                    customers.Add(customer);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\nНе удалось прочитать тендерный план:\n\n{e}");
                }
            }

            return customers;
        }

        private static XmlNode FindXmlNode(XmlNode root, string path)
        {
            XmlNode goalRoot = root.Clone();
            bool isFound = true;
            string[] nodes = path.Split('/');

            for (int i = 0; i < nodes.Length && isFound; i++)
            {
                isFound = false;
                for (int j = 0; j < goalRoot.ChildNodes.Count && !isFound; j++)
                {
                    if (goalRoot.ChildNodes[j].Name == nodes[i])
                    {
                        goalRoot = goalRoot.ChildNodes[j];
                        isFound = true;
                    }
                }
            }

            if (isFound)
            {
                return goalRoot;
            }
            else
            {
                return null;
            }
        }

        private static void PrintCustomers(List<Customer> customers)
        {
            string specialCode = "63";
            foreach (var customer in customers)
            {
                Console.WriteLine($"\nОрганизация: {customer}");
                Console.WriteLine($"ИНН: {customer.INN}");
                Console.WriteLine($"КПП: {customer.KPP}");
                Console.WriteLine($"Среднее арифметическое для кода {specialCode}: {customer.Average(specialCode)}");
                Console.WriteLine($"Количество позиций: {customer.PositionCount}");

                //Console.WriteLine("Позиции:");

                //foreach (var customerPosition in customer.Positions.Where(
                //    x => x.Code != null && x.Code.StartsWith(specialCode)))
                //{
                //    Console.WriteLine($"\tКод: {customerPosition.Code}");
                //    Console.WriteLine($"\tЦена: {customerPosition.Cost}\n");
                //}

                //foreach (var customerPosition in customer.Positions.Where(
                //    x => x.Code == null || !x.Code.StartsWith(specialCode)))
                //{
                //    Console.WriteLine($"\tКод: {customerPosition.Code}");
                //    Console.WriteLine($"\tЦена: {customerPosition.Cost}\n");
                //}
            }
        }
    }
}