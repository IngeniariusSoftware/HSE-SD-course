namespace Program_Elements
{
    class Variable : Identificator
    {
        public Variable(string name, Types.Value valueType, Types.Identificator identType = Types.Identificator.vars)
            : base(name, valueType, identType)
        {
        }
    }
}
