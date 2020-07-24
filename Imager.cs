using System;

namespace TestConekta
{
    internal class Imager
    {
        public Imager()
        {
            canvas = new Canvas();
        }

        public Canvas canvas { get; set; }

        internal ArrangedCommand Command { get; set; }

        internal Command GetCommand()
        {
            var userInput = Console.ReadLine();
            Command = new ArrangedCommand(userInput);
            if (!Command.IsValid)
            {
                Console.WriteLine("Invalid Command");
            }
            if (Command.CommandType == CommandType.X)
            {
                Console.WriteLine("Terminating session...");
                System.Threading.Thread.Sleep(2000);
                Environment.Exit(0);
            }

            return Command;
        }

        internal void ExecuteCommand()
        {

            if (Command.IsValid)
            {
                switch (Command.CommandType)
                {
                    case CommandType.I:
                        canvas.Initialize((int)Command.M, (int)Command.N);
                        break;
                    case CommandType.C:
                        canvas.Initialize(canvas.mSize, canvas.nSize);
                        break;
                    case CommandType.L:
                        if (!canvas.IsInitialized)
                        {
                            Console.WriteLine("Canvas is not initialized!");
                        }
                        canvas.DrawPixel(new Pixel((int)Command.X, (int)Command.Y, (char)Command.Color));
                        break;
                    case CommandType.V:
                        canvas.VerticalLine((int)Command.X, (int)Command.Y1, (int)Command.Y2, (char)Command.Color);
                        break;
                    case CommandType.H:
                        canvas.HorizontalLine((int)Command.X1, (int)Command.X2, (int)Command.Y, (char)Command.Color);
                        break;
                    case CommandType.F:
                        canvas.FillRegion((int)Command.X, (int)Command.Y, (char)Command.Color);
                        break;
                    case CommandType.S:
                        canvas.Print();
                        break;
                    case CommandType.X:
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Unable to execute invalid command");
            }

        }
    }
}
