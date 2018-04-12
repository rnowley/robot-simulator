using System.Collections.Generic;

namespace robot_simulator.Parser
{
    /// <summary>
    /// Defines a token for representing a command to the robot.
    /// </summary>
    public class Token
    {
        /// <summary>
        /// The comnmand to give to the robot.
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// Any arguments required by the command.
        /// </summary>
        public List<string> Arguments { get; set; }
    }
}