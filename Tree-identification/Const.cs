
namespace Tree_identification
{
    using System;

    [Serializable]
    public class Const : Identificator
    {
        public string Value;

        public Const()
        {
        }

        public Const(
            string name,
            string value,
            Types.Value valueType,
            Types.Identification identType = Types.Identification.consts)
            : base(name, valueType, identType) =>
            Value = value;
    }
}