using System.Collections.Generic;

namespace robot_simulator.Parser
{
    public class Token
    {
        public string Command { get; set; }

        public List<string> Arguments { get; set; }
    }
}