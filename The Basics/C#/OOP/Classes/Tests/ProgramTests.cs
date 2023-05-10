using System;
using System.IO;
using Classes;
using Xunit;

namespace ClassesTests
{
    public class ProgramTests
    {
        [Fact]
        public void GivenDogCalledRufus_WhenSpeaks_ThenRufusSaysWoof()
        {
            // Arrange
            Animal dog = new Dog("Rufus");
            const string expectedOutput = "Rufus says woof!";

            // Act
            var consoleOutput = CaptureConsoleOutput(() => dog.Speak());

            // Assert
            Assert.Equal(expectedOutput, consoleOutput.Trim());
        }

        [Fact]
        public void GivenCatCalledTiger_WhenSpeaks_ThenTigerSaysMeow()
        {
            // Arrange
            Animal cat = new Cat("Tiger");
            const string expectedOutput = "Tiger says meow!";

            // Act
            var consoleOutput = CaptureConsoleOutput(() => cat.Speak());

            // Assert
            Assert.Equal(expectedOutput, consoleOutput.Trim());
        }

        [Theory]
        [InlineData(3, 0, 0)]
        [InlineData(-2, 0, 0)]
        [InlineData(-2, 2, -4)]
        public void GivenCalculator_WhenMultiply_ThenReturnsExpectedResult(
            int firstValue, int secondValue, int expectedResult)
        {
            // Act
            var result = Calculator.Multiply(firstValue, secondValue);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(3, 5, 0, 8)]
        [InlineData(3, 0, 0, 3)]
        [InlineData(-2, 0, 1, -1)]
        [InlineData(-2, 2, 10, 10)]
        public void GivenCalculator_WhenAdd_ThenReturnsExpectedResult(
            int firstValue, int secondValue, int thirdValue, int expectedResult)
        {
            // Act
            var result = Calculator.Add(firstValue, secondValue, thirdValue);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(3, 3, 18)]
        [InlineData(3, 1, 10)]
        public void GivenCalculator_WhenCalculatingHypotenuse_ThenReturnsExpectedResult(
            int firstValue, int secondValue, int expectedResult)
        {
            // Act
            var result = Calculator.CalculateHypotenuse(firstValue, secondValue);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        private static string CaptureConsoleOutput(Action action)
        {
            var consoleOutput = new StringWriter();
            var originalOut = Console.Out;

            try
            {
                Console.SetOut(consoleOutput);
                action();
                return consoleOutput.ToString().Trim();
            }
            finally
            {
                Console.SetOut(originalOut);
                consoleOutput.Dispose();
            }
        }
        
        [Fact]
        public void PrintName_ShouldPrintCorrectly()
        {
            // Arrange
            var person = new Person
            {
                FirstName = "John",
                LastName = "Doe"
            };
            
            var expected = "Name: John Doe";

            // Act
            var result = CaptureConsoleOutput(() => person.PrintName());
            
            // Assert
            Assert.Equal(expected, result);
        }
    }
}