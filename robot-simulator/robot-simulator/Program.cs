using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using robot_simulator.Parser;

namespace robot_simulator
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var quit = false;
            var robot = new Robot(new Sensor(new Board(5,5)));
            Console.WriteLine("Welcome to Toy Robot Simulator. Please enter some commands.");
            
            while (!quit)
            {
                try
                {
                    Console.Write("> ");
                    var input = Console.ReadLine();

                    var token = Scanner.ParseString(input);

                    switch (token.Command)
                    {
                        case "LEFT":
                            ProcessLeftTurnCommand(robot, token.Arguments);
                            break;
                        case "RIGHT":
                            ProcessRightTurnCommand(robot, token.Arguments);
                            break;
                        case "MOVE":
                            ProcessMoveCommand(robot, token.Arguments);
                            break;
                        case "REPORT":
                            var report = ProcessReportCommand(robot, token.Arguments);
                            Console.WriteLine(report);
                            break;
                        case "EXIT":
                            ProcessExitCommand(token.Arguments);
                            quit = true;
                            break;
                        case "PLACE":
                            ProcessPlaceCommand(robot, token.Arguments);
                            break;
                        default:
                            Console.WriteLine("Unknown command");
                            break;
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            
            Console.WriteLine("Exiting simulator.");
            
        }

        /// <summary>
        /// Processes the left turn command and if it is valid then the robot has been turned to the left.
        /// </summary>
        /// <param name="robot">The robot that we want to turn to the left.</param>
        /// <param name="arguments">Any arguments passed with the command</param>
        /// <exception cref="ParserException">Indicates that the command was not valid</exception>
        private static void ProcessLeftTurnCommand(Robot robot, List<string> arguments)
        {
            if (arguments.Any())
            {
                throw new ParserException("Too many arguments");
            }

            robot.TurnLeft();
        }
        
        /// <summary>
        /// Processes the right turn command and if it is valid then the robot has been turned to the right.
        /// </summary>
        /// <param name="robot">The robot to turn to the right.</param>
        /// <param name="arguments">Any arguments passed with the command</param>
        /// <exception cref="ParserException">Indicates that the command was not valid</exception>
        private static void ProcessRightTurnCommand(Robot robot, List<string> arguments)
        {
            if (arguments.Any())
            {
                throw new ParserException("Too many arguments");
            }

            robot.TurnRight();
        }
        
        /// <summary>
        /// Processes the report command and if it is valid then the robot reports its position and orientation.
        /// </summary>
        /// <param name="robot">The robot the way want to get a location report from.</param>
        /// <param name="arguments">Any arguments passed with the command</param>
        /// <returns></returns>
        /// <exception cref="ParserException">Indicates that the command was not valid</exception>
        private static string ProcessReportCommand(Robot robot, List<string> arguments)
        {
            if (arguments.Any())
            {
                throw new ParserException("Too many arguments");
            }

            return robot.ReportLocation();
        }
        
        /// <summary>
        /// Processes the move command and if it is valid then the robot has been moved forward.
        /// </summary>
        /// <param name="robot">The robot to move.</param>
        /// <param name="arguments">Any arguments passed with the command</param>
        /// <exception cref="ParserException">Indicates that the command was not valid</exception>
        private static void ProcessMoveCommand(Robot robot, List<string> arguments)
        {
            if (arguments.Any())
            {
                throw new ParserException("Too many arguments");
            }

            robot.MoveForward();
        }
        
        /// <summary>
        /// Processes the exit command and if it is valid then an exception is not thrown.
        /// </summary>
        /// <param name="arguments">Any arguments passed with the command</param>
        /// <exception cref="ParserException">Indicates that the command was not valid</exception>
        private static void ProcessExitCommand(List<string> arguments)
        {
            
            if (arguments.Any())
            {
                throw new ParserException("Too many arguments");
            }

        }

        /// <summary>
        /// Processes the place command and places the robot on the board if it is valid
        /// </summary>
        /// <param name="robot">The robot to place on the board.</param>
        /// <param name="arguments">The arguments required by the place command.</param>
        /// <exception cref="ParserException">Indicates that the command was not valid.</exception>
        private static void ProcessPlaceCommand(Robot robot, IReadOnlyList<string> arguments)
        {
            if (arguments.Count != 3)
            {
                throw new ParserException("Incorrect number of arguments");
            }

            var x = ConvertToInteger(arguments[0]);
            var y = ConvertToInteger(arguments[1]);
            var orientation = MapToOrientation(arguments[2]);
            robot.PlaceRobot(new Point(x, y), orientation);
        }

        /// <summary>
        /// Converts a string representation of an orientation to its corresponding
        /// Orientation enum.
        /// </summary>
        /// <param name="argument">The string representation of the orientation to convert.</param>
        /// <returns>The corresponding orientation enumeration.</returns>
        /// <exception cref="ArgumentException">Indicates that the argument is not a valid orientation.</exception>
        /// <remarks>The string representation of the orientation must be uppercase.</remarks>
        private static Orientation MapToOrientation(string argument)
        {

            switch (argument)
            {
                case "NORTH":
                    return Orientation.North;
                case "SOUTH":
                    return Orientation.South;
                case "EAST":
                    return Orientation.East;
                case "WEST":
                    return Orientation.West;
                default:
                    throw new ArgumentException("An illegal orientation value");
            }
            
        }

        /// <summary>
        /// Converts the provided argument to an integer.
        /// </summary>
        /// <param name="argument">The argument to convert to an integer.</param>
        /// <returns>The integer representation of the argument.</returns>
        /// <exception cref="ArgumentException">Indicates that the argument is not a valid integer.</exception>
        private static int ConvertToInteger(string argument)
        {
            int result;

            try
            {
                result = Convert.ToInt32(argument);
            }
            catch (Exception)
            {
                throw new ArgumentException("Argument is not an integer");
            }

            return result;
        }
    }
}