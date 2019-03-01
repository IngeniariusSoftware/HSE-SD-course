
namespace Tree_identification
{
    using System;

    [Serializable]
    public class Variable : Identificator
    {
        public Variable()
        {
        }

        public Variable(string name, Types.Value valueType, Types.Identification identType = Types.Identification.vars)
            : base(name, valueType, identType)
        {
        }
    }
}