using System;
using System.Collections.Generic;
using System.Linq;

namespace robot_simulator.Parser
{
    /// <summary>
    /// Provides a scanner for processing robot commands.
    /// </summary>
    public static class Scanner
    {
        /// <summary>
        /// Parses the provided string into a Token.
        /// </summary>
        /// <param name="stringToParse">The string to parse.</param>
        /// <returns>A token representing the robot command</returns>
        /// <exception cref="ParserException">Indicates that there was a problem parsing the command.</exception>
        public static Token ParseString(string stringToParse)
        {
            var items = stringToParse.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (!items.Any())
            {
                throw new ParserException("Syntax error");
            }

            if (items.Length > 2)
            {
                throw new ParserException("Syntax error");
            }

            var command = items[0];
            var arguments = new List<string>();

            if (items.Length == 2)
            {
                arguments = items[1].Split(new[] {','}).ToList();
            }

            var token = new Token
            {
                Command = command,
                Arguments = arguments
            };

            return token;
        }
    }
}