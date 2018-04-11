using System;
using robot_simulator.Parser;
using Xunit;

namespace robot_simulator.Tests.Parser
{
    public class ParserTests
    {
        [Fact]
        public void ParseString_CommandWithoutArguments_TokenCorrect()
        {
            const string input = "MOVE";

            var token = Scanner.ParseString(input);
            
            
            Assert.Equal("MOVE", token.Command);
            Assert.Equal(0, token.Arguments.Count);
        }
        
        [Fact]
        public void ParseString_CommandWithArguments_TokenCorrect()
        {
            const string input = "PLACE 1,1,NORTH";

            var token = Scanner.ParseString(input);
            
            
            Assert.Equal("PLACE", token.Command);
            Assert.Equal(3, token.Arguments.Count);
        }
        
        [Fact]
        public void ParseString_CommandOneArgument_TokenCorrect()
        {
            const string input = "PLACE 1";

            var token = Scanner.ParseString(input);
            
            
            Assert.Equal("PLACE", token.Command);
            Assert.Equal(1, token.Arguments.Count);
        }
        
        [Fact]
        public void ParseString_EmptyString_ThrowsException()
        {
            var input = string.Empty;
            
            Assert.Throws<Exception>(() => Scanner.ParseString(input));
        }
    }
}