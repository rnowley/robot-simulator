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

        private static void ProcessLeftTurnCommand(Robot robot, List<string> arguments)
        {
            if (arguments.Any())
            {
                throw new Exception("Too many arguments");
            }

            robot.TurnLeft();
        }
        
        private static void ProcessRightTurnCommand(Robot robot, List<string> arguments)
        {
            if (arguments.Any())
            {
                throw new Exception("Too many arguments");
            }

            robot.TurnRight();
        }
        
        private static string ProcessReportCommand(Robot robot, List<string> arguments)
        {
            if (arguments.Any())
            {
                throw new Exception("Too many arguments");
            }

            return robot.ReportLocation();
        }
        
        private static void ProcessMoveCommand(Robot robot, List<string> arguments)
        {
            if (arguments.Any())
            {
                throw new Exception("Too many arguments");
            }

            robot.MoveForward();
        }
        
        private static void ProcessExitCommand(List<string> arguments)
        {
            
            if (arguments.Any())
            {
                throw new Exception("Too many arguments");
            }

        }

        private static void ProcessPlaceCommand(Robot robot, List<string> arguments)
        {
            if (arguments.Count != 3)
            {
                throw new Exception("Incorrect number of arguments");
            }

            var x = MapToInteger(arguments[0]);
            var y = MapToInteger(arguments[1]);
            var orientation = MapToOrientation(arguments[2]);
            robot.PlaceRobot(new Point(x, y), orientation);
        }

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
                    throw new Exception("An illegal orientation value");
            }
            
        }

        private static int MapToInteger(string argument)
        {
            int result;

            try
            {
                result = Convert.ToInt32(argument);
            }
            catch (Exception)
            {
                throw new Exception("Argument is not an integer");
            }

            return result;
        }
    }
}