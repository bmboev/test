using System;
using System.Collections.Generic;
using System.Linq;

namespace Traveler
{
    public enum RobotDirection { N,S,W,E };
    public enum RobotCommands { F, B, L, R };
    public class Robot
    {
        public Robot() { }
        public Robot(int x,int y, RobotDirection direction) 
        {
            X= x; Y=y; Direction=direction;
        }

        public int X;
        public int Y;
        public RobotDirection Direction;
    }

    public static class TravelParser
    {
        public static Robot[] Run(string input)
        {
            var result = new List<Robot>();
            
            var lines = input
                .Replace("\r\n","\n")
                .Replace("\r", "\n")
                .Split("\n", StringSplitOptions.RemoveEmptyEntries);

            var enumInp = lines.Select(s => s.Trim()).GetEnumerator();
            Robot robot = new Robot();
            while (enumInp.MoveNext())
            {

                var line = enumInp.Current.Trim();
                
                // if line contains comment
                if (line.IndexOf("//")>0)
                {
                    line = line.Substring(0, line.IndexOf("//")).Trim();
                }
                
                //if the line contains initial position
                if (line.StartsWith("POS="))
                {
                    var pos = line.Substring(4).Split(',', StringSplitOptions.RemoveEmptyEntries);
                    RobotDirection dir = RobotDirection.N;
                    int x= 0, y = 0;
                    if (Enum.TryParse<RobotDirection>(pos[2], out dir) 
                        && int.TryParse(pos[0],out x)
                        && int.TryParse(pos[1], out y)
                        )
                    {
                        robot = new Robot(x, y, dir);
                        result.Add((Robot)robot);
                    }
                    else
                    {
                        throw new Exception($"Wrong format ({line}) of robot position");
                    }
                    continue;
                }
                
                // if initial position is not defined yet
                if (string.IsNullOrEmpty(line) && result.Count==0)
                {
                    continue;
                }

                // process commands 
                foreach (var cmd in line)
                {
                    RobotCommands robotCommand;
                    
                    if (Enum.TryParse<RobotCommands>(cmd.ToString(), out robotCommand))
                    {
                        switch (robotCommand)
                        {
                            case RobotCommands.F: robot = Move(robot, 1); break;
                            case RobotCommands.B: robot = Move(robot, -1); break;
                            case RobotCommands.L: robot = Rotate(robot, true); break;
                            case RobotCommands.R: robot = Rotate(robot, false); break;
                            default: continue;
                        }
                    }
                }
            }

            return result.ToArray();
        }

        public static Robot Move(Robot robot, int steps)
        {
            switch (robot.Direction)
            {
                case RobotDirection.N: robot.Y += steps; break;
                case RobotDirection.S: robot.Y -= steps; break;
                case RobotDirection.W: robot.X -= steps; break;
                case RobotDirection.E: robot.X += steps; break;
                default: break;
            }
            return robot;
        }

        public static Robot Rotate(Robot robot, bool left )
        {
            switch (robot.Direction)
            {
                case RobotDirection.N: robot.Direction = left ? RobotDirection.W : RobotDirection.E; break;
                case RobotDirection.S: robot.Direction = left ? RobotDirection.E : RobotDirection.W; break;
                case RobotDirection.W: robot.Direction = left ? RobotDirection.S : RobotDirection.N; break;
                case RobotDirection.E: robot.Direction = left ? RobotDirection.N : RobotDirection.S; break;
                default: break;
            }
            return robot;
        }
    }
}
