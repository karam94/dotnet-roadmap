using Xunit;

namespace Interfaces;

public class InterfacesTests
{
    [Fact]
    public void TestDocumentPrintMethod()
    {
        // Arrange
        var document = new Document("Hello, world!");
        const string expectedOutput = "Hello, world!";

        // Act
        var consoleOutput = Printer.PrintDocument(document);

        // Assert
        Assert.Equal(expectedOutput, consoleOutput);
    }

    [Fact]
    public void TestPhotoPrintMethod()
    {
        // Arrange
        var photo = new Photo();
        const string expectedOutput = "[:D]";

        // Act
        var consoleOutput = Printer.PrintDocument(photo);

        // Assert
        Assert.Equal(expectedOutput, consoleOutput);
    }
}