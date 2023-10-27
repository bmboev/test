using Shouldly;
using System;
using System.ComponentModel;
using System.Linq;
using Xunit;
using Xunit.Sdk;

namespace Traveler.Tests.Should_Run_Robot
{

    [Trait("Category", "Integration")]
    public class Scenario_with
    {
        [Fact]
        
        public void Single_Expected_Outcome()
        {
            // Given
            var input = "POS=0,0,E\r\nFFFRFFF";

            // When
            var result = TravelParser.Run(input);

            // Then
            result.Length.ShouldBe(1);

            result[0].X.ShouldBe(3);
            result[0].Y.ShouldBe(-3);
            result[0].Direction.ShouldBe(RobotDirection.S);
        }

        [Fact]
        public void Multiple_Expected_Outcome()
        {
            // Given
            var input = "POS=0,0,E\r\nFFFRFFF\r\nPOS=6,4,W\r\nBLFLFFFFFRFRFLFL\r\nBLBLBRBL\r\nPOS=1,1,N";

            // When
            var result = TravelParser.Run(input);

            // Then
            result.Length.ShouldBe(3);

            result[0].X.ShouldBe(3);
            result[0].Y.ShouldBe(-3);
            result[0].Direction.ShouldBe(RobotDirection.S);


            result[1].X.ShouldBe(11);
            result[1].Y.ShouldBe(-1);
            result[1].Direction.ShouldBe(RobotDirection.W);


            result[2].X.ShouldBe(1);
            result[2].Y.ShouldBe(1);
            result[2].Direction.ShouldBe(RobotDirection.N);
        }

        [Fact]
        public void Without_Operations()
        {
            // Given
            var input = "POS=10,11,N";

            // When
            var result = TravelParser.Run(input);

            // Then
            result.Length.ShouldBe(1);

            result[0].X.ShouldBe(10);
            result[0].Y.ShouldBe(11);
            result[0].Direction.ShouldBe(RobotDirection.N);
        }

        [Fact]
        public void Single_Line_Feed_As_Separator()
        {
            // Given
            var input = "POS=0,0,E\nFFFRFFF";

            // When
            var result = TravelParser.Run(input);

            // Then
            result.Length.ShouldBe(1);

            result[0].X.ShouldBe(3);
            result[0].Y.ShouldBe(-3);
            result[0].Direction.ShouldBe(RobotDirection.S);
        }

        [Fact]
        public void Comments()
        {
            // Given
            var input = "//Hello World\r\nPOS=0,0,E\r\nFFFRFFF";

            // When
            var result = TravelParser.Run(input);

            // Then
            result.Length.ShouldBe(1);

            result[0].X.ShouldBe(3);
            result[0].Y.ShouldBe(-3);
            result[0].Direction.ShouldBe(RobotDirection.S);
        }

        [Theory]
        [InlineData(0, 0, RobotDirection.E, 3)]
        [InlineData(0, 0, RobotDirection.N, 23)]
        [InlineData(0, 0, RobotDirection.S, 45)]
        [InlineData(0, 0, RobotDirection.W, 1234)]
        public void Circle_Right(int x, int y, RobotDirection o, int steps)
        {
            // Given
            var forwardSteps = Enumerable.Repeat("F", steps);
            var input = $"POS={x},{y},{o}\r\n"
                    + forwardSteps + "R"
                    + forwardSteps + "R"
                    + forwardSteps + "R"
                    + forwardSteps + "R";

            // When
            var result = TravelParser.Run(input);

            // Then
            result.Length.ShouldBe(1);

            result[0].X.ShouldBe(x);
            result[0].Y.ShouldBe(y);
            result[0].Direction.ShouldBe(o);
        }

        [Theory]
        [InlineData(0, 0, RobotDirection.E, 33)]
        [InlineData(0, 0, RobotDirection.N, 3)]
        [InlineData(0, 0, RobotDirection.S, 5)]
        [InlineData(0, 0, RobotDirection.W, 2234)]
        public void Circle_Left(int x, int y, RobotDirection o, int steps)
        {
            // Given
            var forwardSteps = Enumerable.Repeat("F", steps);
            var input = $"POS={x},{y},{o}\r\n"
                    + forwardSteps + "L"
                    + forwardSteps + "L"
                    + forwardSteps + "L"
                    + forwardSteps + "L";

            // When
            var result = TravelParser.Run(input);

            // Then
            result.Length.ShouldBe(1);

            result[0].X.ShouldBe(x);
            result[0].Y.ShouldBe(y);
            result[0].Direction.ShouldBe(o);
        }
    }
}
