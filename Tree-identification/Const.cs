namespace Program_Elements
{
    class Const : Identificator
    {
        private string _value;

        public Const(
            string name,
            string value,
            Types.Value valueType,
            Types.Identificator identType = Types.Identificator.consts)
            : base(name, valueType, identType) =>
            _value = value;
    }
}
