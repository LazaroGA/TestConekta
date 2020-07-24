using System;
using System.Collections.Generic;
using System.Linq;

namespace TestConekta
{
    internal class Command
    {
        private readonly string commandText;

        internal CommandType CommandType { get { return commandType; } }
        CommandType commandType;
        internal bool IsValid { get; set; }


        internal List<CommandParameter> CommandParameters { get; set; }

        public Command(string commandText)
        {
            this.commandText = commandText;
            CommandParameters = new List<CommandParameter>();
            this.Parse();
        }

        private Command Parse()
        {
            string[] commandSections = System.Text.RegularExpressions.Regex.Split(commandText, @"\s{1,}");

            if (!Enum.TryParse(commandSections[0], out commandType))
            {
                IsValid = false;
                return this;
            }

            if (commandSections.Length >= 2)
            {
                for (int i = 1; i < commandSections.Length; i++)
                {
                    var commandP = new CommandParameter(CommandType, commandSections[i], i);
                    CommandParameters.Add(commandP);
                }
            }
            if (CommandParameters.Any(c => !c.IsValid))
            {
                IsValid = false;
                return this;
            }

            IsValid = true;
            return this;
        }

    }
}
