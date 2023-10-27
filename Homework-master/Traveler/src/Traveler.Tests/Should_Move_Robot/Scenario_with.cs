using Shouldly;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace Traveler.Tests.Should_Move_Robot
{

    [Trait("Category", "Unit")]
    public class Scenario_with
    {
        [Theory]
        [InlineData(0,0,4)]
        [InlineData(10,10,3)]
        public void Forward_North(int x, int y, int steps)
        {
            // Given
            var input = new Robot()
            {
                X = x,
                Y = y,
                Direction = RobotDirection.N
            };
            var result = TravelParser.Move(input,steps);

            // Then
            result.X.ShouldBe(x);
            result.Y.ShouldBe(y + steps);
            result.Direction.ShouldBe(RobotDirection.N);
        }

        [Theory]
        [InlineData(0, 0, 4)]
        [InlineData(11, 12, 3)]
        public void Forward_South(int x, int y, int steps)
        {
            // Given
            var input = new Robot()
            {
                X = x,
                Y = y,
                Direction = RobotDirection.S
            };
            var result = TravelParser.Move(input, steps);

            // Then
            result.X.ShouldBe(x);
            result.Y.ShouldBe(y-steps);
            result.Direction.ShouldBe(RobotDirection.S);
        }

        [Theory]
        [InlineData(0, 0, 4)]
        [InlineData(11, 12, 3)]
        public void Forward_East(int x, int y, int steps)
        {
            // Given
            var input = new Robot()
            {
                X = x,
                Y = y,
                Direction = RobotDirection.E
            };
            var result = TravelParser.Move(input, steps);

            // Then
            result.X.ShouldBe(x+steps);
            result.Y.ShouldBe(y);
            result.Direction.ShouldBe(RobotDirection.E);
        }

        [Theory]
        [InlineData(0, 0, 4)]
        [InlineData(11, 12, 3)]
        public void Forward_West(int x, int y, int steps)
        {
            // Given
            var input = new Robot()
            {
                X = x,
                Y = y,
                Direction = RobotDirection.W
            };
            var result = TravelParser.Move(input, steps);

            // Then
            result.X.ShouldBe(x-steps);
            result.Y.ShouldBe(y);
            result.Direction.ShouldBe(RobotDirection.W);
        }
    }
}
