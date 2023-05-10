using System;
using Xunit;

namespace Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message)
        {
        }
    }

    public class ExceptionsClass
    {
        public int Divide(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException e)
            {
                throw new CustomException("Division by zero is not allowed");
            }
            finally
            {
                Console.WriteLine("Finally block executed");
            }
        }

        public void ThrowCustomExceptionIfTrue(bool value)
        {
            try
            {
                if (value)
                {
                    throw new CustomException("Value is true");
                }
            }
            catch (CustomException e) when (e.Message.Contains("true"))
            {
                Console.WriteLine("Custom exception filtered");
                throw;
            }
        }
    }

    public class ExceptionsClassTests
    {
        [Fact]
        public void Divide_WhenDividingByZero_ThrowsCustomException()
        {
            ExceptionsClass exceptions = new ExceptionsClass();
            Assert.Throws<CustomException>(() => exceptions.Divide(5, 0));
        }

        [Fact]
        public void Divide_WhenDividingNormally_ReturnsQuotient()
        {
            ExceptionsClass exceptions = new ExceptionsClass();
            int result = exceptions.Divide(10, 5);
            Assert.Equal(2, result);
        }

        [Fact]
        public void ThrowCustomExceptionIfTrue_WhenValueIsFalse_DoesNotThrow()
        {
            ExceptionsClass exceptions = new ExceptionsClass();
            exceptions.ThrowCustomExceptionIfTrue(false);
        }

        [Fact]
        public void WhenMessageContainsTrue_ThenExceptionFilterWorks()
        {
            ExceptionsClass exceptions = new ExceptionsClass();
            Assert.Throws<CustomException>(() => exceptions.ThrowCustomExceptionIfTrue(true));
        }
    }
}