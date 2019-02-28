
namespace Tree_identification
{
    using System;

    [Serializable]
    public class Class : Identificator
    {
        public Class()
        {
        }

        public Class(
            string name,
            Types.Identification identType = Types.Identification.classes,
            Types.Value valueType = Types.Value.class_type)
            : base(name, valueType, identType)
        {
        }
    }
}