using System;
using Xunit;

namespace Structs;

// Use for small, simple data structures that don't require inheritance or polymorphism.
public struct PointStruct
{
    public int X;
    public int Y;

    public PointStruct(int x, int y)
    {
        X = x;
        Y = y;
    }
}

// Use for immutable data structures that store data, not logic (e.g. DTO).
// Easy to be cloned, used with pattern matching & inheritance or polymorphism.
// Records are generally faster to use than structs, this is because
// they use value-based equality & are immutable.
public record PointRecord(int X, int Y)
{
    public int DistanceFromOrigin => Math.Abs(X) + Math.Abs(Y);
}

// The record struct is about 20 times faster than the regular struct
// when initializing and comparing identical objects. This is because
// record structs are implemented using compiler-generated code that
// is optimized for value-based equality and immutability.
// See https://devblogs.microsoft.com/dotnet/performance-improvements-in-net-6-for-system-text-json/
// for more information.
public readonly record struct PointRecordStruct(int X, int Y)
{
    public int DistanceFromOrigin => Math.Abs(X) + Math.Abs(Y);
    public string? Name { init; get; } = null;
}

public class PointTests
{
    [Fact]
    public void TestStructEquality()
    {
        // Arrange
        var point1 = new PointStruct(1, 2);
        var point2 = new PointStruct(1, 2);
        var point3 = new PointStruct(2, 3);

        // Assert
        // Structs use bitwise comparison for equality
        Assert.True(point1.Equals(point2));
        Assert.False(point1.Equals(point3));

        // Structs are not immutable
        Assert.True(point1.X.Equals(1));
        point1.X = 100;
        Assert.True(point1.X.Equals(100));
    }

    [Fact]
    public void TestRecordEquality()
    {
        // Arrange
        var point1 = new PointRecord(1, 2);
        var point2 = new PointRecord(1, 2);
        var point3 = new PointRecord(2, 3);
        var distance = point1.DistanceFromOrigin;

        // Assert
        // Records use value-based equality
        // Records are immutable
        Assert.True(point1.Equals(point2));
        Assert.False(point1.Equals(point3));
        Assert.Equal(3, distance);
    }

    [Fact]
    public void TestRecordStructEquality()
    {
        // Arrange
        var point1 = new PointRecordStruct(1, 2);
        var point2 = new PointRecordStruct(1, 2);
        var point3 = new PointRecordStruct(2, 3);

        // Assert
        Assert.True(point1.Equals(point2));
        Assert.False(point1.Equals(point3));
    }

    [Fact]
    public void TestRecordStructProperties()
    {
        // Arrange
        var point = new PointRecordStruct(3, -4) { Name = "Point A" }; // init only

        // Act
        var distance = point.DistanceFromOrigin;

        // Assert
        Assert.Equal(7, distance);
        Assert.Equal("Point A", point.Name);
    }
}