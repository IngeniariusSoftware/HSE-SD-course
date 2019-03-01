
namespace Tree_identification
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class List
    {
        public List NextElement;

        public (Types.Value, Types.Parameter) Argument;

        public List()
        {
            Argument.Item1 = Types.Value.void_type;
            Argument.Item2 = Types.Parameter.param_val;
            NextElement = null;
        }

        public List((Types.Value value, Types.Parameter parameter) argument)
        {
            Argument.Item1 = argument.value;
            Argument.Item2 = argument.parameter;
            NextElement = null;
        }

        public List(List<(Types.Value, Types.Parameter)> arguments)
        {
            if (arguments.Count > 0)
            {
                Argument.Item1 = arguments[0].Item1;
                Argument.Item2 = arguments[0].Item2;
                NextElement = null;
                for (int i = 1; i < arguments.Count; i++)
                {
                    AddElement(new List(arguments[i]));
                }
            }
            else
            {
                Argument.Item1 = Types.Value.void_type;
                Argument.Item2 = Types.Parameter.param_val;
                NextElement = null;
            }
        }

        public void AddElement(List element)
        {
            List shelf = this;
            while (shelf.NextElement != null)
            {
                shelf = shelf.NextElement;
            }

            shelf.NextElement = element;
        }
    }
}