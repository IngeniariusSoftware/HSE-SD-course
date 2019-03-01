
namespace Tree_identification
{
    using System;
    using System.Xml.Serialization;

    [XmlInclude(typeof(Variable))]
    [XmlInclude(typeof(Const))]
    [XmlInclude(typeof(Method))]
    [XmlInclude(typeof(Class))]
    [Serializable]
    public abstract class Identificator
    {
        public string Name;

        public int Hash;

        public Types.Identification IdentType;

        public Types.Value ValueType;

        public Identificator()
        {
        }

        public Identificator(string name, Types.Value valueType, Types.Identification identType)
        {
            Name = name;
            Hash = name.GetHashCode();
            ValueType = valueType;
            IdentType = identType;
        }
    }
}