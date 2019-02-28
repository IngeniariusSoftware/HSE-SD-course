
namespace Tree_identification
{
    using System;

    [Serializable]
    public static class Types
    {
        public enum Identification
        {
            classes,

            consts,

            vars,

            methods
        }

        public enum Value
        {
            int_type,

            float_type,

            bool_type,

            char_type,

            string_type,

            class_type,

            void_type
        }

        public enum Parameter
        {
            param_val,

            param_ref,

            param_out
        }

        public static Value ToValue(string type)
        {
            switch (type)
            {
                case "int":
                    {
                        return Value.int_type;
                    }

                case "char":
                    {
                        return Value.char_type;
                    }

                case "bool":
                    {
                        return Value.bool_type;
                    }

                case "float":
                    {
                        return Value.float_type;
                    }

                case "class":
                    {
                        return Value.class_type;
                    }

                case "string":
                    {
                        return Value.string_type;
                    }

                default:
                    {
                        return Value.void_type;
                    }
            }
        }

        public static Parameter ToParameter(string type)
        {
            switch (type)
            {
                case "ref":
                    {
                        return Parameter.param_ref;
                    }

                case "out":
                    {
                        return Parameter.param_out;
                    }

                default:
                    {
                        return Parameter.param_val;
                    }
            }
        }
    }
}