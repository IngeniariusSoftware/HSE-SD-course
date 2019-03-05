
namespace SerializationXPath
{
    using System.Xml;

    public static class XmlWorker
    {
        public static XmlNode FindXmlNode(XmlNode root, string path)
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
    }
}