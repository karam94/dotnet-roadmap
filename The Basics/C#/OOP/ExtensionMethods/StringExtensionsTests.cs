using Xunit;

namespace ExtensionMethods
{
    public class StringExtensionsTests
    {
        [Fact]
        public void IsPalindrome_ReturnsTrue_WhenStringIsPalindrome()
        {
            // Arrange
            const string str = "racecar";

            // Act
            var isPalindrome = str.IsPalindrome();

            // Assert
            Assert.True(isPalindrome);
        }

        [Fact]
        public void IsPalindrome_ReturnsFalse_WhenStringIsNotPalindrome()
        {
            // Arrange
            var str = "hello";

            // Act
            var isPalindrome = str.IsPalindrome();

            // Assert
            Assert.False(isPalindrome);
        }
    }
}