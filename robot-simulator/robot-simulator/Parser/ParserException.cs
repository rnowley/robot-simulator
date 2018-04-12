using System;
using System.Runtime.Serialization;

namespace robot_simulator.Parser
{
    /// <summary>
    /// An exception to use to represent errors parsing a provided command
    /// </summary>
    [Serializable]
    public class ParserException : Exception
    {
        
        public ParserException(string message) :
            base(message) {}
        
        public ParserException(string message, Exception innerException) :
            base(message, innerException) {}
        
        protected ParserException(SerializationInfo info, StreamingContext context) :
            base(info, context) {}
    }
}