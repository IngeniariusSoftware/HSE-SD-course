
namespace SerializationXPath
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml;
    using System.Xml.Serialization;

    using Tree_identification;

    public class Program
    {
        public static void Main()
        {
            MakeTreeSerializationTask();

            MakeXmlTask();

            Console.WriteLine("\n\tДля завершения работы нажмите любую клавишу...");
            Console.ReadKey();
        }

        public static void MakeTreeSerializationTask()
        {
            string treePath = "тест";
            var tree = new BinaryTree(treePath);
            var binaryTree = (BinaryTree)TestTreeBinarySerialize(tree);
            var xmlTree = (BinaryTree)TestTreeXmlSerialize(tree);
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
            string path = null;
            string outPath = ZipWorker.ExtractZipFiles(path);

            foreach (var file in Directory.GetFiles(outPath, "*xml"))
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
                }
            }

            PrintCustomers(customers);
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
                                           FullName =
                                               XmlWorker.FindXmlNode(tenderPlan, "commonInfo/customerInfo/fullName")
                                                   ?.FirstChild?.Value,
                                           INN = XmlWorker.FindXmlNode(tenderPlan, "commonInfo/customerInfo/INN")
                                               ?.FirstChild?.Value,
                                           KPP = XmlWorker.FindXmlNode(tenderPlan, "commonInfo/customerInfo/KPP")
                                               ?.FirstChild?.Value
                                       };

                    XmlNode positions = XmlWorker.FindXmlNode(tenderPlan, "positions");
                    if (positions != null)
                    {
                        foreach (XmlElement position in positions)
                        {
                            string code = XmlWorker.FindXmlNode(position, "purchaseObjectInfo/OKPD2Info/OKPD2/code")
                                ?.FirstChild?.Value;
                            double cost;
                            if (double.TryParse(
                                XmlWorker.FindXmlNode(position, "commonInfo/financeInfo/planPayments/total")?.FirstChild
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

        private static void PrintCustomers(List<Customer> customers)
        {
            string specialCode = "63";
            foreach (var customer in customers)
            {
                Console.Write(customer);
                Console.WriteLine($"Среднее арифметическое для кода {specialCode}: {customer.Average(specialCode)}");
            }
        }
    }
}