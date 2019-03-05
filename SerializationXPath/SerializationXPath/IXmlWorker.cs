
namespace SerializationXPath
{
    using System.Xml;

    public interface IXmlWorker
    {
        XmlNode FindXmlNode(XmlNode root, string path);
    }
}