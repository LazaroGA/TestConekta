using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestConekta
{
    internal class ArrangedCommand : Command
    {
        public int? M { get; set; }
        public int? N { get; set; }
        public char? Color { get; set; }

        public int? X { get; set; }
        public int? Y { get; set; }

        public int? X1 { get; set; }
        public int? X2 { get; set; }

        public int? Y1 { get; set; }
        public int? Y2 { get; set; }

        public ArrangedCommand(string commandText) : base(commandText)
        {
            Arrange();
        }

        internal void Arrange()
        {
            switch (CommandType)
            {
                case CommandType.I:
                    IsValid = CommandParameters.Count == 2
                              && CommandParameters.All(cp => cp.IsNumericValue)
                              && CommandParameters[0].NumericValue >= 1
                              && CommandParameters[0].NumericValue <= Canvas.MAX_CANVAS_SIZE
                              && CommandParameters[1].NumericValue >= 1
                              && CommandParameters[1].NumericValue <= Canvas.MAX_CANVAS_SIZE;
                    if (IsValid)
                    {
                        M = CommandParameters[0].NumericValue;
                        N = CommandParameters[1].NumericValue;
                    }
                    break;
                case CommandType.C:
                    IsValid = CommandParameters.Count == 0;
                    break;
                case CommandType.L:
                    IsValid = CommandParameters.Count == 3
                           && CommandParameters.Take(2).All(cp => cp.IsNumericValue)
                           && CommandParameters[0].NumericValue >= 1
                           && CommandParameters[0].NumericValue <= Canvas.MAX_CANVAS_SIZE
                           && CommandParameters[1].NumericValue >= 1
                           && CommandParameters[1].NumericValue <= Canvas.MAX_CANVAS_SIZE
                           && CommandParameters[2].IsColor
                           && Regex.IsMatch(CommandParameters[2].ColorValue.ToString(), @"[A-Z]{1}");
                    if (IsValid)
                    {
                        X = CommandParameters[0].NumericValue;
                        Y = CommandParameters[1].NumericValue;
                        Color = CommandParameters[2].ColorValue;
                    }
                    break;
                case CommandType.V:
                    IsValid = CommandParameters.Count == 4
                          && CommandParameters.Take(3).All(cp => cp.IsNumericValue)
                          && CommandParameters[0].NumericValue >= 1
                          && CommandParameters[0].NumericValue <= Canvas.MAX_CANVAS_SIZE
                          && CommandParameters[1].NumericValue >= 1
                          && CommandParameters[1].NumericValue <= Canvas.MAX_CANVAS_SIZE
                          && CommandParameters[2].NumericValue >= 1
                          && CommandParameters[2].NumericValue <= Canvas.MAX_CANVAS_SIZE
                          && CommandParameters[3].IsColor
                           && Regex.IsMatch(CommandParameters[3].ColorValue.ToString(), @"[A-Z]{1}");
                    if (IsValid)
                    {
                        X = CommandParameters[0].NumericValue;
                        Y1 = CommandParameters[1].NumericValue;
                        Y2 = CommandParameters[2].NumericValue;
                        Color = CommandParameters[3].ColorValue;
                    }
                    break;
                case CommandType.H:
                    IsValid = CommandParameters.Count == 4
                          && CommandParameters.Take(3).All(cp => cp.IsNumericValue)
                          && CommandParameters[0].NumericValue >= 1
                          && CommandParameters[0].NumericValue <= Canvas.MAX_CANVAS_SIZE
                          && CommandParameters[1].NumericValue >= 1
                          && CommandParameters[1].NumericValue <= Canvas.MAX_CANVAS_SIZE
                          && CommandParameters[2].NumericValue >= 1
                          && CommandParameters[2].NumericValue <= Canvas.MAX_CANVAS_SIZE
                          && CommandParameters[3].IsColor
                          && Regex.IsMatch(CommandParameters[3].ColorValue.ToString(), @"[A-Z]{1}");
                    if (IsValid)
                    {
                        X1 = CommandParameters[0].NumericValue;
                        X2 = CommandParameters[1].NumericValue;
                        Y = CommandParameters[2].NumericValue;
                        Color = CommandParameters[3].ColorValue;
                    }

                    break;
                case CommandType.F:
                    IsValid = CommandParameters.Count == 3
                    && CommandParameters.Take(2).All(cp => cp.IsNumericValue)
                    && CommandParameters[0].NumericValue >= 1
                    && CommandParameters[0].NumericValue <= Canvas.MAX_CANVAS_SIZE
                    && CommandParameters[1].NumericValue >= 1
                    && CommandParameters[1].NumericValue <= Canvas.MAX_CANVAS_SIZE
                    && CommandParameters[2].IsColor
                    && Regex.IsMatch(CommandParameters[2].ColorValue.ToString(), @"[A-Z]{1}");
                    if (IsValid)
                    {
                        X = CommandParameters[0].NumericValue;
                        Y = CommandParameters[1].NumericValue;
                        Color = CommandParameters[1].ColorValue;
                    }
                    break;
                case CommandType.S:
                    IsValid = CommandParameters.Count == 0;
                    break;
                case CommandType.X:
                    IsValid = CommandParameters.Count == 0;
                    break;
                default:
                    break;
            }
        }

      
    }
}
