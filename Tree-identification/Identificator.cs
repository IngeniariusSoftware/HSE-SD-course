namespace Program_Elements
{
    abstract public class Identificator
    {
        public Identificator(string name, Types.Value valueType, Types.Identificator identType)
        {
            _name = name;
            Hash = name.GetHashCode();
            _valueType = valueType;
            _identType = identType;
        }

        private string _name;

        public int Hash;

        private Types.Identificator _identType;

        private Types.Value _valueType;
    }
}
