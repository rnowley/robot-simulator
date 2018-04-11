using System;
using System.Collections.Generic;
using System.Linq;

namespace robot_simulator.Parser
{
    public static class Scanner
    {
        public static Token ParseString(string stringToParse)
        {
            var items = stringToParse.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            if (!items.Any())
            {
                throw new Exception("Syntax error");
            }

            if (items.Length > 2)
            {
                throw new Exception("Syntax error");
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