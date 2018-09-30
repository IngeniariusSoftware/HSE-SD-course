namespace Program_Elements
{
    class Class : Identificator
    {
        public Class(
            string name,
            Types.Identificator identType = Types.Identificator.classes,
            Types.Value valueType = Types.Value.class_type)
            : base(name, valueType, identType)
        {
        }
    }
}
