using Shouldly;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace Traveler.Tests.Should_Rotate_Robot
{

    [Trait("Category", "Unit")]
    public class Scenario_with
    {
        [Theory]
        [InlineData(0,0)]
        [InlineData(11, 12)]
        public void Rotate_Left_When_North(int x, int y)
        {
            // Given
            var input = new Robot(x, y, RobotDirection.N);

            var result = TravelParser.Rotate(input,true);

            // Then
            result.X.ShouldBe(x);
            result.Y.ShouldBe(y);
            result.Direction.ShouldBe(RobotDirection.W);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        public void Rotate_Right_When_North(int x, int y)
        {
            // Given
            var input = new Robot(x, y, RobotDirection.N);

            var result = TravelParser.Rotate(input, false);

            // Then
            result.X.ShouldBe(x);
            result.Y.ShouldBe(y);
            result.Direction.ShouldBe(RobotDirection.E);
        }
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        public void Rotate_Left_When_East(int x, int y)
        {
            // Given
            var input = new Robot(x, y, RobotDirection.E);

            var result = TravelParser.Rotate(input, true);

            // Then
            result.X.ShouldBe(x);
            result.Y.ShouldBe(y);
            result.Direction.ShouldBe(RobotDirection.N);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        public void Rotate_Right_When_East(int x, int y)
        {
            // Given
            var input = new Robot(x, y, RobotDirection.E);

            var result = TravelParser.Rotate(input, false);

            // Then
            result.X.ShouldBe(x);
            result.Y.ShouldBe(y);
            result.Direction.ShouldBe(RobotDirection.S);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        public void Rotate_Left_When_West(int x, int y)
        {
            // Given
            var input = new Robot(x, y, RobotDirection.W);

            var result = TravelParser.Rotate(input, true);

            // Then
            result.X.ShouldBe(x);
            result.Y.ShouldBe(y);
            result.Direction.ShouldBe(RobotDirection.S);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        public void Rotate_Right_When_West(int x, int y)
        {
            // Given
            var input = new Robot(x, y, RobotDirection.W);

            var result = TravelParser.Rotate(input, false);

            // Then
            result.X.ShouldBe(x);
            result.Y.ShouldBe(y);
            result.Direction.ShouldBe(RobotDirection.N);
        }
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        public void Rotate_Left_When_South(int x, int y)
        {
            // Given
            var input = new Robot(x, y, RobotDirection.S);

            var result = TravelParser.Rotate(input, true);

            // Then
            result.X.ShouldBe(x);
            result.Y.ShouldBe(y);
            result.Direction.ShouldBe(RobotDirection.E);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        public void Rotate_Right_When_South(int x, int y)
        {
            // Given
            var input = new Robot(x, y, RobotDirection.S);

            var result = TravelParser.Rotate(input, false);

            // Then
            result.X.ShouldBe(x);
            result.Y.ShouldBe(y);
            result.Direction.ShouldBe(RobotDirection.W);
        }

    }
}
