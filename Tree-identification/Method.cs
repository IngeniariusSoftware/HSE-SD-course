namespace Program_Elements
{
    class Method : Identificator
    {
        private Structures.List _arguments;

        public Method(
            string name,
            Structures.List arguments,
            Types.Value valueType,
            Types.Identificator identType = Types.Identificator.methods)
            : base(name, valueType, identType)
        {
            _arguments = arguments;
        }
    }
}
