using System.Collections.Generic;

namespace Structures
{
    using System.Text.RegularExpressions;

    using Program_Elements;

    public class List
    {
        private List _nextElement;

        private (Types.Value, Types.Parameter) _argument;

        public List()
        {
            _argument.Item1 = Types.Value.void_type;
            _argument.Item2 = Types.Parameter.param_val;
            _nextElement = null;
        }

        public List((Types.Value value, Types.Parameter parameter) argument)
        {
            _argument.Item1 = argument.value;
            _argument.Item2 = argument.parameter;
            _nextElement = null;
        }

        public List(List<(Types.Value, Types.Parameter)> arguments)
        {
            if (arguments.Count > 0)
            {
                _argument.Item1 = arguments[0].Item1;
                _argument.Item2 = arguments[0].Item2;
                _nextElement = null;
                for (int i = 1; i < arguments.Count; i++)
                {
                    AddElement(new List(arguments[i]));
                }
            }
            else
            {
                _argument.Item1 = Types.Value.void_type;
                _argument.Item2 = Types.Parameter.param_val;
                _nextElement = null;
            }
        }

        public void AddElement(List element)
        {
            List shelf = this;
            while (shelf._nextElement !=null)
            {
                shelf = shelf._nextElement;
            }

            shelf._nextElement = element;
        }
    }
}
