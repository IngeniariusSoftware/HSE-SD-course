
namespace Tree_identification
{
    using System;

    [Serializable]
    public class Method : Identificator
    {
        public List Arguments;

        public Method()
        {
        }

        public Method(
            string name,
            List arguments,
            Types.Value valueType,
            Types.Identification identType = Types.Identification.methods)
            : base(name, valueType, identType) =>
            Arguments = arguments;
    }
}