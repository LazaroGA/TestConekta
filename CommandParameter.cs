namespace TestConekta
{
    internal class CommandParameter
    {
        private readonly CommandType commandType;

        private readonly string parameterValue;

        private readonly int parameterPosition;

        public CommandParameter(CommandType commandType, string parameterValue, int parameterPosition)
        {
            this.commandType = commandType;
            this.parameterValue = parameterValue;
            this.parameterPosition = parameterPosition;
        }

        internal int NumericValue
        {
            get
            {
                int val;
                bool wasParsed = int.TryParse(parameterValue, out val);
                if (wasParsed)
                {
                    return val;
                }
                return -1;
            }
        }

        internal char ColorValue
        {
            get
            {
                if (parameterValue.Length > 1)
                {
                    return ' ';
                }
                return parameterValue.ToCharArray()[0];
            }
        }

        internal bool IsColor
        {
            get
            {
                return ColorValue != ' ';
            }
        }

        internal bool IsNumericValue
        {
            get
            {
                return NumericValue != -1;
            }
        }

        internal bool IsValid { get { return IsColor || IsNumericValue; } }

    }
}
